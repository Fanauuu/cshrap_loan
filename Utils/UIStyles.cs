using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1.Utils
{
    /// <summary>
    /// Modern Web-Style UI Design System
    /// Provides consistent styling across the application
    /// </summary>
    public static class UIStyles
    {
        // Color Palette
        public static Color BackgroundColor => Color.FromArgb(244, 246, 248); // #F4F6F8
        public static Color PrimaryColor => Color.FromArgb(37, 99, 235);     // #2563EB
        public static Color SuccessColor => Color.FromArgb(34, 197, 94);      // #22C55E
        public static Color WarningColor => Color.FromArgb(245, 158, 11);     // #F59E0B
        public static Color DangerColor => Color.FromArgb(239, 68, 68);       // #EF4444
        public static Color TextColor => Color.FromArgb(31, 41, 55);          // #1F2937
        public static Color BorderColor => Color.FromArgb(229, 231, 235);     // #E5E7EB
        public static Color SidebarColor => Color.FromArgb(255, 255, 255);    // White
        public static Color CardColor => Color.FromArgb(255, 255, 255);       // White
        public static Color HoverColor => Color.FromArgb(249, 250, 251);      // #F9FAFB
        public static Color TextSecondary => Color.FromArgb(107, 114, 128);   // #6B7280

        // Fonts - Create new instances each time (Font is IDisposable but we don't need to cache)
        public static Font TitleFont
        {
            get
            {
                try
                {
                    return new Font("Segoe UI", 18F, FontStyle.Bold);
                }
                catch
                {
                    return SystemFonts.DefaultFont;
                }
            }
        }

        public static Font SubtitleFont
        {
            get
            {
                try
                {
                    return new Font("Segoe UI", 14F, FontStyle.Bold);
                }
                catch
                {
                    return SystemFonts.DefaultFont;
                }
            }
        }

        public static Font BodyFont
        {
            get
            {
                try
                {
                    return new Font("Segoe UI", 11F);
                }
                catch
                {
                    return SystemFonts.DefaultFont;
                }
            }
        }

        public static Font SmallFont
        {
            get
            {
                try
                {
                    return new Font("Segoe UI", 10F);
                }
                catch
                {
                    return SystemFonts.DefaultFont;
                }
            }
        }

        /// <summary>
        /// Applies modern button styling
        /// </summary>
        public static void ApplyModernButton(Button button, Color? backgroundColor = null, Color? textColor = null)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backgroundColor ?? PrimaryColor;
            button.ForeColor = textColor ?? Color.White;
            button.Font = BodyFont;
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(20, 10, 20, 10);
            button.UseVisualStyleBackColor = false;
        }

        /// <summary>
        /// Applies modern textbox styling
        /// </summary>
        public static void ApplyModernTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = TextColor;
            textBox.Font = BodyFont;
            textBox.Padding = new Padding(10, 8, 10, 8);
        }

        /// <summary>
        /// Applies modern card styling to a panel
        /// </summary>
        public static void ApplyCardStyle(Panel panel)
        {
            panel.BackColor = CardColor;
            panel.Padding = new Padding(20);
        }

        /// <summary>
        /// Creates a rounded rectangle path
        /// </summary>
        public static GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            // Top left arc
            path.AddArc(arc, 180, 90);
            // Top right arc
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // Bottom right arc
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // Bottom left arc
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
