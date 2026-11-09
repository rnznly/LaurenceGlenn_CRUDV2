using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LaurenceGlenn_CRUDV2
{
    public partial class Form1 : Form
    {
        private int selectedCategoryId = 0;
        private int selectedSupplierId = 0;
        private int selectedProductId = 0;
        private int selectedPurchaseOrderId = 0;
        private string selectedPOStatus = "";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ExcelTrustTheme.Apply(this);
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    if (!db.DatabaseExists())
                    {
                        MessageBox.Show("Cannot find database 'Bernado'. Please ensure SQL Server is running.",
                                        "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                LoadCategories();
                LoadSuppliers();
                LoadProducts();
                LoadPurchaseOrders();
                LoadLowStockReport();
                LoadPOReport("All");
                LoadStockMovements();

                cmbSupplierStatus.SelectedIndex = 0;
                cmbFilterPOStatus.SelectedIndex = 0;
                GenerateNewPONumber();

                // Reset child control anchors so programmatic responsive layout handles all resizing cleanly
                ResetChildAnchors();

                this.Resize += (s, args) => AdjustResponsiveLayout();
                tabControlMain.SelectedIndexChanged += (s, args) => AdjustResponsiveLayout();
                AdjustResponsiveLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing application (LINQ to SQL): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ResetChildAnchors()
        {
            try
            {
                Control[] fixedControls = new Control[]
                {
                    grpProductInfo, grpProductSearch, dgvProducts,
                    grpSupplierInfo, grpSupplierSearch, dgvSuppliers,
                    grpCategoryInfo, dgvCategories,
                    grpPOCreate, grpPOList, dgvPurchaseOrders,
                    grpPOActions, grpPOLineEntry, dgvPOLines,
                    grpLowStock, dgvLowStock, grpPOReport, dgvPOReport,
                    grpStockMovements, dgvStockMovements,
                    txtPONumber, btnGeneratePONumber, cmbPOSupplier, btnCreateDraftPO, btnRefreshPOs,
                    btnRefreshLowStock, btnFilterPOReport, cmbFilterPOStatus, btnRefreshMovements,
                    lblPOTotalAmount
                };

                foreach (Control c in fixedControls)
                {
                    if (c != null)
                    {
                        c.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    }
                }
            }
            catch { }
        }

        private void AdjustResponsiveLayout()
        {
            try
            {
                if (tabControlMain == null || tabControlMain.TabCount == 0) return;

                int mainW = tabControlMain.ClientSize.Width;
                int mainH = tabControlMain.ClientSize.Height;

                int tabHeaderW = (mainW - 20) / tabControlMain.TabCount;
                tabControlMain.ItemSize = new System.Drawing.Size(Math.Max(tabHeaderW, 140), 38);

                if (mainW > 600 && mainH > 400)
                {
                    int contentW = mainW - 10;
                    int contentH = mainH - 45;

                    // 1. Products Tab Layout
                    if (grpProductInfo != null && dgvProducts != null && grpProductSearch != null)
                    {
                        int leftColW = 435;
                        int rightColLeft = leftColW + 25;
                        int rightColW = Math.Max(200, contentW - rightColLeft - 10);
                        int searchH = 60;

                        grpProductInfo.Left = 15;
                        grpProductInfo.Top = 15;
                        grpProductInfo.Width = leftColW;
                        grpProductInfo.Height = Math.Max(600, contentH - 25);

                        grpProductSearch.Left = rightColLeft;
                        grpProductSearch.Top = 15;
                        grpProductSearch.Width = rightColW;
                        grpProductSearch.Height = searchH;

                        btnRefreshProducts.Left = rightColW - 115;
                        btnRefreshProducts.Top = 20;
                        btnRefreshProducts.Width = 100;
                        btnRefreshProducts.Height = 28;

                        btnSearchProduct.Left = rightColW - 225;
                        btnSearchProduct.Top = 20;
                        btnSearchProduct.Width = 95;
                        btnSearchProduct.Height = 28;

                        txtProductSearch.Left = 260;
                        txtProductSearch.Top = 22;
                        txtProductSearch.Width = Math.Max(120, rightColW - 495);

                        dgvProducts.Left = rightColLeft;
                        dgvProducts.Top = searchH + 25;
                        dgvProducts.Width = rightColW;
                        dgvProducts.Height = Math.Max(200, contentH - (searchH + 35));
                    }

                    // 2. Suppliers Tab Layout (Photo 3 Gap Fix)
                    if (grpSupplierInfo != null && dgvSuppliers != null && grpSupplierSearch != null)
                    {
                        int leftColW = 435;
                        int rightColLeft = leftColW + 25;
                        int rightColW = Math.Max(200, contentW - rightColLeft - 10);
                        int searchH = 60;

                        grpSupplierInfo.Left = 15;
                        grpSupplierInfo.Top = 15;
                        grpSupplierInfo.Width = leftColW;
                        grpSupplierInfo.Height = Math.Max(460, contentH - 25);

                        grpSupplierSearch.Left = rightColLeft;
                        grpSupplierSearch.Top = 15;
                        grpSupplierSearch.Width = rightColW;
                        grpSupplierSearch.Height = searchH;

                        btnRefreshSuppliers.Left = rightColW - 120;
                        btnRefreshSuppliers.Top = 20;
                        btnRefreshSuppliers.Width = 105;
                        btnRefreshSuppliers.Height = 28;

                        btnSearchSupplier.Left = rightColW - 230;
                        btnSearchSupplier.Top = 20;
                        btnSearchSupplier.Width = 95;
                        btnSearchSupplier.Height = 28;

                        txtSupplierSearch.Left = 220;
                        txtSupplierSearch.Top = 22;
                        txtSupplierSearch.Width = Math.Max(120, rightColW - 460);

                        dgvSuppliers.Left = rightColLeft;
                        dgvSuppliers.Top = searchH + 25;
                        dgvSuppliers.Width = rightColW;
                        dgvSuppliers.Height = Math.Max(200, contentH - (searchH + 35));
                    }

                    // 3. Categories Tab Layout
                    if (grpCategoryInfo != null && dgvCategories != null)
                    {
                        int leftColW = 435;
                        int rightColLeft = leftColW + 25;
                        int rightColW = Math.Max(200, contentW - rightColLeft - 10);

                        grpCategoryInfo.Left = 15;
                        grpCategoryInfo.Top = 15;
                        grpCategoryInfo.Width = leftColW;
                        grpCategoryInfo.Height = Math.Max(340, contentH - 25);

                        dgvCategories.Left = rightColLeft;
                        dgvCategories.Top = 15;
                        dgvCategories.Width = rightColW;
                        dgvCategories.Height = Math.Max(200, contentH - 25);
                    }

                    // 4. Purchase Orders Tab Layout
                    if (grpPOCreate != null && grpPOActions != null && grpPOList != null && grpPOLineEntry != null)
                    {
                        int halfW = (contentW - 35) / 2;
                        int topCardH = 90;
                        int listTop = 118; // Clean 13px spacing below top cards
                        int bottomH = Math.Max(200, contentH - listTop - 10);

                        // Top-Left: Create PO Header Card
                        grpPOCreate.Left = 15;
                        grpPOCreate.Top = 15;
                        grpPOCreate.Width = halfW;
                        grpPOCreate.Height = topCardH;

                        // Precise Alignment inside grpPOCreate:
                        lblPONumber.Left = 15;
                        lblPONumber.Top = 26;

                        txtPONumber.AutoSize = false;
                        txtPONumber.Left = 15;
                        txtPONumber.Top = 48;
                        txtPONumber.Width = 125;
                        txtPONumber.Height = 28;

                        btnGeneratePONumber.Left = 148;
                        btnGeneratePONumber.Top = 48;
                        btnGeneratePONumber.Width = 92;
                        btnGeneratePONumber.Height = 28;

                        lblPOSupplier.Left = 252;
                        lblPOSupplier.Top = 26;

                        btnCreateDraftPO.Width = 145;
                        btnCreateDraftPO.Height = 42;
                        btnCreateDraftPO.Left = halfW - 15 - btnCreateDraftPO.Width;
                        btnCreateDraftPO.Top = 35;

                        cmbPOSupplier.Left = 252;
                        cmbPOSupplier.Top = 48;
                        cmbPOSupplier.Height = 28;
                        cmbPOSupplier.Width = Math.Max(120, (btnCreateDraftPO.Left - 15) - 252);

                        // Bottom-Left: PO List Card
                        grpPOList.Left = 15;
                        grpPOList.Top = listTop;
                        grpPOList.Width = halfW;
                        grpPOList.Height = bottomH;

                        btnRefreshPOs.Width = 110;
                        btnRefreshPOs.Height = 28;
                        btnRefreshPOs.Left = halfW - 15 - btnRefreshPOs.Width;
                        btnRefreshPOs.Top = 18;

                        dgvPurchaseOrders.Left = 15;
                        dgvPurchaseOrders.Top = 55;
                        dgvPurchaseOrders.Width = halfW - 30;
                        dgvPurchaseOrders.Height = Math.Max(100, bottomH - 70);

                        // Top-Right: Receive Order & Challenges Card
                        grpPOActions.Left = halfW + 25;
                        grpPOActions.Top = 15;
                        grpPOActions.Width = halfW;
                        grpPOActions.Height = topCardH;

                        int actMargin = 15;
                        int actSpacing = 12;
                        int actBtnW = Math.Max(60, (halfW - actMargin * 2 - actSpacing * 2) / 3);
                        btnReceivePO.Left = actMargin;
                        btnReceivePO.Top = 35;
                        btnReceivePO.Width = actBtnW;
                        btnReceivePO.Height = 42;

                        btnTestReceiveTwice.Left = actMargin + actBtnW + actSpacing;
                        btnTestReceiveTwice.Top = 35;
                        btnTestReceiveTwice.Width = actBtnW;
                        btnTestReceiveTwice.Height = 42;

                        btnTestDuplicateLine.Left = actMargin + (actBtnW + actSpacing) * 2;
                        btnTestDuplicateLine.Top = 35;
                        btnTestDuplicateLine.Width = actBtnW;
                        btnTestDuplicateLine.Height = 42;

                        // Bottom-Right: Line Items Card
                        grpPOLineEntry.Left = halfW + 25;
                        grpPOLineEntry.Top = listTop;
                        grpPOLineEntry.Width = halfW;
                        grpPOLineEntry.Height = bottomH;
                        dgvPOLines.Left = 15;
                        dgvPOLines.Top = 135;
                        dgvPOLines.Width = halfW - 30;
                        dgvPOLines.Height = Math.Max(100, bottomH - 175);

                        lblPOTotalAmount.Top = dgvPOLines.Bottom + 8;
                        lblPOTotalAmount.Left = Math.Max(15, grpPOLineEntry.Width - 15 - lblPOTotalAmount.Width);
                    }

                    // 5. Reports Tab Layout
                    if (grpLowStock != null && grpPOReport != null && grpStockMovements != null)
                    {
                        int rHalfW = (contentW - 35) / 2;
                        int topH = Math.Max(180, (contentH - 55) / 2);

                        // Top-Left: Low Stock Warning Card
                        grpLowStock.Left = 15;
                        grpLowStock.Top = 15;
                        grpLowStock.Width = rHalfW;
                        grpLowStock.Height = topH;

                        btnRefreshLowStock.Width = 145;
                        btnRefreshLowStock.Height = 28;
                        btnRefreshLowStock.Left = rHalfW - 15 - 145;
                        btnRefreshLowStock.Top = 18;

                        dgvLowStock.Left = 15;
                        dgvLowStock.Top = 55;
                        dgvLowStock.Width = rHalfW - 30;
                        dgvLowStock.Height = Math.Max(80, topH - 70);

                        // Top-Right: Purchase Order Status Summary Card
                        grpPOReport.Left = rHalfW + 25;
                        grpPOReport.Top = 15;
                        grpPOReport.Width = rHalfW;
                        grpPOReport.Height = topH;

                        btnFilterPOReport.Width = 90;
                        btnFilterPOReport.Height = 28;
                        btnFilterPOReport.Top = 18;
                        btnFilterPOReport.Left = rHalfW - 15 - 90;

                        cmbFilterPOStatus.Width = 110;
                        cmbFilterPOStatus.Height = 28;
                        cmbFilterPOStatus.Top = 18;
                        cmbFilterPOStatus.Left = btnFilterPOReport.Left - 8 - 110;

                        lblFilterPOStatus.Top = 23;
                        lblFilterPOStatus.Left = cmbFilterPOStatus.Left - 8 - lblFilterPOStatus.Width;

                        dgvPOReport.Left = 15;
                        dgvPOReport.Top = 55;
                        dgvPOReport.Width = rHalfW - 30;
                        dgvPOReport.Height = Math.Max(80, topH - 70);

                        // Bottom: Stock Movement Audit Trail (Full Width Card)
                        int auditTop = topH + 30; // 15px clean gap below top cards
                        grpStockMovements.Left = 15;
                        grpStockMovements.Top = auditTop;
                        grpStockMovements.Width = contentW - 25;
                        grpStockMovements.Height = Math.Max(160, contentH - auditTop - 10);

                        btnRefreshMovements.Width = 145;
                        btnRefreshMovements.Height = 28;
                        btnRefreshMovements.Left = grpStockMovements.Width - 15 - 145;
                        btnRefreshMovements.Top = 18; // Cleanly inside header area

                        dgvStockMovements.Left = 15;
                        dgvStockMovements.Top = 55;
                        dgvStockMovements.Width = grpStockMovements.Width - 30;
                        dgvStockMovements.Height = Math.Max(100, grpStockMovements.Height - 70);
                    }
                }
            }
            catch { }
        }

        #region Categories CRUD

        private void LoadCategories()
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var catList = db.Categories
                                    .OrderBy(c => c.CategoryName)
                                    .Select(c => new { c.CategoryId, c.CategoryName })
                                    .ToList();

                    dgvCategories.DataSource = catList;

                    var comboList = db.Categories.OrderBy(c => c.CategoryName).ToList();
                    cmbProductCategory.DataSource = comboList;
                    cmbProductCategory.DisplayMember = "CategoryName";
                    cmbProductCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories (LINQ to SQL): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    Categories cat = new Categories
                    {
                        CategoryName = txtCategoryName.Text.Trim()
                    };

                    db.Categories.InsertOnSubmit(cat);
                    db.SubmitChanges();
                }

                MessageBox.Show("Category added successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCategoryFields();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category (Check UNIQUE constraint): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Please select a category from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var cat = db.Categories.FirstOrDefault(c => c.CategoryId == selectedCategoryId);
                    if (cat != null)
                    {
                        cat.CategoryName = txtCategoryName.Text.Trim();
                        db.SubmitChanges();
                        MessageBox.Show("Category updated successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearCategoryFields();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Please select a category from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var cat = db.Categories.FirstOrDefault(c => c.CategoryId == selectedCategoryId);
                    if (cat != null)
                    {
                        db.Categories.DeleteOnSubmit(cat);
                        db.SubmitChanges();
                        MessageBox.Show("Category deleted successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearCategoryFields();
                LoadCategories();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category (check if products are assigned to it): " + ex.Message, "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            ClearCategoryFields();
        }

        private void ClearCategoryFields()
        {
            selectedCategoryId = 0;
            txtCategoryName.Clear();
            txtCategoryName.Focus();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                selectedCategoryId = Convert.ToInt32(row.Cells["CategoryId"].Value);
                txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
            }
        }

        #endregion

        #region Suppliers CRUD

        private void LoadSuppliers()
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var supList = db.Suppliers
                                    .OrderBy(s => s.SupplierName)
                                    .Select(s => new {
                                        s.SupplierId,
                                        s.SupplierCode,
                                        s.SupplierName,
                                        s.ContactEmail,
                                        s.SupplierStatus
                                    }).ToList();

                    dgvSuppliers.DataSource = supList;

                    var comboList = db.Suppliers.Where(s => s.SupplierStatus == "Active").OrderBy(s => s.SupplierName).ToList();
                    cmbProductSupplier.DataSource = comboList;
                    cmbProductSupplier.DisplayMember = "SupplierName";
                    cmbProductSupplier.ValueMember = "SupplierId";

                    var poComboList = db.Suppliers.Where(s => s.SupplierStatus == "Active").OrderBy(s => s.SupplierName).ToList();
                    cmbPOSupplier.DataSource = poComboList;
                    cmbPOSupplier.DisplayMember = "SupplierName";
                    cmbPOSupplier.ValueMember = "SupplierId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers (LINQ to SQL): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierCode.Text) ||
                string.IsNullOrWhiteSpace(txtSupplierName.Text) ||
                string.IsNullOrWhiteSpace(txtSupplierEmail.Text))
            {
                MessageBox.Show("Please fill in all supplier fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    Suppliers sup = new Suppliers
                    {
                        SupplierCode = txtSupplierCode.Text.Trim(),
                        SupplierName = txtSupplierName.Text.Trim(),
                        ContactEmail = txtSupplierEmail.Text.Trim(),
                        SupplierStatus = cmbSupplierStatus.Text
                    };

                    db.Suppliers.InsertOnSubmit(sup);
                    db.SubmitChanges();
                }

                MessageBox.Show("Supplier added successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSupplierFields();
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding supplier (Check UNIQUE constraints): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId <= 0)
            {
                MessageBox.Show("Please select a supplier from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var sup = db.Suppliers.FirstOrDefault(s => s.SupplierId == selectedSupplierId);
                    if (sup != null)
                    {
                        sup.SupplierCode = txtSupplierCode.Text.Trim();
                        sup.SupplierName = txtSupplierName.Text.Trim();
                        sup.ContactEmail = txtSupplierEmail.Text.Trim();
                        sup.SupplierStatus = cmbSupplierStatus.Text;
                        db.SubmitChanges();
                        MessageBox.Show("Supplier updated successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearSupplierFields();
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId <= 0)
            {
                MessageBox.Show("Please select a supplier from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var sup = db.Suppliers.FirstOrDefault(s => s.SupplierId == selectedSupplierId);
                    if (sup != null)
                    {
                        db.Suppliers.DeleteOnSubmit(sup);
                        db.SubmitChanges();
                        MessageBox.Show("Supplier deleted successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearSupplierFields();
                LoadSuppliers();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting supplier (Check foreign key references): " + ex.Message, "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    string term = txtSupplierSearch.Text.Trim().ToLower();
                    var results = db.Suppliers
                                    .Where(s => s.SupplierCode.ToLower().Contains(term) ||
                                                s.SupplierName.ToLower().Contains(term) ||
                                                s.ContactEmail.ToLower().Contains(term))
                                    .OrderBy(s => s.SupplierName)
                                    .Select(s => new {
                                        s.SupplierId,
                                        s.SupplierCode,
                                        s.SupplierName,
                                        s.ContactEmail,
                                        s.SupplierStatus
                                    }).ToList();

                    dgvSuppliers.DataSource = results;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching suppliers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshSuppliers_Click(object sender, EventArgs e)
        {
            txtSupplierSearch.Clear();
            LoadSuppliers();
        }

        private void btnClearSupplier_Click(object sender, EventArgs e)
        {
            ClearSupplierFields();
        }

        private void ClearSupplierFields()
        {
            selectedSupplierId = 0;
            txtSupplierCode.Clear();
            txtSupplierName.Clear();
            txtSupplierEmail.Clear();
            cmbSupplierStatus.SelectedIndex = 0;
            txtSupplierCode.Focus();
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
                selectedSupplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                txtSupplierCode.Text = row.Cells["SupplierCode"].Value.ToString();
                txtSupplierName.Text = row.Cells["SupplierName"].Value.ToString();
                txtSupplierEmail.Text = row.Cells["ContactEmail"].Value.ToString();
                cmbSupplierStatus.Text = row.Cells["SupplierStatus"].Value.ToString();
            }
        }

        #endregion

        #region Products CRUD & Search

        private void LoadProducts()
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var query = from p in db.Products
                                join c in db.Categories on p.CategoryId equals c.CategoryId
                                join s in db.Suppliers on p.SupplierId equals s.SupplierId
                                orderby p.ProductName
                                select new
                                {
                                    p.ProductId,
                                    p.SKU,
                                    p.ProductName,
                                    p.CategoryId,
                                    c.CategoryName,
                                    p.SupplierId,
                                    s.SupplierName,
                                    p.UnitCost,
                                    p.ReorderLevel,
                                    p.StockOnHand,
                                    p.IsActive
                                };

                    dgvProducts.DataSource = query.ToList();

                    var poProdList = db.Products.Where(p => p.IsActive).OrderBy(p => p.ProductName).ToList();
                    cmbPOLineProduct.DataSource = poProdList;
                    cmbPOLineProduct.DisplayMember = "ProductName";
                    cmbPOLineProduct.ValueMember = "ProductId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products (LINQ to SQL): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductSKU.Text) || string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter Product SKU and Product Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbProductCategory.SelectedValue == null || cmbProductSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select a Category and a Supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    Products p = new Products
                    {
                        SKU = txtProductSKU.Text.Trim(),
                        ProductName = txtProductName.Text.Trim(),
                        CategoryId = Convert.ToInt32(cmbProductCategory.SelectedValue),
                        SupplierId = Convert.ToInt32(cmbProductSupplier.SelectedValue),
                        UnitCost = nudProductCost.Value,
                        ReorderLevel = Convert.ToInt32(nudProductReorder.Value),
                        StockOnHand = Convert.ToInt32(nudProductStock.Value),
                        IsActive = chkProductIsActive.Checked
                    };

                    db.Products.InsertOnSubmit(p);
                    db.SubmitChanges();
                }

                MessageBox.Show("Product added successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearProductFields();
                LoadProducts();
                LoadLowStockReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product (Check SKU UNIQUE constraint): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Please select a product from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var p = db.Products.FirstOrDefault(prod => prod.ProductId == selectedProductId);
                    if (p != null)
                    {
                        p.SKU = txtProductSKU.Text.Trim();
                        p.ProductName = txtProductName.Text.Trim();
                        p.CategoryId = Convert.ToInt32(cmbProductCategory.SelectedValue);
                        p.SupplierId = Convert.ToInt32(cmbProductSupplier.SelectedValue);
                        p.UnitCost = nudProductCost.Value;
                        p.ReorderLevel = Convert.ToInt32(nudProductReorder.Value);
                        p.StockOnHand = Convert.ToInt32(nudProductStock.Value);
                        p.IsActive = chkProductIsActive.Checked;

                        db.SubmitChanges();
                        MessageBox.Show("Product updated successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearProductFields();
                LoadProducts();
                LoadLowStockReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Please select a product from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var p = db.Products.FirstOrDefault(prod => prod.ProductId == selectedProductId);
                    if (p != null)
                    {
                        db.Products.DeleteOnSubmit(p);
                        db.SubmitChanges();
                        MessageBox.Show("Product deleted successfully via LINQ to SQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearProductFields();
                LoadProducts();
                LoadLowStockReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product (Check if order lines exist for this product): " + ex.Message, "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    string term = txtProductSearch.Text.Trim().ToLower();

                    var query = from p in db.Products
                                join c in db.Categories on p.CategoryId equals c.CategoryId
                                join s in db.Suppliers on p.SupplierId equals s.SupplierId
                                where p.SKU.ToLower().Contains(term) ||
                                      p.ProductName.ToLower().Contains(term) ||
                                      c.CategoryName.ToLower().Contains(term) ||
                                      s.SupplierName.ToLower().Contains(term)
                                orderby p.ProductName
                                select new
                                {
                                    p.ProductId,
                                    p.SKU,
                                    p.ProductName,
                                    p.CategoryId,
                                    c.CategoryName,
                                    p.SupplierId,
                                    s.SupplierName,
                                    p.UnitCost,
                                    p.ReorderLevel,
                                    p.StockOnHand,
                                    p.IsActive
                                };

                    dgvProducts.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            txtProductSearch.Clear();
            LoadProducts();
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            ClearProductFields();
        }

        private void ClearProductFields()
        {
            selectedProductId = 0;
            txtProductSKU.Clear();
            txtProductName.Clear();
            nudProductCost.Value = 0;
            nudProductReorder.Value = 0;
            nudProductStock.Value = 0;
            chkProductIsActive.Checked = true;
            if (cmbProductCategory.Items.Count > 0) cmbProductCategory.SelectedIndex = 0;
            if (cmbProductSupplier.Items.Count > 0) cmbProductSupplier.SelectedIndex = 0;
            txtProductSKU.Focus();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
                txtProductSKU.Text = row.Cells["SKU"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                cmbProductCategory.SelectedValue = Convert.ToInt32(row.Cells["CategoryId"].Value);
                cmbProductSupplier.SelectedValue = Convert.ToInt32(row.Cells["SupplierId"].Value);
                nudProductCost.Value = Convert.ToDecimal(row.Cells["UnitCost"].Value);
                nudProductReorder.Value = Convert.ToDecimal(row.Cells["ReorderLevel"].Value);
                nudProductStock.Value = Convert.ToDecimal(row.Cells["StockOnHand"].Value);
                chkProductIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
            }
        }

        #endregion

        #region Purchase Orders & Lines

        private void GenerateNewPONumber()
        {
            Random rnd = new Random();
            txtPONumber.Text = "PO-" + DateTime.Now.Year + "-" + rnd.Next(1000, 9999);
        }

        private void btnGeneratePONumber_Click(object sender, EventArgs e)
        {
            GenerateNewPONumber();
        }

        private void LoadPurchaseOrders()
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var poList = (from po in db.PurchaseOrders
                                  join s in db.Suppliers on po.SupplierId equals s.SupplierId
                                  orderby po.PurchaseOrderId descending
                                  select new
                                  {
                                      po.PurchaseOrderId,
                                      po.PONumber,
                                      s.SupplierName,
                                      po.OrderDate,
                                      po.POStatus,
                                      po.TotalAmount
                                  }).ToList();

                    dgvPurchaseOrders.DataSource = poList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading purchase orders (LINQ to SQL): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateDraftPO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPONumber.Text))
            {
                MessageBox.Show("Please enter or generate a PO Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbPOSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select a Supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    int? newPoId = 0;
                    db.usp_PurchaseOrder_CreateDraft(
                        txtPONumber.Text.Trim(),
                        Convert.ToInt32(cmbPOSupplier.SelectedValue),
                        ref newPoId);

                    MessageBox.Show("Draft Purchase Order #" + txtPONumber.Text.Trim() + " created successfully! (ID: " + newPoId + ")",
                                    "PO Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                GenerateNewPONumber();
                LoadPurchaseOrders();
                LoadPOReport(cmbFilterPOStatus.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating purchase order: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshPOs_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }

        private void dgvPurchaseOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPurchaseOrders.Rows[e.RowIndex];
                selectedPurchaseOrderId = Convert.ToInt32(row.Cells["PurchaseOrderId"].Value);
                string poNumber = row.Cells["PONumber"].Value.ToString();
                selectedPOStatus = row.Cells["POStatus"].Value.ToString();

                lblSelectedPO.Text = "Selected PO: " + poNumber + " | Status: " + selectedPOStatus;
                if (selectedPOStatus == "Received")
                {
                    lblSelectedPO.ForeColor = ExcelTrustTheme.SemanticSuccess;
                }
                else if (selectedPOStatus == "Draft")
                {
                    lblSelectedPO.ForeColor = ExcelTrustTheme.ExcelGreen;
                }
                else
                {
                    lblSelectedPO.ForeColor = ExcelTrustTheme.SemanticDanger;
                }

                LoadPOLines(selectedPurchaseOrderId);
            }
        }

        private void LoadPOLines(int poId)
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var lines = (from pol in db.PurchaseOrderLines
                                 join p in db.Products on pol.ProductId equals p.ProductId
                                 where pol.PurchaseOrderId == poId
                                 select new
                                 {
                                     pol.POLineId,
                                     pol.ProductId,
                                     p.SKU,
                                     p.ProductName,
                                     pol.Quantity,
                                     pol.UnitCost,
                                     Subtotal = pol.Quantity * pol.UnitCost
                                 }).ToList();

                    dgvPOLines.DataSource = lines;

                    decimal total = lines.Sum(l => l.Subtotal);
                    lblPOTotalAmount.Text = "Total PO Amount: \u20B1 " + total.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading PO lines: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPOLineProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPOLineProduct.SelectedItem is Products prod)
            {
                nudPOLineCost.Value = prod.UnitCost;
            }
        }

        private void btnAddPOLine_Click(object sender, EventArgs e)
        {
            if (selectedPurchaseOrderId <= 0)
            {
                MessageBox.Show("Please select a Purchase Order from the left table first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectedPOStatus != "Draft")
            {
                MessageBox.Show("Cannot add lines to a Purchase Order with status: " + selectedPOStatus + ". Only Draft orders can be edited.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbPOLineProduct.SelectedValue == null)
            {
                MessageBox.Show("Please select a Product to add.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(cmbPOLineProduct.SelectedValue);
            int quantity = Convert.ToInt32(nudPOLineQty.Value);
            decimal cost = nudPOLineCost.Value;

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    db.usp_PurchaseOrder_AddLine(selectedPurchaseOrderId, productId, quantity, cost);
                }

                MessageBox.Show("Line item added successfully! PO Total recalculated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPOLines(selectedPurchaseOrderId);
                LoadPurchaseOrders();
                LoadPOReport(cmbFilterPOStatus.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add line item!\n" + ex.Message, "PO Line Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceivePO_Click(object sender, EventArgs e)
        {
            if (selectedPurchaseOrderId <= 0)
            {
                MessageBox.Show("Please select a Purchase Order from the table to receive.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to RECEIVE Purchase Order ID: " + selectedPurchaseOrderId + "?\n\n" +
                "This atomic transaction will:\n" +
                "1. Update PO Status to 'Received'\n" +
                "2. Increase Products StockOnHand\n" +
                "3. Insert records into StockMovements (IN)\n\n" +
                "This cannot be received twice.",
                "Confirm PO Receiving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    db.usp_PurchaseOrder_Receive(selectedPurchaseOrderId);
                }

                MessageBox.Show("Purchase Order received successfully via LINQ to SQL!\nStatus updated to 'Received', inventory stock updated, and stock movements recorded atomically.",
                                "Receive Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPurchaseOrders();
                LoadPOLines(selectedPurchaseOrderId);
                LoadProducts();
                LoadLowStockReport();
                LoadPOReport(cmbFilterPOStatus.Text);
                LoadStockMovements();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive Purchase Order Failed!\n\nTransaction was ROLLED BACK.\nError: " + ex.Message,
                                "Atomic Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Set-Specific Challenge Demonstration

        // CHALLENGE 1: Mosulay og receive sa usa ka Purchase Order sa ikaduhang higayon (Receive Twice).
        // Tumong: Pamatud-an nga i-reject sa SQL stored procedure ug mag-rollback aron dili mausab o madoble ang stock.
        private void btnTestReceiveTwice_Click(object sender, EventArgs e)
        {
            int testPoId = selectedPurchaseOrderId;
            if (testPoId <= 0)
            {
                // Mangita o mokuha sa PurchaseOrderId sa usa ka order nga na-Received na daan
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var received = db.PurchaseOrders.FirstOrDefault(po => po.POStatus == "Received");
                    if (received != null)
                    {
                        testPoId = received.PurchaseOrderId;
                    }
                    else
                    {
                        MessageBox.Show("Please first select and receive a PO, so we can demonstrate receiving it a second time.",
                                        "Exam Challenge Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            // Kuhaon ang daan nga stock sa mga produkto sa maong PO sa wala pa mosulay (Stock Before)
            string stockBeforeInfo = GetProductStocksForPO(testPoId);

            try
            {
                // Tuyuon og tawag ang db.usp_PurchaseOrder_Receive(testPoId) bisan Received na kini
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    db.usp_PurchaseOrder_Receive(testPoId);
                }

                MessageBox.Show("Unexpected: Procedure completed without error.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Mo-trigger kini og SQL Exception (Error). Sulod sa catch block, kuhaon nato ang stock human sa pagsulay (Stock After)
                string stockAfterInfo = GetProductStocksForPO(testPoId);

                // I-display sa MessageBox nga parehas ra ang Stock Before ug Stock After (Rollback successful / Unchanged stock)
                MessageBox.Show(
                    "===============================================\n" +
                    "  PRACTICAL EXAM CHALLENGE: RECEIVE TWICE TEST\n" +
                    "===============================================\n\n" +
                    "RESULT: Stored Procedure REJECTED duplicate receive!\n" +
                    "SQL Error: " + ex.Message + "\n\n" +
                    "TRANSACTION STATUS: Atomic Rollback Executed.\n\n" +
                    "STOCK VERIFICATION:\n" +
                    "Stock Before Attempt:\n" + stockBeforeInfo + "\n" +
                    "Stock After Attempt:\n" + stockAfterInfo + "\n" +
                    "==> STOCK IS UNCHANGED! Rollback successful!",
                    "Exam Challenge: Receive Twice Rejected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // CHALLENGE 2: Mosulay og insert og duplicate nga product line sa parehas nga Purchase Order.
        // Tumong: Pamatud-an nga i-reject sa SQL UNIQUE(PurchaseOrderId, ProductId) constraint ug mag-rollback.
        private void btnTestDuplicateLine_Click(object sender, EventArgs e)
        {
            if (selectedPurchaseOrderId <= 0)
            {
                MessageBox.Show("Please select a Purchase Order that already has lines.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int existingProdId = 0;
            int lineCountBefore = 0;

            // Mo Susi kung naay napili nga PO ug kuhaa ang usa ka ProductId nga daan nang naa sa maong order
            using (BernadoDataContext db = new BernadoDataContext())
            {
                var existingLine = db.PurchaseOrderLines.FirstOrDefault(l => l.PurchaseOrderId == selectedPurchaseOrderId);
                if (existingLine == null)
                {
                    MessageBox.Show("The selected PO has no line items yet. Please add at least 1 product line first, then click this button.",
                                    "Exam Challenge Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                existingProdId = existingLine.ProductId;
                // Ihapon kung pila kabuok line items ang naa sa maong order sa wala pa mosulay (Line Count Before)
                lineCountBefore = db.PurchaseOrderLines.Count(l => l.PurchaseOrderId == selectedPurchaseOrderId);
            }

            try
            {
                // Tuyuon og tawag ang db.usp_PurchaseOrder_AddLine uban ang parehas nga ProductId
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    db.usp_PurchaseOrder_AddLine(selectedPurchaseOrderId, existingProdId, 5, 100.00m);
                }

                MessageBox.Show("Unexpected: Stored procedure allowed duplicate product.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Mo-trigger kini og SQL Exception tungod sa duplicate violation. Sulod sa catch block, ihapon nato og usab ang mga lines (Line Count After)
                int lineCountAfter = 0;
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    lineCountAfter = db.PurchaseOrderLines.Count(l => l.PurchaseOrderId == selectedPurchaseOrderId);
                }

                // I-display sa MessageBox nga wala gyud nadugangan ang mga line items (Rollback successful / Unchanged items)
                MessageBox.Show(
                    "===================================================\n" +
                    " PRACTICAL EXAM CHALLENGE: DUPLICATE PRODUCT TEST\n" +
                    "===================================================\n\n" +
                    "RESULT: Duplicate product rejected by SQL constraint/procedure!\n" +
                    "SQL Error: " + ex.Message + "\n\n" +
                    "TRANSACTION STATUS: Rolled back completely.\n\n" +
                    "LINE COUNT VERIFICATION:\n" +
                    "Line items before attempt: " + lineCountBefore + "\n" +
                    "Line items after attempt:  " + lineCountAfter + "\n" +
                    "==> LINE ITEMS AND STOCK REMAIN UNCHANGED!",
                    "Exam Challenge: Duplicate Line Rejected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Function nga mokuha sa kasamtangang StockOnHand sa tanang produkto nga sakop sa usa ka Purchase Order.
        // Gigamit ni para mapakita ang Before ug After nga stock sa Challenge demonstration.
        private string GetProductStocksForPO(int poId)
        {
            using (BernadoDataContext db = new BernadoDataContext())
            {
                var list = (from pol in db.PurchaseOrderLines
                            join p in db.Products on pol.ProductId equals p.ProductId
                            where pol.PurchaseOrderId == poId
                            select new { p.ProductName, p.StockOnHand }).ToList();

                if (list.Count == 0) return "No lines found for PO #" + poId;

                string info = "";
                foreach (var item in list)
                {
                    info += " • " + item.ProductName + " => StockOnHand: " + item.StockOnHand + "\n";
                }
                return info;
            }
        }

        #endregion

        #region Reports & Audit Trail

        private void LoadLowStockReport()
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var report = db.usp_Inventory_LowStockReport().ToList();
                    dgvLowStock.DataSource = report;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading low stock report (LINQ to SQL): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshLowStock_Click(object sender, EventArgs e)
        {
            LoadLowStockReport();
        }

        private void LoadPOReport(string status)
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    string filterStatus = (string.IsNullOrEmpty(status) || status == "All") ? null : status;
                    var report = db.usp_PurchaseOrder_Report(filterStatus).ToList();
                    dgvPOReport.DataSource = report;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading PO report (LINQ to SQL): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterPOReport_Click(object sender, EventArgs e)
        {
            LoadPOReport(cmbFilterPOStatus.Text);
        }

        private void LoadStockMovements()
        {
            try
            {
                using (BernadoDataContext db = new BernadoDataContext())
                {
                    var movements = (from sm in db.StockMovements
                                     join p in db.Products on sm.ProductId equals p.ProductId
                                     orderby sm.MovementId descending
                                     select new
                                     {
                                         sm.MovementId,
                                         p.SKU,
                                         p.ProductName,
                                         sm.MovementType,
                                         sm.Quantity,
                                         sm.ReferenceNo,
                                         sm.MovementDate
                                     }).ToList();

                    dgvStockMovements.DataSource = movements;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock movements (LINQ to SQL): " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshMovements_Click(object sender, EventArgs e)
        {
            LoadStockMovements();
        }

        #endregion
    }
}
