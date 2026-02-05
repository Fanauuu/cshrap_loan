using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.services;
using WinFormsApp1.Utils;

namespace WinFormsApp1
{
    public partial class RepaymentScheduleForm : Form
    {
        private int? _loanContractId;
        private LoanRepaymentScheduleRepository _scheduleRepository;
        private LoanContractRepository _loanContractRepository;
        private LoanCalculationService _calculationService;
        private List<LoanRepaymentSchedule> _schedules;

        public RepaymentScheduleForm(int? loanContractId = null)
        {
            InitializeComponent();
            _loanContractId = loanContractId;
            _scheduleRepository = new LoanRepaymentScheduleRepository();
            _loanContractRepository = new LoanContractRepository();
            _calculationService = new LoanCalculationService();
            _schedules = new List<LoanRepaymentSchedule>();
            InitializeUI();
            if (_loanContractId.HasValue)
            {
                LoadSchedule(_loanContractId.Value);
            }
            else
            {
                // If no contract ID provided, show message
                lblLoanInfo.Text = "Please select a loan contract from Loan Contract Management to view its schedule.";
                lblScheduleCount.Text = "Total Payments: 0";
            }
        }

        private void InitializeUI()
        {
            this.Text = "Loan Repayment Schedule";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.ReadOnly = true;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewStyleHelper.ApplyCleanStyle(dgvSchedule);

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "DueDate", HeaderText = "Due Date", DataPropertyName = "DueDate", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "MonthlyPayment", HeaderText = "Monthly Payment", DataPropertyName = "MonthlyPayment", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "Principal", HeaderText = "Principal", DataPropertyName = "Principal", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "Interest", HeaderText = "Interest", DataPropertyName = "Interest", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "RemainingBalance", HeaderText = "Remaining Balance", DataPropertyName = "RemainingBalance", Width = 140, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "Status", DataPropertyName = "Action", Width = 100 });
            dgvSchedule.CellFormatting += DgvSchedule_CellFormatting;
        }

        private void DgvSchedule_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSchedule.Columns[e.ColumnIndex].Name == "Action")
            {
                if (e.Value?.ToString() == "Paid")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                    e.CellStyle.Font = new Font(dgvSchedule.Font, FontStyle.Bold);
                }
                else if (e.Value?.ToString() == "Late")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font(dgvSchedule.Font, FontStyle.Bold);
                }
            }
        }

        private void LoadSchedule(int lc)
        {
            try
            {
                _schedules = _scheduleRepository.GetScheduleByLoanContract(lc);
                _calculationService.UpdateOverdueStatus(_schedules);
                dgvSchedule.DataSource = null;
                dgvSchedule.DataSource = _schedules;
                
                var contract = _loanContractRepository.GetLoanContractById(lc);
                if (contract != null)
                {
                    lblLoanInfo.Text = $"Loan Contract #{lc} - {contract.CustomerName} - Amount: {contract.LoanAmount:C2}";
                }
                
                lblScheduleCount.Text = $"Total Payments: {_schedules.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment to mark as paid.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoanRepaymentSchedule selectedSchedule = (LoanRepaymentSchedule)dgvSchedule.SelectedRows[0].DataBoundItem;

            if (selectedSchedule.Action == "Paid")
            {
                MessageBox.Show("This payment is already marked as paid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!_loanContractId.HasValue)
            {
                MessageBox.Show("Loan contract ID is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var contract = _loanContractRepository.GetLoanContractById(_loanContractId.Value);
            if (contract == null || contract.Status != "Active")
            {
                MessageBox.Show("Cannot process payment. Loan contract is not Active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Mark payment due on {selectedSchedule.DueDate:yyyy-MM-dd} as paid?",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_scheduleRepository.MarkPaymentAsPaid(selectedSchedule.ScheduleID, DateTime.Today))
                    {
                        MessageBox.Show("Payment marked as paid successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSchedule(_loanContractId.Value);
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark payment as paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                TableExportService.ExportToExcel(dgvSchedule, "RepaymentSchedule");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                TableExportService.ExportToPdf(dgvSchedule, "Repayment Schedule", "RepaymentSchedule");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_loanContractId.HasValue)
            {
                LoadSchedule(_loanContractId.Value);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
