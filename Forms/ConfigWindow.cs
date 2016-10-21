using System;
using System.Windows.Forms;
using SQLParamParser.Config;

namespace SQLParamParser.Forms
{
    public partial class ConfigWindow : Form
    {
        private readonly Settings _settings;

        public ConfigWindow(Settings settings)
        {
            InitializeComponent();

            _settings = settings;

            ParamIdentificatorNameEdit.Text = _settings.ParamIdentificator;
            DateFormatEdit.Text = _settings.DateFormat;

            IndentStringEdit.Text = _settings.IndentString;
            SpacesPerTabEdit.Value = _settings.SpacesPerTab;
            MaxLineWidthEdit.Value = _settings.MaxLineWidth;
            ExpandCommaListEdit.Checked = _settings.ExpandCommaList;
            TrailingCommasEdit.Checked = _settings.TrailingCommas;
            SpaceAfterExpandedCommaEdit.Checked = _settings.SpaceAfterExpandedComma;
            ExpandBooleanExpressionsEdit.Checked = _settings.ExpandBooleanExpressions;
            ExpandCaseStatementsEdit.Checked = _settings.ExpandCaseStatements;
            ExpandBetweenConditionsEdit.Checked = _settings.ExpandBetweenConditions;
            BreakJoinOnSectionsEdit.Checked = _settings.BreakJoinOnSections;
            UppercaseKeywordsEdit.Checked = _settings.UppercaseKeywords;
            KeywordStandardizationEdit.Checked = _settings.KeywordStandardization;
        }

        private void ParamIdentificatorNameEdit_TextChanged(object sender, EventArgs e)
        {
            _settings.ParamIdentificator = ParamIdentificatorNameEdit.Text;
        }

        private void DateFormatEdit_TextChanged(object sender, EventArgs e)
        {
            _settings.DateFormat = DateFormatEdit.Text;
        }

        private void IndentStringEdit_TextChanged(object sender, EventArgs e)
        {
            _settings.IndentString = IndentStringEdit.Text;
        }

        private void SpacesPerTabEdit_ValueChanged(object sender, EventArgs e)
        {
            _settings.SpacesPerTab = (int)SpacesPerTabEdit.Value;
        }

        private void MaxLineWidthEdit_ValueChanged(object sender, EventArgs e)
        {
            _settings.MaxLineWidth = (int)MaxLineWidthEdit.Value;
        }

        private void ExpandCommaListEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ExpandCommaList = ExpandCommaListEdit.Checked;
        }

        private void TrailingCommasEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.TrailingCommas = TrailingCommasEdit.Checked;
        }

        private void SpaceAfterExpandedCommaEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.SpaceAfterExpandedComma = SpaceAfterExpandedCommaEdit.Checked;
        }

        private void ExpandBooleanExpressionsEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ExpandBooleanExpressions = ExpandBooleanExpressionsEdit.Checked;
        }

        private void ExpandCaseStatementsEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ExpandCaseStatements = ExpandCaseStatementsEdit.Checked;
        }

        private void ExpandBetweenConditionsEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ExpandBetweenConditions = ExpandBetweenConditionsEdit.Checked;
        }

        private void BreakJoinOnSectionsEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.BreakJoinOnSections = BreakJoinOnSectionsEdit.Checked;
        }

        private void UppercaseKeywordsEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.UppercaseKeywords = UppercaseKeywordsEdit.Checked;
        }

        private void KeywordStandardizationEdit_CheckedChanged(object sender, EventArgs e)
        {
            _settings.KeywordStandardization = KeywordStandardizationEdit.Checked;
        }
    }
}
