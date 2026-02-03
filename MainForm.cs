using WinFormsApp1.Models;
using WinFormsApp1.services;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private AuthService _authService;

        public MainForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _authService = new AuthService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            lblWelcome.Text = $"Welcome, {_currentUser.FullName} ({_currentUser.Username})";
            lblRole.Text = $"Role: {_currentUser.Role}";
            
            // Only show user management button for admins
            btnUserManagement.Visible = _authService.IsAdmin(_currentUser);
            btnUserManagement.Enabled = _authService.IsAdmin(_currentUser);
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            CustomerManagementForm form = new CustomerManagementForm();
            form.ShowDialog();
        }

        private void btnLoanTermManagement_Click(object sender, EventArgs e)
        {
            LoanTermManagementForm form = new LoanTermManagementForm();
            form.ShowDialog();
        }

        private void btnLoanContractManagement_Click(object sender, EventArgs e)
        {
            LoanContractManagementForm form = new LoanContractManagementForm();
            form.ShowDialog();
        }

        private void btnRepaymentSchedule_Click(object sender, EventArgs e)
        {
            RepaymentScheduleForm form = new RepaymentScheduleForm();
            form.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin(_currentUser))
            {
                MessageBox.Show("Access denied. Admin privileges required.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserManagementForm userMgmtForm = new UserManagementForm(_currentUser);
            userMgmtForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
