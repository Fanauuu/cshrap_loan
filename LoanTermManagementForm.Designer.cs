using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class LoanTermManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Label lblTermCount;
        private DataGridView dgvLoanTerms;
        private Guna2Panel panelButtons;
        private Guna2Button btnAdd;
        private Guna2Button btnEdit;
        private Guna2Button btnDelete;
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
            this.dgvLoanTerms = new DataGridView();
            this.panelHeader = new Guna2Panel();
            this.lblTermCount = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnAdd = new Guna2Button();
            this.btnEdit = new Guna2Button();
            this.btnDelete = new Guna2Button();
            this.btnRefresh = new Guna2Button();
            this.btnExportExcel = new Guna2Button();
            this.btnExportPdf = new Guna2Button();
            this.btnClose = new Guna2Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanTerms)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvLoanTerms);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(900, 500);
            this.panelMain.TabIndex = 0;
            // 
            // dgvLoanTerms
            // 
            this.dgvLoanTerms.AllowUserToAddRows = false;
            this.dgvLoanTerms.AllowUserToDeleteRows = false;
            this.dgvLoanTerms.BackgroundColor = Color.White;
            this.dgvLoanTerms.BorderStyle = BorderStyle.None;
            this.dgvLoanTerms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanTerms.Dock = DockStyle.Fill;
            this.dgvLoanTerms.Location = new Point(15, 80);
            this.dgvLoanTerms.MultiSelect = false;
            this.dgvLoanTerms.Name = "dgvLoanTerms";
            this.dgvLoanTerms.ReadOnly = true;
            this.dgvLoanTerms.RowHeadersWidth = 30;
            this.dgvLoanTerms.RowTemplate.Height = 30;
            this.dgvLoanTerms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanTerms.Size = new Size(870, 320);
            this.dgvLoanTerms.TabIndex = 2;
            this.dgvLoanTerms.DoubleClick += new EventHandler(this.dgvLoanTerms_DoubleClick);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTermCount);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(870, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTermCount
            // 
            this.lblTermCount.AutoSize = true;
            this.lblTermCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTermCount.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblTermCount.Location = new Point(0, 40);
            this.lblTermCount.Name = "lblTermCount";
            this.lblTermCount.Size = new Size(130, 19);
            this.lblTermCount.TabIndex = 1;
            this.lblTermCount.Text = "Total Loan Terms: 0";
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
            this.lblTitle.Text = "Loan Term Management";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnExportExcel);
            this.panelButtons.Controls.Add(this.btnExportPdf);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(15, 400);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(870, 85);
            this.panelButtons.TabIndex = 1;
            // 
            // btnAdd
            //
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.FillColor = Color.FromArgb(34, 197, 94);
            this.btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(0, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(120, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            //
            // btnEdit
            //
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.FillColor = Color.FromArgb(59, 130, 246);
            this.btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(130, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(120, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.FillColor = Color.FromArgb(239, 68, 68);
            this.btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(260, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(120, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FillColor = Color.FromArgb(107, 114, 128);
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(390, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 40);
            this.btnRefresh.TabIndex = 3;
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
            this.btnExportExcel.Location = new Point(390, 15);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new Size(150, 40);
            this.btnExportExcel.TabIndex = 3;
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
            this.btnExportPdf.Location = new Point(550, 15);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new Size(120, 40);
            this.btnExportPdf.TabIndex = 4;
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
            this.btnClose.Location = new Point(730, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(120, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // 
            // LoanTermManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(900, 500);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanTermManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Loan Term Management";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanTerms)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
