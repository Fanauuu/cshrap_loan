using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class LoanContractManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Label lblContractCount;
        private DataGridView dgvLoanContracts;
        private Guna2Panel panelButtons;
        private Guna2Button btnAdd;
        private Guna2Button btnViewSchedule;
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
            this.dgvLoanContracts = new DataGridView();
            this.panelHeader = new Guna2Panel();
            this.lblContractCount = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnAdd = new Guna2Button();
            this.btnViewSchedule = new Guna2Button();
            this.btnRefresh = new Guna2Button();
            this.btnExportExcel = new Guna2Button();
            this.btnExportPdf = new Guna2Button();
            this.btnClose = new Guna2Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanContracts)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvLoanContracts);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(1000, 600);
            this.panelMain.TabIndex = 0;
            // 
            // dgvLoanContracts
            // 
            this.dgvLoanContracts.AllowUserToAddRows = false;
            this.dgvLoanContracts.AllowUserToDeleteRows = false;
            this.dgvLoanContracts.BackgroundColor = Color.White;
            this.dgvLoanContracts.BorderStyle = BorderStyle.None;
            this.dgvLoanContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanContracts.Dock = DockStyle.Fill;
            this.dgvLoanContracts.Location = new Point(15, 80);
            this.dgvLoanContracts.MultiSelect = false;
            this.dgvLoanContracts.Name = "dgvLoanContracts";
            this.dgvLoanContracts.ReadOnly = true;
            this.dgvLoanContracts.RowHeadersWidth = 30;
            this.dgvLoanContracts.RowTemplate.Height = 30;
            this.dgvLoanContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanContracts.Size = new Size(970, 420);
            this.dgvLoanContracts.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblContractCount);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(970, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // lblContractCount
            // 
            this.lblContractCount.AutoSize = true;
            this.lblContractCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblContractCount.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblContractCount.Location = new Point(0, 40);
            this.lblContractCount.Name = "lblContractCount";
            this.lblContractCount.Size = new Size(120, 19);
            this.lblContractCount.TabIndex = 1;
            this.lblContractCount.Text = "Total Contracts: 0";
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
            this.lblTitle.Text = "Loan Contract Management";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnViewSchedule);
            this.panelButtons.Controls.Add(this.btnExportExcel);
            this.panelButtons.Controls.Add(this.btnExportPdf);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.FillColor = Color.Transparent;
            this.panelButtons.Location = new Point(20, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(960, 80);
            this.panelButtons.TabIndex = 1;
            // 
            // btnAdd
            //
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.FillColor = Color.FromArgb(34, 197, 94);
            this.btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(0, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(150, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "New Contract";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            //
            // btnViewSchedule
            //
            this.btnViewSchedule.BorderRadius = 10;
            this.btnViewSchedule.Cursor = Cursors.Hand;
            this.btnViewSchedule.FillColor = Color.FromArgb(20, 184, 166);
            this.btnViewSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnViewSchedule.ForeColor = Color.White;
            this.btnViewSchedule.Location = new Point(160, 20);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new Size(150, 40);
            this.btnViewSchedule.TabIndex = 1;
            this.btnViewSchedule.Text = "View Schedule";
            this.btnViewSchedule.Click += new EventHandler(this.btnViewSchedule_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FillColor = Color.FromArgb(107, 114, 128);
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(320, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 40);
            this.btnRefresh.TabIndex = 2;
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
            this.btnExportExcel.Location = new Point(320, 20);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new Size(160, 40);
            this.btnExportExcel.TabIndex = 2;
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
            this.btnExportPdf.Location = new Point(490, 20);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new Size(140, 40);
            this.btnExportPdf.TabIndex = 3;
            this.btnExportPdf.Text = "Export PDF";
            this.btnExportPdf.Click += new EventHandler(this.btnExportPdf_Click);
            //
            // btnClose
            //
            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.BorderRadius = 10;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.FillColor = Color.FromArgb(107, 114, 128);
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(820, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(120, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // 
            // LoanContractManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanContractManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Loan Contract Management";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanContracts)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
