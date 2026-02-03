namespace WinFormsApp1
{
    partial class LoanContractManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblContractCount;
        private DataGridView dgvLoanContracts;
        private Panel panelButtons;
        private Button btnAdd;
        private Button btnViewSchedule;
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
            this.dgvLoanContracts = new DataGridView();
            this.panelHeader = new Panel();
            this.lblContractCount = new Label();
            this.lblTitle = new Label();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnViewSchedule = new Button();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
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
            this.panelMain.Padding = new Padding(15);
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
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(15, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(970, 85);
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
            this.btnAdd.Size = new Size(150, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ New Contract";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.BackColor = Color.FromArgb(23, 162, 184);
            this.btnViewSchedule.FlatAppearance.BorderSize = 0;
            this.btnViewSchedule.FlatStyle = FlatStyle.Flat;
            this.btnViewSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnViewSchedule.ForeColor = Color.White;
            this.btnViewSchedule.Location = new Point(160, 10);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new Size(150, 35);
            this.btnViewSchedule.TabIndex = 1;
            this.btnViewSchedule.Text = "💰 View Schedule";
            this.btnViewSchedule.UseVisualStyleBackColor = false;
            this.btnViewSchedule.Click += new EventHandler(this.btnViewSchedule_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(320, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(120, 35);
            this.btnRefresh.TabIndex = 2;
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
            this.btnClose.Location = new Point(850, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(120, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
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
