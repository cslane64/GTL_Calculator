using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeImputedWinForms
{
    public partial class Form1 : Form
    {
        private List<CoveredPersonRow> _loadedRows = new();
        private List<ResultRow> _results = new();

        public Form1()
        {
            InitializeComponent();
            var screen = Screen.FromControl(this);
            int width = (int)(screen.WorkingArea.Width * 0.6);   // 60% of screen width
            int height = (int)(screen.WorkingArea.Height * 0.6); // 60% of screen height

            this.Size = new System.Drawing.Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;

            nudYear.Value = DateTime.Today.Year;

            


        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                _loadedRows = ImputedCalculator.LoadCsv(ofd.FileName);
                _results = ImputedCalculator.Compute(_loadedRows, (int)nudYear.Value);

                gridResults.AutoGenerateColumns = true;
                gridResults.DataSource = null;
                gridResults.DataSource = _results;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportSummary_Click(object sender, EventArgs e)
        {
            if (_results == null || _results.Count == 0)
            {
                MessageBox.Show(this, "No results to export. Import a CSV first.", "Nothing to Export",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"imputed_summary_{nudYear.Value}.csv"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var summary = _results
                    .GroupBy(r => new { r.LastName, r.FirstName })
                    .Select(g => new SummaryExportRow(
                        g.Key.LastName,
                        g.Key.FirstName,
                        g.Sum(x => x.ImputedIncome)))
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .ToList();

                CsvExport.WriteSummary(sfd.FileName, summary);

                MessageBox.Show(this, "Summary export complete.", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportDetails_Click(object sender, EventArgs e)
        {
            if (_results == null || _results.Count == 0)
            {
                MessageBox.Show(this, "No results to export. Import a CSV first.", "Nothing to Export",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"imputed_details_{nudYear.Value}.csv"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                CsvExport.WriteDetails(sfd.FileName, _results);

                MessageBox.Show(this, "Detail export complete.", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }



    public record SummaryExportRow(
        string LastName,
        string FirstName,
        decimal TotalImputedIncome
    );
}