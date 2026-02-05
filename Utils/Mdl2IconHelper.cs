using System.Drawing;
using System.Drawing.Text;

namespace WinFormsApp1.Utils
{
    public static class Mdl2IconHelper
    {
        // MDL2 glyphs (Segoe MDL2 Assets). These render as clean monochrome icons.
        public const string Home = "\uE80F";
        public const string Contact = "\uE77B";
        public const string Calendar = "\uE787";
        public const string Document = "\uE8A5";
        public const string People = "\uE716";
        public const string SignOut = "\uE8AC";
        public const string Search = "\uE721";
        public const string Bell = "\uE7ED";
        public const string Lock = "\uE72E";
        public const string Add = "\uE710";

        public static Font GetFont(float size)
        {
            try
            {
                return new Font("Segoe MDL2 Assets", size, FontStyle.Regular, GraphicsUnit.Point);
            }
            catch
            {
                return new Font("Segoe UI", size, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        public static Bitmap RenderGlyph(string glyph, int sizePx, Color color)
        {
            var bmp = new Bitmap(sizePx, sizePx);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using var font = GetFont(Math.Max(10, sizePx - 2));
            var rect = new Rectangle(0, 0, sizePx, sizePx);
            TextRenderer.DrawText(
                g,
                glyph,
                font,
                rect,
                color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding
            );

            return bmp;
        }
    }
}
