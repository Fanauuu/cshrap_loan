using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class RepaymentScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Label lblLoanInfo;
        private Label lblScheduleCount;
        private DataGridView dgvSchedule;
        private Guna2Panel panelButtons;
        private Guna2Button btnMarkPaid;
        private Guna2Button btnRefresh;
        private Guna2Button btnExportExcel;
        private Guna2Button btnExportPdf;
        private Guna2Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Guna2Panel();
            this.dgvSchedule = new DataGridView();
            this.panelHeader = new Guna2Panel();
            this.lblScheduleCount = new Label();
            this.lblLoanInfo = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnMarkPaid = new Guna2Button();
            this.btnRefresh = new Guna2Button();
            this.btnExportExcel = new Guna2Button();
            this.btnExportPdf = new Guna2Button();
            this.btnClose = new Guna2Button();
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
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Padding = new Padding(20);
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
            this.panelButtons.Controls.Add(this.btnExportExcel);
            this.panelButtons.Controls.Add(this.btnExportPdf);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(15, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(870, 85);
            this.panelButtons.TabIndex = 1;
            // 
            // btnMarkPaid
            //
            this.btnMarkPaid.BorderRadius = 10;
            this.btnMarkPaid.Cursor = Cursors.Hand;
            this.btnMarkPaid.FillColor = Color.FromArgb(34, 197, 94);
            this.btnMarkPaid.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnMarkPaid.ForeColor = Color.White;
            this.btnMarkPaid.Location = new Point(0, 15);
            this.btnMarkPaid.Name = "btnMarkPaid";
            this.btnMarkPaid.Size = new Size(150, 40);
            this.btnMarkPaid.TabIndex = 0;
            this.btnMarkPaid.Text = "Mark as Paid";
            this.btnMarkPaid.Click += new EventHandler(this.btnMarkPaid_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FillColor = Color.FromArgb(107, 114, 128);
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(160, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnRefresh.Visible = false;
            //
            // btnExportExcel
            //
            this.btnExportExcel.BorderRadius = 10;
            this.btnExportExcel.Cursor = Cursors.Hand;
            this.btnExportExcel.FillColor = Color.FromArgb(59, 130, 246);
            this.btnExportExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnExportExcel.ForeColor = Color.White;
            this.btnExportExcel.Location = new Point(160, 15);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new Size(150, 40);
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.Click += new EventHandler(this.btnExportExcel_Click);
            //
            // btnExportPdf
            //
            this.btnExportPdf.BorderRadius = 10;
            this.btnExportPdf.Cursor = Cursors.Hand;
            this.btnExportPdf.FillColor = Color.FromArgb(245, 158, 11);
            this.btnExportPdf.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnExportPdf.ForeColor = Color.White;
            this.btnExportPdf.Location = new Point(320, 15);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new Size(120, 40);
            this.btnExportPdf.TabIndex = 2;
            this.btnExportPdf.Text = "Export PDF";
            this.btnExportPdf.Click += new EventHandler(this.btnExportPdf_Click);
            //
            // btnClose
            //
            this.btnClose.BorderRadius = 10;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.FillColor = Color.FromArgb(107, 114, 128);
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(750, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(120, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
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
