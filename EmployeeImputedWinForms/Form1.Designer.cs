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
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
            SuspendLayout();
            // 
            // btnImportCsv
            // 
            btnImportCsv.Location = new Point(60, 32);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(110, 30);
            btnImportCsv.TabIndex = 0;
            btnImportCsv.Text = "Import CSV";
            btnImportCsv.UseVisualStyleBackColor = true;
            btnImportCsv.Click += btnImportCsv_Click;
            // 
            // nudYear
            // 
            nudYear.Location = new Point(747, 37);
            nudYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(120, 23);
            nudYear.TabIndex = 1;
            nudYear.TextAlign = HorizontalAlignment.Right;
            nudYear.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // gridResults
            // 
            gridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResults.Location = new Point(60, 77);
            gridResults.Name = "gridResults";
            gridResults.Size = new Size(807, 287);
            gridResults.TabIndex = 2;
            // 
            // btnExportSummary
            // 
            btnExportSummary.Location = new Point(588, 387);
            btnExportSummary.Name = "btnExportSummary";
            btnExportSummary.Size = new Size(130, 30);
            btnExportSummary.TabIndex = 3;
            btnExportSummary.Text = "Export Summary";
            btnExportSummary.UseVisualStyleBackColor = true;
            btnExportSummary.Click += btnExportSummary_Click;
            // 
            // btnExportDetails
            // 
            btnExportDetails.Location = new Point(737, 387);
            btnExportDetails.Name = "btnExportDetails";
            btnExportDetails.Size = new Size(130, 30);
            btnExportDetails.TabIndex = 4;
            btnExportDetails.Text = "Export Details";
            btnExportDetails.UseVisualStyleBackColor = true;
            btnExportDetails.Click += btnExportDetails_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 501);
            Controls.Add(btnExportDetails);
            Controls.Add(btnExportSummary);
            Controls.Add(gridResults);
            Controls.Add(nudYear);
            Controls.Add(btnImportCsv);
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
    }
}