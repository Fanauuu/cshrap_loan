using System.Linq;
using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.Utils;

namespace WinFormsApp1
{
    public partial class CustomerManagementForm : Form
    {
        private CustomerRepository _customerRepository;
        private List<Customer> _customers;

        public CustomerManagementForm()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
            _customers = new List<Customer>();
            InitializeUI();
            LoadCustomers();
        }

        private void InitializeUI()
        {
            this.Text = "Customer Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Configure DataGridView - Clean styling without colored backgrounds
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            
            // Remove colored backgrounds - clean styling only
            dgvCustomers.DefaultCellStyle.BackColor = Color.White;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvCustomers.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            
            // Clean header styling
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            // Row headers clean
            dgvCustomers.RowHeadersDefaultCellStyle.BackColor = Color.White;
            dgvCustomers.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);

            // Add columns
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CID",
                HeaderText = "CID",
                DataPropertyName = "CID",
                Width = 60
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                Width = 180
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Gender",
                HeaderText = "Gender",
                DataPropertyName = "Gender",
                Width = 80
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateOfBirth",
                HeaderText = "Date of Birth",
                DataPropertyName = "DateOfBirth",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Age",
                HeaderText = "Age",
                DataPropertyName = "Age",
                Width = 60
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentAddress",
                HeaderText = "Address",
                DataPropertyName = "CurrentAddress",
                Width = 250
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 80
            });
        }

        private void DgvCustomers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Clean styling - no colored backgrounds, just text styling
            if (dgvCustomers.Columns[e.ColumnIndex].Name == "Status")
            {
                // Keep text color neutral, no background colors
                e.CellStyle.ForeColor = Color.FromArgb(75, 85, 99);
                e.CellStyle.BackColor = Color.White;
                if (e.Value?.ToString() == "Active")
                {
                    e.CellStyle.Font = new Font(dgvCustomers.Font, FontStyle.Regular);
                }
                else
                {
                    e.CellStyle.Font = new Font(dgvCustomers.Font, FontStyle.Regular);
                }
            }
            else
            {
                // Ensure all cells have white background
                e.CellStyle.BackColor = Color.White;
            }
        }

        private void LoadCustomers()
        {
            try
            {
                _customers = _customerRepository.GetAllCustomers();
                FilterCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterCustomers()
        {
            string searchText = txtSearch.Text.ToLower().Trim();
            List<Customer> filteredCustomers;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                filteredCustomers = _customers;
            }
            else
            {
                filteredCustomers = _customers.Where(c =>
                    c.FullName.ToLower().Contains(searchText) ||
                    c.FirstName.ToLower().Contains(searchText) ||
                    c.LastName.ToLower().Contains(searchText) ||
                    c.CID.ToString().Contains(searchText)
                ).ToList();
            }

            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = filteredCustomers;
            lblCustomerCount.Text = $"📊 Total: {filteredCustomers.Count} (Filtered: {filteredCustomers.Count} of {_customers.Count})";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm(null, _customerRepository);
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer selectedCustomer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
            CustomerForm customerForm = new CustomerForm(selectedCustomer, _customerRepository);
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer selectedCustomer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete customer '{selectedCustomer.FullName}' (CID: {selectedCustomer.CID})?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_customerRepository.DeleteCustomer(selectedCustomer.CID))
                    {
                        MessageBox.Show("Customer deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    string message = DeleteErrorHelper.GetMessage(ex, "customer",
                        "This customer cannot be deleted because they have loan contracts. Remove or update those contracts first.");
                    MessageBox.Show(message, "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            btnViewDetails_Click(sender, e);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to view details.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer selectedCustomer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
            CustomerDetailForm detailForm = new CustomerDetailForm(selectedCustomer);
            detailForm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterCustomers();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            FilterCustomers();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            TableExportService.ExportToExcel(dgvCustomers, "Customers");
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            TableExportService.ExportToPdf(dgvCustomers, "Customer List", "Customers");
        }
    }
}
