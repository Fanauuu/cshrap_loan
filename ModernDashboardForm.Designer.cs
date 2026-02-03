namespace WinFormsApp1
{
    partial class ModernDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.SuspendLayout();
            // 
            // ModernDashboardForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 800);
            this.Name = "ModernDashboardForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Loan Management System";
            this.ResumeLayout(false);
        }
    }
}
