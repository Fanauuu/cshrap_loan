using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Utils;

namespace WinFormsApp1.Components
{
    /// <summary>
    /// Modern Sparkline Card with mini trend chart
    /// </summary>
    public class SparklineCard : Panel
    {
        private Label? _lblTitle;
        private Label? _lblValue;
        private Label? _lblPercent;
        private Panel? _sparklinePanel;
        private List<double> _trendData = new List<double>();
        private Color _accentColor;
        private string _title = "";
        private string _value = "";
        private double _percentChange = 0;
        private bool _isPositive = true;

        public SparklineCard()
        {
            _accentColor = UIStyles.PrimaryColor;
            this.Size = new Size(240, 140);
            this.BackColor = Color.White;
            this.CornerRadius = 15;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            InitializeCard();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int CornerRadius { get; set; } = 15;

        public void SetData(string title, string value, double percentChange, bool isPositive, 
            Color accentColor, List<double> trendData)
        {
            _title = title;
            _value = value;
            _percentChange = percentChange;
            _isPositive = isPositive;
            _accentColor = accentColor;
            _trendData = trendData ?? new List<double>();
            UpdateCard();
        }

        private void InitializeCard()
        {
            // Title
            _lblTitle = new Label
            {
                Text = _title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = UIStyles.TextSecondary,
                AutoSize = false,
                Size = new Size(this.Width - 40, 18),
                Location = new Point(20, 20),
                TextAlign = ContentAlignment.TopLeft
            };

            // Value
            _lblValue = new Label
            {
                Text = _value,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = UIStyles.TextColor,
                AutoSize = true,
                Location = new Point(20, 45)
            };

            // Percentage indicator
            _lblPercent = new Label
            {
                Text = FormatPercent(_percentChange),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = _isPositive ? UIStyles.SuccessColor : UIStyles.DangerColor,
                AutoSize = true,
                Location = new Point(20, 80)
            };

            // Sparkline panel (right side)
            _sparklinePanel = new Panel
            {
                Size = new Size(100, 50),
                Location = new Point(this.Width - 120, 70),
                BackColor = Color.Transparent
            };
            _sparklinePanel.Paint += SparklinePanel_Paint;

            this.Controls.Add(_lblTitle);
            this.Controls.Add(_lblValue);
            this.Controls.Add(_lblPercent);
            this.Controls.Add(_sparklinePanel);
        }

        private void SparklinePanel_Paint(object? sender, PaintEventArgs e)
        {
            if (_trendData == null || _trendData.Count < 2) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int width = _sparklinePanel!.Width;
            int height = _sparklinePanel!.Height;
            int padding = 5;

            double minValue = _trendData.Min();
            double maxValue = _trendData.Max();
            double range = maxValue - minValue;
            if (range == 0) range = 1;

            // Draw sparkline
            List<PointF> points = new List<PointF>();
            for (int i = 0; i < _trendData.Count; i++)
            {
                float x = padding + (i * (width - padding * 2) / (_trendData.Count - 1));
                float y = height - padding - (float)((_trendData[i] - minValue) / range * (height - padding * 2));
                points.Add(new PointF(x, y));
            }

            // Draw area under line
            if (points.Count > 1)
            {
                using (GraphicsPath areaPath = new GraphicsPath())
                {
                    areaPath.AddLine(points[0].X, height - padding, points[0].X, points[0].Y);
                    for (int i = 1; i < points.Count; i++)
                    {
                        areaPath.AddLine(points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y);
                    }
                    areaPath.AddLine(points[points.Count - 1].X, points[points.Count - 1].Y, 
                        points[points.Count - 1].X, height - padding);
                    areaPath.CloseFigure();

                    Color areaColor = Color.FromArgb(30, _accentColor.R, _accentColor.G, _accentColor.B);
                    using (SolidBrush brush = new SolidBrush(areaColor))
                    {
                        g.FillPath(brush, areaPath);
                    }
                }

                // Draw line
                using (Pen linePen = new Pen(_accentColor, 2))
                {
                    for (int i = 1; i < points.Count; i++)
                    {
                        g.DrawLine(linePen, points[i - 1], points[i]);
                    }
                }
            }
        }

        private string FormatPercent(double percent)
        {
            if (percent == 0) return "";
            string sign = percent > 0 ? "+" : "";
            return $"{sign}{percent:F1}%";
        }

        private void UpdateCard()
        {
            if (_lblTitle != null) _lblTitle.Text = _title;
            if (_lblValue != null) _lblValue.Text = _value;
            if (_lblPercent != null)
            {
                _lblPercent.Text = FormatPercent(_percentChange);
                _lblPercent.ForeColor = _isPositive ? UIStyles.SuccessColor : UIStyles.DangerColor;
            }
            if (_sparklinePanel != null) _sparklinePanel.Invalidate();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // Draw shadow
            using (GraphicsPath shadowPath = GetRoundedRectangle(
                new Rectangle(2, 2, rect.Width, rect.Height), CornerRadius))
            {
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(10, 0, 0, 0)))
                {
                    g.FillPath(shadowBrush, shadowPath);
                }
            }

            // Draw card with rounded corners
            using (GraphicsPath path = GetRoundedRectangle(rect, CornerRadius))
            {
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path);
                }
                using (Pen pen = new Pen(UIStyles.BorderColor, 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
