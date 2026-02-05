using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class CustomerManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelSidebar;
        private Guna2Panel panelMain;
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Label lblCustomerCount;
        private DataGridView dgvCustomers;
        private Guna2Panel panelSearch;
        private Guna2TextBox txtSearch;
        private Guna2Button btnClearSearch;
        private Label lblSearch;
        private Guna2Panel panelButtons;
        private Guna2Button btnAdd;
        private Guna2Button btnEdit;
        private Guna2Button btnDelete;
        private Guna2Button btnViewDetails;
        private Guna2Button btnRefresh;
        private Guna2Button btnExportExcel;
        private Guna2Button btnExportPdf;
        private Guna2Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new Guna2Panel();
            this.panelMain = new Guna2Panel();
            this.dgvCustomers = new DataGridView();
            this.panelSearch = new Guna2Panel();
            this.btnClearSearch = new Guna2Button();
            this.txtSearch = new Guna2TextBox();
            this.lblSearch = new Label();
            this.panelHeader = new Guna2Panel();
            this.lblCustomerCount = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnAdd = new Guna2Button();
            this.btnEdit = new Guna2Button();
            this.btnDelete = new Guna2Button();
            this.btnViewDetails = new Guna2Button();
            this.btnRefresh = new Guna2Button();
            this.btnExportExcel = new Guna2Button();
            this.btnExportPdf = new Guna2Button();
            this.btnClose = new Guna2Button();
            this.panelSidebar.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // panelSidebar
            //
            this.panelSidebar.Controls.Add(this.btnClose);
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.FillColor = Color.White;
            this.panelSidebar.Location = new Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new Padding(20, 30, 20, 20);
            this.panelSidebar.ShadowDecoration.Depth = 8;
            this.panelSidebar.ShadowDecoration.Enabled = true;
            this.panelSidebar.ShadowDecoration.Color = Color.FromArgb(180, 180, 180);
            this.panelSidebar.Size = new Size(220, 600);
            this.panelSidebar.TabIndex = 0;
            //
            // btnClose
            //
            this.btnClose.BorderRadius = 10;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Dock = DockStyle.Bottom;
            this.btnClose.FillColor = Color.FromArgb(107, 114, 128);
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(20, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(180, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✕ Close";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            //
            // panelMain
            //
            this.panelMain.Controls.Add(this.dgvCustomers);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Location = new Point(220, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(25);
            this.panelMain.Size = new Size(880, 600);
            this.panelMain.TabIndex = 1;
            //
            // dgvCustomers
            //
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dgvCustomers.BackgroundColor = Color.White;
            this.dgvCustomers.BorderStyle = BorderStyle.None;
            this.dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvCustomers.ColumnHeadersHeight = 45;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(31, 41, 55),
                Font = new Font("Segoe UI", 10F),
                Padding = new Padding(5),
                SelectionBackColor = Color.FromArgb(243, 244, 246),
                SelectionForeColor = Color.FromArgb(31, 41, 55)
            };
            this.dgvCustomers.Dock = DockStyle.Fill;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.GridColor = Color.FromArgb(229, 231, 235);
            this.dgvCustomers.Location = new Point(25, 145);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvCustomers.RowHeadersWidth = 40;
            this.dgvCustomers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomers.RowTemplate.Height = 42;
            this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new Size(830, 330);
            this.dgvCustomers.TabIndex = 3;
            this.dgvCustomers.DoubleClick += new EventHandler(this.dgvCustomers_DoubleClick);
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(75, 85, 99),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Padding = new Padding(5),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            //
            // panelSearch
            //
            this.panelSearch.Controls.Add(this.btnClearSearch);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = DockStyle.Top;
            this.panelSearch.FillColor = Color.Transparent;
            this.panelSearch.Location = new Point(25, 85);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new Size(830, 60);
            this.panelSearch.TabIndex = 2;
            //
            // btnClearSearch
            //
            this.btnClearSearch.BorderRadius = 8;
            this.btnClearSearch.Cursor = Cursors.Hand;
            this.btnClearSearch.FillColor = Color.FromArgb(107, 114, 128);
            this.btnClearSearch.Font = new Font("Segoe UI", 9F);
            this.btnClearSearch.ForeColor = Color.White;
            this.btnClearSearch.Location = new Point(350, 12);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new Size(90, 36);
            this.btnClearSearch.TabIndex = 2;
            this.btnClearSearch.Text = "✕ Clear";
            this.btnClearSearch.Click += new EventHandler(this.btnClearSearch_Click);
            //
            // txtSearch
            //
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = Color.White;
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(100, 12);
            this.txtSearch.Margin = new Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search by name or CID...";
            this.txtSearch.Size = new Size(240, 36);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblSearch.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblSearch.Location = new Point(0, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new Size(90, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "🔍 Search:";
            //
            // panelHeader
            //
            this.panelHeader.Controls.Add(this.lblCustomerCount);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.FillColor = Color.Transparent;
            this.panelHeader.Location = new Point(25, 25);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(830, 60);
            this.panelHeader.TabIndex = 0;
            //
            // lblCustomerCount
            //
            this.lblCustomerCount.AutoSize = true;
            this.lblCustomerCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblCustomerCount.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblCustomerCount.Location = new Point(0, 35);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new Size(120, 19);
            this.lblCustomerCount.TabIndex = 1;
            this.lblCustomerCount.Text = "📊 Total: 0";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(320, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👥 Customer Management";
            //
            // panelButtons
            //
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnViewDetails);
            this.panelButtons.Controls.Add(this.btnExportExcel);
            this.panelButtons.Controls.Add(this.btnExportPdf);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.FillColor = Color.Transparent;
            this.panelButtons.Location = new Point(25, 475);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(830, 100);
            this.panelButtons.TabIndex = 1;
            //
            // btnAdd
            //
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.FillColor = Color.FromArgb(34, 197, 94);
            this.btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(0, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(120, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            //
            // btnEdit
            //
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.FillColor = Color.FromArgb(59, 130, 246);
            this.btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(130, 30);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(120, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏️ Edit";
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.FillColor = Color.FromArgb(239, 68, 68);
            this.btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(260, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(120, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            //
            // btnViewDetails
            //
            this.btnViewDetails.BorderRadius = 10;
            this.btnViewDetails.Cursor = Cursors.Hand;
            this.btnViewDetails.FillColor = Color.FromArgb(20, 184, 166);
            this.btnViewDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnViewDetails.ForeColor = Color.White;
            this.btnViewDetails.Location = new Point(390, 30);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new Size(140, 40);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "👁️ View Details";
            this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FillColor = Color.FromArgb(107, 114, 128);
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(540, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "🔄 Refresh";
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
            this.btnExportExcel.Location = new Point(540, 30);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new Size(140, 40);
            this.btnExportExcel.TabIndex = 4;
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
            this.btnExportPdf.Location = new Point(690, 30);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new Size(120, 40);
            this.btnExportPdf.TabIndex = 5;
            this.btnExportPdf.Text = "Export PDF";
            this.btnExportPdf.Click += new EventHandler(this.btnExportPdf_Click);
            //
            // CustomerManagementForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.ClientSize = new Size(1100, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Customer Management";
            this.panelSidebar.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
