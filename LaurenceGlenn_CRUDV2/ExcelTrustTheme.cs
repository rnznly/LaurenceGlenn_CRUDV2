using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace LaurenceGlenn_CRUDV2
{
    /// <summary>
    /// Excel Trust Enterprise Design System
    /// Inspired by Microsoft Excel 365 & modern enterprise Data Editors (Progress / Telerik Data Editor)
    /// Official Excel Trust Green (#107C41), calm mint off-white canvas (#F4F6F4),
    /// pure white floating cards (#FFFFFF) with 1px hairline borders (#E1DFDD),
    /// solid Excel Green table headers with pure white text, Excel range mint selection (#E8F8EE),
    /// smooth rounded capsule pill buttons (Photo 5), floating capsule navigation pills with vector UI icons,
    /// and deep Navy Blue header title (#002060).
    /// </summary>
    public static class ExcelTrustTheme
    {
        // ==========================================
        // Palette Tokens (Microsoft Excel 365 & Trust Green)
        // ==========================================
        public static readonly Color CanvasBg          = Color.FromArgb(244, 246, 244); // #F4F6F4 (Calm, fresh Excel off-white)
        public static readonly Color SurfaceCard       = Color.FromArgb(255, 255, 255); // #FFFFFF (Pure white card)
        public static readonly Color SurfaceRowAlt     = Color.FromArgb(248, 250, 248); // #F8FAF8 (Zebra row light mint)

        // Microsoft Excel Green Spectrum
        public static readonly Color ExcelGreen        = Color.FromArgb(16, 124, 65);   // #107C41 (Official Microsoft Excel Green)
        public static readonly Color ExcelGreenDark    = Color.FromArgb(14, 110, 56);   // #0E6E38 (Dark Excel Green)
        public static readonly Color ExcelGreenDeep    = Color.FromArgb(10, 82, 41);    // #0A5229 (Pressed Green)
        public static readonly Color ExcelMint         = Color.FromArgb(232, 248, 238); // #E8F8EE (Active Cell / Range Tint)
        public static readonly Color ExcelMintBorder   = Color.FromArgb(163, 226, 185); // #A3E2B9 (Mint Border)

        // Deep Navy Blue (Header Title requirement Photo 2)
        public static readonly Color TitleNavy         = Color.FromArgb(0, 32, 96);     // #002060 (Corporate Trust Navy Blue)

        // Borders & Dividers
        public static readonly Color GridlineColor     = Color.FromArgb(225, 223, 221); // #E1DFDD (Excel Sheet Gridline)
        public static readonly Color BorderSubtle      = Color.FromArgb(226, 232, 240); // #E2E8F0 (Card hairline border)
        public static readonly Color BorderControl     = Color.FromArgb(200, 198, 196); // #C8C6C4 (Input border)

        // Typography Colors (Office 365 Neutral Spectrum)
        public static readonly Color TextPrimary       = Color.FromArgb(32, 31, 30);    // #201F1E (Office Slate Charcoal)
        public static readonly Color TextMuted         = Color.FromArgb(96, 94, 92);    // #605E5C (Muted metadata)
        public static readonly Color TextSubtle        = Color.FromArgb(120, 120, 120);

        // Semantic Colors
        public static readonly Color SemanticSuccess   = Color.FromArgb(16, 124, 65);   // #107C41 (Active / Received / IN)
        public static readonly Color SemanticWarning   = Color.FromArgb(216, 59, 1);    // #D83B01 (Draft / REORDER NOW)
        public static readonly Color SemanticDanger    = Color.FromArgb(168, 0, 0);     // #A80000 (Inactive / Cancelled)

        public static void Apply(Form form)
        {
            if (form == null) return;

            form.BackColor = CanvasBg;
            form.ForeColor = TextPrimary;
            form.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            form.Text = "Inventory & Purchase Order Management System";

            ApplyToHierarchy(form);
        }

        private static void ApplyToHierarchy(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TabControl tc)
                {
                    StyleTabControl(tc);
                }
                else if (c is TabPage tp)
                {
                    tp.UseVisualStyleBackColor = false;
                    tp.BackColor = CanvasBg;
                    tp.ForeColor = TextPrimary;
                }
                else if (c is GroupBox gb)
                {
                    StyleGroupBox(gb);
                }
                else if (c is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                else if (c is Button btn)
                {
                    StyleButton(btn);
                }
                else if (c is TextBox tb)
                {
                    tb.BackColor = SurfaceCard;
                    tb.ForeColor = TextPrimary;
                    tb.BorderStyle = BorderStyle.FixedSingle;

                    if (tb.Name.IndexOf("sku", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        tb.Name.IndexOf("code", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        tb.Name.IndexOf("po", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        tb.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular);
                    }
                    else
                    {
                        tb.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);
                    }
                }
                else if (c is ComboBox cb)
                {
                    StyleComboBox(cb);
                }
                else if (c is NumericUpDown nud)
                {
                    nud.BackColor = SurfaceCard;
                    nud.ForeColor = TextPrimary;
                    nud.BorderStyle = BorderStyle.FixedSingle;
                    nud.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular);
                }
                else if (c is Label lbl)
                {
                    StyleLabel(lbl);
                }
                else if (c is CheckBox chk)
                {
                    chk.ForeColor = TextPrimary;
                    chk.BackColor = Color.Transparent;
                    chk.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                }

                if (c.HasChildren)
                {
                    ApplyToHierarchy(c);
                }
            }
        }

        public static void StyleLabel(Label lbl)
        {
            lbl.UseMnemonic = false;
            if (lbl.Name == "lblAppTitle")
            {
                lbl.Text = "Inventory & Purchase Order Management System";
                lbl.ForeColor = ExcelGreen; // Microsoft Excel Trust Green (#107C41)
                lbl.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            }
            else if (lbl.Name == "lblProductCost" || lbl.Name == "lblPOLineCost")
            {
                lbl.Text = "Unit Cost (PHP):";
                lbl.ForeColor = TextMuted;
                lbl.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular);
            }
            else if (lbl.Name == "lblPOTotalAmount")
            {
                lbl.ForeColor = ExcelGreen;
                lbl.Font = new Font("Cascadia Mono", 11F, FontStyle.Bold);
            }
            else if (lbl.Name == "lblSelectedPO")
            {
                lbl.ForeColor = ExcelGreen;
                lbl.Font = new Font("Cascadia Mono", 9F, FontStyle.Bold);
            }
            else
            {
                lbl.ForeColor = TextMuted;
                lbl.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular);
            }
        }

        public static void StyleGroupBox(GroupBox gb)
        {
            gb.BackColor = SurfaceCard;
            gb.ForeColor = TextPrimary;

            gb.Paint -= GroupBox_Paint;
            gb.Paint += GroupBox_Paint;
        }

        private static void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            if (gb == null) return;

            // 1. Clear with pure white card surface (#FFFFFF)
            e.Graphics.Clear(SurfaceCard);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 2. Draw 1px clean hairline card border (#E2E8F0)
            Rectangle cardRect = new Rectangle(0, 0, gb.Width - 1, gb.Height - 1);
            using (Pen borderPen = new Pen(BorderSubtle, 1))
            {
                e.Graphics.DrawRectangle(borderPen, cardRect);
            }

            // 3. Top Microsoft Excel Green Accent Bar (#107C41)
            using (SolidBrush accentBrush = new SolidBrush(ExcelGreen))
            {
                e.Graphics.FillRectangle(accentBrush, 1, 1, 46, 3);
            }

            // 4. Header Typography (#201F1E) with NoPrefix
            using (Font headerFont = new Font("Segoe UI", 9.25F, FontStyle.Bold))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    gb.Text,
                    headerFont,
                    new Point(14, 10),
                    TextPrimary,
                    TextFormatFlags.NoPrefix
                );
            }
        }

        public static void StyleTabControl(TabControl tc)
        {
            tc.DrawMode = TabDrawMode.OwnerDrawFixed;
            tc.SizeMode = TabSizeMode.Fixed;
            tc.Padding = new Point(0, 0);

            int tabW = tc.TabCount > 0 ? (tc.ClientSize.Width - 20) / tc.TabCount : 200;
            tc.ItemSize = new Size(Math.Max(tabW, 140), 38);

            tc.DrawItem -= Tc_DrawItem;
            tc.DrawItem += Tc_DrawItem;
        }

        private static void Tc_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tc = sender as TabControl;
            if (tc == null || e.Index < 0 || e.Index >= tc.TabPages.Count) return;

            TabPage page = tc.TabPages[e.Index];
            bool isSelected = (tc.SelectedIndex == e.Index);
            Rectangle rect = e.Bounds;

            // 1. Clear background behind tabs to blend smoothly with canvas
            using (SolidBrush bgBrush = new SolidBrush(CanvasBg))
            {
                e.Graphics.FillRectangle(bgBrush, rect);
                if (e.Index == tc.TabCount - 1)
                {
                    e.Graphics.FillRectangle(bgBrush, rect.Right - 1, rect.Y, 4, rect.Height);
                }
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 2. Floating Capsule Pill with 8px horizontal gap and 4px vertical margin
            Rectangle pillRect = new Rectangle(rect.X + 4, rect.Y + 2, rect.Width - 8, rect.Height - 4);

            using (GraphicsPath path = GetCapsulePath(pillRect, pillRect.Height / 2))
            {
                if (isSelected)
                {
                    // Active Sheet: Solid Microsoft Excel Green Pill (#107C41)
                    using (SolidBrush pillBrush = new SolidBrush(ExcelGreen))
                    {
                        e.Graphics.FillPath(pillBrush, path);
                    }
                    using (Pen pillPen = new Pen(ExcelGreenDark, 1.2f))
                    {
                        e.Graphics.DrawPath(pillPen, path);
                    }
                }
                else
                {
                    // Inactive Sheet: Clean Floating White Card Pill (#FFFFFF) with subtle border
                    using (SolidBrush pillBrush = new SolidBrush(SurfaceCard))
                    {
                        e.Graphics.FillPath(pillBrush, path);
                    }
                    using (Pen borderPen = new Pen(GridlineColor, 1f))
                    {
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
            }

            // 3. Tab Text & Vector UI Icon
            Color fgColor = isSelected ? Color.White : TextPrimary;
            Font textFont = new Font("Segoe UI", isSelected ? 9.25F : 9F, isSelected ? FontStyle.Bold : FontStyle.Regular);

            int iconSize = 16;
            int spacing = 8;
            SizeF textSize = e.Graphics.MeasureString(page.Text, textFont);
            int totalW = iconSize + spacing + (int)textSize.Width;
            int contentX = pillRect.X + (pillRect.Width - totalW) / 2;
            int contentY = pillRect.Y + (pillRect.Height - iconSize) / 2;

            // Draw Vector UI Icon
            DrawTabIcon(e.Graphics, e.Index, new Rectangle(contentX, contentY, iconSize, iconSize), fgColor);

            // Draw Tab Label
            Rectangle textRect = new Rectangle(contentX + iconSize + spacing, pillRect.Y, pillRect.Width - (contentX - pillRect.X + iconSize + spacing), pillRect.Height);
            using (SolidBrush textBrush = new SolidBrush(fgColor))
            using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoWrap })
            {
                e.Graphics.DrawString(page.Text, textFont, textBrush, textRect, sf);
            }

            // 4. Clean, centered vertical hairline dividers between adjacent tab buttons
            using (Pen divPen = new Pen(Color.FromArgb(120, 120, 120), 1f))
            {
                if (e.Index > 0)
                {
                    e.Graphics.DrawLine(divPen, rect.X, rect.Y + 8, rect.X, rect.Bottom - 8);
                }
                if (e.Index < tc.TabCount - 1)
                {
                    e.Graphics.DrawLine(divPen, rect.Right, rect.Y + 8, rect.Right, rect.Bottom - 8);
                }
            }
        }

        private static void DrawTabIcon(Graphics g, int tabIndex, Rectangle iconRect, Color color)
        {
            using (Pen pen = new Pen(color, 1.5f))
            using (Brush brush = new SolidBrush(color))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                int x = iconRect.X + (iconRect.Width - 16) / 2;
                int y = iconRect.Y + (iconRect.Height - 16) / 2;

                switch (tabIndex)
                {
                    case 0: // Products: Isometric Box / Package
                        Point[] topFlap = { new Point(x + 8, y + 2), new Point(x + 14, y + 5), new Point(x + 8, y + 8), new Point(x + 2, y + 5) };
                        g.DrawPolygon(pen, topFlap);
                        g.DrawLine(pen, x + 2, y + 5, x + 2, y + 11);
                        g.DrawLine(pen, x + 14, y + 5, x + 14, y + 11);
                        g.DrawLine(pen, x + 8, y + 8, x + 8, y + 14);
                        g.DrawLine(pen, x + 2, y + 11, x + 8, y + 14);
                        g.DrawLine(pen, x + 14, y + 11, x + 8, y + 14);
                        break;

                    case 1: // Suppliers: Enterprise Building
                        g.DrawRectangle(pen, x + 2, y + 2, 12, 12);
                        g.FillRectangle(brush, x + 4, y + 4, 2, 2);
                        g.FillRectangle(brush, x + 10, y + 4, 2, 2);
                        g.FillRectangle(brush, x + 4, y + 8, 2, 2);
                        g.FillRectangle(brush, x + 10, y + 8, 2, 2);
                        g.FillRectangle(brush, x + 7, y + 10, 2, 4);
                        break;

                    case 2: // Categories: Tag / Label Badge
                        Point[] tag = {
                            new Point(x + 2, y + 8),
                            new Point(x + 8, y + 2),
                            new Point(x + 14, y + 8),
                            new Point(x + 8, y + 14)
                        };
                        g.DrawPolygon(pen, tag);
                        g.FillEllipse(brush, x + 7, y + 4, 3, 3);
                        break;

                    case 3: // Purchase Orders: Order Clipboard
                        g.DrawRectangle(pen, x + 2, y + 3, 12, 11);
                        g.FillRectangle(brush, x + 5, y + 1, 6, 3);
                        g.DrawLine(pen, x + 5, y + 6, x + 11, y + 6);
                        g.DrawLine(pen, x + 5, y + 9, x + 11, y + 9);
                        g.DrawLine(pen, x + 5, y + 12, x + 9, y + 12);
                        break;

                    case 4: // Reports: Ascending Bar Chart
                        g.DrawLine(pen, x + 1, y + 14, x + 15, y + 14);
                        g.FillRectangle(brush, x + 2, y + 9, 3, 5);
                        g.FillRectangle(brush, x + 6, y + 5, 3, 9);
                        g.FillRectangle(brush, x + 10, y + 2, 3, 12);
                        break;
                }
            }
        }

        public static void StyleButton(Button btn)
        {
            string name = btn.Name.ToLowerInvariant();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            // Multiline labels for challenge and receipt buttons
            if (name.Contains("receivepo"))
            {
                btn.Text = "Receive Selected PO\n[Update Stock In]";
            }
            else if (name.Contains("receivetwice"))
            {
                btn.Text = "Challenge 1:\nReceive Twice Rollback";
            }
            else if (name.Contains("duplicateline"))
            {
                btn.Text = "Challenge 2:\nDuplicate Line Rollback";
            }

            bool isSquare = ShouldUseSquareStyle(btn);
            if (isSquare)
            {
                btn.Region = null;
            }
            else
            {
                UpdatePillRegion(btn);
            }

            btn.Resize -= Btn_PillResize;
            btn.Resize += Btn_PillResize;

            btn.Paint -= Button_PillPaint;
            btn.Paint += Button_PillPaint;

            btn.MouseEnter -= Btn_Invalidate;
            btn.MouseEnter += Btn_Invalidate;
            btn.MouseLeave -= Btn_Invalidate;
            btn.MouseLeave += Btn_Invalidate;
            btn.MouseDown -= Btn_InvalidateMouse;
            btn.MouseDown += Btn_InvalidateMouse;
            btn.MouseUp -= Btn_InvalidateMouse;
            btn.MouseUp += Btn_InvalidateMouse;
        }

        public static bool ShouldUseSquareStyle(Button btn)
        {
            if (btn == null) return false;
            string name = (btn.Name ?? "").ToLowerInvariant();
            return name.Contains("receivepo") ||
                   name.Contains("receivetwice") ||
                   name.Contains("duplicateline") ||
                   name.Contains("createdraft") ||
                   name.Contains("generate") ||
                   name.Contains("test") ||
                   name.Contains("challenge");
        }

        private static void Btn_PillResize(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (ShouldUseSquareStyle(btn))
                {
                    btn.Region = null;
                }
                else
                {
                    UpdatePillRegion(btn);
                }
            }
        }

        private static void UpdatePillRegion(Button btn)
        {
            if (btn.Width <= 0 || btn.Height <= 0) return;
            using (GraphicsPath path = GetCapsulePath(new Rectangle(0, 0, btn.Width, btn.Height), btn.Height / 2))
            {
                btn.Region = new Region(path);
            }
        }

        private static void Btn_Invalidate(object sender, EventArgs e)
        {
            (sender as Control)?.Invalidate();
        }

        private static void Btn_InvalidateMouse(object sender, MouseEventArgs e)
        {
            (sender as Control)?.Invalidate();
        }

        private static void Button_PillPaint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Color bg, fg, border, hoverBg, pressBg;
            GetButtonPalette(btn, out bg, out fg, out border, out hoverBg, out pressBg);

            Point mousePos = btn.PointToClient(Control.MousePosition);
            bool isHover = btn.Enabled && btn.ClientRectangle.Contains(mousePos);
            bool isPress = isHover && (Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left;

            Color curBg = !btn.Enabled ? Color.FromArgb(243, 242, 241) : (isPress ? pressBg : (isHover ? hoverBg : bg));
            Color curFg = !btn.Enabled ? Color.FromArgb(161, 159, 157) : fg;
            Color curBorder = !btn.Enabled ? Color.FromArgb(225, 223, 221) : border;

            bool isSquare = ShouldUseSquareStyle(btn);

            if (isSquare)
            {
                // Clean crisp square / rectangular action tile (as requested for Receive & Challenge buttons)
                Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
                using (SolidBrush fillBrush = new SolidBrush(curBg))
                {
                    e.Graphics.FillRectangle(fillBrush, rect);
                }
                if (curBorder != Color.Transparent)
                {
                    using (Pen borderPen = new Pen(curBorder, 1.2f))
                    {
                        e.Graphics.DrawRectangle(borderPen, 0, 0, btn.Width - 1, btn.Height - 1);
                    }
                }
            }
            else
            {
                // Draw smooth capsule background & border
                Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                using (GraphicsPath path = GetCapsulePath(rect, rect.Height / 2))
                {
                    using (SolidBrush fillBrush = new SolidBrush(curBg))
                    {
                        e.Graphics.FillPath(fillBrush, path);
                    }
                    if (curBorder != Color.Transparent)
                    {
                        using (Pen borderPen = new Pen(curBorder, 1.2f))
                        {
                            e.Graphics.DrawPath(borderPen, path);
                        }
                    }
                }
            }

            // Draw centered button text (supports multi-line)
            Rectangle textRect = new Rectangle(0, 0, btn.Width, btn.Height);
            using (Font font = new Font(btn.Font.FontFamily, btn.Font.Size > 0 ? btn.Font.Size : 9F, btn.Font.Style))
            using (SolidBrush textBrush = new SolidBrush(curFg))
            using (StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                e.Graphics.DrawString(btn.Text, font, textBrush, textRect, sf);
            }
        }

        private static void GetButtonPalette(Button btn, out Color bg, out Color fg, out Color border, out Color hoverBg, out Color pressBg)
        {
            string name = (btn.Name ?? "").ToLowerInvariant();

            // 1. Challenge Demonstration Buttons
            if (name.Contains("test") || name.Contains("challenge"))
            {
                bg = ExcelMint;
                fg = ExcelGreenDark;
                border = ExcelMintBorder;
                hoverBg = Color.FromArgb(209, 245, 222);
                pressBg = Color.FromArgb(163, 226, 185);
            }
            // 2. Primary Hero Buttons (Add, Save, Receive, Create PO) - Solid Excel Green Pill
            else if (name.Contains("add") || name.Contains("save") || name.Contains("receive") || name.Contains("createdraft"))
            {
                bg = ExcelGreen;
                fg = Color.White;
                border = ExcelGreenDark;
                hoverBg = ExcelGreenDark;
                pressBg = ExcelGreenDeep;
            }
            // 3. Secondary Actions (Update) - Excel Mint Tint Pill
            else if (name.Contains("update"))
            {
                bg = ExcelMint;
                fg = ExcelGreenDark;
                border = ExcelMintBorder;
                hoverBg = Color.FromArgb(209, 245, 222);
                pressBg = Color.FromArgb(163, 226, 185);
            }
            // 4. Danger / Destructive Actions (Delete) - Soft Rose Pill
            else if (name.Contains("delete"))
            {
                bg = Color.FromArgb(253, 243, 242);
                fg = SemanticDanger; // #A80000
                border = Color.FromArgb(241, 169, 160);
                hoverBg = Color.FromArgb(250, 226, 224);
                pressBg = Color.FromArgb(244, 192, 187);
            }
            // 5. Secondary Outline / Ghost Actions (Clear, Search, Refresh, Filter, Show All) - White Pill with subtle border
            else
            {
                bg = SurfaceCard; // Pure White #FFFFFF
                fg = Color.FromArgb(50, 49, 48); // Crisp Dark Slate
                border = BorderControl; // #C8C6C4
                hoverBg = Color.FromArgb(244, 246, 244);
                pressBg = Color.FromArgb(225, 223, 221);
            }
        }

        public static GraphicsPath GetCapsulePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (rect.Width <= 0 || rect.Height <= 0) return path;

            int diameter = radius * 2;
            if (diameter > rect.Height) diameter = rect.Height;
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter <= 0) diameter = 1;

            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);
            path.AddArc(arc, 90, 180);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 180);
            path.CloseFigure();

            return path;
        }

        public static void StyleComboBox(ComboBox cb)
        {
            cb.BackColor = SurfaceCard;
            cb.ForeColor = TextPrimary;
            cb.FlatStyle = FlatStyle.Flat;
            cb.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            cb.DrawMode = DrawMode.OwnerDrawFixed;
            cb.ItemHeight = 22;

            cb.DrawItem -= Cb_DrawItem;
            cb.DrawItem += Cb_DrawItem;
        }

        private static void Cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb == null || e.Index < 0 || e.Index >= cb.Items.Count) return;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color bg = isSelected ? ExcelGreen : SurfaceCard;
            Color fg = isSelected ? Color.White : TextPrimary;

            using (SolidBrush bgBrush = new SolidBrush(bg))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            string text = cb.GetItemText(cb.Items[e.Index]);
            using (Font font = new Font("Segoe UI", 9F, FontStyle.Regular))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    font,
                    new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 2, e.Bounds.Width - 8, e.Bounds.Height - 4),
                    fg,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix
                );
            }

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = SurfaceCard;
            dgv.GridColor = GridlineColor; // #E1DFDD (Excel sheet gridline)
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;

            // Comfortable 34px modern row height
            dgv.RowTemplate.Height = 34;
            dgv.ColumnHeadersHeight = 36;

            // Column Headers Style: Solid Microsoft Excel Green with pure white bold text
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ExcelGreen;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ExcelGreen;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Row Cells Style (Pure white with Excel Range Mint selection #E8F8EE)
            dgv.DefaultCellStyle.BackColor = SurfaceCard;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = ExcelMint;
            dgv.DefaultCellStyle.SelectionForeColor = ExcelGreenDark;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Alternating Rows (Very soft light mint zebra #F8FAF8)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SurfaceRowAlt;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = ExcelMint;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = ExcelGreenDark;

            // Hide internal foreign keys and format columns on data binding
            dgv.DataBindingComplete -= Dgv_DataBindingComplete;
            dgv.DataBindingComplete += Dgv_DataBindingComplete;

            dgv.CellFormatting -= Dgv_CellFormatting;
            dgv.CellFormatting += Dgv_CellFormatting;
        }

        private static void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            // Clean Excel Sheet: Hide internal foreign key database IDs from view
            string[] hiddenColumns = { "ProductId", "CategoryId", "SupplierId", "PurchaseOrderId", "PurchaseOrderLineId", "MovementId", "Movementid", "StockMovementId" };
            foreach (string colName in hiddenColumns)
            {
                if (dgv.Columns.Contains(colName))
                {
                    dgv.Columns[colName].Visible = false;
                }
            }

            // User-friendly Excel column headers
            if (dgv.Columns.Contains("CategoryName")) dgv.Columns["CategoryName"].HeaderText = "Category";
            if (dgv.Columns.Contains("SupplierName")) dgv.Columns["SupplierName"].HeaderText = "Supplier";
            if (dgv.Columns.Contains("SupplierCode")) dgv.Columns["SupplierCode"].HeaderText = "Code";
            if (dgv.Columns.Contains("ContactEmail")) dgv.Columns["ContactEmail"].HeaderText = "Email";
            if (dgv.Columns.Contains("SupplierStatus")) dgv.Columns["SupplierStatus"].HeaderText = "Status";
            if (dgv.Columns.Contains("UnitCost")) dgv.Columns["UnitCost"].HeaderText = "Unit Cost (PHP)";
            if (dgv.Columns.Contains("ReorderLevel")) dgv.Columns["ReorderLevel"].HeaderText = "Reorder Level";
            if (dgv.Columns.Contains("StockOnHand")) dgv.Columns["StockOnHand"].HeaderText = "Stock On Hand";
            if (dgv.Columns.Contains("PONumber")) dgv.Columns["PONumber"].HeaderText = "PO Number";
            if (dgv.Columns.Contains("OrderDate")) dgv.Columns["OrderDate"].HeaderText = "Order Date";
            if (dgv.Columns.Contains("POStatus")) dgv.Columns["POStatus"].HeaderText = "Status";
            if (dgv.Columns.Contains("TotalAmount")) dgv.Columns["TotalAmount"].HeaderText = "Total Amount (PHP)";
            if (dgv.Columns.Contains("MovementType")) dgv.Columns["MovementType"].HeaderText = "Type";
            if (dgv.Columns.Contains("ReferenceNo")) dgv.Columns["ReferenceNo"].HeaderText = "Reference";
            if (dgv.Columns.Contains("MovementDate")) dgv.Columns["MovementDate"].HeaderText = "Movement Date";
        }

        private static void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            string val = e.Value.ToString().Trim();

            // Status Badge Formatting (Active / Received / IN vs Draft vs Inactive / Cancelled)
            if (val.Equals("Active", StringComparison.OrdinalIgnoreCase) ||
                val.Equals("Received", StringComparison.OrdinalIgnoreCase) ||
                val.Equals("IN", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = SemanticSuccess; // #107C41 Excel Green
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else if (val.Equals("Draft", StringComparison.OrdinalIgnoreCase) ||
                     val.Equals("REORDER NOW", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = SemanticWarning; // #D83B01 Excel Amber
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else if (val.Equals("Inactive", StringComparison.OrdinalIgnoreCase) ||
                     val.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = SemanticDanger; // #A80000 Office Red
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            // Currency formatting: ₱ #,##0.00 with Cascadia Mono
            else if (val.StartsWith("₱") || val.Contains(".") && decimal.TryParse(val.Replace("₱", "").Trim(), out decimal decVal))
            {
                e.CellStyle.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            // Monospace SKU / Code / PO Number
            else if (val.StartsWith("SKU-") || val.StartsWith("PO-") || val.StartsWith("SUP-"))
            {
                e.CellStyle.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular);
            }
        }
    }
}
