using System.Linq;
using System.Drawing.Drawing2D;
using WinFormsApp1.Models;
using WinFormsApp1.services;
using WinFormsApp1.Utils;
using WinFormsApp1.Repository;
using WinFormsApp1.Components;
using static WinFormsApp1.Utils.IconHelper;
using Guna.UI2.WinForms;

namespace WinFormsApp1
{
    public partial class ModernDashboardForm : Form
    {
        private User _currentUser;
        private AuthService _authService;
        private Guna2Panel? panelSidebar;
        private Guna2Panel? panelTopBar;
        private Guna2Panel? panelContent;
        private Guna2Panel? panelSidebarNav;
        private Guna2Panel? panelSidebarFooter;
        private Guna2Panel? activeNavIndicator;
        private Label? lblPageTitle;
        private Guna2Button? btnDashboard;
        private Guna2Button? btnCustomers;
        private Guna2Button? btnLoanTerms;
        private Guna2Button? btnLoanContracts;
        private Guna2Button? btnUsers;
        private Guna2Button? btnLogout;
        private Label? lblUserInfo;
        private Label? lblDate;

        public ModernDashboardForm(User currentUser)
        {
            if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser), "Current user cannot be null");
            }

            InitializeComponent();
            _currentUser = currentUser;
            _authService = new AuthService();
            this.Load += ModernDashboardForm_Load;
        }

        private void ModernDashboardForm_Load(object? sender, EventArgs e)
        {
            try
            {
                InitializeModernUI();
                LoadDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard UI: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeModernUI()
        {
            this.Text = "Loan Management System";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = UIStyles.BackgroundColor;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.AutoScroll = false;
            this.MinimumSize = new Size(1366, 768);

            // Sidebar - Guna UI clean design
            panelSidebar = new Guna2Panel
            {
                Dock = DockStyle.Left,
                Width = 270,
                BackColor = Color.Transparent,
                FillColor = Color.White,
                BorderRadius = 0,
                BorderThickness = 0
            };
            panelSidebar.ShadowDecoration.Depth = 8;
            panelSidebar.ShadowDecoration.Enabled = true;
            panelSidebar.ShadowDecoration.Color = Color.FromArgb(180, 180, 180);

            Guna2Panel sidebarHeader = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 92,
                BackColor = Color.Transparent,
                FillColor = Color.White,
                BorderRadius = 0
            };

            Label lblAppName = new Label
            {
                Text = "Loan Management",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(18, 18)
            };

            Label lblAppTag = new Label
            {
                Text = "System",
                Font = new Font("Segoe UI", 10F),
                ForeColor = UIStyles.TextSecondary,
                AutoSize = true,
                Location = new Point(18, 52)
            };

            sidebarHeader.Controls.Add(lblAppName);
            sidebarHeader.Controls.Add(lblAppTag);
            panelSidebar.Controls.Add(sidebarHeader);

            // Sidebar Nav container
            panelSidebarNav = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Padding = new Padding(12, 10, 12, 10)
            };

            activeNavIndicator = new Guna2Panel
            {
                Size = new Size(4, 44),
                FillColor = UIStyles.PrimaryColor,
                BorderRadius = 2,
                Location = new Point(8, 18)
            };
            panelSidebarNav.Controls.Add(activeNavIndicator);

            int menuTop = 6;
            int menuHeight = 44;
            int menuSpacing = 6;

            btnDashboard = CreateModernMenuButton($"{Dashboard}  Dashboard", menuTop, true);
            menuTop += menuHeight + menuSpacing;

            btnCustomers = CreateModernMenuButton($"{Customers}  Customers", menuTop);
            menuTop += menuHeight + menuSpacing;

            btnLoanTerms = CreateModernMenuButton($"{LoanTerms}  Loan Terms", menuTop);
            menuTop += menuHeight + menuSpacing;

            btnLoanContracts = CreateModernMenuButton($"{LoanContracts}  Loan Contracts", menuTop);
            menuTop += menuHeight + menuSpacing;

            if (_authService.IsAdmin(_currentUser))
            {
                btnUsers = CreateModernMenuButton($"{UserManagement}  User Management", menuTop);
                menuTop += menuHeight + menuSpacing;
            }

            panelSidebar.Controls.Add(panelSidebarNav);

            panelSidebarFooter = new Guna2Panel
            {
                Dock = DockStyle.Bottom,
                Height = 90,
                FillColor = Color.White,
                Padding = new Padding(12, 10, 12, 12)
            };

            btnLogout = CreateModernMenuButton($"{Logout}  Logout", 0, false, true);
            btnLogout.Size = new Size(246, 44);
            btnLogout.Location = new Point(12, 10);
            panelSidebarFooter.Controls.Add(btnLogout);

            panelSidebar.Controls.Add(panelSidebarFooter);

            // Top Bar - Guna UI header
            panelTopBar = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 74,
                BackColor = Color.Transparent,
                FillColor = Color.White,
                BorderRadius = 0,
                BorderThickness = 0
            };
            panelTopBar.ShadowDecoration.Depth = 4;
            panelTopBar.ShadowDecoration.Enabled = true;
            panelTopBar.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);

            // Page title (left)
            lblPageTitle = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(22, 14)
            };

            string roleDisplay = string.IsNullOrWhiteSpace(_currentUser.Role)
                ? ""
                : char.ToUpperInvariant(_currentUser.Role[0]) + _currentUser.Role.Substring(1).ToLowerInvariant();

            // User Info (left, secondary)
            lblUserInfo = new Label
            {
                Text = $"• {_currentUser.FullName} ({roleDisplay})",
                Font = new Font("Segoe UI", 10F),
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(22, 42)
            };

            // Date (Right)
            lblDate = new Label
            {
                Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy | hh:mm tt"),
                Font = new Font("Segoe UI", 10F),
                ForeColor = UIStyles.TextSecondary,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            panelTopBar.Controls.Add(lblPageTitle);
            panelTopBar.Controls.Add(lblUserInfo);
            panelTopBar.Controls.Add(lblDate);

            panelTopBar.Resize += (s, e) =>
            {
                if (lblDate != null)
                    lblDate.Location = new Point(panelTopBar.Width - lblDate.Width - 25, 22);
            };
            lblDate.Location = new Point(panelTopBar.Width - lblDate.Width - 25, 22);

            // Content Area
            panelContent = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                FillColor = UIStyles.BackgroundColor,
                BorderRadius = 0,
                AutoScroll = false,
                MaximumSize = new Size(0, 0)
            };
            panelContent.Padding = new Padding(20);

            // Add panels to form (order matters for z-index)
            this.Controls.Add(panelContent);
            this.Controls.Add(panelTopBar);
            this.Controls.Add(panelSidebar);

            // Set initial active button
            SetActiveButton(btnDashboard);
            MoveActiveIndicator(btnDashboard);
        }

        private Guna2Button CreateModernMenuButton(string text, int top, bool isActive = false, bool isLogout = false)
        {
            var btn = new Guna2Button
            {
                Text = text,
                Location = new Point(12, top),
                Size = new Size(246, 44),
                TextAlign = HorizontalAlignment.Left,
                Font = new Font("Segoe UI", 11F),
                ForeColor = isLogout ? UIStyles.DangerColor : (isActive ? UIStyles.PrimaryColor : UIStyles.TextColor),
                FillColor = isActive ? Color.FromArgb(240, 245, 255) : Color.Transparent,
                BorderThickness = 0,
                BorderRadius = 12,
                Cursor = Cursors.Hand,
                TextOffset = new Point(20, 0)
            };
            btn.CheckedState.FillColor = Color.FromArgb(240, 245, 255);
            btn.CheckedState.ForeColor = UIStyles.PrimaryColor;
            if (isLogout)
                btn.HoverState.FillColor = Color.FromArgb(255, 240, 240);
            else
                btn.HoverState.FillColor = Color.FromArgb(248, 250, 252);
            if (isActive) btn.Checked = true;

            panelSidebarNav?.Controls.Add(btn);
            return btn;
        }

        private void SetActiveButton(Guna2Button? activeButton)
        {
            if (activeButton == null || panelSidebarNav == null) return;

            foreach (Control control in panelSidebarNav.Controls)
            {
                if (control is Guna2Button btn && btn != btnLogout && btn != activeButton)
                {
                    btn.Checked = false;
                    btn.FillColor = Color.Transparent;
                    btn.ForeColor = UIStyles.TextColor;
                    btn.Invalidate();
                }
            }

            if (activeButton != btnLogout)
            {
                activeButton.Checked = true;
                activeButton.FillColor = Color.FromArgb(240, 245, 255);
                activeButton.ForeColor = UIStyles.PrimaryColor;
                activeButton.Invalidate();
            }

            MoveActiveIndicator(activeButton);
        }

        private void MoveActiveIndicator(Guna2Button? activeButton)
        {
            if (activeButton == null || activeNavIndicator == null || panelSidebarNav == null) return;
            if (activeButton == btnLogout) return;

            activeNavIndicator.Location = new Point(8, activeButton.Top + (activeButton.Height - activeNavIndicator.Height) / 2);
            activeNavIndicator.BringToFront();
        }

        private void LoadDashboard()
        {
            if (panelContent == null) return;
            
            panelContent.Controls.Clear();
            panelContent.AutoScroll = true;

            // Sparkline Cards - Modern SaaS Design
            LoadSparklineCards();

            // Charts Section
            LoadCharts();

            // Extra sections (make dashboard richer)
            LoadRecentContracts();

            // Attach menu button events
            if (btnDashboard != null)
            {
                btnDashboard.Click += (s, e) => { SetActiveButton(btnDashboard!); SetPageTitle("Dashboard"); LoadDashboard(); };
            }
            if (btnCustomers != null)
            {
                btnCustomers.Click += (s, e) => { SetActiveButton(btnCustomers!); SetPageTitle("Customers"); ShowCustomers(); };
            }
            if (btnLoanTerms != null)
            {
                btnLoanTerms.Click += (s, e) => { SetActiveButton(btnLoanTerms!); SetPageTitle("Loan Terms"); ShowLoanTerms(); };
            }
            if (btnLoanContracts != null)
            {
                btnLoanContracts.Click += (s, e) => { SetActiveButton(btnLoanContracts!); SetPageTitle("Loan Contracts"); ShowLoanContracts(); };
            }
            
            if (_authService.IsAdmin(_currentUser) && btnUsers != null)
            {
                btnUsers.Click += (s, e) => { SetActiveButton(btnUsers!); SetPageTitle("User Management"); ShowUserManagement(); };
            }

            if (btnLogout != null)
            {
                btnLogout.Click += BtnLogout_Click;
            }
        }

        private void SetPageTitle(string title)
        {
            if (lblPageTitle != null)
                lblPageTitle.Text = title;
        }

        private void LoadRecentContracts()
        {
            if (panelContent == null) return;

            int y = 180 + 260 + 18 + 240 + 26;
            int x = 20;
            int width = panelContent.Width - 40;

            CardPanel recentPanel = new CardPanel
            {
                Location = new Point(x, y),
                Size = new Size(width, 260),
                CornerRadius = 15,
                ShowShadow = true
            };

            var lbl = new Label
            {
                Text = "Recent Loan Contracts",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(18, 14)
            };
            recentPanel.Controls.Add(lbl);

            var grid = new DataGridView
            {
                Location = new Point(18, 48),
                Size = new Size(width - 36, 200),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 44,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };
            grid.RowTemplate.Height = 44;
            DataGridViewStyleHelper.ApplyCleanStyle(grid);
            grid.RowHeadersVisible = false;
            grid.GridColor = Color.FromArgb(229, 231, 235);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            grid.DefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(249, 250, 251),
                ForeColor = Color.FromArgb(31, 41, 55),
                SelectionBackColor = Color.FromArgb(243, 244, 246),
                SelectionForeColor = Color.FromArgb(31, 41, 55),
                Font = new Font("Segoe UI", 10F),
                Padding = new Padding(12, 0, 12, 0)
            };

            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "LC", HeaderText = "LC", FillWeight = 10 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "Customer", FillWeight = 40 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Amount", HeaderText = "Amount", FillWeight = 18 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", FillWeight = 16 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date", FillWeight = 16 });

            try
            {
                var repo = new LoanContractRepository();
                var contracts = repo.GetAllLoanContracts()
                    .OrderByDescending(c => c.LoanDate)
                    .Take(6)
                    .ToList();

                foreach (var c in contracts)
                {
                    grid.Rows.Add(
                        c.LC,
                        c.CustomerName ?? "",
                        c.LoanAmount.ToString("C0"),
                        c.Status ?? "",
                        c.LoanDate.ToString("yyyy-MM-dd")
                    );
                }
            }
            catch
            {
                // ignore
            }

            recentPanel.Controls.Add(grid);
            panelContent.Controls.Add(recentPanel);
        }

        private void LoadSparklineCards()
        {
            try
            {
                if (panelContent == null) return;

                var customerRepo = new CustomerRepository();
                var contractRepo = new LoanContractRepository();
                var scheduleRepo = new LoanRepaymentScheduleRepository();

                var customers = customerRepo?.GetAllCustomers() ?? new List<Customer>();
                var contracts = contractRepo?.GetAllLoanContracts() ?? new List<LoanContract>();
                var activeContracts = contracts.Count(c => c.Status == "Active");
                var overduePayments = scheduleRepo?.GetOverduePayments()?.Count ?? 0;
                var totalLoanAmount = contracts.Sum(c => c.LoanAmount);

                // Calculate percentage changes
                int prevCustomers = Math.Max(0, customers.Count - 2);
                int prevActiveLoans = Math.Max(0, activeContracts - 1);
                int prevContracts = Math.Max(0, contracts.Count - 1);
                int prevOverdue = overduePayments > 0 ? overduePayments + 1 : 0;
                decimal prevAmount = totalLoanAmount * 0.95m;

                double customerChange = prevCustomers > 0 ? ((customers.Count - prevCustomers) / (double)prevCustomers) * 100 : 0;
                double loanChange = prevActiveLoans > 0 ? ((activeContracts - prevActiveLoans) / (double)prevActiveLoans) * 100 : 0;
                double contractChange = prevContracts > 0 ? ((contracts.Count - prevContracts) / (double)prevContracts) * 100 : 0;
                double overdueChange = prevOverdue > 0 ? ((overduePayments - prevOverdue) / (double)prevOverdue) * 100 : (overduePayments == 0 ? 0 : -100);
                double amountChange = prevAmount > 0 ? ((double)(totalLoanAmount - prevAmount) / (double)prevAmount) * 100 : 0;

                // Generate 7-day trend data (simplified - using random variation)
                Random rand = new Random();
                List<double> GenerateTrend(double baseValue, double change)
                {
                    List<double> trend = new List<double>();
                    for (int i = 0; i < 7; i++)
                    {
                        double variation = baseValue * (change / 100) * (i / 6.0) + baseValue * (rand.NextDouble() * 0.1 - 0.05);
                        trend.Add(Math.Max(0, variation));
                    }
                    return trend;
                }

                // Calculate card dimensions
                int availableWidth = panelContent.Width - 40;
                int spacing = 20;
                int cardWidth = (availableWidth - (spacing * 4)) / 5;
                int cardHeight = 140;
                int startX = 20;
                int startY = 20;

                // Create Sparkline Cards
                CreateSparklineCard("Total Amount", totalLoanAmount.ToString("C0"), amountChange, amountChange >= 0,
                    Color.FromArgb(59, 130, 246), GenerateTrend((double)totalLoanAmount, amountChange),
                    startX, startY, cardWidth, cardHeight);
                startX += cardWidth + spacing;

                CreateSparklineCard("Total Contracts", contracts.Count.ToString("N0"), contractChange, contractChange >= 0,
                    Color.FromArgb(245, 158, 11), GenerateTrend(contracts.Count, contractChange),
                    startX, startY, cardWidth, cardHeight);
                startX += cardWidth + spacing;

                CreateSparklineCard("Active Loans", activeContracts.ToString("N0"), loanChange, loanChange >= 0,
                    Color.FromArgb(16, 185, 129), GenerateTrend(activeContracts, loanChange),
                    startX, startY, cardWidth, cardHeight);
                startX += cardWidth + spacing;

                CreateSparklineCard("Total Customers", customers.Count.ToString("N0"), customerChange, customerChange >= 0,
                    Color.FromArgb(59, 130, 246), GenerateTrend(customers.Count, customerChange),
                    startX, startY, cardWidth, cardHeight);
                startX += cardWidth + spacing;

                CreateSparklineCard("Late Payments", overduePayments.ToString("N0"), overdueChange, overdueChange < 0,
                    Color.FromArgb(239, 68, 68), GenerateTrend(overduePayments, overdueChange),
                    startX, startY, cardWidth, cardHeight);
            }
            catch
            {
                // Silently handle errors
            }
        }

        private void CreateSparklineCard(string title, string value, double percentChange, bool isPositive,
            Color accentColor, List<double> trendData, int x, int y, int width, int height)
        {
            if (panelContent == null) return;

            SparklineCard card = new SparklineCard
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                CornerRadius = 15
            };
            card.SetData(title, value, percentChange, isPositive, accentColor, trendData);
            panelContent.Controls.Add(card);
        }

        private string FormatChangePercent(double change)
        {
            if (change == 0) return "";
            string sign = change > 0 ? "+" : "";
            return $"{sign}{change:F1}%";
        }

        private void CreateKPICard(string icon, string title, string value, Color accentColor, 
            string subtitle, string changePercent, bool isPositiveTrend, int x, int y, int width, int height, bool isPrimary = false)
        {
            if (panelContent == null) return;

            KPICard card = new KPICard
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                CornerRadius = 12,
                ShowShadow = true
            };
            card.SetData(icon, title, value, accentColor, subtitle, changePercent, isPositiveTrend, isPrimary);
            panelContent.Controls.Add(card);
        }

        private void LoadCharts()
        {
            try
            {
                if (panelContent == null) return;

                var contractRepo = new LoanContractRepository();
                var scheduleRepo = new LoanRepaymentScheduleRepository();
                var contracts = contractRepo?.GetAllLoanContracts() ?? new List<LoanContract>();

                int chartY = 180;
                int chartWidth = (panelContent.Width - 50) / 2;
                int chartHeight = 260;
                int chartSpacing = 18;

                // Modern Chart Panels with 15px radius
                CardPanel chartPanel1 = new CardPanel
                {
                    Location = new Point(20, chartY),
                    Size = new Size(chartWidth, chartHeight),
                    CornerRadius = 15,
                    ShowShadow = true
                };

                var statusData = new List<ChartDataPoint>();
                var activeCount = contracts.Count(c => c.Status == "Active");
                var closedCount = contracts.Count(c => c.Status == "Closed");
                var pendingCount = contracts.Count(c => c.Status == "Pending");

                statusData.Add(new ChartDataPoint { Label = "Active", Value = activeCount });
                statusData.Add(new ChartDataPoint { Label = "Closed", Value = closedCount });
                statusData.Add(new ChartDataPoint { Label = "Pending", Value = pendingCount });

                ModernChart statusChart = new ModernChart
                {
                    Location = new Point(15, 15),
                    Size = new Size(chartWidth - 30, chartHeight - 30),
                    CornerRadius = 15
                };
                statusChart.SetData(statusData, "Loan Status Overview", Color.FromArgb(59, 130, 246), ModernChart.ChartType.Bar);

                chartPanel1.Controls.Add(statusChart);
                panelContent.Controls.Add(chartPanel1);

                // Payment Status Chart (Right)
                CardPanel chartPanel2 = new CardPanel
                {
                    Location = new Point(chartWidth + chartSpacing + 20, chartY),
                    Size = new Size(chartWidth, chartHeight),
                    CornerRadius = 15,
                    ShowShadow = true
                };

                var paymentData = new List<ChartDataPoint>();
                var allSchedules = scheduleRepo?.GetAllSchedules() ?? new List<LoanRepaymentSchedule>();
                var paidCount = allSchedules.Count(s => s.Action == "Paid");
                var pendingCount2 = allSchedules.Count(s => s.Action == "Pending" || s.Action == "Unpaid");
                var lateCount = allSchedules.Count(s => s.Action == "Late");

                paymentData.Add(new ChartDataPoint { Label = "Paid", Value = paidCount });
                paymentData.Add(new ChartDataPoint { Label = "Pending", Value = pendingCount2 });
                paymentData.Add(new ChartDataPoint { Label = "Late", Value = lateCount });

                ModernChart paymentChart = new ModernChart
                {
                    Location = new Point(15, 15),
                    Size = new Size(chartWidth - 30, chartHeight - 30),
                    CornerRadius = 15
                };
                paymentChart.SetData(paymentData, "Payment Status", Color.FromArgb(16, 185, 129), ModernChart.ChartType.Bar);

                chartPanel2.Controls.Add(paymentChart);
                panelContent.Controls.Add(chartPanel2);

                // Monthly Loan Activity Chart (Bottom, Full Width) - Area Chart
                CardPanel chartPanel3 = new CardPanel
                {
                    Location = new Point(20, chartY + chartHeight + chartSpacing),
                    Size = new Size(panelContent.Width - 40, 240),
                    CornerRadius = 15,
                    ShowShadow = true
                };

                var monthlyData = new List<ChartDataPoint>();
                for (int i = 5; i >= 0; i--)
                {
                    DateTime month = DateTime.Now.AddMonths(-i);
                    int monthContracts = contracts.Count(c => 
                        c.LoanDate.Year == month.Year && c.LoanDate.Month == month.Month);
                    monthlyData.Add(new ChartDataPoint 
                    { 
                        Label = month.ToString("MMM"), 
                        Value = monthContracts 
                    });
                }

                ModernChart monthlyChart = new ModernChart
                {
                    Location = new Point(15, 15),
                    Size = new Size(panelContent.Width - 90, 210),
                    CornerRadius = 15
                };
                monthlyChart.SetData(monthlyData, "Monthly Loan Activity (Last 6 Months)", Color.FromArgb(245, 158, 11), ModernChart.ChartType.Area);

                chartPanel3.Controls.Add(monthlyChart);
                panelContent.Controls.Add(chartPanel3);
            }
            catch
            {
                // Silently handle errors
            }
        }

        private void ShowCustomers()
        {
            try
            {
                CustomerManagementForm form = new CustomerManagementForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoanTerms()
        {
            try
            {
                LoanTermManagementForm form = new LoanTermManagementForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading loan terms: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoanContracts()
        {
            try
            {
                LoanContractManagementForm form = new LoanContractManagementForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading loan contracts: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ShowUserManagement()
        {
            try
            {
                UserManagementForm form = new UserManagementForm(_currentUser);
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user management: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
