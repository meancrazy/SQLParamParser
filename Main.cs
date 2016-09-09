using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SQLParamParser.Forms;
using SQLParamParser.PluginInfrastructure;

namespace SQLParamParser
{
    public class Main
    {
        internal const string PluginName = "SQLParamParser";
        private static string _iniFilePath = null;
        private static bool _someSetting = false;
        private static ConfigWindow _configWindow = null;
        private static int _idMyDlg = -1;
        private static readonly Bitmap TbBmp = Properties.Resources.star;
        private static readonly Bitmap TbBmpTbTab = Properties.Resources.star_bmp;
        private static Icon _tbIcon = null;

        private static readonly IScintillaGateway Editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());

        private static string FixGuidText(string guid)
        {
            var regex = new Regex(@"[\s]+", RegexOptions.Compiled | RegexOptions.Singleline);

            return regex.Replace(guid, "");
        }

        private static void SetSQLLang()
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)LangType.L_SQL);
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
            StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            _iniFilePath = sbIniFilePath.ToString();
            if (!Directory.Exists(_iniFilePath)) Directory.CreateDirectory(_iniFilePath);
            _iniFilePath = Path.Combine(_iniFilePath, PluginName + ".ini");
            _someSetting = (Win32.GetPrivateProfileInt("SomeSection", "SomeKey", 0, _iniFilePath) != 0);

            PluginBase.SetCommand(0, "Parse", ParseParams, new ShortcutKey(false, false, false, Keys.None));
            //PluginBase.SetCommand(0, "Format", FormatSQL, new ShortcutKey(false, false, false, Keys.None));
            //PluginBase.SetCommand(0, "Format And Parse", FormatSQLAndParseParams, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(1, "Config", ShowConfigWindow); _idMyDlg = 1;
        }

        internal static void SetToolBarIcon()
        {
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = TbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[_idMyDlg]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {
            Win32.WritePrivateProfileString("SomeSection", "SomeKey", _someSetting ? "1" : "0", _iniFilePath);
        }

        internal static void ParseParams()
        {
            try
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)LangType.L_SQL);

                var text = Editor.GetText(Editor.GetLength() + 1);

                //Group0 - paramNumber
                //Group1 - paramValue (original)
                //Group2 - param Type
                var regex = new Regex(@":p(?<Number>\d+)[\s]*=[\s]*(?<Value>((?!:p)[^\[])+)[\s]\[(?i)TYPE:[\s]*(?<Type>[^\s]+)[\s]*\([^\]]*\)[\s]*\]", RegexOptions.IgnoreCase);

                var matches = regex.Matches(text);

                if (matches.Count == 0) //нет параметров
                {
                    return;
                }

                var newText = text;
                var offset = 0;
                var parameters = new Dictionary<int, string>();//param number - value

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
                        //case "STRING":
                        //case "STRINGFIXEDLENGTH":
                        //case "INT32":
                        //case "INT64":
                        //case "UINT32":
                        //case "UINT64":
                        //break;
                        case "DECIMAL":
                            paramValueFormated = decimal.Parse(paramValueOriginal).ToString(new NumberFormatInfo { NumberDecimalSeparator = "." });
                            break;
                        case "GUID":
                            paramValueFormated = $"'{FixGuidText(paramValueOriginal)}'";
                            break;
                        case "DATETIME":
                            paramValueFormated = $"'{DateTime.Parse(paramValueOriginal).ToString("yyyy-MM-dd HH:mm:ss")}'";
                            break;
                        case "BOOLEAN":
                            paramValueFormated = bool.Parse(paramValueOriginal) ? "1" : "0";
                            break;
                        default:
                            paramValueFormated = paramValueOriginal;
                            break;
                            //throw new Exception("Unknown param type = " + paramType);
                    }

                    parameters.Add(paramNumber, paramValueFormated);
                    newText = newText.Remove(match.Index + offset, 1);
                    newText = newText.Insert(match.Index + offset, paramComment);

                    offset += paramCommentLength - 1;
                }

                var paramToChangeRegex = new Regex(@":p(?<number>\d+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

                while (true)
                {
                    var match = paramToChangeRegex.Match(newText);
                    if (!match.Success)
                    {
                        break;
                    }

                    var paramNumber = int.Parse(match.Groups["number"].ToString());
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

        //internal static void FormatSQL()
        //{
        //    SetSQLLang();

        //    //var text = Editor.GetText(Editor.GetTextLength());

        //    //lzbasetype.gFmtOpt.Select_Columnlist_Style = TAlignStyle.asStacked;
        //    //lzbasetype.gFmtOpt.Select_Columnlist_Comma = TLinefeedsCommaOption.lfAfterComma;
        //    //lzbasetype.gFmtOpt.SelectItemInNewLine = false;
        //    //lzbasetype.gFmtOpt.AlignAliasInSelectList = true;
        //    //lzbasetype.gFmtOpt.TreatDistinctAsVirtualColumn = false;
        //    //lzbasetype.gFmtOpt.linenumber_enabled = false;

        //    //var sqlparser = new TGSqlParser(TDbVendor.DbVMssql) { SqlText = { Text = text } };

        //    //var i = sqlparser.PrettyPrint();
        //    //if (i == 0)
        //    //{
        //    //    var newText = sqlparser.FormattedSqlText.Text;
        //    //    Editor.SetText(newText);
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show(sqlparser.ErrorMessages);
        //    //}
        //}

        //internal static void FormatSQLAndParseParams()
        //{
        //    FormatSQL();
        //    ParseParams();
        //}

        internal static void ShowConfigWindow()
        {
            if (_configWindow == null)
            {
                _configWindow = new ConfigWindow();

                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(TbBmpTbTab, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    _tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = _configWindow.Handle;
                _nppTbData.pszName = "Config";
                _nppTbData.dlgID = _idMyDlg;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)_tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, _configWindow.Handle);
            }
        }
    }
}