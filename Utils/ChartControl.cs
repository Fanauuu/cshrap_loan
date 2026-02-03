using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1.Utils
{
    /// <summary>
    /// Custom chart control for displaying bar charts
    /// </summary>
    public class ChartControl : Panel
    {
        private List<ChartDataPoint> _dataPoints = new List<ChartDataPoint>();
        private string _title = "";
        private Color _chartColor = UIStyles.PrimaryColor;

        public ChartControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
            this.Paint += ChartControl_Paint;
        }

        public void SetData(List<ChartDataPoint> dataPoints, string title = "", Color? chartColor = null)
        {
            _dataPoints = dataPoints ?? new List<ChartDataPoint>();
            _title = title;
            _chartColor = chartColor ?? UIStyles.PrimaryColor;
            this.Invalidate();
        }

        private void ChartControl_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            if (_dataPoints == null || _dataPoints.Count == 0)
            {
                using (Font noDataFont = new Font("Segoe UI", 11F))
                using (SolidBrush brush = new SolidBrush(UIStyles.TextSecondary))
                {
                    string noDataText = "No data available";
                    SizeF textSize = g.MeasureString(noDataText, noDataFont);
                    g.DrawString(noDataText, noDataFont, brush,
                        new PointF((this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2));
                }
                return;
            }

            // Calculate chart area - compact for dashboard
            int padding = 15;
            int chartTop = string.IsNullOrEmpty(_title) ? 5 : 35;
            int chartHeight = Math.Max(80, this.Height - chartTop - padding - 20);
            int chartWidth = Math.Max(150, this.Width - (padding * 2));
            int chartLeft = padding;

            // Draw title if provided
            if (!string.IsNullOrEmpty(_title))
            {
                using (Font titleFont = new Font("Segoe UI", 12F, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(UIStyles.TextColor))
                {
                    g.DrawString(_title, titleFont, brush, new PointF(padding, 5));
                }
            }

            // Calculate max value
            double maxValue = _dataPoints.Count > 0 ? _dataPoints.Max(p => p.Value) : 1;
            if (maxValue <= 0) maxValue = 1;

            // Calculate bar dimensions
            int pointCount = _dataPoints.Count;
            int spacing = 10;
            int pointWidth = (chartWidth - (spacing * (pointCount - 1))) / pointCount;
            int barWidth = Math.Max(20, pointWidth - spacing);

            // Draw grid lines (lighter, fewer lines for compact view)
            using (Pen gridPen = new Pen(Color.FromArgb(240, 242, 245), 1))
            {
                for (int i = 0; i <= 4; i++)
                {
                    int y = chartTop + (int)(chartHeight * i / 4);
                    g.DrawLine(gridPen, chartLeft, y, chartLeft + chartWidth, y);
                }
            }

            // Draw bars
            for (int i = 0; i < _dataPoints.Count; i++)
            {
                var point = _dataPoints[i];
                int x = chartLeft + (i * pointWidth) + (spacing / 2);
                int barHeight = maxValue > 0 ? (int)((point.Value / maxValue) * chartHeight) : 0;
                int y = chartTop + chartHeight - barHeight;

                if (barHeight > 0)
                {
                    Rectangle barRect = new Rectangle(x, y, barWidth, barHeight);

                    // Create rounded rectangle path (rounded top corners)
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = 4;
                        path.AddArc(barRect.X, barRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddLine(barRect.X + radius, barRect.Y, barRect.Right - radius, barRect.Y);
                        path.AddArc(barRect.Right - radius * 2, barRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddLine(barRect.Right, barRect.Y + radius, barRect.Right, barRect.Bottom);
                        path.AddLine(barRect.Right, barRect.Bottom, barRect.X, barRect.Bottom);
                        path.AddLine(barRect.X, barRect.Bottom, barRect.X, barRect.Y + radius);
                        path.CloseFigure();

                        // Gradient fill
                        using (LinearGradientBrush brush = new LinearGradientBrush(
                            barRect, _chartColor, Color.FromArgb(Math.Min(255, _chartColor.R + 30),
                            Math.Min(255, _chartColor.G + 30), Math.Min(255, _chartColor.B + 30)),
                            LinearGradientMode.Vertical))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                }

                // Draw value on top (only if bar is tall enough)
                if (barHeight > 25)
                {
                    using (Font valueFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                    {
                        string valueText = point.Value.ToString("N0");
                        SizeF valueSize = g.MeasureString(valueText, valueFont);
                        g.DrawString(valueText, valueFont, new SolidBrush(_chartColor),
                            new PointF(x + (barWidth / 2) - (valueSize.Width / 2), y - valueSize.Height - 3));
                    }
                }

                // Draw label below
                if (!string.IsNullOrEmpty(point.Label))
                {
                    using (Font labelFont = new Font("Segoe UI", 7.5F))
                    {
                        SizeF labelSize = g.MeasureString(point.Label, labelFont);
                        g.DrawString(point.Label, labelFont, new SolidBrush(UIStyles.TextSecondary),
                            new PointF(x + (barWidth / 2) - (labelSize.Width / 2), 
                            chartTop + chartHeight + 3));
                    }
                }
            }
        }
    }

    /// <summary>
    /// Data point for chart
    /// </summary>
    public class ChartDataPoint
    {
        public string Label { get; set; } = "";
        public double Value { get; set; }
    }
}
