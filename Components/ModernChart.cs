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
    /// Modern chart with rounded corners and soft colors
    /// </summary>
    public class ModernChart : Panel
    {
        private List<ChartDataPoint> _dataPoints = new List<ChartDataPoint>();
        private string _title = "";
        private Color _chartColor = Color.FromArgb(59, 130, 246); // Royal Blue
        private ChartType _chartType = ChartType.Bar;

        public enum ChartType
        {
            Bar,
            Area
        }

        public ModernChart()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
            this.Paint += ModernChart_Paint;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int CornerRadius { get; set; } = 15;

        public void SetData(List<ChartDataPoint> dataPoints, string title = "", Color? chartColor = null, ChartType chartType = ChartType.Bar)
        {
            _dataPoints = dataPoints ?? new List<ChartDataPoint>();
            _title = title;
            _chartColor = chartColor ?? Color.FromArgb(59, 130, 246);
            _chartType = chartType;
            this.Invalidate();
        }

        private void ModernChart_Paint(object? sender, PaintEventArgs e)
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
            int titleHeight = string.IsNullOrEmpty(_title) ? 0 : 40;
            int chartTop = padding + titleHeight;
            int chartHeight = Math.Max(120, this.Height - chartTop - padding - 30);
            int chartWidth = Math.Max(200, this.Width - (padding * 2));
            int chartLeft = padding;

            // Draw title
            if (!string.IsNullOrEmpty(_title))
            {
                using (Font titleFont = new Font("Segoe UI", 14F, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(UIStyles.TextColor))
                {
                    g.DrawString(_title, titleFont, brush, new PointF(padding, 15));
                }
            }

            if (_chartType == ChartType.Bar)
            {
                DrawRoundedBarChart(g, chartLeft, chartTop, chartWidth, chartHeight);
            }
            else if (_chartType == ChartType.Area)
            {
                DrawAreaChart(g, chartLeft, chartTop, chartWidth, chartHeight);
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

        private void DrawRoundedBarChart(Graphics g, int chartLeft, int chartTop, int chartWidth, int chartHeight)
        {
            double maxValue = _dataPoints.Max(p => p.Value);
            if (maxValue <= 0) maxValue = 1;

            int pointCount = _dataPoints.Count;
            int spacing = 16;
            int pointWidth = (chartWidth - (spacing * (pointCount - 1))) / pointCount;
            int barWidth = Math.Max(30, pointWidth - spacing);

            // Draw grid lines (subtle)
            using (Pen gridPen = new Pen(Color.FromArgb(240, 242, 245), 1))
            {
                for (int i = 0; i <= 5; i++)
                {
                    int y = chartTop + (int)(chartHeight * i / 5);
                    g.DrawLine(gridPen, chartLeft, y, chartLeft + chartWidth, y);
                }
            }

            // Draw bars with rounded top corners
            for (int i = 0; i < _dataPoints.Count; i++)
            {
                var point = _dataPoints[i];
                int x = chartLeft + (i * pointWidth) + (spacing / 2);
                int barHeight = (int)((point.Value / maxValue) * chartHeight);
                int y = chartTop + chartHeight - barHeight;

                if (barHeight > 0)
                {
                    Rectangle barRect = new Rectangle(x, y, barWidth, barHeight);

                    // Rounded top corners (15px radius)
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = 15;
                        path.AddArc(barRect.X, barRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddLine(barRect.X + radius, barRect.Y, barRect.Right - radius, barRect.Y);
                        path.AddArc(barRect.Right - radius * 2, barRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddLine(barRect.Right, barRect.Y + radius, barRect.Right, barRect.Bottom);
                        path.AddLine(barRect.Right, barRect.Bottom, barRect.X, barRect.Bottom);
                        path.AddLine(barRect.X, barRect.Bottom, barRect.X, barRect.Y + radius);
                        path.CloseFigure();

                        // Soft gradient fill
                        using (LinearGradientBrush brush = new LinearGradientBrush(
                            barRect, 
                            _chartColor, 
                            Color.FromArgb(Math.Min(255, _chartColor.R + 30),
                            Math.Min(255, _chartColor.G + 30), 
                            Math.Min(255, _chartColor.B + 30)),
                            LinearGradientMode.Vertical))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                }

                // Value on top
                if (barHeight > 35)
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
                    using (Font labelFont = new Font("Segoe UI", 9F))
                    {
                        SizeF labelSize = g.MeasureString(point.Label, labelFont);
                        g.DrawString(point.Label, labelFont, new SolidBrush(UIStyles.TextSecondary),
                            new PointF(x + (barWidth / 2) - (labelSize.Width / 2), chartTop + chartHeight + 8));
                    }
                }
            }
        }

        private void DrawAreaChart(Graphics g, int chartLeft, int chartTop, int chartWidth, int chartHeight)
        {
            double maxValue = _dataPoints.Max(p => p.Value);
            if (maxValue <= 0) maxValue = 1;

            int pointCount = _dataPoints.Count;
            int spacing = chartWidth / (pointCount - 1);

            List<PointF> points = new List<PointF>();
            for (int i = 0; i < _dataPoints.Count; i++)
            {
                float x = chartLeft + (i * spacing);
                float y = chartTop + chartHeight - (float)((_dataPoints[i].Value / maxValue) * chartHeight);
                points.Add(new PointF(x, y));
            }

            // Draw area
            if (points.Count > 1)
            {
                using (GraphicsPath areaPath = new GraphicsPath())
                {
                    areaPath.AddLine(chartLeft, chartTop + chartHeight, points[0].X, points[0].Y);
                    for (int i = 1; i < points.Count; i++)
                    {
                        areaPath.AddLine(points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y);
                    }
                    areaPath.AddLine(points[points.Count - 1].X, points[points.Count - 1].Y, 
                        chartLeft + chartWidth, chartTop + chartHeight);
                    areaPath.CloseFigure();

                    Color areaColor = Color.FromArgb(40, _chartColor.R, _chartColor.G, _chartColor.B);
                    using (SolidBrush brush = new SolidBrush(areaColor))
                    {
                        g.FillPath(brush, areaPath);
                    }
                }

                // Draw line
                using (Pen linePen = new Pen(_chartColor, 3))
                {
                    for (int i = 1; i < points.Count; i++)
                    {
                        g.DrawLine(linePen, points[i - 1], points[i]);
                    }
                }
            }
        }
    }
}
