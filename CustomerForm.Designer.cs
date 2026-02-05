using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelForm;
        private Label lblCID;
        private Guna2TextBox txtCID;
        private Label lblFirstName;
        private Guna2TextBox txtFirstName;
        private Label lblLastName;
        private Guna2TextBox txtLastName;
        private Label lblGender;
        private Guna2ComboBox cmbGender;
        private Label lblPlaceOfBirth;
        private Guna2TextBox txtPlaceOfBirth;
        private Label lblDateOfBirth;
        private Guna2DateTimePicker dtpDateOfBirth;
        private Label lblCurrentAddress;
        private Guna2TextBox txtCurrentAddress;
        private Label lblStatus;
        private Guna2ComboBox cmbStatus;
        private Guna2Panel panelButtons;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Guna2Panel();
            this.panelForm = new Guna2Panel();
            this.cmbStatus = new Guna2ComboBox();
            this.lblStatus = new Label();
            this.txtCurrentAddress = new Guna2TextBox();
            this.lblCurrentAddress = new Label();
            this.dtpDateOfBirth = new Guna2DateTimePicker();
            this.lblDateOfBirth = new Label();
            this.txtPlaceOfBirth = new Guna2TextBox();
            this.lblPlaceOfBirth = new Label();
            this.cmbGender = new Guna2ComboBox();
            this.lblGender = new Label();
            this.txtLastName = new Guna2TextBox();
            this.lblLastName = new Label();
            this.txtFirstName = new Guna2TextBox();
            this.lblFirstName = new Label();
            this.txtCID = new Guna2TextBox();
            this.lblCID = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnCancel = new Guna2Button();
            this.btnSave = new Guna2Button();
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
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(24);
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
            this.panelForm.FillColor = Color.White;
            this.panelForm.Location = new Point(24, 24);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(20);
            this.panelForm.Size = new Size(552, 412);
            this.panelForm.TabIndex = 0;
            this.panelForm.BorderRadius = 12;
            //
            // cmbStatus
            //
            this.cmbStatus.BackColor = Color.Transparent;
            this.cmbStatus.BorderRadius = 8;
            this.cmbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FillColor = Color.FromArgb(249, 250, 251);
            this.cmbStatus.FocusedColor = Color.FromArgb(59, 130, 246);
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new Point(150, 358);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(382, 36);
            this.cmbStatus.TabIndex = 15;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStatus.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblStatus.Location = new Point(20, 366);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(54, 19);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status:";
            //
            // txtCurrentAddress
            //
            this.txtCurrentAddress.BorderRadius = 8;
            this.txtCurrentAddress.Cursor = Cursors.IBeam;
            this.txtCurrentAddress.DefaultText = "";
            this.txtCurrentAddress.FillColor = Color.FromArgb(249, 250, 251);
            this.txtCurrentAddress.Font = new Font("Segoe UI", 10F);
            this.txtCurrentAddress.Location = new Point(150, 278);
            this.txtCurrentAddress.Multiline = true;
            this.txtCurrentAddress.Name = "txtCurrentAddress";
            this.txtCurrentAddress.Size = new Size(382, 64);
            this.txtCurrentAddress.TabIndex = 13;
            //
            // lblCurrentAddress
            //
            this.lblCurrentAddress.AutoSize = true;
            this.lblCurrentAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCurrentAddress.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblCurrentAddress.Location = new Point(20, 281);
            this.lblCurrentAddress.Name = "lblCurrentAddress";
            this.lblCurrentAddress.Size = new Size(120, 19);
            this.lblCurrentAddress.TabIndex = 12;
            this.lblCurrentAddress.Text = "Current Address:";
            //
            // dtpDateOfBirth
            //
            this.dtpDateOfBirth.BorderRadius = 8;
            this.dtpDateOfBirth.Checked = true;
            this.dtpDateOfBirth.FillColor = Color.FromArgb(249, 250, 251);
            this.dtpDateOfBirth.Font = new Font("Segoe UI", 10F);
            this.dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new Point(150, 238);
            this.dtpDateOfBirth.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new Size(382, 36);
            this.dtpDateOfBirth.TabIndex = 11;
            //
            // lblDateOfBirth
            //
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDateOfBirth.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblDateOfBirth.Location = new Point(20, 241);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new Size(95, 19);
            this.lblDateOfBirth.TabIndex = 10;
            this.lblDateOfBirth.Text = "Date of Birth:";
            //
            // txtPlaceOfBirth
            //
            this.txtPlaceOfBirth.BorderRadius = 8;
            this.txtPlaceOfBirth.Cursor = Cursors.IBeam;
            this.txtPlaceOfBirth.DefaultText = "";
            this.txtPlaceOfBirth.FillColor = Color.FromArgb(249, 250, 251);
            this.txtPlaceOfBirth.Font = new Font("Segoe UI", 10F);
            this.txtPlaceOfBirth.Location = new Point(150, 198);
            this.txtPlaceOfBirth.Name = "txtPlaceOfBirth";
            this.txtPlaceOfBirth.Size = new Size(382, 36);
            this.txtPlaceOfBirth.TabIndex = 9;
            //
            // lblPlaceOfBirth
            //
            this.lblPlaceOfBirth.AutoSize = true;
            this.lblPlaceOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPlaceOfBirth.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblPlaceOfBirth.Location = new Point(20, 201);
            this.lblPlaceOfBirth.Name = "lblPlaceOfBirth";
            this.lblPlaceOfBirth.Size = new Size(100, 19);
            this.lblPlaceOfBirth.TabIndex = 8;
            this.lblPlaceOfBirth.Text = "Place of Birth:";
            //
            // cmbGender
            //
            this.cmbGender.BackColor = Color.Transparent;
            this.cmbGender.BorderRadius = 8;
            this.cmbGender.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGender.FillColor = Color.FromArgb(249, 250, 251);
            this.cmbGender.FocusedColor = Color.FromArgb(59, 130, 246);
            this.cmbGender.Font = new Font("Segoe UI", 10F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new Point(150, 158);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new Size(382, 36);
            this.cmbGender.TabIndex = 7;
            //
            // lblGender
            //
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblGender.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblGender.Location = new Point(20, 161);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new Size(62, 19);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Gender:";
            //
            // txtLastName
            //
            this.txtLastName.BorderRadius = 8;
            this.txtLastName.Cursor = Cursors.IBeam;
            this.txtLastName.DefaultText = "";
            this.txtLastName.FillColor = Color.FromArgb(249, 250, 251);
            this.txtLastName.Font = new Font("Segoe UI", 10F);
            this.txtLastName.Location = new Point(150, 118);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(382, 36);
            this.txtLastName.TabIndex = 5;
            //
            // lblLastName
            //
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblLastName.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblLastName.Location = new Point(20, 121);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(79, 19);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";
            //
            // txtFirstName
            //
            this.txtFirstName.BorderRadius = 8;
            this.txtFirstName.Cursor = Cursors.IBeam;
            this.txtFirstName.DefaultText = "";
            this.txtFirstName.FillColor = Color.FromArgb(249, 250, 251);
            this.txtFirstName.Font = new Font("Segoe UI", 10F);
            this.txtFirstName.Location = new Point(150, 78);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(382, 36);
            this.txtFirstName.TabIndex = 3;
            //
            // lblFirstName
            //
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFirstName.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblFirstName.Location = new Point(20, 81);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(81, 19);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            //
            // txtCID
            //
            this.txtCID.BorderRadius = 8;
            this.txtCID.Cursor = Cursors.IBeam;
            this.txtCID.DefaultText = "";
            this.txtCID.FillColor = Color.FromArgb(243, 244, 246);
            this.txtCID.Font = new Font("Segoe UI", 10F);
            this.txtCID.Location = new Point(150, 38);
            this.txtCID.Name = "txtCID";
            this.txtCID.ReadOnly = true;
            this.txtCID.Size = new Size(382, 36);
            this.txtCID.TabIndex = 1;
            //
            // lblCID
            //
            this.lblCID.AutoSize = true;
            this.lblCID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCID.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblCID.Location = new Point(20, 41);
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
            this.panelButtons.FillColor = Color.Transparent;
            this.panelButtons.Location = new Point(24, 436);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(552, 40);
            this.panelButtons.TabIndex = 1;
            //
            // btnCancel
            //
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.FillColor = Color.FromArgb(107, 114, 128);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(300, 0);
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
            this.btnSave.Location = new Point(150, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(120, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            //
            // CustomerForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 250, 252);
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
