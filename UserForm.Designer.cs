using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelForm;
        private Label lblUserId;
        private TextBox txtUserId;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblRole;
        private ComboBox cmbRole;
        private CheckBox chkIsActive;
        private Guna2Panel panelButtons;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;

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
            this.panelForm = new Guna2Panel();
            this.chkIsActive = new CheckBox();
            this.cmbRole = new ComboBox();
            this.lblRole = new Label();
            this.txtLastName = new TextBox();
            this.lblLastName = new Label();
            this.txtFirstName = new TextBox();
            this.lblFirstName = new Label();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.txtPassword = new TextBox();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.lblUsername = new Label();
            this.txtUserId = new TextBox();
            this.lblUserId = new Label();
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
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.FillColor = Color.FromArgb(248, 250, 252);
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(500, 450);
            this.panelMain.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.chkIsActive);
            this.panelForm.Controls.Add(this.cmbRole);
            this.panelForm.Controls.Add(this.lblRole);
            this.panelForm.Controls.Add(this.txtLastName);
            this.panelForm.Controls.Add(this.lblLastName);
            this.panelForm.Controls.Add(this.txtFirstName);
            this.panelForm.Controls.Add(this.lblFirstName);
            this.panelForm.Controls.Add(this.txtEmail);
            this.panelForm.Controls.Add(this.lblEmail);
            this.panelForm.Controls.Add(this.txtPassword);
            this.panelForm.Controls.Add(this.lblPassword);
            this.panelForm.Controls.Add(this.txtUsername);
            this.panelForm.Controls.Add(this.lblUsername);
            this.panelForm.Controls.Add(this.txtUserId);
            this.panelForm.Controls.Add(this.lblUserId);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.FillColor = Color.White;
            this.panelForm.BorderRadius = 12;
            this.panelForm.Location = new Point(20, 20);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(20);
            this.panelForm.Size = new Size(460, 360);
            this.panelForm.TabIndex = 0;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.chkIsActive.Location = new Point(120, 320);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new Size(78, 23);
            this.chkIsActive.TabIndex = 14;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new Point(120, 280);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new Size(320, 25);
            this.cmbRole.TabIndex = 13;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblRole.Location = new Point(20, 283);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(40, 19);
            this.lblRole.TabIndex = 12;
            this.lblRole.Text = "Role:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtLastName.Location = new Point(120, 240);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(320, 25);
            this.txtLastName.TabIndex = 11;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblLastName.Location = new Point(20, 243);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(79, 19);
            this.lblLastName.TabIndex = 10;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtFirstName.Location = new Point(120, 200);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(320, 25);
            this.txtFirstName.TabIndex = 9;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblFirstName.Location = new Point(20, 203);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(81, 19);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtEmail.Location = new Point(120, 160);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(320, 25);
            this.txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblEmail.Location = new Point(20, 163);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(48, 19);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtPassword.Location = new Point(120, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(320, 25);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblPassword.Location = new Point(20, 123);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(73, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtUsername.Location = new Point(120, 80);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(320, 25);
            this.txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblUsername.Location = new Point(20, 83);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(76, 19);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // txtUserId
            // 
            this.txtUserId.Enabled = false;
            this.txtUserId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtUserId.Location = new Point(120, 40);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new Size(320, 25);
            this.txtUserId.TabIndex = 1;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblUserId.Location = new Point(20, 43);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new Size(60, 19);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User ID:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 380);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(460, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnCancel
            //
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.FillColor = Color.FromArgb(107, 114, 128);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(250, 8);
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
            this.btnSave.Location = new Point(120, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(120, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(500, 450);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "User Form";
            this.panelMain.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
