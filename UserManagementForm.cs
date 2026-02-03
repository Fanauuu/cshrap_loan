using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.services;
using WinFormsApp1.Utils;

namespace WinFormsApp1
{
    public partial class UserManagementForm : Form
    {
        private User _currentUser;
        private UserRepository _userRepository;
        private AuthService _authService;
        private List<User> _users;

        public UserManagementForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _userRepository = new UserRepository();
            _authService = new AuthService();
            _users = new List<User>();
            
            // Check if user is admin
            if (!_authService.IsAdmin(_currentUser))
            {
                MessageBox.Show("Access denied. Admin privileges required.", "Access Denied", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            InitializeUI();
            LoadUsers();
        }

        private void InitializeUI()
        {
            this.Text = "User Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            // Configure DataGridView
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellFormatting += DgvUsers_CellFormatting;
            
            // Add columns
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserId",
                HeaderText = "ID",
                DataPropertyName = "UserId",
                Width = 50,
                ReadOnly = true
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username",
                Width = 120
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                Width = 150
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                Width = 80
            });

            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Active",
                DataPropertyName = "IsActive",
                Width = 60
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedDate",
                HeaderText = "Created Date",
                DataPropertyName = "CreatedDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" }
            });
        }

        private void DgvUsers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Role")
            {
                if (e.Value?.ToString() == "Admin")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font(dgvUsers.Font, FontStyle.Bold);
                }
                else if (e.Value?.ToString() == "Manager")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(0, 123, 255);
                    e.CellStyle.Font = new Font(dgvUsers.Font, FontStyle.Bold);
                }
            }

            if (dgvUsers.Columns[e.ColumnIndex].Name == "IsActive")
            {
                if (e.Value is bool isActive && !isActive)
                {
                    e.CellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void LoadUsers()
        {
            try
            {
                _users = _userRepository.GetAllUsers();
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _users;
                lblUserCount.Text = $"Total Users: {_users.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin(_currentUser))
            {
                MessageBox.Show("Access denied. Admin privileges required.", "Access Denied", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserForm userForm = new UserForm(null, _userRepository);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin(_currentUser))
            {
                MessageBox.Show("Access denied. Admin privileges required.", "Access Denied", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            User selectedUser = (User)dgvUsers.SelectedRows[0].DataBoundItem;
            UserForm userForm = new UserForm(selectedUser, _userRepository);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin(_currentUser))
            {
                MessageBox.Show("Access denied. Admin privileges required.", "Access Denied", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            User selectedUser = (User)dgvUsers.SelectedRows[0].DataBoundItem;

            // Prevent deleting yourself
            if (selectedUser.UserId == _currentUser.UserId)
            {
                MessageBox.Show("You cannot delete your own account.", "Invalid Operation", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete user '{selectedUser.Username}'?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_userRepository.DeleteUser(selectedUser.UserId))
                    {
                        MessageBox.Show("User deleted successfully.", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    string message = DeleteErrorHelper.GetMessage(ex, "user",
                        "This user cannot be deleted because they are linked to existing data (e.g. loan contracts). Update or remove those records first.");
                    MessageBox.Show(message, "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
