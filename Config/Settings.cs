using System.IO;
using System.Text;
using SQLParamParser.PluginInfrastructure;

namespace SQLParamParser.Config
{
    public class Settings
    {
        private readonly string _iniFilePath;

        //parse settings
        public string ParamIdentificator { get; set; }
        public string DateFormat { get; set; }

        //format settings
        public string IndentString { get; set; }
        public int SpacesPerTab { get; set; }
        public int MaxLineWidth { get; set; }
        public bool ExpandCommaList { get; set; }
        public bool TrailingCommas { get; set; }
        public bool SpaceAfterExpandedComma { get; set; }
        public bool ExpandBooleanExpressions { get; set; }
        public bool ExpandCaseStatements { get; set; }
        public bool ExpandBetweenConditions { get; set; }
        public bool BreakJoinOnSections { get; set; }
        public bool UppercaseKeywords { get; set; }
        public bool KeywordStandardization { get; set; }

        public Settings()
        {
            var sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            _iniFilePath = sbIniFilePath.ToString();

            if (!Directory.Exists(_iniFilePath)) Directory.CreateDirectory(_iniFilePath);
            _iniFilePath = Path.Combine(_iniFilePath, Main.PluginName + ".ini");

            ReadAllSettings();
        }

        private string ReadString(SettingsSection section, SettingName name, string defaultValue)
        {
            var sb = new StringBuilder(Win32.MAX_PATH);
            var res = Win32.GetPrivateProfileString(section.ToString(),
                                                    name.ToString(),
                                                    defaultValue,
                                                    sb,
                                                    (uint)sb.Capacity,
                                                    _iniFilePath);

            var result = sb.ToString();

            result = result.Replace("{space}", " ");

            return result;
        }

        private int ReadInt(SettingsSection section, SettingName name, int defaultValue)
        {
            var intString = ReadString(section, name, defaultValue.ToString());

            int result;
            if (int.TryParse(intString, out result))
            {
                return result;
            }

            return defaultValue;
        }

        private bool ReadBool(SettingsSection section, SettingName name, bool defaultValue)
        {
            var boolString = ReadString(section, name, defaultValue.ToString());

            bool result;
            if (bool.TryParse(boolString, out result))
            {
                return result;
            }

            return defaultValue;
        }

        private bool WriteString(SettingsSection section, SettingName name, string value)
        {
            value = value.Replace(" ", "{space}");

            return Win32.WritePrivateProfileString(section.ToString(),
                                name.ToString(),
                                value,
                                _iniFilePath);
        }

        private void ReadAllSettings()
        {
            //ParamParseSettings
            ParamIdentificator = ReadString(SettingsSection.ParamParseSettings, SettingName.ParamIdentificator, ":p");
            DateFormat = ReadString(SettingsSection.ParamParseSettings, SettingName.DateFormat, "yyyy-MM-dd HH:mm:ss");

            //FormatSettings
            IndentString = ReadString(SettingsSection.FormatSettings, SettingName.IndentString, "\t");
            SpacesPerTab = ReadInt(SettingsSection.FormatSettings, SettingName.SpacesPerTab, 4);
            MaxLineWidth = ReadInt(SettingsSection.FormatSettings, SettingName.MaxLineWidth, 999);
            ExpandCommaList = ReadBool(SettingsSection.FormatSettings, SettingName.ExpandCommaList, true);
            TrailingCommas = ReadBool(SettingsSection.FormatSettings, SettingName.TrailingCommas, false);
            SpaceAfterExpandedComma = ReadBool(SettingsSection.FormatSettings, SettingName.SpaceAfterExpandedComma, false);
            ExpandBooleanExpressions = ReadBool(SettingsSection.FormatSettings, SettingName.ExpandBooleanExpressions, true);
            ExpandCaseStatements = ReadBool(SettingsSection.FormatSettings, SettingName.ExpandCaseStatements, true);
            ExpandBetweenConditions = ReadBool(SettingsSection.FormatSettings, SettingName.ExpandBetweenConditions, true);
            BreakJoinOnSections = ReadBool(SettingsSection.FormatSettings, SettingName.BreakJoinOnSections, false);
            UppercaseKeywords = ReadBool(SettingsSection.FormatSettings, SettingName.UppercaseKeywords, true);
            KeywordStandardization = ReadBool(SettingsSection.FormatSettings, SettingName.KeywordStandardization, false);
        }

        public void SaveAllSettings()
        {
            //ParamParseSettings
            WriteString(SettingsSection.ParamParseSettings, SettingName.ParamIdentificator, ParamIdentificator);
            WriteString(SettingsSection.ParamParseSettings, SettingName.DateFormat, DateFormat);

            //FormatSettings
            WriteString(SettingsSection.FormatSettings, SettingName.IndentString, IndentString);
            WriteString(SettingsSection.FormatSettings, SettingName.SpacesPerTab, SpacesPerTab.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.MaxLineWidth, MaxLineWidth.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.ExpandCommaList, ExpandCommaList.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.TrailingCommas, TrailingCommas.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.SpaceAfterExpandedComma, SpaceAfterExpandedComma.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.ExpandBooleanExpressions, ExpandBooleanExpressions.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.ExpandCaseStatements, ExpandCaseStatements.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.ExpandBetweenConditions, ExpandBetweenConditions.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.BreakJoinOnSections, BreakJoinOnSections.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.UppercaseKeywords, UppercaseKeywords.ToString());
            WriteString(SettingsSection.FormatSettings, SettingName.KeywordStandardization, KeywordStandardization.ToString());
        }
    }
}
