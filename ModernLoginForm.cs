using WinFormsApp1.services;
using WinFormsApp1.Models;
using Guna.UI2.WinForms;
using WinFormsApp1.Utils;

namespace WinFormsApp1
{
    public partial class ModernLoginForm : Form
    {
        private Guna2Panel? panelCard;
        private Label? lblTitle;
        private Label? lblSubtitle;
        private Label? lblError;
        private Guna2Panel? panelError;
        private Guna2TextBox? txtUsername;
        private Guna2TextBox? txtPassword;
        private Guna2Button? btnLogin;
        private Guna2Panel? panelMain;
        private Guna2CheckBox? chkShowPassword;
        private LinkLabel? lnkForgot;

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
            // Reset in case designer added controls
            this.Controls.Clear();

            this.BackColor = Color.FromArgb(246, 247, 251);
            this.Text = "Login - Loan Management System";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(520, 680);
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.KeyPreview = true;

            panelMain = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                FillColor = Color.FromArgb(246, 247, 251)
            };
            this.Controls.Add(panelMain);

            panelCard = new Guna2Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(420, 0),
                MaximumSize = new Size(460, 0),
                BackColor = Color.Transparent,
                FillColor = Color.White,
                BorderRadius = 22,
                Padding = new Padding(36, 30, 36, 28)
            };
            panelCard.ShadowDecoration.Enabled = true;
            panelCard.ShadowDecoration.Depth = 18;
            panelCard.ShadowDecoration.Color = Color.FromArgb(120, 120, 120);
            panelCard.ShadowDecoration.Shadow = new Padding(0, 0, 0, 10);

            // Layout container (prevents overlap + keeps spacing consistent)
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                RowCount = 10
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // Header (icon + titles)
            var header = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 3,
                Margin = new Padding(0, 0, 0, 14)
            };
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            var logo = new PictureBox
            {
                Size = new Size(44, 44),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Image = Mdl2IconHelper.RenderGlyph(Mdl2IconHelper.Home, 28, Color.FromArgb(37, 99, 235)),
                Margin = new Padding(0, 0, 0, 10)
            };

            lblTitle = new Label
            {
                Text = "Welcome back",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 2)
            };

            lblSubtitle = new Label
            {
                Text = "Sign in to continue",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(107, 114, 128),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 0)
            };

            header.Controls.Add(logo, 0, 0);
            header.Controls.Add(lblTitle, 0, 1);
            header.Controls.Add(lblSubtitle, 0, 2);

            lblError = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(185, 28, 28),
                AutoSize = true,
                Margin = new Padding(10, 8, 10, 8)
            };

            panelError = new Guna2Panel
            {
                Visible = false,
                FillColor = Color.FromArgb(254, 242, 242),
                BorderColor = Color.FromArgb(254, 202, 202),
                BorderThickness = 1,
                BorderRadius = 12,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 14)
            };
            panelError.Controls.Add(lblError);

            Label lblUsername = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 81),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 6)
            };

            txtUsername = new Guna2TextBox
            {
                Dock = DockStyle.Top,
                Height = 46,
                Font = new Font("Segoe UI", 11F),
                FillColor = Color.FromArgb(249, 250, 251),
                BorderColor = Color.FromArgb(229, 231, 235),
                BorderThickness = 1,
                BorderRadius = 12,
                PlaceholderText = "Enter your username",
                Cursor = Cursors.IBeam,
                Margin = new Padding(0, 0, 0, 14)
            };
            txtUsername.IconLeft = Mdl2IconHelper.RenderGlyph(Mdl2IconHelper.Contact, 18, Color.FromArgb(107, 114, 128));
            txtUsername.IconLeftOffset = new Point(8, 0);

            Label lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 81),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 6)
            };

            txtPassword = new Guna2TextBox
            {
                Dock = DockStyle.Top,
                Height = 46,
                Font = new Font("Segoe UI", 11F),
                FillColor = Color.FromArgb(249, 250, 251),
                BorderColor = Color.FromArgb(229, 231, 235),
                BorderThickness = 1,
                BorderRadius = 12,
                PlaceholderText = "Enter your password",
                PasswordChar = '●',
                UseSystemPasswordChar = true,
                Cursor = Cursors.IBeam,
                Margin = new Padding(0, 0, 0, 10)
            };
            txtPassword.KeyDown += TxtPassword_KeyDown;
            txtPassword.IconLeft = Mdl2IconHelper.RenderGlyph(Mdl2IconHelper.Lock, 18, Color.FromArgb(107, 114, 128));
            txtPassword.IconLeftOffset = new Point(8, 0);

            var optionsRow = new Panel
            {
                Dock = DockStyle.Top,
                Height = 28,
                Margin = new Padding(0, 0, 0, 18)
            };

            chkShowPassword = new Guna2CheckBox
            {
                Text = "Show password",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(75, 85, 99),
                CheckedState = { FillColor = Color.FromArgb(37, 99, 235) },
                UncheckedState = { FillColor = Color.White, BorderColor = Color.FromArgb(209, 213, 219) },
                Location = new Point(0, 4),
                AutoSize = true
            };
            chkShowPassword.CheckedChanged += (s, e) =>
            {
                if (txtPassword != null)
                    txtPassword.UseSystemPasswordChar = !(chkShowPassword?.Checked ?? false);
            };

            lnkForgot = new LinkLabel
            {
                Text = "Forgot password?",
                AutoSize = true,
                LinkColor = Color.FromArgb(37, 99, 235),
                ActiveLinkColor = Color.FromArgb(29, 78, 216),
                VisitedLinkColor = Color.FromArgb(37, 99, 235),
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(0, 4),
                TextAlign = ContentAlignment.MiddleRight
            };
            lnkForgot.Click += (s, e) =>
            {
                MessageBox.Show("Please contact the administrator to reset your password.", "Password Reset",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Right align the link within the options row
            optionsRow.Controls.Add(chkShowPassword);
            optionsRow.Controls.Add(lnkForgot);
            optionsRow.Resize += (s, e) =>
            {
                if (lnkForgot != null)
                    lnkForgot.Left = Math.Max(0, optionsRow.Width - lnkForgot.Width);
            };

            btnLogin = new Guna2Button
            {
                Text = "Sign In",
                Dock = DockStyle.Top,
                Height = 48,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                FillColor = Color.FromArgb(37, 99, 235),
                BorderRadius = 14,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 0, 10)
            };
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += (s, e) => { if (btnLogin != null) btnLogin.FillColor = Color.FromArgb(29, 78, 216); };
            btnLogin.MouseLeave += (s, e) => { if (btnLogin != null) btnLogin.FillColor = Color.FromArgb(37, 99, 235); };

            var footer = new Label
            {
                Text = "Tip: Press Enter to sign in",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(156, 163, 175),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 0)
            };

            layout.Controls.Add(header);
            layout.Controls.Add(panelError);
            layout.Controls.Add(lblUsername);
            layout.Controls.Add(txtUsername);
            layout.Controls.Add(lblPassword);
            layout.Controls.Add(txtPassword);
            layout.Controls.Add(optionsRow);
            layout.Controls.Add(btnLogin);
            layout.Controls.Add(footer);

            panelCard.Controls.Add(layout);

            if (panelMain != null && panelCard != null)
                panelMain.Controls.Add(panelCard);

            // Better UX: Enter triggers sign-in
            this.AcceptButton = btnLogin;

            this.Shown += (s, e) => CenterCard();
        }

        private void CenterCard()
        {
            if (panelCard != null && this.Width > 0 && this.Height > 0)
            {
                // Ensure layout is measured before centering
                panelCard.PerformLayout();
                panelCard.Location = new Point(
                    Math.Max(0, (this.Width - panelCard.Width) / 2),
                    Math.Max(0, (this.Height - panelCard.Height) / 2)
                );
            }
        }

        private void TxtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnLogin_Click(sender, e);
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            if (lblError != null && panelError != null)
            {
                lblError.Text = "";
                panelError.Visible = false;
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
                    if (lblError != null) lblError.Visible = false;
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
                txtPassword?.Clear();
                txtUsername?.Focus();
            }
        }

        private void ShowError(string message)
        {
            if (lblError != null && panelError != null)
            {
                lblError.Text = message;
                panelError.Visible = true;
            }
            else
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterCard();
        }
    }
}
