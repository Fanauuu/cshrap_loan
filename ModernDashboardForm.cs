using System.Linq;
using System.Drawing.Drawing2D;
using WinFormsApp1.Models;
using WinFormsApp1.services;
using WinFormsApp1.Utils;
using WinFormsApp1.Repository;
using WinFormsApp1.Components;
using static WinFormsApp1.Utils.IconHelper;

namespace WinFormsApp1
{
    public partial class ModernDashboardForm : Form
    {
        private User _currentUser;
        private AuthService _authService;
        private Panel? panelSidebar;
        private Panel? panelTopBar;
        private Panel? panelContent;
        private Button? btnDashboard;
        private Button? btnCustomers;
        private Button? btnLoanTerms;
        private Button? btnLoanContracts;
        private Button? btnUsers;
        private Button? btnLogout;
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

            // Sidebar - Minimalist White Design
            panelSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                BackColor = Color.White,
                Padding = new Padding(0)
            };
            panelSidebar.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(UIStyles.BorderColor, 1))
                {
                    e.Graphics.DrawLine(borderPen, panelSidebar.Width - 1, 0, panelSidebar.Width - 1, panelSidebar.Height);
                }
            };

            // Sidebar Header - Clean, minimal
            Panel sidebarHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(20, 20, 20, 20)
            };

            Label lblAppName = new Label
            {
                Text = "Loan Management",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(20, 25)
            };

            sidebarHeader.Controls.Add(lblAppName);
            panelSidebar.Controls.Add(sidebarHeader);

            // Menu Items - Clean, modern design
            int menuTop = 20;
            int menuHeight = 48;
            int menuSpacing = 4;

            btnDashboard = CreateModernMenuButton("Dashboard", menuTop, true);
            menuTop += menuHeight + menuSpacing;

            btnCustomers = CreateModernMenuButton("Customers", menuTop);
            menuTop += menuHeight + menuSpacing;

            btnLoanTerms = CreateModernMenuButton("Loan Terms", menuTop);
            menuTop += menuHeight + menuSpacing;

            btnLoanContracts = CreateModernMenuButton("Loan Contracts", menuTop);
            menuTop += menuHeight + menuSpacing;

            // Removed Repayment Schedule as per requirements

            // Admin only menu
            if (_authService.IsAdmin(_currentUser))
            {
                btnUsers = CreateModernMenuButton("User Management", menuTop);
                menuTop += menuHeight + menuSpacing;
            }

            // Logout button at bottom
            btnLogout = CreateModernMenuButton("Logout", 600, false, true);

            // Top Bar - Professional Header
            panelTopBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = UIStyles.CardColor,
                Padding = new Padding(25, 15, 25, 15)
            };
            // Add subtle border at bottom
            panelTopBar.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(UIStyles.BorderColor, 1))
                {
                    e.Graphics.DrawLine(borderPen, 0, panelTopBar.Height - 1, panelTopBar.Width, panelTopBar.Height - 1);
                }
            };

            // User Info (Left)
            lblUserInfo = new Label
            {
                Text = $"👤 {_currentUser.FullName} ({_currentUser.Role})",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(25, 22)
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

            panelTopBar.Controls.Add(lblUserInfo);
            panelTopBar.Controls.Add(lblDate);

            // Update date label position
            panelTopBar.Resize += (s, e) =>
            {
                if (lblDate != null)
                {
                    lblDate.Location = new Point(panelTopBar.Width - lblDate.Width - 25, 22);
                }
            };
            
            // Set initial position
            lblDate.Location = new Point(panelTopBar.Width - lblDate.Width - 25, 22);

            // Content Area
            panelContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UIStyles.BackgroundColor,
                Padding = new Padding(20),
                AutoScroll = false,
                MaximumSize = new Size(0, 0)
            };

            // Add panels to form (order matters for z-index)
            this.Controls.Add(panelContent);
            this.Controls.Add(panelTopBar);
            this.Controls.Add(panelSidebar);

            // Position logout button at bottom
            this.Resize += (s, e) =>
            {
                if (btnLogout != null && panelSidebar != null)
                {
                    btnLogout.Location = new Point(10, panelSidebar.Height - 70);
                }
            };
            
            // Set initial logout button position
            if (btnLogout != null && panelSidebar != null)
            {
                btnLogout.Location = new Point(10, panelSidebar.Height - 70);
            }

            // Set initial active button
            SetActiveButton(btnDashboard);
        }

        private Button CreateModernMenuButton(string text, int top, bool isActive = false, bool isLogout = false)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(12, top),
                Size = new Size(236, 48),
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                ForeColor = isLogout ? UIStyles.DangerColor : (isActive ? UIStyles.PrimaryColor : UIStyles.TextColor),
                BackColor = isActive ? Color.FromArgb(240, 245, 255) : Color.Transparent,
                Cursor = Cursors.Hand,
                Padding = new Padding(20, 0, 0, 0)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = isLogout ? Color.FromArgb(255, 240, 240) : Color.FromArgb(248, 250, 252);

            // Add rounded corners effect
            btn.Paint += (s, e) =>
            {
                if (isActive)
                {
                    Graphics g = e.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                    using (GraphicsPath path = UIStyles.GetRoundedRectangle(rect, 12))
                    {
                        using (SolidBrush brush = new SolidBrush(btn.BackColor))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                }
            };

            panelSidebar?.Controls.Add(btn);
            return btn;
        }

        private void SetActiveButton(Button? activeButton)
        {
            if (activeButton == null || panelSidebar == null) return;

            // Reset all buttons
            foreach (Control control in panelSidebar.Controls)
            {
                if (control is Button btn && btn != btnLogout && btn != activeButton)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = UIStyles.TextColor;
                    btn.Invalidate();
                }
            }

            // Set active button
            if (activeButton != btnLogout)
            {
                activeButton.BackColor = Color.FromArgb(240, 245, 255);
                activeButton.ForeColor = UIStyles.PrimaryColor;
                activeButton.Invalidate();
            }
        }

        private void LoadDashboard()
        {
            if (panelContent == null) return;
            
            panelContent.Controls.Clear();
            panelContent.AutoScroll = false;

            // Sparkline Cards - Modern SaaS Design
            LoadSparklineCards();

            // Charts Section
            LoadCharts();

            // Attach menu button events
            if (btnDashboard != null)
            {
                btnDashboard.Click += (s, e) => { SetActiveButton(btnDashboard!); LoadDashboard(); };
            }
            if (btnCustomers != null)
            {
                btnCustomers.Click += (s, e) => { SetActiveButton(btnCustomers!); ShowCustomers(); };
            }
            if (btnLoanTerms != null)
            {
                btnLoanTerms.Click += (s, e) => { SetActiveButton(btnLoanTerms!); ShowLoanTerms(); };
            }
            if (btnLoanContracts != null)
            {
                btnLoanContracts.Click += (s, e) => { SetActiveButton(btnLoanContracts!); ShowLoanContracts(); };
            }
            
            if (_authService.IsAdmin(_currentUser) && btnUsers != null)
            {
                btnUsers.Click += (s, e) => { SetActiveButton(btnUsers!); ShowUserManagement(); };
            }

            if (btnLogout != null)
            {
                btnLogout.Click += BtnLogout_Click;
            }
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
