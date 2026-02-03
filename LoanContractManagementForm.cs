using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.services;

namespace WinFormsApp1
{
    public partial class LoanContractManagementForm : Form
    {
        private LoanContractRepository _loanContractRepository;
        private CustomerRepository _customerRepository;
        private LoanTermRepository _loanTermRepository;
        private LoanCalculationService _calculationService;
        private List<LoanContract> _loanContracts;

        public LoanContractManagementForm()
        {
            InitializeComponent();
            _loanContractRepository = new LoanContractRepository();
            _customerRepository = new CustomerRepository();
            _loanTermRepository = new LoanTermRepository();
            _calculationService = new LoanCalculationService();
            _loanContracts = new List<LoanContract>();
            InitializeUI();
            LoadLoanContracts();
        }

        private void InitializeUI()
        {
            this.Text = "Loan Contract Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            dgvLoanContracts.AutoGenerateColumns = false;
            dgvLoanContracts.AllowUserToAddRows = false;
            dgvLoanContracts.ReadOnly = true;
            dgvLoanContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "LC", HeaderText = "LC", DataPropertyName = "LC", Width = 60 });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerName", HeaderText = "Customer", DataPropertyName = "CustomerName", Width = 180 });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanAmount", HeaderText = "Loan Amount", DataPropertyName = "LoanAmount", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "TermMonths", HeaderText = "Term", DataPropertyName = "TermMonths", Width = 80 });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "MonthlyInterest", HeaderText = "Monthly Rate (%)", DataPropertyName = "MonthlyInterest", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" } });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanDate", HeaderText = "Loan Date", DataPropertyName = "LoanDate", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 80 });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "ScheduleStatus", HeaderText = "Schedule", DataPropertyName = "ScheduleStatus", Width = 100 });
        }

        private void LoadLoanContracts()
        {
            try
            {
                _loanContracts = _loanContractRepository.GetAllLoanContracts();
                dgvLoanContracts.DataSource = null;
                dgvLoanContracts.DataSource = _loanContracts;
                lblContractCount.Text = $"Total Contracts: {_loanContracts.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading loan contracts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoanContractForm contractForm = new LoanContractForm(null, _loanContractRepository, _customerRepository, _loanTermRepository, _calculationService);
            if (contractForm.ShowDialog() == DialogResult.OK)
            {
                LoadLoanContracts();
            }
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            if (dgvLoanContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a loan contract to view schedule.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoanContract selectedContract = (LoanContract)dgvLoanContracts.SelectedRows[0].DataBoundItem;
            RepaymentScheduleForm scheduleForm = new RepaymentScheduleForm(selectedContract.LC);
            scheduleForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadLoanContracts();
        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
