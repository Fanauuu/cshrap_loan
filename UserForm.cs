using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.Utils;

namespace WinFormsApp1
{
    public partial class UserForm : Form
    {
        private User? _user;
        private UserRepository _userRepository;
        private bool _isEditMode;

        public UserForm(User? user, UserRepository userRepository)
        {
            InitializeComponent();
            _user = user;
            _userRepository = userRepository;
            _isEditMode = _user != null;

            InitializeUI();
            LoadUserData();
        }

        private void InitializeUI()
        {
            this.Text = _isEditMode ? "Edit User" : "Add New User";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Populate Role ComboBox
            cmbRole.Items.AddRange(new string[] { "Admin", "User", "Manager" });
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            // Set default values
            cmbRole.SelectedIndex = 1; // Default to "User"
            chkIsActive.Checked = true;
        }

        private void LoadUserData()
        {
            if (_isEditMode && _user != null)
            {
                txtUserId.Text = _user.UserId.ToString();
                txtUsername.Text = _user.Username;
                txtPassword.Text = _user.Password;
                txtEmail.Text = _user.Email ?? string.Empty;
                txtFirstName.Text = _user.FirstName ?? string.Empty;
                txtLastName.Text = _user.LastName ?? string.Empty;
                cmbRole.SelectedItem = _user.Role;
                chkIsActive.Checked = _user.IsActive;

                txtUserId.Enabled = false;
                txtUsername.ReadOnly = true;
                txtUsername.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                txtUserId.Text = "Auto";
                txtUserId.Enabled = false;
                txtUserId.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            // Check if username already exists (only for new users or if username changed)
            if (!_isEditMode || (_isEditMode && _user != null && txtUsername.Text != _user.Username))
            {
                int? excludeUserId = _isEditMode && _user != null ? _user.UserId : null;
                if (_userRepository.UsernameExists(txtUsername.Text, excludeUserId))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                // Hash password before saving
                string passwordHash = PasswordHasher.HashPassword(txtPassword.Text);

                User userToSave = new User
                {
                    Username = txtUsername.Text.Trim(),
                    Password = passwordHash, // Store hashed password
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    FirstName = string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text.Trim(),
                    LastName = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text.Trim(),
                    Role = cmbRole.SelectedItem?.ToString() ?? "User",
                    IsActive = chkIsActive.Checked
                };

                bool success = false;
                string message = string.Empty;

                if (_isEditMode && _user != null)
                {
                    userToSave.UserId = _user.UserId;
                    // If password wasn't changed, keep the old hash
                    if (txtPassword.Text == _user.Password || txtPassword.Text.Length < 6)
                    {
                        userToSave.Password = _user.Password; // Keep existing hash
                    }
                    success = _userRepository.UpdateUser(userToSave);
                    message = success ? "User updated successfully." : "Failed to update user.";
                }
                else
                {
                    success = _userRepository.CreateUser(userToSave);
                    message = success ? "User created successfully." : "Failed to create user.";
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
