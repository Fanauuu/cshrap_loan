using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    partial class LoanTermForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelMain;
        private Guna2Panel panelForm;
        private Label lblTID;
        private TextBox txtTID;
        private Label lblTerm;
        private NumericUpDown numTerm;
        private Label lblAnnualRate;
        private NumericUpDown numAnnualRate;
        private Label lblMonthlyRate;
        private Label lblDescription;
        private TextBox txtDescription;
        private CheckBox chkIsActive;
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
            this.chkIsActive = new CheckBox();
            this.txtDescription = new TextBox();
            this.lblDescription = new Label();
            this.lblMonthlyRate = new Label();
            this.numAnnualRate = new NumericUpDown();
            this.lblAnnualRate = new Label();
            this.numTerm = new NumericUpDown();
            this.lblTerm = new Label();
            this.txtTID = new TextBox();
            this.lblTID = new Label();
            this.panelButtons = new Guna2Panel();
            this.btnCancel = new Guna2Button();
            this.btnSave = new Guna2Button();
            this.panelMain.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnnualRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTerm)).BeginInit();
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
            this.panelMain.Size = new Size(500, 350);
            this.panelMain.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.chkIsActive);
            this.panelForm.Controls.Add(this.txtDescription);
            this.panelForm.Controls.Add(this.lblDescription);
            this.panelForm.Controls.Add(this.lblMonthlyRate);
            this.panelForm.Controls.Add(this.numAnnualRate);
            this.panelForm.Controls.Add(this.lblAnnualRate);
            this.panelForm.Controls.Add(this.numTerm);
            this.panelForm.Controls.Add(this.lblTerm);
            this.panelForm.Controls.Add(this.txtTID);
            this.panelForm.Controls.Add(this.lblTID);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.FillColor = Color.White;
            this.panelForm.BorderRadius = 12;
            this.panelForm.Location = new Point(20, 20);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(20);
            this.panelForm.Size = new Size(460, 260);
            this.panelForm.TabIndex = 0;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.chkIsActive.Location = new Point(120, 220);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new Size(78, 23);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtDescription.Location = new Point(120, 160);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(320, 50);
            this.txtDescription.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblDescription.Location = new Point(20, 163);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(85, 19);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description:";
            // 
            // lblMonthlyRate
            // 
            this.lblMonthlyRate.AutoSize = true;
            this.lblMonthlyRate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMonthlyRate.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblMonthlyRate.Location = new Point(300, 123);
            this.lblMonthlyRate.Name = "lblMonthlyRate";
            this.lblMonthlyRate.Size = new Size(120, 19);
            this.lblMonthlyRate.TabIndex = 6;
            this.lblMonthlyRate.Text = "Monthly Rate: 0%";
            // 
            // numAnnualRate
            // 
            this.numAnnualRate.DecimalPlaces = 2;
            this.numAnnualRate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numAnnualRate.Location = new Point(120, 120);
            this.numAnnualRate.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numAnnualRate.Name = "numAnnualRate";
            this.numAnnualRate.Size = new Size(170, 25);
            this.numAnnualRate.TabIndex = 5;
            this.numAnnualRate.ValueChanged += new EventHandler(this.numAnnualRate_ValueChanged);
            // 
            // lblAnnualRate
            // 
            this.lblAnnualRate.AutoSize = true;
            this.lblAnnualRate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblAnnualRate.Location = new Point(20, 123);
            this.lblAnnualRate.Name = "lblAnnualRate";
            this.lblAnnualRate.Size = new Size(145, 19);
            this.lblAnnualRate.TabIndex = 4;
            this.lblAnnualRate.Text = "Annual Rate (%):";
            // 
            // numTerm
            // 
            this.numTerm.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numTerm.Location = new Point(120, 80);
            this.numTerm.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.numTerm.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numTerm.Name = "numTerm";
            this.numTerm.Size = new Size(170, 25);
            this.numTerm.TabIndex = 3;
            this.numTerm.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTerm.Location = new Point(20, 83);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new Size(95, 19);
            this.lblTerm.TabIndex = 2;
            this.lblTerm.Text = "Term (Months):";
            // 
            // txtTID
            // 
            this.txtTID.Enabled = false;
            this.txtTID.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtTID.Location = new Point(120, 40);
            this.txtTID.Name = "txtTID";
            this.txtTID.Size = new Size(320, 25);
            this.txtTID.TabIndex = 1;
            // 
            // lblTID
            // 
            this.lblTID.AutoSize = true;
            this.lblTID.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTID.Location = new Point(20, 43);
            this.lblTID.Name = "lblTID";
            this.lblTID.Size = new Size(35, 19);
            this.lblTID.TabIndex = 0;
            this.lblTID.Text = "TID:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 280);
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
            // LoanTermForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(500, 350);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanTermForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Loan Term Form";
            this.panelMain.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnnualRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTerm)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
