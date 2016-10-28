namespace SQLParamParser.Forms
{
    partial class ExecuteWindow
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
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ExecuteTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.TerminateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MaxRowsEdit = new System.Windows.Forms.NumericUpDown();
            this.PageSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.ExecuteTableLayout.SuspendLayout();
            this.ButtonsLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRowsEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(3, 43);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(594, 270);
            this.DataGridView.TabIndex = 2;
            this.DataGridView.VirtualMode = true;
            // 
            // ExecuteTableLayout
            // 
            this.ExecuteTableLayout.ColumnCount = 1;
            this.ExecuteTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExecuteTableLayout.Controls.Add(this.DataGridView, 0, 1);
            this.ExecuteTableLayout.Controls.Add(this.ButtonsLayoutPanel, 0, 0);
            this.ExecuteTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExecuteTableLayout.Location = new System.Drawing.Point(0, 0);
            this.ExecuteTableLayout.Name = "ExecuteTableLayout";
            this.ExecuteTableLayout.RowCount = 2;
            this.ExecuteTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ExecuteTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExecuteTableLayout.Size = new System.Drawing.Size(600, 316);
            this.ExecuteTableLayout.TabIndex = 3;
            // 
            // ButtonsLayoutPanel
            // 
            this.ButtonsLayoutPanel.Controls.Add(this.ExecuteButton);
            this.ButtonsLayoutPanel.Controls.Add(this.TerminateButton);
            this.ButtonsLayoutPanel.Controls.Add(this.panel1);
            this.ButtonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.ButtonsLayoutPanel.Name = "ButtonsLayoutPanel";
            this.ButtonsLayoutPanel.Size = new System.Drawing.Size(594, 34);
            this.ButtonsLayoutPanel.TabIndex = 3;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(3, 3);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(96, 29);
            this.ExecuteButton.TabIndex = 2;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // TerminateButton
            // 
            this.TerminateButton.Location = new System.Drawing.Point(105, 3);
            this.TerminateButton.Name = "TerminateButton";
            this.TerminateButton.Size = new System.Drawing.Size(96, 29);
            this.TerminateButton.TabIndex = 3;
            this.TerminateButton.Text = "Terminate";
            this.TerminateButton.UseVisualStyleBackColor = true;
            this.TerminateButton.Click += new System.EventHandler(this.TerminateButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.MaxRowsEdit);
            this.panel1.Controls.Add(this.PageSizeLabel);
            this.panel1.Location = new System.Drawing.Point(207, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 30);
            this.panel1.TabIndex = 5;
            // 
            // MaxRowsEdit
            // 
            this.MaxRowsEdit.Location = new System.Drawing.Point(65, 4);
            this.MaxRowsEdit.Name = "MaxRowsEdit";
            this.MaxRowsEdit.Size = new System.Drawing.Size(83, 20);
            this.MaxRowsEdit.TabIndex = 1;
            this.MaxRowsEdit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.MaxRowsEdit.ValueChanged += new System.EventHandler(this.PageSizeEdit_ValueChanged);
            // 
            // PageSizeLabel
            // 
            this.PageSizeLabel.AutoSize = true;
            this.PageSizeLabel.Location = new System.Drawing.Point(3, 7);
            this.PageSizeLabel.Name = "PageSizeLabel";
            this.PageSizeLabel.Size = new System.Drawing.Size(55, 13);
            this.PageSizeLabel.TabIndex = 0;
            this.PageSizeLabel.Text = "Max rows:";
            // 
            // ExecuteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 316);
            this.Controls.Add(this.ExecuteTableLayout);
            this.Name = "ExecuteWindow";
            this.Text = "SQLParamParser Execute";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ExecuteTableLayout.ResumeLayout(false);
            this.ButtonsLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRowsEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.TableLayoutPanel ExecuteTableLayout;
        private System.Windows.Forms.FlowLayoutPanel ButtonsLayoutPanel;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button TerminateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown MaxRowsEdit;
        private System.Windows.Forms.Label PageSizeLabel;
    }
}