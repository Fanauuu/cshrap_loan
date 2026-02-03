using WinFormsApp1.Models;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class LoanTermForm : Form
    {
        private LoanTerm? _loanTerm;
        private LoanTermRepository _loanTermRepository;
        private bool _isEditMode;

        public LoanTermForm(LoanTerm? loanTerm, LoanTermRepository loanTermRepository)
        {
            InitializeComponent();
            _loanTerm = loanTerm;
            _loanTermRepository = loanTermRepository;
            _isEditMode = _loanTerm != null;
            InitializeUI();
            LoadLoanTermData();
        }

        private void InitializeUI()
        {
            this.Text = _isEditMode ? "Edit Loan Term" : "Add New Loan Term";
            chkIsActive.Checked = true;
        }

        private void LoadLoanTermData()
        {
            if (_isEditMode && _loanTerm != null)
            {
                txtTID.Text = _loanTerm.TID.ToString();
                txtTID.Enabled = false;
                txtTID.BackColor = Color.FromArgb(240, 240, 240);
                numTerm.Value = _loanTerm.Term;
                numAnnualRate.Value = _loanTerm.AnnualInterestRate;
                txtDescription.Text = _loanTerm.Description ?? string.Empty;
                chkIsActive.Checked = _loanTerm.IsActive;
            }
            else
            {
                txtTID.Text = "Auto";
                txtTID.Enabled = false;
                txtTID.BackColor = Color.FromArgb(240, 240, 240);
                numTerm.Value = 12;
                numAnnualRate.Value = 12.00m;
            }
            UpdateMonthlyRate();
        }

        private void numAnnualRate_ValueChanged(object sender, EventArgs e)
        {
            UpdateMonthlyRate();
        }

        private void UpdateMonthlyRate()
        {
            decimal monthlyRate = numAnnualRate.Value / 12;
            lblMonthlyRate.Text = $"Monthly Rate: {monthlyRate:F4}%";
        }

        private bool ValidateInput()
        {
            if (numTerm.Value <= 0)
            {
                MessageBox.Show("Term must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numAnnualRate.Value < 0 || numAnnualRate.Value > 100)
            {
                MessageBox.Show("Annual Interest Rate must be between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                LoanTerm termToSave = new LoanTerm
                {
                    Term = (int)numTerm.Value,
                    AnnualInterestRate = numAnnualRate.Value,
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    IsActive = chkIsActive.Checked
                };

                bool success = false;
                string message = string.Empty;

                if (_isEditMode && _loanTerm != null)
                {
                    termToSave.TID = _loanTerm.TID;
                    success = _loanTermRepository.UpdateLoanTerm(termToSave);
                    message = success ? "Loan term updated successfully." : "Failed to update loan term.";
                }
                else
                {
                    success = _loanTermRepository.CreateLoanTerm(termToSave);
                    message = success ? "Loan term created successfully." : "Failed to create loan term.";
                }

                if (success)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
