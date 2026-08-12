namespace EmployeeImputedWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnImportCsv = new Button();
            nudYear = new NumericUpDown();
            gridResults = new DataGridView();
            btnExportSummary = new Button();
            btnExportDetails = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
            SuspendLayout();
            // 
            // btnImportCsv
            // 
            btnImportCsv.Location = new Point(146, 87);
            btnImportCsv.Margin = new Padding(7, 8, 7, 8);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(267, 82);
            btnImportCsv.TabIndex = 0;
            btnImportCsv.Text = "Import CSV";
            btnImportCsv.UseVisualStyleBackColor = true;
            btnImportCsv.Click += btnImportCsv_Click;
            // 
            // nudYear
            // 
            nudYear.Location = new Point(1814, 101);
            nudYear.Margin = new Padding(7, 8, 7, 8);
            nudYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(291, 47);
            nudYear.TabIndex = 1;
            nudYear.TextAlign = HorizontalAlignment.Right;
            nudYear.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // gridResults
            // 
            gridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResults.Location = new Point(146, 210);
            gridResults.Margin = new Padding(7, 8, 7, 8);
            gridResults.Name = "gridResults";
            gridResults.RowHeadersWidth = 102;
            gridResults.Size = new Size(1960, 784);
            gridResults.TabIndex = 2;
            // 
            // btnExportSummary
            // 
            btnExportSummary.Location = new Point(1428, 1058);
            btnExportSummary.Margin = new Padding(7, 8, 7, 8);
            btnExportSummary.Name = "btnExportSummary";
            btnExportSummary.Size = new Size(316, 82);
            btnExportSummary.TabIndex = 3;
            btnExportSummary.Text = "Export Summary";
            btnExportSummary.UseVisualStyleBackColor = true;
            btnExportSummary.Click += btnExportSummary_Click;
            // 
            // btnExportDetails
            // 
            btnExportDetails.Location = new Point(1790, 1058);
            btnExportDetails.Margin = new Padding(7, 8, 7, 8);
            btnExportDetails.Name = "btnExportDetails";
            btnExportDetails.Size = new Size(316, 82);
            btnExportDetails.TabIndex = 4;
            btnExportDetails.Text = "Export Details";
            btnExportDetails.UseVisualStyleBackColor = true;
            btnExportDetails.Click += btnExportDetails_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(146, 1058);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(244, 82);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2329, 1369);
            Controls.Add(btnExit);
            Controls.Add(btnExportDetails);
            Controls.Add(btnExportSummary);
            Controls.Add(gridResults);
            Controls.Add(nudYear);
            Controls.Add(btnImportCsv);
            Margin = new Padding(7, 8, 7, 8);
            Name = "Form1";
            Text = "Employee Imputed Income";
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnImportCsv;
        private NumericUpDown nudYear;
        private DataGridView gridResults;
        private Button btnExportSummary;
        private Button btnExportDetails;
        private Button btnExit;
    }
}