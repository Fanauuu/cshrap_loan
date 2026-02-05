using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class CustomerDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelCustomerInfo;
        private Label lblTitle;
        private Label lblCustomerName;
        private Label lblCID;
        private Label lblGender;
        private Label lblDateOfBirth;
        private Label lblAge;
        private Label lblPlaceOfBirth;
        private Label lblAddress;
        private Label lblStatus;
        private Guna2Panel panelLoanSummary;
        private Label lblLoanCount;
        private Label lblTotalLoanAmount;
        private Label lblActiveLoans;
        private DataGridView dgvLoanContracts;
        private Guna2Panel panelButtons;
        private Guna2Button btnViewSchedule;
        private Guna2Button btnRefresh;
        private Guna2Button btnExportExcel;
        private Guna2Button btnExportPdf;
        private Guna2Button btnClose;

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
            this.panelMain = new Guna2Panel();
            this.dgvLoanContracts = new DataGridView();
            this.panelLoanSummary = new Guna2Panel();
            this.lblActiveLoans = new Label();
            this.lblTotalLoanAmount = new Label();
            this.lblLoanCount = new Label();
            this.panelCustomerInfo = new Guna2Panel();
            this.lblStatus = new Label();
            this.lblAddress = new Label();
            this.lblPlaceOfBirth = new Label();
            this.lblAge = new Label();
            this.lblDateOfBirth = new Label();
            this.lblGender = new Label();
            this.lblCID = new Label();
            this.lblCustomerName = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnViewSchedule = new Guna2Button();
            this.btnRefresh = new Guna2Button();
            this.btnExportExcel = new Guna2Button();
            this.btnExportPdf = new Guna2Button();
            this.btnClose = new Guna2Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanContracts)).BeginInit();
            this.panelLoanSummary.SuspendLayout();
            this.panelCustomerInfo.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvLoanContracts);
            this.panelMain.Controls.Add(this.panelLoanSummary);
            this.panelMain.Controls.Add(this.panelCustomerInfo);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(1000, 700);
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
            this.dgvLoanContracts.Location = new Point(15, 280);
            this.dgvLoanContracts.MultiSelect = false;
            this.dgvLoanContracts.Name = "dgvLoanContracts";
            this.dgvLoanContracts.ReadOnly = true;
            this.dgvLoanContracts.RowHeadersWidth = 30;
            this.dgvLoanContracts.RowTemplate.Height = 30;
            this.dgvLoanContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanContracts.Size = new Size(970, 320);
            this.dgvLoanContracts.TabIndex = 3;
            this.dgvLoanContracts.DoubleClick += new EventHandler(this.dgvLoanContracts_DoubleClick);
            // 
            // panelLoanSummary
            // 
            this.panelLoanSummary.Controls.Add(this.lblActiveLoans);
            this.panelLoanSummary.Controls.Add(this.lblTotalLoanAmount);
            this.panelLoanSummary.Controls.Add(this.lblLoanCount);
            this.panelLoanSummary.Dock = DockStyle.Top;
            this.panelLoanSummary.Location = new Point(15, 220);
            this.panelLoanSummary.Name = "panelLoanSummary";
            this.panelLoanSummary.Size = new Size(970, 60);
            this.panelLoanSummary.TabIndex = 2;
            // 
            // lblActiveLoans
            // 
            this.lblActiveLoans.AutoSize = true;
            this.lblActiveLoans.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblActiveLoans.ForeColor = Color.FromArgb(40, 167, 69);
            this.lblActiveLoans.Location = new Point(400, 20);
            this.lblActiveLoans.Name = "lblActiveLoans";
            this.lblActiveLoans.Size = new Size(100, 19);
            this.lblActiveLoans.TabIndex = 2;
            this.lblActiveLoans.Text = "Active Loans: 0";
            // 
            // lblTotalLoanAmount
            // 
            this.lblTotalLoanAmount.AutoSize = true;
            this.lblTotalLoanAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotalLoanAmount.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblTotalLoanAmount.Location = new Point(200, 20);
            this.lblTotalLoanAmount.Name = "lblTotalLoanAmount";
            this.lblTotalLoanAmount.Size = new Size(150, 19);
            this.lblTotalLoanAmount.TabIndex = 1;
            this.lblTotalLoanAmount.Text = "Total Loan Amount: $0";
            // 
            // lblLoanCount
            // 
            this.lblLoanCount.AutoSize = true;
            this.lblLoanCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblLoanCount.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblLoanCount.Location = new Point(0, 20);
            this.lblLoanCount.Name = "lblLoanCount";
            this.lblLoanCount.Size = new Size(100, 19);
            this.lblLoanCount.TabIndex = 0;
            this.lblLoanCount.Text = "Total Loans: 0";
            // 
            // panelCustomerInfo
            // 
            this.panelCustomerInfo.Controls.Add(this.lblStatus);
            this.panelCustomerInfo.Controls.Add(this.lblAddress);
            this.panelCustomerInfo.Controls.Add(this.lblPlaceOfBirth);
            this.panelCustomerInfo.Controls.Add(this.lblAge);
            this.panelCustomerInfo.Controls.Add(this.lblDateOfBirth);
            this.panelCustomerInfo.Controls.Add(this.lblGender);
            this.panelCustomerInfo.Controls.Add(this.lblCID);
            this.panelCustomerInfo.Controls.Add(this.lblCustomerName);
            this.panelCustomerInfo.Controls.Add(this.lblTitle);
            this.panelCustomerInfo.Dock = DockStyle.Top;
            this.panelCustomerInfo.Location = new Point(15, 15);
            this.panelCustomerInfo.Name = "panelCustomerInfo";
            this.panelCustomerInfo.Size = new Size(970, 205);
            this.panelCustomerInfo.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblStatus.Location = new Point(500, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(60, 19);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status: ";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblAddress.Location = new Point(0, 180);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new Size(70, 19);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Address: ";
            // 
            // lblPlaceOfBirth
            // 
            this.lblPlaceOfBirth.AutoSize = true;
            this.lblPlaceOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblPlaceOfBirth.Location = new Point(500, 80);
            this.lblPlaceOfBirth.Name = "lblPlaceOfBirth";
            this.lblPlaceOfBirth.Size = new Size(100, 19);
            this.lblPlaceOfBirth.TabIndex = 6;
            this.lblPlaceOfBirth.Text = "Place of Birth: ";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblAge.Location = new Point(500, 40);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new Size(45, 19);
            this.lblAge.TabIndex = 5;
            this.lblAge.Text = "Age: ";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblDateOfBirth.Location = new Point(0, 120);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new Size(95, 19);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "Date of Birth: ";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblGender.Location = new Point(0, 80);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new Size(62, 19);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Gender: ";
            // 
            // lblCID
            // 
            this.lblCID.AutoSize = true;
            this.lblCID.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblCID.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblCID.Location = new Point(0, 40);
            this.lblCID.Name = "lblCID";
            this.lblCID.Size = new Size(40, 19);
            this.lblCID.TabIndex = 2;
            this.lblCID.Text = "CID: ";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblCustomerName.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblCustomerName.Location = new Point(0, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new Size(150, 30);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(0, 32);
            this.lblTitle.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnViewSchedule);
            this.panelButtons.Controls.Add(this.btnExportExcel);
            this.panelButtons.Controls.Add(this.btnExportPdf);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(15, 600);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(970, 85);
            this.panelButtons.TabIndex = 0;
            // 
            // btnViewSchedule
            //
            this.btnViewSchedule.BorderRadius = 10;
            this.btnViewSchedule.Cursor = Cursors.Hand;
            this.btnViewSchedule.FillColor = Color.FromArgb(20, 184, 166);
            this.btnViewSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnViewSchedule.ForeColor = Color.White;
            this.btnViewSchedule.Location = new Point(0, 15);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new Size(150, 40);
            this.btnViewSchedule.TabIndex = 0;
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
            this.btnClose.Location = new Point(850, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(120, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // 
            // CustomerDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDetailForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Customer Details";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanContracts)).EndInit();
            this.panelLoanSummary.ResumeLayout(false);
            this.panelLoanSummary.PerformLayout();
            this.panelCustomerInfo.ResumeLayout(false);
            this.panelCustomerInfo.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
