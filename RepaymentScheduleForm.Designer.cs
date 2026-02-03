namespace WinFormsApp1
{
    partial class RepaymentScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblLoanInfo;
        private Label lblScheduleCount;
        private DataGridView dgvSchedule;
        private Panel panelButtons;
        private Button btnMarkPaid;
        private Button btnRefresh;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.dgvSchedule = new DataGridView();
            this.panelHeader = new Panel();
            this.lblScheduleCount = new Label();
            this.lblLoanInfo = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Panel();
            this.btnMarkPaid = new Button();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvSchedule);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(15);
            this.panelMain.Size = new Size(900, 600);
            this.panelMain.TabIndex = 0;
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.BackgroundColor = Color.White;
            this.dgvSchedule.BorderStyle = BorderStyle.None;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Dock = DockStyle.Fill;
            this.dgvSchedule.Location = new Point(15, 120);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersWidth = 30;
            this.dgvSchedule.RowTemplate.Height = 30;
            this.dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new Size(870, 380);
            this.dgvSchedule.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblScheduleCount);
            this.panelHeader.Controls.Add(this.lblLoanInfo);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(870, 105);
            this.panelHeader.TabIndex = 0;
            // 
            // lblScheduleCount
            // 
            this.lblScheduleCount.AutoSize = true;
            this.lblScheduleCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblScheduleCount.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblScheduleCount.Location = new Point(0, 80);
            this.lblScheduleCount.Name = "lblScheduleCount";
            this.lblScheduleCount.Size = new Size(120, 19);
            this.lblScheduleCount.TabIndex = 2;
            this.lblScheduleCount.Text = "Total Payments: 0";
            // 
            // lblLoanInfo
            // 
            this.lblLoanInfo.AutoSize = true;
            this.lblLoanInfo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblLoanInfo.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblLoanInfo.Location = new Point(0, 45);
            this.lblLoanInfo.Name = "lblLoanInfo";
            this.lblLoanInfo.Size = new Size(100, 20);
            this.lblLoanInfo.TabIndex = 1;
            this.lblLoanInfo.Text = "Loan Contract";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(280, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Loan Repayment Schedule";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnMarkPaid);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(15, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(870, 85);
            this.panelButtons.TabIndex = 1;
            // 
            // btnMarkPaid
            // 
            this.btnMarkPaid.BackColor = Color.FromArgb(40, 167, 69);
            this.btnMarkPaid.FlatAppearance.BorderSize = 0;
            this.btnMarkPaid.FlatStyle = FlatStyle.Flat;
            this.btnMarkPaid.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnMarkPaid.ForeColor = Color.White;
            this.btnMarkPaid.Location = new Point(0, 10);
            this.btnMarkPaid.Name = "btnMarkPaid";
            this.btnMarkPaid.Size = new Size(150, 35);
            this.btnMarkPaid.TabIndex = 0;
            this.btnMarkPaid.Text = "✅ Mark as Paid";
            this.btnMarkPaid.UseVisualStyleBackColor = false;
            this.btnMarkPaid.Click += new EventHandler(this.btnMarkPaid_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(160, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = Color.FromArgb(108, 117, 125);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(750, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(120, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // 
            // RepaymentScheduleForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(900, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepaymentScheduleForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Loan Repayment Schedule";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
