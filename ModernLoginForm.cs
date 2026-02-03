using WinFormsApp1.services;
using WinFormsApp1.Models;
using WinFormsApp1.Utils;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class ModernLoginForm : Form
    {
        private Panel? panelCard;
        private Label? lblTitle;
        private Label? lblSubtitle;
        private Label? lblError;
        private TextBox? txtUsername;
        private TextBox? txtPassword;
        private Button? btnLogin;
        private Panel? panelMain;

        public ModernLoginForm()
        {
            InitializeComponent();
            this.Load += ModernLoginForm_Load;
        }

        private void ModernLoginForm_Load(object? sender, EventArgs e)
        {
            try
            {
                InitializeModernUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading UI: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeModernUI()
        {
            // Initialize form properties first
            this.BackColor = UIStyles.BackgroundColor;
            this.Text = "Login - Loan Management System";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(450, 600);
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            // Main panel with gradient-like background
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UIStyles.BackgroundColor
            };
            this.Controls.Add(panelMain);

            // Login card panel
            panelCard = new Panel
            {
                Size = new Size(400, 500),
                Location = new Point(25, 50),
                BackColor = UIStyles.CardColor,
                Padding = new Padding(40)
            };

            // Title
            lblTitle = new Label
            {
                Text = "Welcome Back",
                Font = UIStyles.TitleFont,
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(40, 40)
            };

            // Subtitle
            lblSubtitle = new Label
            {
                Text = "Sign in to your account",
                Font = UIStyles.SmallFont,
                ForeColor = UIStyles.TextSecondary,
                AutoSize = true,
                Location = new Point(40, 80)
            };

            // Error label (hidden by default)
            lblError = new Label
            {
                Text = "",
                Font = UIStyles.SmallFont,
                ForeColor = UIStyles.DangerColor,
                AutoSize = true,
                Location = new Point(40, 120),
                Visible = false
            };

            // Username field
            Label lblUsername = new Label
            {
                Text = "Username",
                Font = UIStyles.BodyFont,
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(40, 160)
            };

            txtUsername = new TextBox
            {
                Location = new Point(40, 185),
                Size = new Size(320, 40),
                Font = UIStyles.BodyFont,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Padding = new Padding(12, 10, 12, 10)
            };
            UIStyles.ApplyModernTextBox(txtUsername);

            // Password field
            Label lblPassword = new Label
            {
                Text = "Password",
                Font = UIStyles.BodyFont,
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(40, 245)
            };

            txtPassword = new TextBox
            {
                Location = new Point(40, 270),
                Size = new Size(320, 40),
                Font = UIStyles.BodyFont,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                UseSystemPasswordChar = true,
                Padding = new Padding(12, 10, 12, 10)
            };
            UIStyles.ApplyModernTextBox(txtPassword);
            txtPassword.KeyDown += TxtPassword_KeyDown;

            // Login button
            btnLogin = new Button
            {
                Text = "Sign In",
                Location = new Point(40, 340),
                Size = new Size(320, 45),
                Font = UIStyles.SubtitleFont
            };
            UIStyles.ApplyModernButton(btnLogin, UIStyles.PrimaryColor);
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;

            // Add controls to card
            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(lblSubtitle);
            panelCard.Controls.Add(lblError);
            panelCard.Controls.Add(lblUsername);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(lblPassword);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(btnLogin);

            // Add card to main panel
            if (panelMain != null && panelCard != null)
            {
                panelMain.Controls.Add(panelCard);
            }

            // Center card after form is shown
            this.Shown += (s, e) => CenterCard();
        }

        private void CenterCard()
        {
            if (panelCard != null && this.Width > 0 && this.Height > 0)
            {
                panelCard.Location = new Point(
                    Math.Max(0, (this.Width - panelCard.Width) / 2),
                    Math.Max(0, (this.Height - panelCard.Height) / 2)
                );
            }
        }

        private void BtnLogin_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(29, 78, 216); // Darker blue
            }
        }

        private void BtnLogin_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = UIStyles.PrimaryColor;
            }
        }

        private void TxtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            if (lblError != null)
            {
                lblError.Visible = false;
                lblError.Text = "";
            }

            if (txtUsername == null || txtPassword == null || 
                string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Please enter both username and password.");
                return;
            }

            AuthService authService = new AuthService();
            User? loggedInUser = authService.Login(txtUsername.Text, txtPassword.Text);

            if (loggedInUser != null)
            {
                try
                {
                    this.Hide();
                    ModernDashboardForm dashboard = new ModernDashboardForm(loggedInUser);
                    dashboard.ShowDialog();
                    this.Show();
                    if (txtUsername != null && txtPassword != null)
                    {
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                    if (lblError != null)
                    {
                        lblError.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            else
            {
                ShowError("Invalid username or password.");
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void ShowError(string message)
        {
            if (lblError != null)
            {
                lblError.Text = message;
                lblError.Visible = true;
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (panelCard != null)
            {
                CenterCard();
            }
        }
    }
}
