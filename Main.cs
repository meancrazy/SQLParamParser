using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = "SQLParamParser";
        static string iniFilePath = null;
        static bool someSetting = false;
        static ConfigWindow _configWindow = null;
        static int idMyDlg = -1;
        static Bitmap tbBmp = Properties.Resources.star;
        static Bitmap tbBmp_tbTab = Properties.Resources.star_bmp;
        static Icon tbIcon = null;

        static IScintillaGateway Editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());

        private static string FixGuidText(string guid)
        {
            var regex = new Regex(@"[\s]+", RegexOptions.Compiled | RegexOptions.Singleline);

            return regex.Replace(guid, "");
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
            iniFilePath = sbIniFilePath.ToString();
            if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
            iniFilePath = Path.Combine(iniFilePath, PluginName + ".ini");
            someSetting = (Win32.GetPrivateProfileInt("SomeSection", "SomeKey", 0, iniFilePath) != 0);

            PluginBase.SetCommand(0, "Parse", ParseParams, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(1, "Config", ShowConfigWindow); idMyDlg = 1;
        }

        internal static void SetToolBarIcon()
        {
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {
            Win32.WritePrivateProfileString("SomeSection", "SomeKey", someSetting ? "1" : "0", iniFilePath);
        }

        internal static void ParseParams()
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)LangType.L_SQL);

            var text = Editor.GetText(Editor.GetTextLength());

            //Group0 - paramNumber
            //Group1 - paramValue (original)
            //Group2 - param Type
            var regex = new Regex(@":p([0-9]+)[\s]*=[\s]*([^\[]+)[\s]\[TYPE:[\s]*([^\s]+)[\s]*\([^\]]*\)[\s]*\]", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            var matches = regex.Matches(text);

            if (matches.Count == 0) //нет параметров
            {
                return;
            }

            var newText = text;
            var offset = 0;
            var parameters = new Dictionary<int, string>();//param number - value

            foreach (Match match in matches)
            {
                var paramNumber = int.Parse(match.Groups[1].ToString());
                var paramValueOriginal = match.Groups[2].ToString();
                var paramType = match.Groups[3].ToString().ToUpper();

                string paramValueFormated;
                switch (paramType)
                {
                    case "STRING":
                    case "STRINGFIXEDLENGTH":
                    case "INT32":
                    case "INT64":
                    case "UINT32":
                    case "UINT64":
                        paramValueFormated = paramValueOriginal;
                        break;
                    case "GUID":
                        paramValueFormated = $"'{FixGuidText(paramValueOriginal)}'";
                        break;
                    case "DATETIME":
                        paramValueFormated = $"'{DateTime.Parse(paramValueOriginal).ToString("yyyy-MM-dd HH:mm:ss")}'";
                        break;
                    default:
                        throw new Exception("Unknown param type = " + paramType);
                }

                parameters.Add(paramNumber, paramValueFormated);
                newText = newText.Remove(match.Index + offset, 1);
                newText = newText.Insert(match.Index + offset, "--");

                offset += 1;
            }

            var paramToChangeRegex = new Regex(":p(?<number>[0-9]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

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
                    g.DrawImage(tbBmp_tbTab, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = _configWindow.Handle;
                _nppTbData.pszName = "My dockable dialog";
                _nppTbData.dlgID = idMyDlg;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
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