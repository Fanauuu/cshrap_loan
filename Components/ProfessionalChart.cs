using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Utils;

namespace WinFormsApp1.Components
{
    /// <summary>
    /// Professional chart component with enhanced visuals
    /// </summary>
    public class ProfessionalChart : Panel
    {
        private List<ChartDataPoint> _dataPoints = new List<ChartDataPoint>();
        private string _title = "";
        private Color _chartColor = UIStyles.PrimaryColor;
        private ChartType _chartType = ChartType.Bar;

        public enum ChartType
        {
            Bar,
            Line,
            Pie
        }

        public ProfessionalChart()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
            this.Paint += ProfessionalChart_Paint;
        }

        public void SetData(List<ChartDataPoint> dataPoints, string title = "", Color? chartColor = null, ChartType chartType = ChartType.Bar)
        {
            _dataPoints = dataPoints ?? new List<ChartDataPoint>();
            _title = title;
            _chartColor = chartColor ?? UIStyles.PrimaryColor;
            _chartType = chartType;
            this.Invalidate();
        }

        private void ProfessionalChart_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            if (_dataPoints == null || _dataPoints.Count == 0)
            {
                DrawNoData(g);
                return;
            }

            int padding = 20;
            int titleHeight = string.IsNullOrEmpty(_title) ? 0 : 35;
            int chartTop = padding + titleHeight;
            int chartHeight = Math.Max(100, this.Height - chartTop - padding - 30);
            int chartWidth = Math.Max(200, this.Width - (padding * 2));
            int chartLeft = padding;

            // Draw title
            if (!string.IsNullOrEmpty(_title))
            {
                using (Font titleFont = new Font("Segoe UI", 13F, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(UIStyles.TextColor))
                {
                    g.DrawString(_title, titleFont, brush, new PointF(padding, 10));
                }
            }

            if (_chartType == ChartType.Bar)
            {
                DrawBarChart(g, chartLeft, chartTop, chartWidth, chartHeight);
            }
        }

        private void DrawNoData(Graphics g)
        {
            using (Font noDataFont = new Font("Segoe UI", 11F))
            using (SolidBrush brush = new SolidBrush(UIStyles.TextSecondary))
            {
                string noDataText = "No data available";
                SizeF textSize = g.MeasureString(noDataText, noDataFont);
                g.DrawString(noDataText, noDataFont, brush,
                    new PointF((this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2));
            }
        }

        private void DrawBarChart(Graphics g, int chartLeft, int chartTop, int chartWidth, int chartHeight)
        {
            double maxValue = _dataPoints.Max(p => p.Value);
            if (maxValue <= 0) maxValue = 1;

            int pointCount = _dataPoints.Count;
            int spacing = 12;
            int pointWidth = (chartWidth - (spacing * (pointCount - 1))) / pointCount;
            int barWidth = Math.Max(25, pointWidth - spacing);

            // Draw grid lines
            using (Pen gridPen = new Pen(Color.FromArgb(235, 237, 240), 1))
            {
                for (int i = 0; i <= 5; i++)
                {
                    int y = chartTop + (int)(chartHeight * i / 5);
                    g.DrawLine(gridPen, chartLeft, y, chartLeft + chartWidth, y);
                }
            }

            // Draw Y-axis labels
            using (Font labelFont = new Font("Segoe UI", 8F))
            using (SolidBrush brush = new SolidBrush(UIStyles.TextSecondary))
            {
                for (int i = 0; i <= 5; i++)
                {
                    double value = maxValue * (5 - i) / 5;
                    string label = value >= 1000 ? $"{value / 1000:F1}K" : value.ToString("F0");
                    SizeF labelSize = g.MeasureString(label, labelFont);
                    int y = chartTop + (int)(chartHeight * i / 5);
                    g.DrawString(label, labelFont, brush, chartLeft - labelSize.Width - 8, y - labelSize.Height / 2);
                }
            }

            // Draw bars
            for (int i = 0; i < _dataPoints.Count; i++)
            {
                var point = _dataPoints[i];
                int x = chartLeft + (i * pointWidth) + (spacing / 2);
                int barHeight = (int)((point.Value / maxValue) * chartHeight);
                int y = chartTop + chartHeight - barHeight;

                if (barHeight > 0)
                {
                    Rectangle barRect = new Rectangle(x, y, barWidth, barHeight);

                    // Rounded top corners
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = 5;
                        path.AddArc(barRect.X, barRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddLine(barRect.X + radius, barRect.Y, barRect.Right - radius, barRect.Y);
                        path.AddArc(barRect.Right - radius * 2, barRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddLine(barRect.Right, barRect.Y + radius, barRect.Right, barRect.Bottom);
                        path.AddLine(barRect.Right, barRect.Bottom, barRect.X, barRect.Bottom);
                        path.AddLine(barRect.X, barRect.Bottom, barRect.X, barRect.Y + radius);
                        path.CloseFigure();

                        // Enhanced gradient
                        using (LinearGradientBrush brush = new LinearGradientBrush(
                            barRect, _chartColor, 
                            Color.FromArgb(Math.Min(255, _chartColor.R + 40),
                            Math.Min(255, _chartColor.G + 40), 
                            Math.Min(255, _chartColor.B + 40)),
                            LinearGradientMode.Vertical))
                        {
                            g.FillPath(brush, path);
                        }

                        // Border
                        using (Pen pen = new Pen(Color.FromArgb(100, _chartColor), 1))
                        {
                            g.DrawPath(pen, path);
                        }
                    }
                }

                // Value on top
                if (barHeight > 30)
                {
                    using (Font valueFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                    {
                        string valueText = point.Value >= 1000 ? $"{point.Value / 1000:F1}K" : point.Value.ToString("F0");
                        SizeF valueSize = g.MeasureString(valueText, valueFont);
                        g.DrawString(valueText, valueFont, new SolidBrush(_chartColor),
                            new PointF(x + (barWidth / 2) - (valueSize.Width / 2), y - valueSize.Height - 5));
                    }
                }

                // Label below
                if (!string.IsNullOrEmpty(point.Label))
                {
                    using (Font labelFont = new Font("Segoe UI", 8.5F))
                    {
                        SizeF labelSize = g.MeasureString(point.Label, labelFont);
                        g.DrawString(point.Label, labelFont, new SolidBrush(UIStyles.TextSecondary),
                            new PointF(x + (barWidth / 2) - (labelSize.Width / 2), chartTop + chartHeight + 8));
                    }
                }
            }
        }
    }
}
