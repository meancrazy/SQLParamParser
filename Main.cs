using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PoorMansTSqlFormatterLib.Formatters;
using PoorMansTSqlFormatterLib.Parsers;
using PoorMansTSqlFormatterLib.Tokenizers;
using SQLParamParser.Config;
using SQLParamParser.Forms;
using SQLParamParser.PluginInfrastructure;

namespace SQLParamParser
{
    public class Main
    {
        internal const string PluginName = "SQLParamParser";
        private static Settings _settings;

        private static ConfigWindow _configWindow;
        private static ExecuteWindow _executeWindow;
        private static int _idConfigWindow = -1;
        private static int _idExecuteWindow = -1;
        private static readonly Bitmap TbBmp = Properties.Resources.star;
        private static readonly Bitmap TbBmpTbTab = Properties.Resources.star_bmp;
        private static Icon _tbIcon;

        public static NotepadPPGateway Gateway { get; private set; }

        public static Icon ConfigWindowToolBarIcon
        {
            get
            {
                if (_tbIcon == null)
                {
                    using (var newBmp = new Bitmap(16, 16))
                    {
                        var g = Graphics.FromImage(newBmp);
                        var colorMap = new ColorMap[1];
                        colorMap[0] = new ColorMap
                        {
                            OldColor = Color.Fuchsia,
                            NewColor = Color.FromKnownColor(KnownColor.ButtonFace)
                        };
                        var attr = new ImageAttributes();
                        attr.SetRemapTable(colorMap);
                        g.DrawImage(TbBmpTbTab, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                        _tbIcon = Icon.FromHandle(newBmp.GetHicon());
                    }
                }

                return _tbIcon;
            }
        }

        private static readonly IScintillaGateway Editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());

        private static string FixGuidText(string guid)
        {
            var regex = new Regex(@"[\s]+", RegexOptions.Compiled | RegexOptions.Singleline);

            return regex.Replace(guid, "");
        }

        private static string GetCurrentText()
        {
            return Editor.GetText(Editor.GetLength() + 1);
        }

        public static void OnNotification(ScNotification notification)
        {
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            // if (notification.Header.Code == (uint)NppMsg.NPPN_xxx)
            // { ... }
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }
        }

        internal static void CommandMenuInit()
        {
            _settings = new Settings();

            Gateway = new NotepadPPGateway();

            PluginBase.SetCommand(0, "Parse", ParseParams);
            PluginBase.SetCommand(1, "Format", FormatSql);
            PluginBase.SetCommand(2, "Format And Parse", FormatSqlAndParseParams);
            PluginBase.SetCommand(3, "Format, Parse, Execute", FormatSqlParseExecuteParams);

            PluginBase.SetCommand(4, "Execute", ShowExecuteWindow, new ShortcutKey(true, false, false, Keys.F5));
            _idExecuteWindow = 4;

            PluginBase.SetCommand(5, "Config", ShowConfigWindow);
            _idConfigWindow = 5;
        }

