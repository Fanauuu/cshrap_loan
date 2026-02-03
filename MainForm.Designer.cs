namespace WinFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Label lblRole;
        private Button btnUserManagement;
        private Button btnCustomerManagement;
        private Button btnLoanTermManagement;
        private Button btnLoanContractManagement;
        private Button btnRepaymentSchedule;
        private Button btnLogout;
        private Panel panelMain;
        private Label lblLoanManagement;
        private Label lblSystemManagement;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.lblWelcome = new Label();
            this.lblRole = new Label();
            this.lblSystemManagement = new Label();
            this.btnUserManagement = new Button();
            this.lblLoanManagement = new Label();
            this.btnCustomerManagement = new Button();
            this.btnLoanTermManagement = new Button();
            this.btnLoanContractManagement = new Button();
            this.btnRepaymentSchedule = new Button();
            this.btnLogout = new Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = Color.FromArgb(240, 240, 240);
            this.panelMain.Controls.Add(this.lblWelcome);
            this.panelMain.Controls.Add(this.lblRole);
            this.panelMain.Controls.Add(this.lblSystemManagement);
            this.panelMain.Controls.Add(this.btnUserManagement);
            this.panelMain.Controls.Add(this.lblLoanManagement);
            this.panelMain.Controls.Add(this.btnCustomerManagement);
            this.panelMain.Controls.Add(this.btnLoanTermManagement);
            this.panelMain.Controls.Add(this.btnLoanContractManagement);
            this.panelMain.Controls.Add(this.btnRepaymentSchedule);
            this.panelMain.Controls.Add(this.btnLogout);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblWelcome.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblWelcome.Location = new Point(20, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(200, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, User";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblRole.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblRole.Location = new Point(20, 75);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(50, 21);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role: ";
            // 
            // lblSystemManagement
            // 
            this.lblSystemManagement.AutoSize = true;
            this.lblSystemManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblSystemManagement.ForeColor = Color.FromArgb(70, 70, 70);
            this.lblSystemManagement.Location = new Point(20, 120);
            this.lblSystemManagement.Name = "lblSystemManagement";
            this.lblSystemManagement.Size = new Size(170, 21);
            this.lblSystemManagement.TabIndex = 4;
            this.lblSystemManagement.Text = "System Management";
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = Color.FromArgb(0, 120, 215);
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = FlatStyle.Flat;
            this.btnUserManagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnUserManagement.ForeColor = Color.White;
            this.btnUserManagement.Location = new Point(20, 150);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new Size(180, 40);
            this.btnUserManagement.TabIndex = 2;
            this.btnUserManagement.Text = "👥 User Management";
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new EventHandler(this.btnUserManagement_Click);
            // 
            // lblLoanManagement
            // 
            this.lblLoanManagement.AutoSize = true;
            this.lblLoanManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblLoanManagement.ForeColor = Color.FromArgb(70, 70, 70);
            this.lblLoanManagement.Location = new Point(20, 220);
            this.lblLoanManagement.Name = "lblLoanManagement";
            this.lblLoanManagement.Size = new Size(150, 21);
            this.lblLoanManagement.TabIndex = 5;
            this.lblLoanManagement.Text = "Loan Management";
            // 
            // btnCustomerManagement
            // 
            this.btnCustomerManagement.BackColor = Color.FromArgb(40, 167, 69);
            this.btnCustomerManagement.FlatAppearance.BorderSize = 0;
            this.btnCustomerManagement.FlatStyle = FlatStyle.Flat;
            this.btnCustomerManagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCustomerManagement.ForeColor = Color.White;
            this.btnCustomerManagement.Location = new Point(20, 250);
            this.btnCustomerManagement.Name = "btnCustomerManagement";
            this.btnCustomerManagement.Size = new Size(180, 40);
            this.btnCustomerManagement.TabIndex = 6;
            this.btnCustomerManagement.Text = "👤 Customer Management";
            this.btnCustomerManagement.UseVisualStyleBackColor = false;
            this.btnCustomerManagement.Click += new EventHandler(this.btnCustomerManagement_Click);
            // 
            // btnLoanTermManagement
            // 
            this.btnLoanTermManagement.BackColor = Color.FromArgb(0, 123, 255);
            this.btnLoanTermManagement.FlatAppearance.BorderSize = 0;
            this.btnLoanTermManagement.FlatStyle = FlatStyle.Flat;
            this.btnLoanTermManagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLoanTermManagement.ForeColor = Color.White;
            this.btnLoanTermManagement.Location = new Point(220, 250);
            this.btnLoanTermManagement.Name = "btnLoanTermManagement";
            this.btnLoanTermManagement.Size = new Size(180, 40);
            this.btnLoanTermManagement.TabIndex = 7;
            this.btnLoanTermManagement.Text = "📅 Loan Terms";
            this.btnLoanTermManagement.UseVisualStyleBackColor = false;
            this.btnLoanTermManagement.Click += new EventHandler(this.btnLoanTermManagement_Click);
            // 
            // btnLoanContractManagement
            // 
            this.btnLoanContractManagement.BackColor = Color.FromArgb(255, 193, 7);
            this.btnLoanContractManagement.FlatAppearance.BorderSize = 0;
            this.btnLoanContractManagement.FlatStyle = FlatStyle.Flat;
            this.btnLoanContractManagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLoanContractManagement.ForeColor = Color.White;
            this.btnLoanContractManagement.Location = new Point(20, 300);
            this.btnLoanContractManagement.Name = "btnLoanContractManagement";
            this.btnLoanContractManagement.Size = new Size(180, 40);
            this.btnLoanContractManagement.TabIndex = 8;
            this.btnLoanContractManagement.Text = "📋 Loan Contracts";
            this.btnLoanContractManagement.UseVisualStyleBackColor = false;
            this.btnLoanContractManagement.Click += new EventHandler(this.btnLoanContractManagement_Click);
            // 
            // btnRepaymentSchedule
            // 
            this.btnRepaymentSchedule.BackColor = Color.FromArgb(23, 162, 184);
            this.btnRepaymentSchedule.FlatAppearance.BorderSize = 0;
            this.btnRepaymentSchedule.FlatStyle = FlatStyle.Flat;
            this.btnRepaymentSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRepaymentSchedule.ForeColor = Color.White;
            this.btnRepaymentSchedule.Location = new Point(220, 300);
            this.btnRepaymentSchedule.Name = "btnRepaymentSchedule";
            this.btnRepaymentSchedule.Size = new Size(180, 40);
            this.btnRepaymentSchedule.TabIndex = 9;
            this.btnRepaymentSchedule.Text = "💰 Repayment Schedule";
            this.btnRepaymentSchedule.UseVisualStyleBackColor = false;
            this.btnRepaymentSchedule.Click += new EventHandler(this.btnRepaymentSchedule_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(680, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(100, 35);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Main Dashboard";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
