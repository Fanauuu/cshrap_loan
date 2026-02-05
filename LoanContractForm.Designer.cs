using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class LoanContractForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelForm;
        private Label lblLC;
        private TextBox txtLC;
        private Label lblCustomer;
        private ComboBox cmbCustomer;
        private Label lblLoanAmount;
        private NumericUpDown numLoanAmount;
        private Label lblLoanTerm;
        private ComboBox cmbLoanTerm;
        private Label lblMonthlyInterest;
        private NumericUpDown numMonthlyInterest;
        private Label lblMonthlyPayment;
        private Label lblLoanDate;
        private DateTimePicker dtpLoanDate;
        private Label lblStartPaymentDate;
        private DateTimePicker dtpStartPaymentDate;
        private Label lblServicePayment;
        private NumericUpDown numServicePayment;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Guna2Panel panelButtons;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Guna2Panel();
            this.panelForm = new Guna2Panel();
            this.cmbStatus = new ComboBox();
            this.lblStatus = new Label();
            this.numServicePayment = new NumericUpDown();
            this.lblServicePayment = new Label();
            this.dtpStartPaymentDate = new DateTimePicker();
            this.lblStartPaymentDate = new Label();
            this.dtpLoanDate = new DateTimePicker();
            this.lblLoanDate = new Label();
            this.lblMonthlyPayment = new Label();
            this.numMonthlyInterest = new NumericUpDown();
            this.lblMonthlyInterest = new Label();
            this.cmbLoanTerm = new ComboBox();
            this.lblLoanTerm = new Label();
            this.numLoanAmount = new NumericUpDown();
            this.lblLoanAmount = new Label();
            this.cmbCustomer = new ComboBox();
            this.lblCustomer = new Label();
            this.txtLC = new TextBox();
            this.lblLC = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnCancel = new Guna2Button();
            this.btnSave = new Guna2Button();
            this.panelMain.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numServicePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthlyInterest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoanAmount)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelForm);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(600, 550);
            this.panelMain.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.cmbStatus);
            this.panelForm.Controls.Add(this.lblStatus);
            this.panelForm.Controls.Add(this.numServicePayment);
            this.panelForm.Controls.Add(this.lblServicePayment);
            this.panelForm.Controls.Add(this.dtpStartPaymentDate);
            this.panelForm.Controls.Add(this.lblStartPaymentDate);
            this.panelForm.Controls.Add(this.dtpLoanDate);
            this.panelForm.Controls.Add(this.lblLoanDate);
            this.panelForm.Controls.Add(this.lblMonthlyPayment);
            this.panelForm.Controls.Add(this.numMonthlyInterest);
            this.panelForm.Controls.Add(this.lblMonthlyInterest);
            this.panelForm.Controls.Add(this.cmbLoanTerm);
            this.panelForm.Controls.Add(this.lblLoanTerm);
            this.panelForm.Controls.Add(this.numLoanAmount);
            this.panelForm.Controls.Add(this.lblLoanAmount);
            this.panelForm.Controls.Add(this.cmbCustomer);
            this.panelForm.Controls.Add(this.lblCustomer);
            this.panelForm.Controls.Add(this.txtLC);
            this.panelForm.Controls.Add(this.lblLC);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.FillColor = Color.White;
            this.panelForm.BorderRadius = 12;
            this.panelForm.Location = new Point(20, 20);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(20);
            this.panelForm.Size = new Size(560, 480);
            this.panelForm.TabIndex = 0;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Closed", "Default" });
            this.cmbStatus.Location = new Point(150, 440);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(390, 25);
            this.cmbStatus.TabIndex = 18;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblStatus.Location = new Point(20, 443);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(54, 19);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Status:";
            // 
            // numServicePayment
            // 
            this.numServicePayment.DecimalPlaces = 2;
            this.numServicePayment.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numServicePayment.Location = new Point(150, 400);
            this.numServicePayment.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numServicePayment.Name = "numServicePayment";
            this.numServicePayment.Size = new Size(390, 25);
            this.numServicePayment.TabIndex = 16;
            // 
            // lblServicePayment
            // 
            this.lblServicePayment.AutoSize = true;
            this.lblServicePayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblServicePayment.Location = new Point(20, 403);
            this.lblServicePayment.Name = "lblServicePayment";
            this.lblServicePayment.Size = new Size(125, 19);
            this.lblServicePayment.TabIndex = 15;
            this.lblServicePayment.Text = "Service Payment:";
            // 
            // dtpStartPaymentDate
            // 
            this.dtpStartPaymentDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpStartPaymentDate.Format = DateTimePickerFormat.Short;
            this.dtpStartPaymentDate.Location = new Point(150, 360);
            this.dtpStartPaymentDate.Name = "dtpStartPaymentDate";
            this.dtpStartPaymentDate.Size = new Size(390, 25);
            this.dtpStartPaymentDate.TabIndex = 14;
            // 
            // lblStartPaymentDate
            // 
            this.lblStartPaymentDate.AutoSize = true;
            this.lblStartPaymentDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblStartPaymentDate.Location = new Point(20, 363);
            this.lblStartPaymentDate.Name = "lblStartPaymentDate";
            this.lblStartPaymentDate.Size = new Size(145, 19);
            this.lblStartPaymentDate.TabIndex = 13;
            this.lblStartPaymentDate.Text = "Start Payment Date:";
            // 
            // dtpLoanDate
            // 
            this.dtpLoanDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpLoanDate.Format = DateTimePickerFormat.Short;
            this.dtpLoanDate.Location = new Point(150, 320);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new Size(390, 25);
            this.dtpLoanDate.TabIndex = 12;
            // 
            // lblLoanDate
            // 
            this.lblLoanDate.AutoSize = true;
            this.lblLoanDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblLoanDate.Location = new Point(20, 323);
            this.lblLoanDate.Name = "lblLoanDate";
            this.lblLoanDate.Size = new Size(78, 19);
            this.lblLoanDate.TabIndex = 11;
            this.lblLoanDate.Text = "Loan Date:";
            // 
            // lblMonthlyPayment
            // 
            this.lblMonthlyPayment.AutoSize = true;
            this.lblMonthlyPayment.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblMonthlyPayment.ForeColor = Color.FromArgb(40, 167, 69);
            this.lblMonthlyPayment.Location = new Point(150, 280);
            this.lblMonthlyPayment.Name = "lblMonthlyPayment";
            this.lblMonthlyPayment.Size = new Size(150, 20);
            this.lblMonthlyPayment.TabIndex = 10;
            this.lblMonthlyPayment.Text = "Monthly Payment: $0";
            // 
            // numMonthlyInterest
            // 
            this.numMonthlyInterest.DecimalPlaces = 4;
            this.numMonthlyInterest.Enabled = false;
            this.numMonthlyInterest.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numMonthlyInterest.Location = new Point(150, 240);
            this.numMonthlyInterest.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numMonthlyInterest.Name = "numMonthlyInterest";
            this.numMonthlyInterest.Size = new Size(390, 25);
            this.numMonthlyInterest.TabIndex = 9;
            // 
            // lblMonthlyInterest
            // 
            this.lblMonthlyInterest.AutoSize = true;
            this.lblMonthlyInterest.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblMonthlyInterest.Location = new Point(20, 243);
            this.lblMonthlyInterest.Name = "lblMonthlyInterest";
            this.lblMonthlyInterest.Size = new Size(125, 19);
            this.lblMonthlyInterest.TabIndex = 8;
            this.lblMonthlyInterest.Text = "Monthly Rate (%):";
            // 
            // cmbLoanTerm
            // 
            this.cmbLoanTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLoanTerm.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbLoanTerm.FormattingEnabled = true;
            this.cmbLoanTerm.Location = new Point(150, 200);
            this.cmbLoanTerm.Name = "cmbLoanTerm";
            this.cmbLoanTerm.Size = new Size(390, 25);
            this.cmbLoanTerm.TabIndex = 7;
            this.cmbLoanTerm.SelectedIndexChanged += new EventHandler(this.cmbLoanTerm_SelectedIndexChanged);
            // 
            // lblLoanTerm
            // 
            this.lblLoanTerm.AutoSize = true;
            this.lblLoanTerm.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblLoanTerm.Location = new Point(20, 203);
            this.lblLoanTerm.Name = "lblLoanTerm";
            this.lblLoanTerm.Size = new Size(81, 19);
            this.lblLoanTerm.TabIndex = 6;
            this.lblLoanTerm.Text = "Loan Term:";
            // 
            // numLoanAmount
            // 
            this.numLoanAmount.DecimalPlaces = 2;
            this.numLoanAmount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numLoanAmount.Location = new Point(150, 160);
            this.numLoanAmount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numLoanAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numLoanAmount.Name = "numLoanAmount";
            this.numLoanAmount.Size = new Size(390, 25);
            this.numLoanAmount.TabIndex = 5;
            this.numLoanAmount.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numLoanAmount.ValueChanged += new EventHandler(this.numLoanAmount_ValueChanged);
            // 
            // lblLoanAmount
            // 
            this.lblLoanAmount.AutoSize = true;
            this.lblLoanAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblLoanAmount.Location = new Point(20, 163);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new Size(102, 19);
            this.lblLoanAmount.TabIndex = 4;
            this.lblLoanAmount.Text = "Loan Amount:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new Point(150, 120);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new Size(390, 25);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblCustomer.Location = new Point(20, 123);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new Size(75, 19);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer:";
            // 
            // txtLC
            // 
            this.txtLC.Enabled = false;
            this.txtLC.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtLC.Location = new Point(150, 80);
            this.txtLC.Name = "txtLC";
            this.txtLC.Size = new Size(390, 25);
            this.txtLC.TabIndex = 1;
            // 
            // lblLC
            // 
            this.lblLC.AutoSize = true;
            this.lblLC.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblLC.Location = new Point(20, 83);
            this.lblLC.Name = "lblLC";
            this.lblLC.Size = new Size(30, 19);
            this.lblLC.TabIndex = 0;
            this.lblLC.Text = "LC:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(560, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnCancel
            //
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.FillColor = Color.FromArgb(107, 114, 128);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(300, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(120, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            //
            // btnSave
            //
            this.btnSave.BorderRadius = 10;
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.FillColor = Color.FromArgb(34, 197, 94);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(150, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(120, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // LoanContractForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(600, 550);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanContractForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Loan Contract Form";
            this.panelMain.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numServicePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthlyInterest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoanAmount)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
