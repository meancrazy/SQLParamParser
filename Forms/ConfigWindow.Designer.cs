namespace SQLParamParser.Forms
{
    partial class ConfigWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ParamParseSettingsTab = new System.Windows.Forms.TabPage();
            this.ParaseParamSettingsTable = new System.Windows.Forms.TableLayoutPanel();
            this.DateFormatLabel = new System.Windows.Forms.Label();
            this.ParamIdentificatorNameLabel = new System.Windows.Forms.Label();
            this.ParamIdentificatorNameEdit = new System.Windows.Forms.TextBox();
            this.DateFormatEdit = new System.Windows.Forms.TextBox();
            this.FormatSQLSettingsTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MaxLineWidthEdit = new System.Windows.Forms.NumericUpDown();
            this.MaxLineWidthLabel = new System.Windows.Forms.Label();
            this.SpacesPerTabLabel = new System.Windows.Forms.Label();
            this.IndentStringLabel = new System.Windows.Forms.Label();
            this.IndentStringEdit = new System.Windows.Forms.TextBox();
            this.SpacesPerTabEdit = new System.Windows.Forms.NumericUpDown();
            this.ExpandCommaListLabel = new System.Windows.Forms.Label();
            this.ExpandCommaListEdit = new System.Windows.Forms.CheckBox();
            this.TrailingCommasLabel = new System.Windows.Forms.Label();
            this.TrailingCommasEdit = new System.Windows.Forms.CheckBox();
            this.SpaceAfterExpandedCommaLabel = new System.Windows.Forms.Label();
            this.SpaceAfterExpandedCommaEdit = new System.Windows.Forms.CheckBox();
            this.ExpandBooleanExpressionsLabel = new System.Windows.Forms.Label();
            this.ExpandBooleanExpressionsEdit = new System.Windows.Forms.CheckBox();
            this.ExpandCaseStatementsLabel = new System.Windows.Forms.Label();
            this.ExpandCaseStatementsEdit = new System.Windows.Forms.CheckBox();
            this.ExpandBetweenConditionsLabel = new System.Windows.Forms.Label();
            this.ExpandBetweenConditionsEdit = new System.Windows.Forms.CheckBox();
            this.BreakJoinOnSectionsLabel = new System.Windows.Forms.Label();
            this.BreakJoinOnSectionsEdit = new System.Windows.Forms.CheckBox();
            this.UppercaseKeywordsLabel = new System.Windows.Forms.Label();
            this.UppercaseKeywordsEdit = new System.Windows.Forms.CheckBox();
            this.KeywordStandardizationLabel = new System.Windows.Forms.Label();
            this.KeywordStandardizationEdit = new System.Windows.Forms.CheckBox();
            this.MainTabControl.SuspendLayout();
            this.ParamParseSettingsTab.SuspendLayout();
            this.ParaseParamSettingsTable.SuspendLayout();
            this.FormatSQLSettingsTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxLineWidthEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpacesPerTabEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.ParamParseSettingsTab);
            this.MainTabControl.Controls.Add(this.FormatSQLSettingsTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(678, 427);
            this.MainTabControl.TabIndex = 0;
            // 
            // ParamParseSettingsTab
            // 
            this.ParamParseSettingsTab.Controls.Add(this.ParaseParamSettingsTable);
            this.ParamParseSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.ParamParseSettingsTab.Name = "ParamParseSettingsTab";
            this.ParamParseSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ParamParseSettingsTab.Size = new System.Drawing.Size(670, 401);
            this.ParamParseSettingsTab.TabIndex = 0;
            this.ParamParseSettingsTab.Text = "Parse Params Settigns";
            this.ParamParseSettingsTab.UseVisualStyleBackColor = true;
            // 
            // ParaseParamSettingsTable
            // 
            this.ParaseParamSettingsTable.ColumnCount = 2;
            this.ParaseParamSettingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.ParaseParamSettingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ParaseParamSettingsTable.Controls.Add(this.DateFormatLabel, 0, 1);
            this.ParaseParamSettingsTable.Controls.Add(this.ParamIdentificatorNameLabel, 0, 0);
            this.ParaseParamSettingsTable.Controls.Add(this.ParamIdentificatorNameEdit, 1, 0);
            this.ParaseParamSettingsTable.Controls.Add(this.DateFormatEdit, 1, 1);
            this.ParaseParamSettingsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParaseParamSettingsTable.Location = new System.Drawing.Point(3, 3);
            this.ParaseParamSettingsTable.Name = "ParaseParamSettingsTable";
            this.ParaseParamSettingsTable.RowCount = 6;
            this.ParaseParamSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ParaseParamSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ParaseParamSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ParaseParamSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ParaseParamSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ParaseParamSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ParaseParamSettingsTable.Size = new System.Drawing.Size(664, 395);
            this.ParaseParamSettingsTable.TabIndex = 0;
            // 
            // DateFormatLabel
            // 
            this.DateFormatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateFormatLabel.Location = new System.Drawing.Point(3, 25);
            this.DateFormatLabel.Name = "DateFormatLabel";
            this.DateFormatLabel.Size = new System.Drawing.Size(194, 25);
            this.DateFormatLabel.TabIndex = 2;
            this.DateFormatLabel.Text = "Формат даты:";
            this.DateFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ParamIdentificatorNameLabel
            // 
            this.ParamIdentificatorNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParamIdentificatorNameLabel.Location = new System.Drawing.Point(3, 0);
            this.ParamIdentificatorNameLabel.Name = "ParamIdentificatorNameLabel";
            this.ParamIdentificatorNameLabel.Size = new System.Drawing.Size(194, 25);
            this.ParamIdentificatorNameLabel.TabIndex = 0;
            this.ParamIdentificatorNameLabel.Text = "Идентификатор параметра:";
            this.ParamIdentificatorNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ParamIdentificatorNameEdit
            // 
            this.ParamIdentificatorNameEdit.Location = new System.Drawing.Point(203, 3);
            this.ParamIdentificatorNameEdit.Name = "ParamIdentificatorNameEdit";
            this.ParamIdentificatorNameEdit.Size = new System.Drawing.Size(250, 20);
            this.ParamIdentificatorNameEdit.TabIndex = 1;
            this.ParamIdentificatorNameEdit.TextChanged += new System.EventHandler(this.ParamIdentificatorNameEdit_TextChanged);
            // 
            // DateFormatEdit
            // 
            this.DateFormatEdit.Location = new System.Drawing.Point(203, 28);
            this.DateFormatEdit.Name = "DateFormatEdit";
            this.DateFormatEdit.Size = new System.Drawing.Size(250, 20);
            this.DateFormatEdit.TabIndex = 3;
            this.DateFormatEdit.TextChanged += new System.EventHandler(this.DateFormatEdit_TextChanged);
            // 
            // FormatSQLSettingsTab
            // 
            this.FormatSQLSettingsTab.Controls.Add(this.tableLayoutPanel1);
            this.FormatSQLSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.FormatSQLSettingsTab.Name = "FormatSQLSettingsTab";
            this.FormatSQLSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.FormatSQLSettingsTab.Size = new System.Drawing.Size(670, 401);
            this.FormatSQLSettingsTab.TabIndex = 1;
            this.FormatSQLSettingsTab.Text = "Format SQL Settings";
            this.FormatSQLSettingsTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.KeywordStandardizationLabel, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.KeywordStandardizationEdit, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.UppercaseKeywordsLabel, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.UppercaseKeywordsEdit, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.BreakJoinOnSectionsLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.BreakJoinOnSectionsEdit, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.ExpandBetweenConditionsLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.ExpandCaseStatementsLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.ExpandBooleanExpressionsLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.SpaceAfterExpandedCommaEdit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.SpaceAfterExpandedCommaLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.TrailingCommasEdit, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TrailingCommasLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ExpandCommaListLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.MaxLineWidthEdit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.MaxLineWidthLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SpacesPerTabLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.IndentStringLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.IndentStringEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SpacesPerTabEdit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ExpandCommaListEdit, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ExpandBooleanExpressionsEdit, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.ExpandCaseStatementsEdit, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.ExpandBetweenConditionsEdit, 1, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 395);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // MaxLineWidthEdit
            // 
            this.MaxLineWidthEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxLineWidthEdit.Location = new System.Drawing.Point(203, 53);
            this.MaxLineWidthEdit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MaxLineWidthEdit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxLineWidthEdit.Name = "MaxLineWidthEdit";
            this.MaxLineWidthEdit.Size = new System.Drawing.Size(120, 20);
            this.MaxLineWidthEdit.TabIndex = 5;
            this.MaxLineWidthEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxLineWidthEdit.ValueChanged += new System.EventHandler(this.MaxLineWidthEdit_ValueChanged);
            // 
            // MaxLineWidthLabel
            // 
            this.MaxLineWidthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxLineWidthLabel.Location = new System.Drawing.Point(3, 50);
            this.MaxLineWidthLabel.Name = "MaxLineWidthLabel";
            this.MaxLineWidthLabel.Size = new System.Drawing.Size(194, 25);
            this.MaxLineWidthLabel.TabIndex = 4;
            this.MaxLineWidthLabel.Text = "Максимальная длина строки:";
            this.MaxLineWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SpacesPerTabLabel
            // 
            this.SpacesPerTabLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpacesPerTabLabel.Location = new System.Drawing.Point(3, 25);
            this.SpacesPerTabLabel.Name = "SpacesPerTabLabel";
            this.SpacesPerTabLabel.Size = new System.Drawing.Size(194, 25);
            this.SpacesPerTabLabel.TabIndex = 2;
            this.SpacesPerTabLabel.Text = "Пробелов в табуляции:";
            this.SpacesPerTabLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IndentStringLabel
            // 
            this.IndentStringLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IndentStringLabel.Location = new System.Drawing.Point(3, 0);
            this.IndentStringLabel.Name = "IndentStringLabel";
            this.IndentStringLabel.Size = new System.Drawing.Size(194, 25);
            this.IndentStringLabel.TabIndex = 0;
            this.IndentStringLabel.Text = "Значение отступа:";
            this.IndentStringLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IndentStringEdit
            // 
            this.IndentStringEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.IndentStringEdit.Location = new System.Drawing.Point(203, 3);
            this.IndentStringEdit.Name = "IndentStringEdit";
            this.IndentStringEdit.Size = new System.Drawing.Size(250, 20);
            this.IndentStringEdit.TabIndex = 1;
            this.IndentStringEdit.TextChanged += new System.EventHandler(this.IndentStringEdit_TextChanged);
            // 
            // SpacesPerTabEdit
            // 
            this.SpacesPerTabEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SpacesPerTabEdit.Location = new System.Drawing.Point(203, 28);
            this.SpacesPerTabEdit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpacesPerTabEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpacesPerTabEdit.Name = "SpacesPerTabEdit";
            this.SpacesPerTabEdit.Size = new System.Drawing.Size(120, 20);
            this.SpacesPerTabEdit.TabIndex = 3;
            this.SpacesPerTabEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpacesPerTabEdit.ValueChanged += new System.EventHandler(this.SpacesPerTabEdit_ValueChanged);
            // 
            // ExpandCommaListLabel
            // 
            this.ExpandCommaListLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpandCommaListLabel.Location = new System.Drawing.Point(3, 75);
            this.ExpandCommaListLabel.Name = "ExpandCommaListLabel";
            this.ExpandCommaListLabel.Size = new System.Drawing.Size(194, 25);
            this.ExpandCommaListLabel.TabIndex = 6;
            this.ExpandCommaListLabel.Text = "Expand Comma List";
            this.ExpandCommaListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExpandCommaListEdit
            // 
            this.ExpandCommaListEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ExpandCommaListEdit.AutoSize = true;
            this.ExpandCommaListEdit.Location = new System.Drawing.Point(203, 78);
            this.ExpandCommaListEdit.Name = "ExpandCommaListEdit";
            this.ExpandCommaListEdit.Size = new System.Drawing.Size(15, 19);
            this.ExpandCommaListEdit.TabIndex = 7;
            this.ExpandCommaListEdit.UseVisualStyleBackColor = true;
            this.ExpandCommaListEdit.CheckedChanged += new System.EventHandler(this.ExpandCommaListEdit_CheckedChanged);
            // 
            // TrailingCommasLabel
            // 
            this.TrailingCommasLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrailingCommasLabel.Location = new System.Drawing.Point(3, 100);
            this.TrailingCommasLabel.Name = "TrailingCommasLabel";
            this.TrailingCommasLabel.Size = new System.Drawing.Size(194, 25);
            this.TrailingCommasLabel.TabIndex = 8;
            this.TrailingCommasLabel.Text = "Trailing Commas:";
            this.TrailingCommasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrailingCommasEdit
            // 
            this.TrailingCommasEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TrailingCommasEdit.AutoSize = true;
            this.TrailingCommasEdit.Location = new System.Drawing.Point(203, 103);
            this.TrailingCommasEdit.Name = "TrailingCommasEdit";
            this.TrailingCommasEdit.Size = new System.Drawing.Size(15, 19);
            this.TrailingCommasEdit.TabIndex = 9;
            this.TrailingCommasEdit.UseVisualStyleBackColor = true;
            this.TrailingCommasEdit.CheckedChanged += new System.EventHandler(this.TrailingCommasEdit_CheckedChanged);
            // 
            // SpaceAfterExpandedCommaLabel
            // 
            this.SpaceAfterExpandedCommaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpaceAfterExpandedCommaLabel.Location = new System.Drawing.Point(3, 125);
            this.SpaceAfterExpandedCommaLabel.Name = "SpaceAfterExpandedCommaLabel";
            this.SpaceAfterExpandedCommaLabel.Size = new System.Drawing.Size(194, 25);
            this.SpaceAfterExpandedCommaLabel.TabIndex = 10;
            this.SpaceAfterExpandedCommaLabel.Text = "Space After Expanded Comma:";
            this.SpaceAfterExpandedCommaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SpaceAfterExpandedCommaEdit
            // 
            this.SpaceAfterExpandedCommaEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SpaceAfterExpandedCommaEdit.AutoSize = true;
            this.SpaceAfterExpandedCommaEdit.Location = new System.Drawing.Point(203, 128);
            this.SpaceAfterExpandedCommaEdit.Name = "SpaceAfterExpandedCommaEdit";
            this.SpaceAfterExpandedCommaEdit.Size = new System.Drawing.Size(15, 19);
            this.SpaceAfterExpandedCommaEdit.TabIndex = 11;
            this.SpaceAfterExpandedCommaEdit.UseVisualStyleBackColor = true;
            this.SpaceAfterExpandedCommaEdit.CheckedChanged += new System.EventHandler(this.SpaceAfterExpandedCommaEdit_CheckedChanged);
            // 
            // ExpandBooleanExpressionsLabel
            // 
            this.ExpandBooleanExpressionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpandBooleanExpressionsLabel.Location = new System.Drawing.Point(3, 150);
            this.ExpandBooleanExpressionsLabel.Name = "ExpandBooleanExpressionsLabel";
            this.ExpandBooleanExpressionsLabel.Size = new System.Drawing.Size(194, 25);
            this.ExpandBooleanExpressionsLabel.TabIndex = 12;
            this.ExpandBooleanExpressionsLabel.Text = "Expand Boolean Expressions:";
            this.ExpandBooleanExpressionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExpandBooleanExpressionsEdit
            // 
            this.ExpandBooleanExpressionsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ExpandBooleanExpressionsEdit.AutoSize = true;
            this.ExpandBooleanExpressionsEdit.Location = new System.Drawing.Point(203, 153);
            this.ExpandBooleanExpressionsEdit.Name = "ExpandBooleanExpressionsEdit";
            this.ExpandBooleanExpressionsEdit.Size = new System.Drawing.Size(15, 19);
            this.ExpandBooleanExpressionsEdit.TabIndex = 13;
            this.ExpandBooleanExpressionsEdit.UseVisualStyleBackColor = true;
            this.ExpandBooleanExpressionsEdit.CheckedChanged += new System.EventHandler(this.ExpandBooleanExpressionsEdit_CheckedChanged);
            // 
            // ExpandCaseStatementsLabel
            // 
            this.ExpandCaseStatementsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpandCaseStatementsLabel.Location = new System.Drawing.Point(3, 175);
            this.ExpandCaseStatementsLabel.Name = "ExpandCaseStatementsLabel";
            this.ExpandCaseStatementsLabel.Size = new System.Drawing.Size(194, 25);
            this.ExpandCaseStatementsLabel.TabIndex = 14;
            this.ExpandCaseStatementsLabel.Text = "Expand Case Statements:";
            this.ExpandCaseStatementsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExpandCaseStatementsEdit
            // 
            this.ExpandCaseStatementsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ExpandCaseStatementsEdit.AutoSize = true;
            this.ExpandCaseStatementsEdit.Location = new System.Drawing.Point(203, 178);
            this.ExpandCaseStatementsEdit.Name = "ExpandCaseStatementsEdit";
            this.ExpandCaseStatementsEdit.Size = new System.Drawing.Size(15, 19);
            this.ExpandCaseStatementsEdit.TabIndex = 15;
            this.ExpandCaseStatementsEdit.UseVisualStyleBackColor = true;
            this.ExpandCaseStatementsEdit.CheckedChanged += new System.EventHandler(this.ExpandCaseStatementsEdit_CheckedChanged);
            // 
            // ExpandBetweenConditionsLabel
            // 
            this.ExpandBetweenConditionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpandBetweenConditionsLabel.Location = new System.Drawing.Point(3, 200);
            this.ExpandBetweenConditionsLabel.Name = "ExpandBetweenConditionsLabel";
            this.ExpandBetweenConditionsLabel.Size = new System.Drawing.Size(194, 25);
            this.ExpandBetweenConditionsLabel.TabIndex = 16;
            this.ExpandBetweenConditionsLabel.Text = "Expand Between Conditions:";
            this.ExpandBetweenConditionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExpandBetweenConditionsEdit
            // 
            this.ExpandBetweenConditionsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ExpandBetweenConditionsEdit.AutoSize = true;
            this.ExpandBetweenConditionsEdit.Location = new System.Drawing.Point(203, 203);
            this.ExpandBetweenConditionsEdit.Name = "ExpandBetweenConditionsEdit";
            this.ExpandBetweenConditionsEdit.Size = new System.Drawing.Size(15, 19);
            this.ExpandBetweenConditionsEdit.TabIndex = 17;
            this.ExpandBetweenConditionsEdit.UseVisualStyleBackColor = true;
            this.ExpandBetweenConditionsEdit.CheckedChanged += new System.EventHandler(this.ExpandBetweenConditionsEdit_CheckedChanged);
            // 
            // BreakJoinOnSectionsLabel
            // 
            this.BreakJoinOnSectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BreakJoinOnSectionsLabel.Location = new System.Drawing.Point(3, 225);
            this.BreakJoinOnSectionsLabel.Name = "BreakJoinOnSectionsLabel";
            this.BreakJoinOnSectionsLabel.Size = new System.Drawing.Size(194, 25);
            this.BreakJoinOnSectionsLabel.TabIndex = 18;
            this.BreakJoinOnSectionsLabel.Text = "Break Join On Sections:";
            this.BreakJoinOnSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BreakJoinOnSectionsEdit
            // 
            this.BreakJoinOnSectionsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BreakJoinOnSectionsEdit.AutoSize = true;
            this.BreakJoinOnSectionsEdit.Location = new System.Drawing.Point(203, 228);
            this.BreakJoinOnSectionsEdit.Name = "BreakJoinOnSectionsEdit";
            this.BreakJoinOnSectionsEdit.Size = new System.Drawing.Size(15, 19);
            this.BreakJoinOnSectionsEdit.TabIndex = 19;
            this.BreakJoinOnSectionsEdit.UseVisualStyleBackColor = true;
            this.BreakJoinOnSectionsEdit.CheckedChanged += new System.EventHandler(this.BreakJoinOnSectionsEdit_CheckedChanged);
            // 
            // UppercaseKeywordsLabel
            // 
            this.UppercaseKeywordsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UppercaseKeywordsLabel.Location = new System.Drawing.Point(3, 250);
            this.UppercaseKeywordsLabel.Name = "UppercaseKeywordsLabel";
            this.UppercaseKeywordsLabel.Size = new System.Drawing.Size(194, 25);
            this.UppercaseKeywordsLabel.TabIndex = 20;
            this.UppercaseKeywordsLabel.Text = "Uppercase Keywords:";
            this.UppercaseKeywordsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UppercaseKeywordsEdit
            // 
            this.UppercaseKeywordsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UppercaseKeywordsEdit.AutoSize = true;
            this.UppercaseKeywordsEdit.Location = new System.Drawing.Point(203, 253);
            this.UppercaseKeywordsEdit.Name = "UppercaseKeywordsEdit";
            this.UppercaseKeywordsEdit.Size = new System.Drawing.Size(15, 19);
            this.UppercaseKeywordsEdit.TabIndex = 21;
            this.UppercaseKeywordsEdit.UseVisualStyleBackColor = true;
            this.UppercaseKeywordsEdit.CheckedChanged += new System.EventHandler(this.UppercaseKeywordsEdit_CheckedChanged);
            // 
            // KeywordStandardizationLabel
            // 
            this.KeywordStandardizationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeywordStandardizationLabel.Location = new System.Drawing.Point(3, 275);
            this.KeywordStandardizationLabel.Name = "KeywordStandardizationLabel";
            this.KeywordStandardizationLabel.Size = new System.Drawing.Size(194, 25);
            this.KeywordStandardizationLabel.TabIndex = 22;
            this.KeywordStandardizationLabel.Text = "Keyword Standardization:";
            this.KeywordStandardizationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KeywordStandardizationEdit
            // 
            this.KeywordStandardizationEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.KeywordStandardizationEdit.AutoSize = true;
            this.KeywordStandardizationEdit.Location = new System.Drawing.Point(203, 278);
            this.KeywordStandardizationEdit.Name = "KeywordStandardizationEdit";
            this.KeywordStandardizationEdit.Size = new System.Drawing.Size(15, 19);
            this.KeywordStandardizationEdit.TabIndex = 23;
            this.KeywordStandardizationEdit.UseVisualStyleBackColor = true;
            this.KeywordStandardizationEdit.CheckedChanged += new System.EventHandler(this.KeywordStandardizationEdit_CheckedChanged);
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 427);
            this.Controls.Add(this.MainTabControl);
            this.Name = "ConfigWindow";
            this.Text = "SQLParamParser Configuration";
            this.MainTabControl.ResumeLayout(false);
            this.ParamParseSettingsTab.ResumeLayout(false);
            this.ParaseParamSettingsTable.ResumeLayout(false);
            this.ParaseParamSettingsTable.PerformLayout();
            this.FormatSQLSettingsTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxLineWidthEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpacesPerTabEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ParamParseSettingsTab;
        private System.Windows.Forms.TableLayoutPanel ParaseParamSettingsTable;
        private System.Windows.Forms.Label ParamIdentificatorNameLabel;
        private System.Windows.Forms.TabPage FormatSQLSettingsTab;
        private System.Windows.Forms.TextBox ParamIdentificatorNameEdit;
        private System.Windows.Forms.Label DateFormatLabel;
        private System.Windows.Forms.TextBox DateFormatEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label SpacesPerTabLabel;
        private System.Windows.Forms.Label IndentStringLabel;
        private System.Windows.Forms.TextBox IndentStringEdit;
        private System.Windows.Forms.NumericUpDown SpacesPerTabEdit;
        private System.Windows.Forms.Label MaxLineWidthLabel;
        private System.Windows.Forms.NumericUpDown MaxLineWidthEdit;
        private System.Windows.Forms.Label ExpandCommaListLabel;
        private System.Windows.Forms.CheckBox ExpandCommaListEdit;
        private System.Windows.Forms.Label TrailingCommasLabel;
        private System.Windows.Forms.CheckBox TrailingCommasEdit;
        private System.Windows.Forms.Label SpaceAfterExpandedCommaLabel;
        private System.Windows.Forms.CheckBox SpaceAfterExpandedCommaEdit;
        private System.Windows.Forms.Label ExpandBooleanExpressionsLabel;
        private System.Windows.Forms.CheckBox ExpandBooleanExpressionsEdit;
        private System.Windows.Forms.Label ExpandCaseStatementsLabel;
        private System.Windows.Forms.CheckBox ExpandCaseStatementsEdit;
        private System.Windows.Forms.Label ExpandBetweenConditionsLabel;
        private System.Windows.Forms.CheckBox ExpandBetweenConditionsEdit;
        private System.Windows.Forms.Label BreakJoinOnSectionsLabel;
        private System.Windows.Forms.CheckBox BreakJoinOnSectionsEdit;
        private System.Windows.Forms.Label UppercaseKeywordsLabel;
        private System.Windows.Forms.CheckBox UppercaseKeywordsEdit;
        private System.Windows.Forms.Label KeywordStandardizationLabel;
        private System.Windows.Forms.CheckBox KeywordStandardizationEdit;
    }
}