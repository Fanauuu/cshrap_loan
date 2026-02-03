namespace WinFormsApp1
{
    partial class CustomerManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblCustomerCount;
        private DataGridView dgvCustomers;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnClearSearch;
        private Label lblSearch;
        private Panel panelButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnViewDetails;
        private Button btnRefresh;
        private Button btnClose;

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
            this.dgvCustomers = new DataGridView();
            this.panelSearch = new Panel();
            this.btnClearSearch = new Button();
            this.txtSearch = new TextBox();
            this.lblSearch = new Label();
            this.panelHeader = new Panel();
            this.lblCustomerCount = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnViewDetails = new Button();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvCustomers);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(15);
            this.panelMain.Size = new Size(1100, 600);
            this.panelMain.TabIndex = 0;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dgvCustomers.BackgroundColor = Color.White;
            this.dgvCustomers.BorderStyle = BorderStyle.None;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = DockStyle.Fill;
            this.dgvCustomers.GridColor = Color.FromArgb(240, 240, 240);
            this.dgvCustomers.Location = new Point(15, 140);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidth = 30;
            this.dgvCustomers.RowTemplate.Height = 30;
            this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new Size(1070, 360);
            this.dgvCustomers.TabIndex = 3;
            this.dgvCustomers.DoubleClick += new EventHandler(this.dgvCustomers_DoubleClick);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnClearSearch);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = DockStyle.Top;
            this.panelSearch.Location = new Point(15, 80);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new Size(1070, 60);
            this.panelSearch.TabIndex = 2;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = Color.FromArgb(108, 117, 125);
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = FlatStyle.Flat;
            this.btnClearSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnClearSearch.ForeColor = Color.White;
            this.btnClearSearch.Location = new Point(350, 15);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new Size(80, 30);
            this.btnClearSearch.TabIndex = 2;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new EventHandler(this.btnClearSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtSearch.Location = new Point(80, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search by name or CID...";
            this.txtSearch.Size = new Size(260, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblSearch.Location = new Point(0, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new Size(58, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblCustomerCount);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1070, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // lblCustomerCount
            // 
            this.lblCustomerCount.AutoSize = true;
            this.lblCustomerCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblCustomerCount.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblCustomerCount.Location = new Point(0, 40);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new Size(120, 19);
            this.lblCustomerCount.TabIndex = 1;
            this.lblCustomerCount.Text = "Total Customers: 0";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(268, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Customer Management";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnViewDetails);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(15, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(1070, 85);
            this.panelButtons.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(0, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(120, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = Color.FromArgb(0, 123, 255);
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(130, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(120, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏️ Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(260, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(120, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = Color.FromArgb(23, 162, 184);
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatStyle = FlatStyle.Flat;
            this.btnViewDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnViewDetails.ForeColor = Color.White;
            this.btnViewDetails.Location = new Point(390, 10);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new Size(150, 35);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "👁️ View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(550, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 35);
            this.btnRefresh.TabIndex = 4;
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
            this.btnClose.Location = new Point(950, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(120, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // 
            // CustomerManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(1100, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Customer Management";
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
