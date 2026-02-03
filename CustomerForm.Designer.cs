namespace WinFormsApp1
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMain;
        private Panel panelForm;
        private Label lblCID;
        private TextBox txtCID;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblGender;
        private ComboBox cmbGender;
        private Label lblPlaceOfBirth;
        private TextBox txtPlaceOfBirth;
        private Label lblDateOfBirth;
        private DateTimePicker dtpDateOfBirth;
        private Label lblCurrentAddress;
        private TextBox txtCurrentAddress;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;

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
            this.panelForm = new Panel();
            this.cmbStatus = new ComboBox();
            this.lblStatus = new Label();
            this.txtCurrentAddress = new TextBox();
            this.lblCurrentAddress = new Label();
            this.dtpDateOfBirth = new DateTimePicker();
            this.lblDateOfBirth = new Label();
            this.txtPlaceOfBirth = new TextBox();
            this.lblPlaceOfBirth = new Label();
            this.cmbGender = new ComboBox();
            this.lblGender = new Label();
            this.txtLastName = new TextBox();
            this.lblLastName = new Label();
            this.txtFirstName = new TextBox();
            this.lblFirstName = new Label();
            this.txtCID = new TextBox();
            this.lblCID = new Label();
            this.panelButtons = new Panel();
            this.btnCancel = new Button();
            this.btnSave = new Button();
            this.panelMain.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelForm);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(600, 500);
            this.panelMain.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.cmbStatus);
            this.panelForm.Controls.Add(this.lblStatus);
            this.panelForm.Controls.Add(this.txtCurrentAddress);
            this.panelForm.Controls.Add(this.lblCurrentAddress);
            this.panelForm.Controls.Add(this.dtpDateOfBirth);
            this.panelForm.Controls.Add(this.lblDateOfBirth);
            this.panelForm.Controls.Add(this.txtPlaceOfBirth);
            this.panelForm.Controls.Add(this.lblPlaceOfBirth);
            this.panelForm.Controls.Add(this.cmbGender);
            this.panelForm.Controls.Add(this.lblGender);
            this.panelForm.Controls.Add(this.txtLastName);
            this.panelForm.Controls.Add(this.lblLastName);
            this.panelForm.Controls.Add(this.txtFirstName);
            this.panelForm.Controls.Add(this.lblFirstName);
            this.panelForm.Controls.Add(this.txtCID);
            this.panelForm.Controls.Add(this.lblCID);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.Location = new Point(20, 20);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new Size(560, 410);
            this.panelForm.TabIndex = 0;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new Point(150, 360);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(390, 25);
            this.cmbStatus.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblStatus.Location = new Point(20, 363);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(54, 19);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status:";
            // 
            // txtCurrentAddress
            // 
            this.txtCurrentAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtCurrentAddress.Location = new Point(150, 280);
            this.txtCurrentAddress.Multiline = true;
            this.txtCurrentAddress.Name = "txtCurrentAddress";
            this.txtCurrentAddress.Size = new Size(390, 60);
            this.txtCurrentAddress.TabIndex = 13;
            // 
            // lblCurrentAddress
            // 
            this.lblCurrentAddress.AutoSize = true;
            this.lblCurrentAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblCurrentAddress.Location = new Point(20, 283);
            this.lblCurrentAddress.Name = "lblCurrentAddress";
            this.lblCurrentAddress.Size = new Size(120, 19);
            this.lblCurrentAddress.TabIndex = 12;
            this.lblCurrentAddress.Text = "Current Address:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new Point(150, 240);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new Size(390, 25);
            this.dtpDateOfBirth.TabIndex = 11;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblDateOfBirth.Location = new Point(20, 243);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new Size(95, 19);
            this.lblDateOfBirth.TabIndex = 10;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // txtPlaceOfBirth
            // 
            this.txtPlaceOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtPlaceOfBirth.Location = new Point(150, 200);
            this.txtPlaceOfBirth.Name = "txtPlaceOfBirth";
            this.txtPlaceOfBirth.Size = new Size(390, 25);
            this.txtPlaceOfBirth.TabIndex = 9;
            // 
            // lblPlaceOfBirth
            // 
            this.lblPlaceOfBirth.AutoSize = true;
            this.lblPlaceOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblPlaceOfBirth.Location = new Point(20, 203);
            this.lblPlaceOfBirth.Name = "lblPlaceOfBirth";
            this.lblPlaceOfBirth.Size = new Size(100, 19);
            this.lblPlaceOfBirth.TabIndex = 8;
            this.lblPlaceOfBirth.Text = "Place of Birth:";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new Point(150, 160);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new Size(390, 25);
            this.cmbGender.TabIndex = 7;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblGender.Location = new Point(20, 163);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new Size(62, 19);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Gender:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtLastName.Location = new Point(150, 120);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(390, 25);
            this.txtLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblLastName.Location = new Point(20, 123);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(79, 19);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtFirstName.Location = new Point(150, 80);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(390, 25);
            this.txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblFirstName.Location = new Point(20, 83);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(81, 19);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtCID
            // 
            this.txtCID.Enabled = false;
            this.txtCID.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtCID.Location = new Point(150, 40);
            this.txtCID.Name = "txtCID";
            this.txtCID.Size = new Size(390, 25);
            this.txtCID.TabIndex = 1;
            // 
            // lblCID
            // 
            this.lblCID.AutoSize = true;
            this.lblCID.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblCID.Location = new Point(20, 43);
            this.lblCID.Name = "lblCID";
            this.lblCID.Size = new Size(38, 19);
            this.lblCID.TabIndex = 0;
            this.lblCID.Text = "CID:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 430);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(560, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(300, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(120, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = Color.FromArgb(40, 167, 69);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(150, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(120, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(600, 500);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Customer Form";
            this.panelMain.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
