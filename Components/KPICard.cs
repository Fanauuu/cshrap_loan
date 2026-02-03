using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinFormsApp1.Utils;

namespace WinFormsApp1.Components
{
    /// <summary>
    /// Modern, Clean KPI Card Component
    /// </summary>
    public class KPICard : CardPanel
    {
        private Label? _lblIcon;
        private Label? _lblTitle;
        private Label? _lblValue;
        private Label? _lblSubtitle;
        private Panel? _iconPanel;
        private Panel? _badgePanel;
        private Label? _lblBadge;
        private Color _accentColor;
        private string _icon = "";
        private string _title = "";
        private string _value = "";
        private string _subtitle = "";
        private string _changePercent = "";
        private bool _isPositiveTrend = true;
        private bool _isPrimary = false;

        public KPICard()
        {
            _accentColor = UIStyles.PrimaryColor;
            this.Size = new Size(240, 150);
            this.Padding = new Padding(0);
            this.CornerRadius = 12;
            InitializeCard();
        }

        public void SetData(string icon, string title, string value, Color accentColor, 
            string subtitle = "", string changePercent = "", bool isPositiveTrend = true, bool isPrimary = false)
        {
            _icon = icon;
            _title = title;
            _value = value;
            _accentColor = accentColor;
            _subtitle = subtitle;
            _changePercent = changePercent;
            _isPositiveTrend = isPositiveTrend;
            _isPrimary = isPrimary;
            UpdateCard();
        }

        private void InitializeCard()
        {
            // Icon panel (top-left) - smaller, cleaner
            _iconPanel = new Panel
            {
                Size = new Size(44, 44),
                Location = new Point(20, 20),
                BackColor = Color.Transparent
            };
            _iconPanel.Paint += IconPanel_Paint;

            _lblIcon = new Label
            {
                Text = _icon,
                Font = new Font("Segoe UI Emoji", 20F),
                AutoSize = false,
                Size = new Size(44, 44),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 0),
                ForeColor = _isPrimary ? Color.White : _accentColor,
                UseCompatibleTextRendering = true
            };
            _iconPanel.Controls.Add(_lblIcon);

            // Change badge (top-right) - cleaner pill shape
            _badgePanel = new Panel
            {
                Size = new Size(55, 22),
                Location = new Point(this.Width - 75, 20),
                BackColor = Color.Transparent
            };
            _badgePanel.Paint += BadgePanel_Paint;

            _lblBadge = new Label
            {
                Text = _changePercent,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(55, 22),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 0)
            };
            _badgePanel.Controls.Add(_lblBadge);

            // Title (below icon, compact)
            _lblTitle = new Label
            {
                Text = _title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = _isPrimary ? Color.FromArgb(220, 255, 255, 255) : UIStyles.TextSecondary,
                AutoSize = false,
                Size = new Size(this.Width - 40, 18),
                Location = new Point(20, 70),
                TextAlign = ContentAlignment.TopLeft
            };

            // Value (large, prominent)
            _lblValue = new Label
            {
                Text = _value,
                Font = new Font("Segoe UI", 30F, FontStyle.Bold),
                ForeColor = _isPrimary ? Color.White : UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(20, 95)
            };

            // Subtitle (below value, single line)
            _lblSubtitle = new Label
            {
                Text = _subtitle,
                Font = new Font("Segoe UI", 9F),
                ForeColor = _isPrimary ? Color.FromArgb(200, 255, 255, 255) : UIStyles.TextSecondary,
                AutoSize = false,
                Size = new Size(this.Width - 40, 16),
                Location = new Point(20, 130),
                TextAlign = ContentAlignment.TopLeft
            };

            this.Controls.Add(_iconPanel);
            this.Controls.Add(_badgePanel);
            this.Controls.Add(_lblTitle);
            this.Controls.Add(_lblValue);
            this.Controls.Add(_lblSubtitle);
        }

        private void IconPanel_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, _iconPanel!.Width - 1, _iconPanel.Height - 1);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                Color iconBgColor;
                if (_isPrimary)
                {
                    iconBgColor = Color.FromArgb(120, 255, 255, 255); // White with transparency for primary
                }
                else
                {
                    // Light background matching accent color
                    iconBgColor = Color.FromArgb(245, _accentColor.R, _accentColor.G, _accentColor.B);
                }
                using (SolidBrush brush = new SolidBrush(iconBgColor))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        private void BadgePanel_Paint(object? sender, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(_changePercent)) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, _badgePanel!.Width - 1, _badgePanel.Height - 1);
            int radius = 11;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y);
                path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom);
                path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom);
                path.AddLine(rect.X, rect.Bottom, rect.X, rect.Y + radius);
                path.CloseFigure();

                Color badgeColor = _isPositiveTrend ? UIStyles.SuccessColor : UIStyles.DangerColor;
                using (SolidBrush brush = new SolidBrush(badgeColor))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (_isPrimary)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                using (GraphicsPath path = UIStyles.GetRoundedRectangle(rect, this.CornerRadius))
                {
                    // Modern gradient background for primary card
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect, 
                        Color.FromArgb(59, 130, 246), // Blue
                        Color.FromArgb(139, 92, 246), // Purple
                        LinearGradientMode.Horizontal))
                    {
                        g.FillPath(brush, path);
                    }
                }
            }
        }

        private void UpdateCard()
        {
            if (_lblIcon != null)
            {
                _lblIcon.Text = _icon;
                _lblIcon.ForeColor = _isPrimary ? Color.White : _accentColor;
            }
            if (_lblTitle != null)
            {
                _lblTitle.Text = _title;
                _lblTitle.ForeColor = _isPrimary ? Color.FromArgb(220, 255, 255, 255) : UIStyles.TextSecondary;
            }
            if (_lblValue != null)
            {
                _lblValue.Text = _value;
                _lblValue.ForeColor = _isPrimary ? Color.White : UIStyles.TextColor;
            }
            if (_lblSubtitle != null)
            {
                _lblSubtitle.Text = _subtitle;
                _lblSubtitle.ForeColor = _isPrimary ? Color.FromArgb(200, 255, 255, 255) : UIStyles.TextSecondary;
            }
            if (_lblBadge != null)
            {
                _lblBadge.Text = _changePercent;
                _lblBadge.Visible = !string.IsNullOrEmpty(_changePercent);
            }
            if (_badgePanel != null)
            {
                _badgePanel.Visible = !string.IsNullOrEmpty(_changePercent);
            }
            if (_iconPanel != null) _iconPanel.Invalidate();
            if (_badgePanel != null) _badgePanel.Invalidate();
            this.Invalidate();
        }
    }
}
