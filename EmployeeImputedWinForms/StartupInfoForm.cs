using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeImputedWinForms
{

    public partial class StartupInfoForm : Form
    {
        private Label lblHeader;
        private Label lblInfo;
        private Button btnContinue;
        private Button btnExit;

        public StartupInfoForm()
        {
            InitializeComponent();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.FormClosed += (s, args) => this.Close();
            form1.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupInfoForm));
            lblHeader = new Label();
            lblInfo = new Label();
            btnContinue = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(2400, 100);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Please review this information before continuing.";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            lblInfo.BorderStyle = BorderStyle.FixedSingle;
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.Location = new Point(150, 100);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(2115, 1348);
            lblInfo.TabIndex = 1;
            lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(150, 1495);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(400, 80);
            btnContinue.TabIndex = 2;
            btnContinue.Text = "Continue";
            btnContinue.Click += BtnContinue_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1865, 1495);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(400, 80);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.Click += BtnExit_Click;
            // 
            // StartupInfoForm
            // 
            AcceptButton = btnContinue;
            CancelButton = btnExit;
            ClientSize = new Size(2400, 1600);
            Controls.Add(lblHeader);
            Controls.Add(lblInfo);
            Controls.Add(btnContinue);
            Controls.Add(btnExit);
            Name = "StartupInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Imputed Calculator Info Form";
            ResumeLayout(false);
        }
    }
}

