using WinFormsApp1.Models;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class CustomerForm : Form
    {
        private Customer? _customer;
        private CustomerRepository _customerRepository;
        private bool _isEditMode;

        public CustomerForm(Customer? customer, CustomerRepository customerRepository)
        {
            InitializeComponent();
            _customer = customer;
            _customerRepository = customerRepository;
            _isEditMode = _customer != null;
            InitializeUI();
            LoadCustomerData();
        }

        private void InitializeUI()
        {
            this.Text = _isEditMode ? "Edit Customer" : "Add New Customer";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Populate Gender ComboBox
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;

            // Populate Status ComboBox
            cmbStatus.Items.AddRange(new string[] { "Active", "Inactive" });
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;

            // Set date picker range
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18); // At least 18 years old
            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-100);
        }

        private void LoadCustomerData()
        {
            if (_isEditMode && _customer != null)
            {
                txtCID.Text = _customer.CID.ToString();
                txtCID.Enabled = false;
                txtCID.BackColor = Color.FromArgb(240, 240, 240);
                txtFirstName.Text = _customer.FirstName;
                txtLastName.Text = _customer.LastName;
                cmbGender.SelectedItem = _customer.Gender;
                txtPlaceOfBirth.Text = _customer.PlaceOfBirth ?? string.Empty;
                dtpDateOfBirth.Value = _customer.DateOfBirth;
                txtCurrentAddress.Text = _customer.CurrentAddress;
                cmbStatus.SelectedItem = _customer.Status;
            }
            else
            {
                txtCID.Text = "Auto";
                txtCID.Enabled = false;
                txtCID.BackColor = Color.FromArgb(240, 240, 240);
                dtpDateOfBirth.Value = DateTime.Today.AddYears(-25);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please select a gender.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCurrentAddress.Text))
            {
                MessageBox.Show("Current Address is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentAddress.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                Customer customerToSave = new Customer
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Gender = cmbGender.SelectedItem?.ToString() ?? string.Empty,
                    PlaceOfBirth = string.IsNullOrWhiteSpace(txtPlaceOfBirth.Text) ? null : txtPlaceOfBirth.Text.Trim(),
                    DateOfBirth = dtpDateOfBirth.Value.Date,
                    CurrentAddress = txtCurrentAddress.Text.Trim(),
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Active"
                };

                bool success = false;
                string message = string.Empty;

                if (_isEditMode && _customer != null)
                {
                    customerToSave.CID = _customer.CID;
                    success = _customerRepository.UpdateCustomer(customerToSave);
                    message = success ? "Customer updated successfully." : "Failed to update customer.";
                }
                else
                {
                    success = _customerRepository.CreateCustomer(customerToSave);
                    message = success ? "Customer created successfully." : "Failed to create customer.";
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
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
