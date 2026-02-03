using System.Linq;
using WinFormsApp1.Models;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class CustomerDetailForm : Form
    {
        private Customer _customer;
        private CustomerRepository _customerRepository;
        private LoanContractRepository _loanContractRepository;
        private List<LoanContract> _customerLoans;

        public CustomerDetailForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            _customerRepository = new CustomerRepository();
            _loanContractRepository = new LoanContractRepository();
            _customerLoans = new List<LoanContract>();
            InitializeUI();
            LoadCustomerDetails();
            LoadCustomerLoans();
        }

        private void InitializeUI()
        {
            this.Text = $"Customer Details - {_customer.FullName}";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Configure Loan Contracts DataGridView
            dgvLoanContracts.AutoGenerateColumns = false;
            dgvLoanContracts.AllowUserToAddRows = false;
            dgvLoanContracts.ReadOnly = true;
            dgvLoanContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoanContracts.MultiSelect = false;
            dgvLoanContracts.BackgroundColor = Color.White;
            dgvLoanContracts.BorderStyle = BorderStyle.None;
            dgvLoanContracts.CellFormatting += DgvLoanContracts_CellFormatting;

            // Add columns
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "LC", HeaderText = "LC", DataPropertyName = "LC", Width = 60 });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanAmount", HeaderText = "Loan Amount", DataPropertyName = "LoanAmount", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "TermMonths", HeaderText = "Term", DataPropertyName = "TermMonths", Width = 80 });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "MonthlyInterest", HeaderText = "Monthly Rate (%)", DataPropertyName = "MonthlyInterest", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" } });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanDate", HeaderText = "Loan Date", DataPropertyName = "LoanDate", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 80 });
            dgvLoanContracts.Columns.Add(new DataGridViewTextBoxColumn { Name = "ScheduleStatus", HeaderText = "Schedule", DataPropertyName = "ScheduleStatus", Width = 100 });
        }

        private void DgvLoanContracts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLoanContracts.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value?.ToString() == "Active")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                    e.CellStyle.Font = new Font(dgvLoanContracts.Font, FontStyle.Bold);
                }
                else if (e.Value?.ToString() == "Default")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font(dgvLoanContracts.Font, FontStyle.Bold);
                }
            }
        }

        private void LoadCustomerDetails()
        {
            lblCustomerName.Text = _customer.FullName;
            lblCID.Text = $"CID: {_customer.CID}";
            lblGender.Text = $"Gender: {_customer.Gender}";
            lblDateOfBirth.Text = $"Date of Birth: {_customer.DateOfBirth:yyyy-MM-dd}";
            lblAge.Text = $"Age: {_customer.Age} years";
            lblPlaceOfBirth.Text = $"Place of Birth: {_customer.PlaceOfBirth ?? "N/A"}";
            lblAddress.Text = $"Address: {_customer.CurrentAddress}";
            lblStatus.Text = $"Status: {_customer.Status}";
            
            if (_customer.Status == "Active")
            {
                lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);
            }
            else
            {
                lblStatus.ForeColor = Color.Gray;
            }
        }

        private void LoadCustomerLoans()
        {
            try
            {
                var allLoans = _loanContractRepository.GetAllLoanContracts();
                _customerLoans = allLoans.Where(l => l.CID == _customer.CID).ToList();
                
                dgvLoanContracts.DataSource = null;
                dgvLoanContracts.DataSource = _customerLoans;
                
                lblLoanCount.Text = $"Total Loans: {_customerLoans.Count}";
                
                // Calculate summary
                decimal totalLoanAmount = _customerLoans.Sum(l => l.LoanAmount);
                int activeLoans = _customerLoans.Count(l => l.Status == "Active");
                lblTotalLoanAmount.Text = $"Total Loan Amount: {totalLoanAmount:C2}";
                lblActiveLoans.Text = $"Active Loans: {activeLoans}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer loans: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            if (dgvLoanContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a loan contract to view schedule.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoanContract selectedContract = (LoanContract)dgvLoanContracts.SelectedRows[0].DataBoundItem;
            RepaymentScheduleForm scheduleForm = new RepaymentScheduleForm(selectedContract.LC);
            scheduleForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomerLoans();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLoanContracts_DoubleClick(object sender, EventArgs e)
        {
            btnViewSchedule_Click(sender, e);
        }
    }
}
