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

            // Optional: Set the form to a percentage of the screen size
            var screen = Screen.FromControl(this);
            int width = (int)(screen.WorkingArea.Width * 0.8);   // 80% of screen width
            int height = (int)(screen.WorkingArea.Height * 0.8); // 80% of screen height

            this.Size = new System.Drawing.Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
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
            Panel buttonPanel = new Panel();

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
            lblHeader.Text = "Please review the information below.";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            lblInfo.BorderStyle = BorderStyle.FixedSingle;
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.Location = new Point(150, 100);
            lblInfo.Name = "lblInfo";
            lblInfo.AutoSize = false;
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.TabIndex = 1;
            lblInfo.Text = resources.GetString("lblInfo.Text");
            lblInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonPanel
            // 
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 75;
            buttonPanel.Padding = new Padding(20,10,20,10);
            buttonPanel.Name = "buttonPanel";
            // 
            // btnContinue
            // 
            btnContinue.Dock = DockStyle.Left;
            btnContinue.Name = "btnContinue";
            btnContinue.Width = 150;
            btnContinue.TabIndex = 2;
            btnContinue.Text = "Continue";
            btnContinue.Click += BtnContinue_Click;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Right;
            btnExit.Name = "btnExit";
            btnExit.Width = 150;
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.Click += BtnExit_Click;
            // 
            // StartupInfoForm
            // 
            AcceptButton = btnContinue;
            CancelButton = btnExit;
            ClientSize = new Size(2400, 1600);
            Controls.Add(lblInfo);
            Controls.Add(buttonPanel);
            Controls.Add(lblHeader);
            buttonPanel.Controls.Add(btnContinue);
            buttonPanel.Controls.Add(btnExit);
            Name = "StartupInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Imputed Calculator Info Form";
            ResumeLayout(false);
        }
    }
}