using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace WinFormsApp1.Utils
{
    public static class TableExportService
    {
        public static void ExportToExcel(DataGridView dgv, string defaultFileName)
        {
            if (dgv == null) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"{SafeFileName(defaultFileName)}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            var columns = GetExportColumns(dgv);
            var rows = GetExportRows(dgv, columns);

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Export");

            // headers
            for (int c = 0; c < columns.Count; c++)
            {
                ws.Cell(1, c + 1).Value = columns[c].HeaderText;
            }

            // body
            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < columns.Count; c++)
                {
                    ws.Cell(r + 2, c + 1).Value = rows[r][c] ?? "";
                }
            }

            var headerRange = ws.Range(1, 1, 1, columns.Count);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#F3F4F6");
            headerRange.Style.Font.FontColor = XLColor.FromHtml("#374151");
            headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            ws.SheetView.FreezeRows(1);
            ws.RangeUsed().SetAutoFilter();
            ws.Columns().AdjustToContents();

            wb.SaveAs(sfd.FileName);
        }

        public static void ExportToPdf(DataGridView dgv, string title, string defaultFileName)
        {
            if (dgv == null) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"{SafeFileName(defaultFileName)}_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            var columns = GetExportColumns(dgv);
            var rows = GetExportRows(dgv, columns);

            using var doc = new PdfDocument();
            doc.Info.Title = title;

            var page = doc.AddPage();
            page.Orientation = PdfSharpCore.PageOrientation.Landscape;
            var gfx = XGraphics.FromPdfPage(page);

            var fontTitle = new XFont("Segoe UI", 14, XFontStyle.Bold);
            var fontHeader = new XFont("Segoe UI", 9, XFontStyle.Bold);
            var fontCell = new XFont("Segoe UI", 9, XFontStyle.Regular);

            double margin = 32;
            double y = margin;

            gfx.DrawString(title, fontTitle, XBrushes.Black, new XRect(margin, y, page.Width - margin * 2, 24),
                XStringFormats.TopLeft);
            y += 28;

            // column widths (simple proportional)
            double tableWidth = page.Width - margin * 2;
            double[] colWidths = ComputeColumnWidths(columns, tableWidth);
            double rowH = 18;

            DrawHeader(gfx, columns, colWidths, margin, ref y, rowH, fontHeader);

            for (int r = 0; r < rows.Count; r++)
            {
                if (y + rowH + margin > page.Height)
                {
                    page = doc.AddPage();
                    page.Orientation = PdfSharpCore.PageOrientation.Landscape;
                    gfx = XGraphics.FromPdfPage(page);
                    y = margin;
                    gfx.DrawString(title, fontTitle, XBrushes.Black, new XRect(margin, y, page.Width - margin * 2, 24),
                        XStringFormats.TopLeft);
                    y += 28;
                    DrawHeader(gfx, columns, colWidths, margin, ref y, rowH, fontHeader);
                }

                var isAlt = r % 2 == 1;
                DrawRow(gfx, rows[r], colWidths, margin, y, rowH, fontCell, isAlt);
                y += rowH;
            }

            doc.Save(sfd.FileName);
        }

        private static void DrawHeader(XGraphics gfx, List<DataGridViewColumn> columns, double[] widths, double x, ref double y, double h, XFont font)
        {
            double cx = x;
            for (int i = 0; i < columns.Count; i++)
            {
                var rect = new XRect(cx, y, widths[i], h);
                gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(243, 244, 246)), rect);
                gfx.DrawRectangle(new XPen(XColor.FromArgb(229, 231, 235)), rect);
                gfx.DrawString(columns[i].HeaderText, font, new XSolidBrush(XColor.FromArgb(55, 65, 81)),
                    new XRect(cx + 4, y + 3, widths[i] - 8, h), XStringFormats.TopLeft);
                cx += widths[i];
            }
            y += h;
        }

        private static void DrawRow(XGraphics gfx, List<string?> row, double[] widths, double x, double y, double h, XFont font, bool alternate)
        {
            double cx = x;
            var bg = alternate ? XColor.FromArgb(249, 250, 251) : XColors.White;
            for (int i = 0; i < widths.Length; i++)
            {
                var rect = new XRect(cx, y, widths[i], h);
                gfx.DrawRectangle(new XSolidBrush(bg), rect);
                gfx.DrawRectangle(new XPen(XColor.FromArgb(229, 231, 235)), rect);

                string text = row[i] ?? "";
                gfx.DrawString(text, font, new XSolidBrush(XColor.FromArgb(31, 41, 55)),
                    new XRect(cx + 4, y + 3, widths[i] - 8, h), XStringFormats.TopLeft);
                cx += widths[i];
            }
        }

        private static double[] ComputeColumnWidths(List<DataGridViewColumn> cols, double totalWidth)
        {
            // Prefer DataGridView column widths if present; normalize into totalWidth
            var raw = cols.Select(c => Math.Max(50, c.Width)).Select(w => (double)w).ToArray();
            double sum = raw.Sum();
            if (sum <= 0) sum = 1;
            return raw.Select(w => (w / sum) * totalWidth).ToArray();
        }

        private static List<DataGridViewColumn> GetExportColumns(DataGridView dgv)
        {
            return dgv.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();
        }

        private static List<List<string?>> GetExportRows(DataGridView dgv, List<DataGridViewColumn> columns)
        {
            var rows = new List<List<string?>>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                var values = new List<string?>(columns.Count);
                foreach (var col in columns)
                {
                    object? v = row.Cells[col.Index].Value;
                    values.Add(v?.ToString());
                }
                rows.Add(values);
            }
            return rows;
        }

        private static string SafeFileName(string name)
        {
            var invalid = System.IO.Path.GetInvalidFileNameChars();
            return string.Concat(name.Select(ch => invalid.Contains(ch) ? '_' : ch));
        }
    }
}

