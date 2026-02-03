using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1.Utils
{
    /// <summary>
    /// Modern card panel with shadow and rounded corners
    /// </summary>
    public class CardPanel : Panel
    {
        private int _cornerRadius = 8;
        private bool _showShadow = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; this.Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool ShowShadow
        {
            get => _showShadow;
            set { _showShadow = value; this.Invalidate(); }
        }

        public CardPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint | 
                         ControlStyles.DoubleBuffer | 
                         ControlStyles.ResizeRedraw, true);
            this.BackColor = UIStyles.CardColor;
            _cornerRadius = 15; // Default to 15px for modern design
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // Draw shadow
            if (_showShadow)
            {
                using (GraphicsPath shadowPath = UIStyles.GetRoundedRectangle(
                    new Rectangle(2, 2, rect.Width, rect.Height), _cornerRadius))
                {
                    using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
                    {
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
            }

            // Draw card with rounded corners
            using (GraphicsPath path = UIStyles.GetRoundedRectangle(rect, _cornerRadius))
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
    }
}
