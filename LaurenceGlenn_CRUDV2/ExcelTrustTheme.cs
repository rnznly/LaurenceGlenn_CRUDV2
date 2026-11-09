using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LaurenceGlenn_CRUDV2
{
    /// <summary>
    /// Excel Trust Enterprise Design System
    /// Inspired by Microsoft Excel 365 & modern enterprise Data Editors (Telerik / Progress Data Editor)
    /// Official Excel Trust Green (#107C41), clean calm mint off-white canvas (#F4F6F4),
    /// pure white floating cards (#FFFFFF) with 1px hairline borders (#E1DFDD),
    /// solid Excel Green table headers with pure white text, Excel range mint selection (#E8F8EE),
    /// pill-style sheet tabs, and clean professional currency & tabular figures.
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

        // Borders & Dividers
        public static readonly Color GridlineColor      = Color.FromArgb(225, 223, 221); // #E1DFDD (Excel Sheet Gridline)
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
            form.Text = "CTU SmartDesk  •  Campus Inventory & Restocking Data Editor";

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
                lbl.Text = "CTU SmartDesk  •  Campus Inventory & Restocking Data Editor";
                lbl.ForeColor = TextPrimary;
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
            int tabW = tc.TabCount > 0 ? (tc.ClientSize.Width - 12) / tc.TabCount : 200;
            tc.ItemSize = new Size(Math.Max(tabW, 130), 38);

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

            // Pill-style Sheet Tabs (Matching the top pills in Data Editor)
            if (isSelected)
            {
                // Solid Microsoft Excel Green Pill for Active Sheet
                using (SolidBrush pillBrush = new SolidBrush(ExcelGreen))
                {
                    e.Graphics.FillRectangle(pillBrush, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                }
                using (Pen pillPen = new Pen(ExcelGreenDark, 1))
                {
                    e.Graphics.DrawRectangle(pillPen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                }
            }
            else
            {
                // Clean White Card Tab with subtle border
                using (SolidBrush bgBrush = new SolidBrush(SurfaceCard))
                {
                    e.Graphics.FillRectangle(bgBrush, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                }
                using (Pen borderPen = new Pen(GridlineColor, 1))
                {
                    e.Graphics.DrawRectangle(borderPen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                }
            }

            // Tab Text (Pure White on active green pill, Slate on inactive)
            Color textColor = isSelected ? Color.White : TextPrimary;
            Font textFont = new Font("Segoe UI", isSelected ? 9.25F : 9F, isSelected ? FontStyle.Bold : FontStyle.Regular);

            TextRenderer.DrawText(
                e.Graphics,
                page.Text,
                textFont,
                rect,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix
            );
        }

        public static void StyleButton(Button btn)
        {
            string name = btn.Name.ToLowerInvariant();
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;

            // 1. Challenge Demonstration Buttons
            if (name.Contains("test") || name.Contains("challenge"))
            {
                btn.BackColor = ExcelMint;           // #E8F8EE Excel Mint Tint
                btn.ForeColor = ExcelGreenDark;      // #0E6E38 Deep Excel Green
                btn.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                btn.FlatAppearance.BorderColor = ExcelMintBorder; // #A3E2B9
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(209, 245, 222);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(163, 226, 185);

                if (name.Contains("receive"))
                {
                    btn.Text = "Challenge 1:\nReceive Twice Rollback";
                }
                else if (name.Contains("duplicate"))
                {
                    btn.Text = "Challenge 2:\nDuplicate Line Rollback";
                }
            }
            // 2. Hero Primary CTA Buttons (Solid Microsoft Excel Green #107C41)
            else if (name.Contains("add") || name.Contains("save") || name.Contains("receive") || name.Contains("createdraft"))
            {
                btn.BackColor = ExcelGreen;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = ExcelGreenDark;
                btn.FlatAppearance.MouseDownBackColor = ExcelGreenDeep;

                if (name == "btnreceivepo")
                {
                    btn.Text = "Receive Selected PO\n[Update Stock In]";
                }
            }
            // 3. Secondary Actions (Update) - Mint tint with green border & text
            else if (name.Contains("update"))
            {
                btn.BackColor = ExcelMint;
                btn.ForeColor = ExcelGreenDark;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                btn.FlatAppearance.BorderColor = ExcelMintBorder;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(209, 245, 222);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(163, 226, 185);
            }
            // 4. Danger / Destructive Actions (Delete)
            else if (name.Contains("delete"))
            {
                btn.BackColor = Color.FromArgb(253, 243, 242); // Soft Excel rose wash
                btn.ForeColor = Color.FromArgb(168, 0, 0);     // #A80000 Office Red
                btn.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
                btn.FlatAppearance.BorderColor = Color.FromArgb(241, 169, 160);
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(250, 226, 224);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(244, 192, 187);
            }
            // 5. Secondary Ghost / Outline Actions (Search, Refresh, Clear, Generate)
            else
            {
                btn.BackColor = SurfaceCard;
                btn.ForeColor = TextMuted;
                btn.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular);
                btn.FlatAppearance.BorderColor = BorderControl;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(244, 246, 244);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 223, 221);
            }
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
            string[] hiddenColumns = { "ProductId", "CategoryId", "SupplierId", "PurchaseOrderId", "PurchaseOrderLineId" };
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
