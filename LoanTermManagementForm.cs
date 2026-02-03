using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.Utils;

namespace WinFormsApp1
{
    public partial class LoanTermManagementForm : Form
    {
        private LoanTermRepository _loanTermRepository;
        private List<LoanTerm> _loanTerms;

        public LoanTermManagementForm()
        {
            InitializeComponent();
            _loanTermRepository = new LoanTermRepository();
            _loanTerms = new List<LoanTerm>();
            InitializeUI();
            LoadLoanTerms();
        }

        private void InitializeUI()
        {
            this.Text = "Loan Term Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            dgvLoanTerms.AutoGenerateColumns = false;
            dgvLoanTerms.AllowUserToAddRows = false;
            dgvLoanTerms.ReadOnly = true;
            dgvLoanTerms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLoanTerms.Columns.Add(new DataGridViewTextBoxColumn { Name = "TID", HeaderText = "TID", DataPropertyName = "TID", Width = 60 });
            dgvLoanTerms.Columns.Add(new DataGridViewTextBoxColumn { Name = "Term", HeaderText = "Term (Months)", DataPropertyName = "Term", Width = 120 });
            dgvLoanTerms.Columns.Add(new DataGridViewTextBoxColumn { Name = "AnnualInterestRate", HeaderText = "Annual Rate (%)", DataPropertyName = "AnnualInterestRate", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" } });
            dgvLoanTerms.Columns.Add(new DataGridViewTextBoxColumn { Name = "MonthlyRate", HeaderText = "Monthly Rate (%)", DataPropertyName = "MonthlyInterestRate", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "F4" } });
            dgvLoanTerms.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", DataPropertyName = "Description", Width = 250 });
            dgvLoanTerms.Columns.Add(new DataGridViewCheckBoxColumn { Name = "IsActive", HeaderText = "Active", DataPropertyName = "IsActive", Width = 80 });
        }

        private void LoadLoanTerms()
        {
            try
            {
                _loanTerms = _loanTermRepository.GetAllLoanTerms();
                dgvLoanTerms.DataSource = null;
                dgvLoanTerms.DataSource = _loanTerms;
                lblTermCount.Text = $"Total Loan Terms: {_loanTerms.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading loan terms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoanTermForm termForm = new LoanTermForm(null, _loanTermRepository);
            if (termForm.ShowDialog() == DialogResult.OK)
            {
                LoadLoanTerms();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLoanTerms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a loan term to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoanTerm selectedTerm = (LoanTerm)dgvLoanTerms.SelectedRows[0].DataBoundItem;
            LoanTermForm termForm = new LoanTermForm(selectedTerm, _loanTermRepository);
            if (termForm.ShowDialog() == DialogResult.OK)
            {
                LoadLoanTerms();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLoanTerms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a loan term to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoanTerm selectedTerm = (LoanTerm)dgvLoanTerms.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete loan term '{selectedTerm.DisplayText}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_loanTermRepository.DeleteLoanTerm(selectedTerm.TID))
                    {
                        MessageBox.Show("Loan term deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLoanTerms();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete loan term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    string message = DeleteErrorHelper.GetMessage(ex, "loan term",
                        "This loan term cannot be deleted because it is used by one or more loan contracts. Remove or update those contracts first.");
                    MessageBox.Show(message, "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadLoanTerms();
        private void btnClose_Click(object sender, EventArgs e) => this.Close();
        private void dgvLoanTerms_DoubleClick(object sender, EventArgs e) => btnEdit_Click(sender, e);
    }
}
