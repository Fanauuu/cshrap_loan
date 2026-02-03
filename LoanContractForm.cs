using System.Linq;
using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.services;

namespace WinFormsApp1
{
    public partial class LoanContractForm : Form
    {
        private LoanContract? _loanContract;
        private LoanContractRepository _loanContractRepository;
        private CustomerRepository _customerRepository;
        private LoanTermRepository _loanTermRepository;
        private LoanCalculationService _calculationService;
        private LoanRepaymentScheduleRepository _scheduleRepository;
        private bool _isEditMode;

        public LoanContractForm(LoanContract? loanContract, LoanContractRepository loanContractRepository,
            CustomerRepository customerRepository, LoanTermRepository loanTermRepository,
            LoanCalculationService calculationService)
        {
            InitializeComponent();
            _loanContract = loanContract;
            _loanContractRepository = loanContractRepository;
            _customerRepository = customerRepository;
            _loanTermRepository = loanTermRepository;
            _calculationService = calculationService;
            _scheduleRepository = new LoanRepaymentScheduleRepository();
            _isEditMode = _loanContract != null;
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            this.Text = _isEditMode ? "Edit Loan Contract" : "New Loan Contract";
            dtpLoanDate.Value = DateTime.Today;
            dtpStartPaymentDate.Value = DateTime.Today.AddMonths(1);
            numServicePayment.Value = 0;
        }

        private void LoadData()
        {
            // Load customers
            var customers = _customerRepository.GetActiveCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "CID";

            // Load loan terms
            var terms = _loanTermRepository.GetActiveLoanTerms();
            cmbLoanTerm.DataSource = terms;
            cmbLoanTerm.DisplayMember = "DisplayText";
            cmbLoanTerm.ValueMember = "TID";

            if (_isEditMode && _loanContract != null)
            {
                txtLC.Text = _loanContract.LC.ToString();
                txtLC.Enabled = false;
                cmbCustomer.SelectedValue = _loanContract.CID;
                cmbCustomer.Enabled = false;
                numLoanAmount.Value = _loanContract.LoanAmount;
                cmbLoanTerm.SelectedValue = _loanContract.TermID;
                cmbLoanTerm.Enabled = false;
                numMonthlyInterest.Value = _loanContract.MonthlyInterest;
                dtpLoanDate.Value = _loanContract.LoanDate;
                dtpStartPaymentDate.Value = _loanContract.StartPaymentDate;
                numServicePayment.Value = _loanContract.ServicePayment;
                cmbStatus.SelectedItem = _loanContract.Status;
            }
            else
            {
                txtLC.Text = "Auto";
                txtLC.Enabled = false;
                CalculateMonthlyPayment();
            }
        }

        private void CalculateMonthlyPayment()
        {
            if (numLoanAmount.Value > 0 && cmbLoanTerm.SelectedValue != null)
            {
                var selectedTerm = (LoanTerm)cmbLoanTerm.SelectedItem;
                decimal monthlyPayment = _calculationService.CalculateMonthlyPayment(
                    numLoanAmount.Value, selectedTerm.AnnualInterestRate, selectedTerm.Term);
                lblMonthlyPayment.Text = $"Monthly Payment: {monthlyPayment:C2}";
                numMonthlyInterest.Value = _calculationService.CalculateMonthlyInterestRate(selectedTerm.AnnualInterestRate);
            }
        }

        private void numLoanAmount_ValueChanged(object sender, EventArgs e) => CalculateMonthlyPayment();
        private void cmbLoanTerm_SelectedIndexChanged(object sender, EventArgs e) => CalculateMonthlyPayment();

        private bool ValidateInput()
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numLoanAmount.Value <= 0)
            {
                MessageBox.Show("Loan amount must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbLoanTerm.SelectedValue == null)
            {
                MessageBox.Show("Please select a loan term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var selectedTerm = (LoanTerm)cmbLoanTerm.SelectedItem;
                LoanContract contractToSave = new LoanContract
                {
                    CID = (int)cmbCustomer.SelectedValue,
                    LoanAmount = numLoanAmount.Value,
                    TermID = selectedTerm.TID,
                    MonthlyInterest = numMonthlyInterest.Value,
                    LoanDate = dtpLoanDate.Value.Date,
                    StartPaymentDate = dtpStartPaymentDate.Value.Date,
                    ServicePayment = numServicePayment.Value,
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Active",
                    ScheduleStatus = "Pending"
                };

                bool success = false;
                string message = string.Empty;

                if (_isEditMode && _loanContract != null)
                {
                    contractToSave.LC = _loanContract.LC;
                    success = _loanContractRepository.UpdateLoanContract(contractToSave);
                    message = success ? "Loan contract updated successfully." : "Failed to update loan contract.";
                }
                else
                {
                    int newContractId = _loanContractRepository.CreateLoanContract(contractToSave);
                    if (newContractId > 0)
                    {
                        contractToSave.LC = newContractId;
                        success = true;

                        // Generate repayment schedule
                        var schedule = _calculationService.GenerateRepaymentSchedule(
                            contractToSave.LC,
                            contractToSave.CID,
                            contractToSave.LoanAmount,
                            selectedTerm.AnnualInterestRate,
                            selectedTerm.Term,
                            contractToSave.StartPaymentDate,
                            contractToSave.ServicePayment);

                        if (schedule != null && schedule.Count > 0)
                        {
                            if (_scheduleRepository.CreateRepaymentSchedules(schedule))
                            {
                                var updateContract = _loanContractRepository.GetLoanContractById(contractToSave.LC);
                                if (updateContract != null)
                                {
                                    updateContract.ScheduleStatus = "Generated";
                                    _loanContractRepository.UpdateLoanContract(updateContract);
                                }
                                message = "Loan contract created and schedule generated successfully.";
                            }
                            else
                            {
                                message = "Loan contract created but schedule generation failed.";
                            }
                        }
                        else
                        {
                            message = "Loan contract created but schedule is empty.";
                        }
                    }
                    else
                    {
                        message = "Failed to create loan contract.";
                    }
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