        internal static void SetToolBarIcon()
        {
            var tbIcons = new toolbarIcons
            {
                hToolbarBmp = TbBmp.GetHbitmap()
            };
            var pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[_idConfigWindow]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {
            _settings.SaveAllSettings();
        }

        private static string NullOrValue(string originalValue, Func<string, string> processedValue)
        {
            return originalValue.Equals("NULL", StringComparison.OrdinalIgnoreCase) ? "NULL" : processedValue.Invoke(originalValue);
        }

        internal static void ParseParams()
        {
            try
            {
                Gateway.SetCurrentLanguage(LangType.L_SQL);

                var text = GetCurrentText();

                //Group0 - paramNumber
                //Group1 - paramValue (original)
                //Group2 - param Type
                var regex = new Regex($@"{_settings.ParamIdentificator}(?<Number>\d+)[\s]*=[\s]*(?<Value>((?!{_settings.ParamIdentificator})[^\[])+)[\s]\[(?i)TYPE:[\s]*(?<Type>[^\s]+)[\s]*\([^\]]*\)[\s]*\]", RegexOptions.IgnoreCase);

                var matches = regex.Matches(text);

                if (matches.Count == 0) //нет параметров
                {
                    return;
                }

                var newText = text;
                var offset = 0;
                var parameters = new Dictionary<int, string>(); //param number - value

                const string paramComment = "\r\n--";
                var paramCommentLength = paramComment.Length;

                foreach (Match match in matches)
                {
                    var paramNumber = int.Parse(match.Groups["Number"].ToString());
                    var paramValueOriginal = match.Groups["Value"].ToString();
                    var paramType = match.Groups["Type"].ToString().ToUpper();

                    string paramValueFormated;
                    switch (paramType)
                    {
                        case "DECIMAL":
                            paramValueFormated = NullOrValue(paramValueOriginal, o => decimal.Parse(paramValueOriginal).ToString(new NumberFormatInfo { NumberDecimalSeparator = "." }));
                            break;
                        case "GUID":
                            paramValueFormated = NullOrValue(paramValueOriginal, o => $"'{FixGuidText(paramValueOriginal)}'");
                            break;
                        case "DATETIME":
                            paramValueFormated = NullOrValue(paramValueOriginal, o => $"'{DateTime.Parse(paramValueOriginal).ToString(_settings.DateFormat)}'");
                            break;
                        case "BOOLEAN":
                            paramValueFormated = NullOrValue(paramValueOriginal, o => bool.Parse(paramValueOriginal) ? "1" : "0");
                            break;
                        default:
                            paramValueFormated = paramValueOriginal;
                            break;
                    }

                    parameters.Add(paramNumber, paramValueFormated);
                    newText = newText.Remove(match.Index + offset, 1);
                    newText = newText.Insert(match.Index + offset, paramComment);

                    offset += paramCommentLength - 1;
                }

                var paramToChangeRegex = new Regex($@"{_settings.ParamIdentificator}(?<number>\d+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

                while (true)
                {
                    var match = paramToChangeRegex.Match(newText);
                    if (!match.Success)
                    {
                        break;
                    }

                    var paramNumber = int.Parse(match.Groups["number"].ToString());

                    string paramValue;
                    if (!parameters.TryGetValue(paramNumber, out paramValue))
                    {
                        throw new Exception($"Parameter with index \"{paramNumber}\" was not found in the list of paramters.");
                    }

                    newText = newText.Remove(match.Index, match.Length);
                    newText = newText.Insert(match.Index, parameters[paramNumber]);
                }

                Editor.SetText(newText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void FormatSql()
        {
            Gateway.SetCurrentLanguage(LangType.L_SQL);

            var text = GetCurrentText();

            var innerFormatter = new TSqlStandardFormatter(_settings.IndentString,
                                                           _settings.SpacesPerTab,
                                                           _settings.MaxLineWidth,
                                                           _settings.ExpandCommaList,
                                                           _settings.TrailingCommas,
                                                           _settings.SpaceAfterExpandedComma,
                                                           _settings.ExpandBooleanExpressions,
                                                           _settings.ExpandCaseStatements,
                                                           _settings.ExpandBetweenConditions,
                                                           _settings.BreakJoinOnSections,
                                                           _settings.UppercaseKeywords,
                                                           false,
                                                           _settings.KeywordStandardization);
            var tokenizer = new TSqlStandardTokenizer();
            var parser = new TSqlStandardParser();


            var parsedSql = parser.ParseSQL(tokenizer.TokenizeSQL(text));

            Editor.SetText(innerFormatter.FormatSQLTree(parsedSql));

        }

        internal static void FormatSqlAndParseParams()
        {
            ParseParams();
            FormatSql();
        }

        internal static void FormatSqlParseExecuteParams()
        {
            ParseParams();
            FormatSql();
            ShowExecuteWindow();
        }

        internal static void ShowConfigWindow()
        {
            if (_configWindow == null)
            {
                _configWindow = new ConfigWindow(_settings);

                var nppTbData = new NppTbData
                {
                    hClient = _configWindow.Handle,
                    pszName = $"{PluginName} Configuration",
                    dlgID = _idConfigWindow,
                    uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR,
                    hIconTab = (uint)ConfigWindowToolBarIcon.Handle,
                    pszModuleName = PluginName
                };
                var ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(nppTbData));
                Marshal.StructureToPtr(nppTbData, ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, _configWindow.Handle);
            }
        }

        internal static void ShowExecuteWindow()
        {
            if (_executeWindow == null)
            {
                _executeWindow = new ExecuteWindow(_settings);

                var nppTbData = new NppTbData
                {
                    hClient = _executeWindow.Handle,
                    pszName = $"{PluginName} Execute",
                    dlgID = _idExecuteWindow,
                    uMask = NppTbMsg.CONT_BOTTOM,
                    hIconTab = (uint)ConfigWindowToolBarIcon.Handle,
                    pszModuleName = PluginName
                };
                var ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(nppTbData));
                Marshal.StructureToPtr(nppTbData, ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, ptrNppTbData);

                _executeWindow.Execute();
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, _executeWindow.Handle);

                _executeWindow.Execute();
            }
        }
    }
}