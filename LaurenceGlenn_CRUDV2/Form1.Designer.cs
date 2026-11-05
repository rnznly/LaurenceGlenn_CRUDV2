namespace LaurenceGlenn_CRUDV2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.grpProductSearch = new System.Windows.Forms.GroupBox();
            this.btnRefreshProducts = new System.Windows.Forms.Button();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.lblProductSearch = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.grpProductInfo = new System.Windows.Forms.GroupBox();
            this.chkProductIsActive = new System.Windows.Forms.CheckBox();
            this.nudProductStock = new System.Windows.Forms.NumericUpDown();
            this.lblProductStock = new System.Windows.Forms.Label();
            this.nudProductReorder = new System.Windows.Forms.NumericUpDown();
            this.lblProductReorder = new System.Windows.Forms.Label();
            this.nudProductCost = new System.Windows.Forms.NumericUpDown();
            this.lblProductCost = new System.Windows.Forms.Label();
            this.cmbProductSupplier = new System.Windows.Forms.ComboBox();
            this.lblProductSupplier = new System.Windows.Forms.Label();
            this.cmbProductCategory = new System.Windows.Forms.ComboBox();
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductSKU = new System.Windows.Forms.TextBox();
            this.lblProductSKU = new System.Windows.Forms.Label();
            this.btnClearProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.tabSuppliers = new System.Windows.Forms.TabPage();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.grpSupplierSearch = new System.Windows.Forms.GroupBox();
            this.btnRefreshSuppliers = new System.Windows.Forms.Button();
            this.btnSearchSupplier = new System.Windows.Forms.Button();
            this.txtSupplierSearch = new System.Windows.Forms.TextBox();
            this.lblSupplierSearch = new System.Windows.Forms.Label();
            this.grpSupplierInfo = new System.Windows.Forms.GroupBox();
            this.cmbSupplierStatus = new System.Windows.Forms.ComboBox();
            this.lblSupplierStatus = new System.Windows.Forms.Label();
            this.txtSupplierEmail = new System.Windows.Forms.TextBox();
            this.lblSupplierEmail = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.btnClearSupplier = new System.Windows.Forms.Button();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.btnUpdateSupplier = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.grpCategoryInfo = new System.Windows.Forms.GroupBox();
            this.btnClearCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.tabPurchaseOrders = new System.Windows.Forms.TabPage();
            this.grpPOActions = new System.Windows.Forms.GroupBox();
            this.btnTestDuplicateLine = new System.Windows.Forms.Button();
            this.btnTestReceiveTwice = new System.Windows.Forms.Button();
            this.btnReceivePO = new System.Windows.Forms.Button();
            this.grpPOLineEntry = new System.Windows.Forms.GroupBox();
            this.lblPOTotalAmount = new System.Windows.Forms.Label();
            this.dgvPOLines = new System.Windows.Forms.DataGridView();
            this.btnAddPOLine = new System.Windows.Forms.Button();
            this.nudPOLineCost = new System.Windows.Forms.NumericUpDown();
            this.lblPOLineCost = new System.Windows.Forms.Label();
            this.nudPOLineQty = new System.Windows.Forms.NumericUpDown();
            this.lblPOLineQty = new System.Windows.Forms.Label();
            this.cmbPOLineProduct = new System.Windows.Forms.ComboBox();
            this.lblPOLineProduct = new System.Windows.Forms.Label();
            this.lblSelectedPO = new System.Windows.Forms.Label();
            this.grpPOList = new System.Windows.Forms.GroupBox();
            this.btnRefreshPOs = new System.Windows.Forms.Button();
            this.dgvPurchaseOrders = new System.Windows.Forms.DataGridView();
            this.grpPOCreate = new System.Windows.Forms.GroupBox();
            this.btnCreateDraftPO = new System.Windows.Forms.Button();
            this.cmbPOSupplier = new System.Windows.Forms.ComboBox();
            this.lblPOSupplier = new System.Windows.Forms.Label();
            this.btnGeneratePONumber = new System.Windows.Forms.Button();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.lblPONumber = new System.Windows.Forms.Label();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.grpStockMovements = new System.Windows.Forms.GroupBox();
            this.btnRefreshMovements = new System.Windows.Forms.Button();
            this.dgvStockMovements = new System.Windows.Forms.DataGridView();
            this.grpPOReport = new System.Windows.Forms.GroupBox();
            this.btnFilterPOReport = new System.Windows.Forms.Button();
            this.cmbFilterPOStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterPOStatus = new System.Windows.Forms.Label();
            this.dgvPOReport = new System.Windows.Forms.DataGridView();
            this.grpLowStock = new System.Windows.Forms.GroupBox();
            this.btnRefreshLowStock = new System.Windows.Forms.Button();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.grpProductSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.grpProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductReorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCost)).BeginInit();
            this.tabSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.grpSupplierSearch.SuspendLayout();
            this.grpSupplierInfo.SuspendLayout();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.grpCategoryInfo.SuspendLayout();
            this.tabPurchaseOrders.SuspendLayout();
            this.grpPOActions.SuspendLayout();
            this.grpPOLineEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPOLineCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPOLineQty)).BeginInit();
            this.grpPOList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).BeginInit();
            this.grpPOCreate.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.grpStockMovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMovements)).BeginInit();
            this.grpPOReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOReport)).BeginInit();
            this.grpLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabProducts);
            this.tabControlMain.Controls.Add(this.tabSuppliers);
            this.tabControlMain.Controls.Add(this.tabCategories);
            this.tabControlMain.Controls.Add(this.tabPurchaseOrders);
            this.tabControlMain.Controls.Add(this.tabReports);
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(12, 45);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1240, 665);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.grpProductSearch);
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Controls.Add(this.grpProductInfo);
            this.tabProducts.Location = new System.Drawing.Point(4, 24);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(1232, 637);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Products CRUD";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // grpProductSearch
            // 
            this.grpProductSearch.Controls.Add(this.btnRefreshProducts);
            this.grpProductSearch.Controls.Add(this.btnSearchProduct);
            this.grpProductSearch.Controls.Add(this.txtProductSearch);
            this.grpProductSearch.Controls.Add(this.lblProductSearch);
            this.grpProductSearch.Location = new System.Drawing.Point(400, 15);
            this.grpProductSearch.Name = "grpProductSearch";
            this.grpProductSearch.Size = new System.Drawing.Size(815, 60);
            this.grpProductSearch.TabIndex = 2;
            this.grpProductSearch.TabStop = false;
            this.grpProductSearch.Text = "Search & Filter Products";
            // 
            // btnRefreshProducts
            // 
            this.btnRefreshProducts.Location = new System.Drawing.Point(695, 22);
            this.btnRefreshProducts.Name = "btnRefreshProducts";
            this.btnRefreshProducts.Size = new System.Drawing.Size(100, 25);
            this.btnRefreshProducts.TabIndex = 3;
            this.btnRefreshProducts.Text = "Show All";
            this.btnRefreshProducts.UseVisualStyleBackColor = true;
            this.btnRefreshProducts.Click += new System.EventHandler(this.btnRefreshProducts_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Location = new System.Drawing.Point(585, 22);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(95, 25);
            this.btnSearchProduct.TabIndex = 2;
            this.btnSearchProduct.Text = "Search";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Location = new System.Drawing.Point(260, 23);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(310, 23);
            this.txtProductSearch.TabIndex = 1;
            // 
            // lblProductSearch
            // 
            this.lblProductSearch.AutoSize = true;
            this.lblProductSearch.Location = new System.Drawing.Point(15, 26);
            this.lblProductSearch.Name = "lblProductSearch";
            this.lblProductSearch.Size = new System.Drawing.Size(232, 15);
            this.lblProductSearch.TabIndex = 0;
            this.lblProductSearch.Text = "Search (SKU, Name, Category, or Supplier):";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(400, 85);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(815, 535);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // grpProductInfo
            // 
            this.grpProductInfo.Controls.Add(this.chkProductIsActive);
            this.grpProductInfo.Controls.Add(this.nudProductStock);
            this.grpProductInfo.Controls.Add(this.lblProductStock);
            this.grpProductInfo.Controls.Add(this.nudProductReorder);
            this.grpProductInfo.Controls.Add(this.lblProductReorder);
            this.grpProductInfo.Controls.Add(this.nudProductCost);
            this.grpProductInfo.Controls.Add(this.lblProductCost);
            this.grpProductInfo.Controls.Add(this.cmbProductSupplier);
            this.grpProductInfo.Controls.Add(this.lblProductSupplier);
            this.grpProductInfo.Controls.Add(this.cmbProductCategory);
            this.grpProductInfo.Controls.Add(this.lblProductCategory);
            this.grpProductInfo.Controls.Add(this.txtProductName);
            this.grpProductInfo.Controls.Add(this.lblProductName);
            this.grpProductInfo.Controls.Add(this.txtProductSKU);
            this.grpProductInfo.Controls.Add(this.lblProductSKU);
            this.grpProductInfo.Controls.Add(this.btnClearProduct);
            this.grpProductInfo.Controls.Add(this.btnDeleteProduct);
            this.grpProductInfo.Controls.Add(this.btnUpdateProduct);
            this.grpProductInfo.Controls.Add(this.btnAddProduct);
            this.grpProductInfo.Location = new System.Drawing.Point(15, 15);
            this.grpProductInfo.Name = "grpProductInfo";
            this.grpProductInfo.Size = new System.Drawing.Size(365, 605);
            this.grpProductInfo.TabIndex = 0;
            this.grpProductInfo.TabStop = false;
            this.grpProductInfo.Text = "Product Information";
            // 
            // chkProductIsActive
            // 
            this.chkProductIsActive.AutoSize = true;
            this.chkProductIsActive.Checked = true;
            this.chkProductIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProductIsActive.Location = new System.Drawing.Point(130, 420);
            this.chkProductIsActive.Name = "chkProductIsActive";
            this.chkProductIsActive.Size = new System.Drawing.Size(129, 19);
            this.chkProductIsActive.TabIndex = 18;
            this.chkProductIsActive.Text = "Is Active (Available)";
            this.chkProductIsActive.UseVisualStyleBackColor = true;
            // 
            // nudProductStock
            // 
            this.nudProductStock.Location = new System.Drawing.Point(130, 365);
            this.nudProductStock.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudProductStock.Name = "nudProductStock";
            this.nudProductStock.Size = new System.Drawing.Size(210, 23);
            this.nudProductStock.TabIndex = 17;
            // 
            // lblProductStock
            // 
            this.lblProductStock.AutoSize = true;
            this.lblProductStock.Location = new System.Drawing.Point(20, 368);
            this.lblProductStock.Name = "lblProductStock";
            this.lblProductStock.Size = new System.Drawing.Size(90, 15);
            this.lblProductStock.TabIndex = 16;
            this.lblProductStock.Text = "Stock On Hand:";
            // 
            // nudProductReorder
            // 
            this.nudProductReorder.Location = new System.Drawing.Point(130, 310);
            this.nudProductReorder.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudProductReorder.Name = "nudProductReorder";
            this.nudProductReorder.Size = new System.Drawing.Size(210, 23);
            this.nudProductReorder.TabIndex = 15;
            // 
            // lblProductReorder
            // 
            this.lblProductReorder.AutoSize = true;
            this.lblProductReorder.Location = new System.Drawing.Point(20, 313);
            this.lblProductReorder.Name = "lblProductReorder";
            this.lblProductReorder.Size = new System.Drawing.Size(81, 15);
            this.lblProductReorder.TabIndex = 14;
            this.lblProductReorder.Text = "Reorder Level:";
            // 
            // nudProductCost
            // 
            this.nudProductCost.DecimalPlaces = 2;
            this.nudProductCost.Location = new System.Drawing.Point(130, 255);
            this.nudProductCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudProductCost.Name = "nudProductCost";
            this.nudProductCost.Size = new System.Drawing.Size(210, 23);
            this.nudProductCost.TabIndex = 13;
            // 
            // lblProductCost
            // 
            this.lblProductCost.AutoSize = true;
            this.lblProductCost.Location = new System.Drawing.Point(20, 258);
            this.lblProductCost.Name = "lblProductCost";
            this.lblProductCost.Size = new System.Drawing.Size(77, 15);
            this.lblProductCost.TabIndex = 12;
            this.lblProductCost.Text = "Unit Cost (â‚±):";
            // 
            // cmbProductSupplier
            // 
            this.cmbProductSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductSupplier.FormattingEnabled = true;
            this.cmbProductSupplier.Location = new System.Drawing.Point(130, 200);
            this.cmbProductSupplier.Name = "cmbProductSupplier";
            this.cmbProductSupplier.Size = new System.Drawing.Size(210, 23);
            this.cmbProductSupplier.TabIndex = 11;
            // 
            // lblProductSupplier
            // 
            this.lblProductSupplier.AutoSize = true;
            this.lblProductSupplier.Location = new System.Drawing.Point(20, 203);
            this.lblProductSupplier.Name = "lblProductSupplier";
            this.lblProductSupplier.Size = new System.Drawing.Size(53, 15);
            this.lblProductSupplier.TabIndex = 10;
            this.lblProductSupplier.Text = "Supplier:";
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Location = new System.Drawing.Point(130, 145);
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(210, 23);
            this.cmbProductCategory.TabIndex = 9;
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.AutoSize = true;
            this.lblProductCategory.Location = new System.Drawing.Point(20, 148);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(58, 15);
            this.lblProductCategory.TabIndex = 8;
            this.lblProductCategory.Text = "Category:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(130, 90);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(210, 23);
            this.txtProductName.TabIndex = 7;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(20, 93);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(87, 15);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "Product Name:";
            // 
            // txtProductSKU
            // 
            this.txtProductSKU.Location = new System.Drawing.Point(130, 40);
            this.txtProductSKU.Name = "txtProductSKU";
            this.txtProductSKU.Size = new System.Drawing.Size(210, 23);
            this.txtProductSKU.TabIndex = 5;
            // 
            // lblProductSKU
            // 
            this.lblProductSKU.AutoSize = true;
            this.lblProductSKU.Location = new System.Drawing.Point(20, 43);
            this.lblProductSKU.Name = "lblProductSKU";
            this.lblProductSKU.Size = new System.Drawing.Size(76, 15);
            this.lblProductSKU.TabIndex = 4;
            this.lblProductSKU.Text = "Product SKU:";
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.Location = new System.Drawing.Point(195, 530);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(145, 35);
            this.btnClearProduct.TabIndex = 3;
            this.btnClearProduct.Text = "Clear Fields";
            this.btnClearProduct.UseVisualStyleBackColor = true;
            this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(20, 530);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(145, 35);
            this.btnDeleteProduct.TabIndex = 2;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(195, 475);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(145, 35);
            this.btnUpdateProduct.TabIndex = 1;
            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(20, 475);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(145, 35);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // tabSuppliers
            // 
            this.tabSuppliers.Controls.Add(this.dgvSuppliers);
            this.tabSuppliers.Controls.Add(this.grpSupplierSearch);
            this.tabSuppliers.Controls.Add(this.grpSupplierInfo);
            this.tabSuppliers.Location = new System.Drawing.Point(4, 24);
            this.tabSuppliers.Name = "tabSuppliers";
            this.tabSuppliers.Padding = new System.Windows.Forms.Padding(3);
            this.tabSuppliers.Size = new System.Drawing.Size(1232, 637);
            this.tabSuppliers.TabIndex = 1;
            this.tabSuppliers.Text = "Suppliers CRUD";
            this.tabSuppliers.UseVisualStyleBackColor = true;
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.AllowUserToAddRows = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliers.Location = new System.Drawing.Point(420, 85);
            this.dgvSuppliers.MultiSelect = false;
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.ReadOnly = true;
            this.dgvSuppliers.RowHeadersVisible = false;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(795, 535);
            this.dgvSuppliers.TabIndex = 2;
            this.dgvSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuppliers_CellClick);
            // 
            // grpSupplierSearch
            // 
            this.grpSupplierSearch.Controls.Add(this.btnRefreshSuppliers);
            this.grpSupplierSearch.Controls.Add(this.btnSearchSupplier);
            this.grpSupplierSearch.Controls.Add(this.txtSupplierSearch);
            this.grpSupplierSearch.Controls.Add(this.lblSupplierSearch);
            this.grpSupplierSearch.Location = new System.Drawing.Point(420, 15);
            this.grpSupplierSearch.Name = "grpSupplierSearch";
            this.grpSupplierSearch.Size = new System.Drawing.Size(795, 60);
            this.grpSupplierSearch.TabIndex = 1;
            this.grpSupplierSearch.TabStop = false;
            this.grpSupplierSearch.Text = "Search Suppliers";
            // 
            // btnRefreshSuppliers
            // 
            this.btnRefreshSuppliers.Location = new System.Drawing.Point(670, 22);
            this.btnRefreshSuppliers.Name = "btnRefreshSuppliers";
            this.btnRefreshSuppliers.Size = new System.Drawing.Size(105, 25);
            this.btnRefreshSuppliers.TabIndex = 3;
            this.btnRefreshSuppliers.Text = "Show All";
            this.btnRefreshSuppliers.UseVisualStyleBackColor = true;
            this.btnRefreshSuppliers.Click += new System.EventHandler(this.btnRefreshSuppliers_Click);
            // 
            // btnSearchSupplier
            // 
            this.btnSearchSupplier.Location = new System.Drawing.Point(555, 22);
            this.btnSearchSupplier.Name = "btnSearchSupplier";
            this.btnSearchSupplier.Size = new System.Drawing.Size(95, 25);
            this.btnSearchSupplier.TabIndex = 2;
            this.btnSearchSupplier.Text = "Search";
            this.btnSearchSupplier.UseVisualStyleBackColor = true;
            this.btnSearchSupplier.Click += new System.EventHandler(this.btnSearchSupplier_Click);
            // 
            // txtSupplierSearch
            // 
            this.txtSupplierSearch.Location = new System.Drawing.Point(230, 23);
            this.txtSupplierSearch.Name = "txtSupplierSearch";
            this.txtSupplierSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSupplierSearch.TabIndex = 1;
            // 
            // lblSupplierSearch
            // 
            this.lblSupplierSearch.AutoSize = true;
            this.lblSupplierSearch.Location = new System.Drawing.Point(20, 26);
            this.lblSupplierSearch.Name = "lblSupplierSearch";
            this.lblSupplierSearch.Size = new System.Drawing.Size(171, 15);
            this.lblSupplierSearch.TabIndex = 0;
            this.lblSupplierSearch.Text = "Search (Code, Name, or Email):";
            // 
            // grpSupplierInfo
            // 
            this.grpSupplierInfo.Controls.Add(this.cmbSupplierStatus);
            this.grpSupplierInfo.Controls.Add(this.lblSupplierStatus);
            this.grpSupplierInfo.Controls.Add(this.txtSupplierEmail);
            this.grpSupplierInfo.Controls.Add(this.lblSupplierEmail);
            this.grpSupplierInfo.Controls.Add(this.txtSupplierName);
            this.grpSupplierInfo.Controls.Add(this.lblSupplierName);
            this.grpSupplierInfo.Controls.Add(this.txtSupplierCode);
            this.grpSupplierInfo.Controls.Add(this.lblSupplierCode);
            this.grpSupplierInfo.Controls.Add(this.btnClearSupplier);
            this.grpSupplierInfo.Controls.Add(this.btnDeleteSupplier);
            this.grpSupplierInfo.Controls.Add(this.btnUpdateSupplier);
            this.grpSupplierInfo.Controls.Add(this.btnAddSupplier);
            this.grpSupplierInfo.Location = new System.Drawing.Point(15, 15);
            this.grpSupplierInfo.Name = "grpSupplierInfo";
            this.grpSupplierInfo.Size = new System.Drawing.Size(380, 605);
            this.grpSupplierInfo.TabIndex = 0;
            this.grpSupplierInfo.TabStop = false;
            this.grpSupplierInfo.Text = "Supplier Information";
            // 
            // cmbSupplierStatus
            // 
            this.cmbSupplierStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierStatus.FormattingEnabled = true;
            this.cmbSupplierStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbSupplierStatus.Location = new System.Drawing.Point(135, 210);
            this.cmbSupplierStatus.Name = "cmbSupplierStatus";
            this.cmbSupplierStatus.Size = new System.Drawing.Size(220, 23);
            this.cmbSupplierStatus.TabIndex = 11;
            // 
            // lblSupplierStatus
            // 
            this.lblSupplierStatus.AutoSize = true;
            this.lblSupplierStatus.Location = new System.Drawing.Point(20, 213);
            this.lblSupplierStatus.Name = "lblSupplierStatus";
            this.lblSupplierStatus.Size = new System.Drawing.Size(88, 15);
            this.lblSupplierStatus.TabIndex = 10;
            this.lblSupplierStatus.Text = "Supplier Status:";
            // 
            // txtSupplierEmail
            // 
            this.txtSupplierEmail.Location = new System.Drawing.Point(135, 150);
            this.txtSupplierEmail.Name = "txtSupplierEmail";
            this.txtSupplierEmail.Size = new System.Drawing.Size(220, 23);
            this.txtSupplierEmail.TabIndex = 9;
            // 
            // lblSupplierEmail
            // 
            this.lblSupplierEmail.AutoSize = true;
            this.lblSupplierEmail.Location = new System.Drawing.Point(20, 153);
            this.lblSupplierEmail.Name = "lblSupplierEmail";
            this.lblSupplierEmail.Size = new System.Drawing.Size(84, 15);
            this.lblSupplierEmail.TabIndex = 8;
            this.lblSupplierEmail.Text = "Contact Email:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(135, 95);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(220, 23);
            this.txtSupplierName.TabIndex = 7;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(20, 98);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(88, 15);
            this.lblSupplierName.TabIndex = 6;
            this.lblSupplierName.Text = "Supplier Name:";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(135, 45);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(220, 23);
            this.txtSupplierCode.TabIndex = 5;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(20, 48);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(84, 15);
            this.lblSupplierCode.TabIndex = 4;
            this.lblSupplierCode.Text = "Supplier Code:";
            // 
            // btnClearSupplier
            // 
            this.btnClearSupplier.Location = new System.Drawing.Point(205, 345);
            this.btnClearSupplier.Name = "btnClearSupplier";
            this.btnClearSupplier.Size = new System.Drawing.Size(150, 35);
            this.btnClearSupplier.TabIndex = 3;
            this.btnClearSupplier.Text = "Clear Fields";
            this.btnClearSupplier.UseVisualStyleBackColor = true;
            this.btnClearSupplier.Click += new System.EventHandler(this.btnClearSupplier_Click);
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Location = new System.Drawing.Point(25, 345);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(150, 35);
            this.btnDeleteSupplier.TabIndex = 2;
            this.btnDeleteSupplier.Text = "Delete Supplier";
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            this.btnDeleteSupplier.Click += new System.EventHandler(this.btnDeleteSupplier_Click);
            // 
            // btnUpdateSupplier
            // 
            this.btnUpdateSupplier.Location = new System.Drawing.Point(205, 285);
            this.btnUpdateSupplier.Name = "btnUpdateSupplier";
            this.btnUpdateSupplier.Size = new System.Drawing.Size(150, 35);
            this.btnUpdateSupplier.TabIndex = 1;
            this.btnUpdateSupplier.Text = "Update Supplier";
            this.btnUpdateSupplier.UseVisualStyleBackColor = true;
            this.btnUpdateSupplier.Click += new System.EventHandler(this.btnUpdateSupplier_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(25, 285);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(150, 35);
            this.btnAddSupplier.TabIndex = 0;
            this.btnAddSupplier.Text = "Add Supplier";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.grpCategoryInfo);
            this.tabCategories.Location = new System.Drawing.Point(4, 24);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(1232, 637);
            this.tabCategories.TabIndex = 2;
            this.tabCategories.Text = "Categories CRUD";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(420, 20);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(795, 600);
            this.dgvCategories.TabIndex = 1;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            // 
            // grpCategoryInfo
            // 
            this.grpCategoryInfo.Controls.Add(this.btnClearCategory);
            this.grpCategoryInfo.Controls.Add(this.btnDeleteCategory);
            this.grpCategoryInfo.Controls.Add(this.btnUpdateCategory);
            this.grpCategoryInfo.Controls.Add(this.btnAddCategory);
            this.grpCategoryInfo.Controls.Add(this.txtCategoryName);
            this.grpCategoryInfo.Controls.Add(this.lblCategoryName);
            this.grpCategoryInfo.Location = new System.Drawing.Point(20, 20);
            this.grpCategoryInfo.Name = "grpCategoryInfo";
            this.grpCategoryInfo.Size = new System.Drawing.Size(380, 260);
            this.grpCategoryInfo.TabIndex = 0;
            this.grpCategoryInfo.TabStop = false;
            this.grpCategoryInfo.Text = "Category Information";
            // 
            // btnClearCategory
            // 
            this.btnClearCategory.Location = new System.Drawing.Point(205, 175);
            this.btnClearCategory.Name = "btnClearCategory";
            this.btnClearCategory.Size = new System.Drawing.Size(150, 35);
            this.btnClearCategory.TabIndex = 5;
            this.btnClearCategory.Text = "Clear Fields";
            this.btnClearCategory.UseVisualStyleBackColor = true;
            this.btnClearCategory.Click += new System.EventHandler(this.btnClearCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(25, 175);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(150, 35);
            this.btnDeleteCategory.TabIndex = 4;
            this.btnDeleteCategory.Text = "Delete Category";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Location = new System.Drawing.Point(205, 115);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(150, 35);
            this.btnUpdateCategory.TabIndex = 3;
            this.btnUpdateCategory.Text = "Update Category";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(25, 115);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(150, 35);
            this.btnAddCategory.TabIndex = 2;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(135, 45);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(220, 23);
            this.txtCategoryName.TabIndex = 1;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(20, 48);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(93, 15);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Category Name:";
            // 
            // tabPurchaseOrders
            // 
            this.tabPurchaseOrders.Controls.Add(this.grpPOActions);
            this.tabPurchaseOrders.Controls.Add(this.grpPOLineEntry);
            this.tabPurchaseOrders.Controls.Add(this.grpPOList);
            this.tabPurchaseOrders.Controls.Add(this.grpPOCreate);
            this.tabPurchaseOrders.Location = new System.Drawing.Point(4, 24);
            this.tabPurchaseOrders.Name = "tabPurchaseOrders";
            this.tabPurchaseOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPurchaseOrders.Size = new System.Drawing.Size(1232, 637);
            this.tabPurchaseOrders.TabIndex = 3;
            this.tabPurchaseOrders.Text = "Purchase Orders & Lines";
            this.tabPurchaseOrders.UseVisualStyleBackColor = true;
            // 
            // grpPOActions
            // 
            this.grpPOActions.Controls.Add(this.btnTestDuplicateLine);
            this.grpPOActions.Controls.Add(this.btnTestReceiveTwice);
            this.grpPOActions.Controls.Add(this.btnReceivePO);
            this.grpPOActions.Location = new System.Drawing.Point(620, 10);
            this.grpPOActions.Name = "grpPOActions";
            this.grpPOActions.Size = new System.Drawing.Size(595, 100);
            this.grpPOActions.TabIndex = 3;
            this.grpPOActions.TabStop = false;
            this.grpPOActions.Text = "Receive Order & Exam Challenge Tests";
            // 
            // btnTestDuplicateLine
            // 
            this.btnTestDuplicateLine.BackColor = System.Drawing.SystemColors.Control;
            this.btnTestDuplicateLine.Location = new System.Drawing.Point(395, 25);
            this.btnTestDuplicateLine.Name = "btnTestDuplicateLine";
            this.btnTestDuplicateLine.Size = new System.Drawing.Size(185, 55);
            this.btnTestDuplicateLine.TabIndex = 2;
            this.btnTestDuplicateLine.Text = "Test Challenge:\nDuplicate Line Rollback";
            this.btnTestDuplicateLine.UseVisualStyleBackColor = false;
            this.btnTestDuplicateLine.Click += new System.EventHandler(this.btnTestDuplicateLine_Click);
            // 
            // btnTestReceiveTwice
            // 
            this.btnTestReceiveTwice.BackColor = System.Drawing.SystemColors.Control;
            this.btnTestReceiveTwice.Location = new System.Drawing.Point(195, 25);
            this.btnTestReceiveTwice.Name = "btnTestReceiveTwice";
            this.btnTestReceiveTwice.Size = new System.Drawing.Size(185, 55);
            this.btnTestReceiveTwice.TabIndex = 1;
            this.btnTestReceiveTwice.Text = "Test Challenge:\nReceive Twice Rollback";
            this.btnTestReceiveTwice.UseVisualStyleBackColor = false;
            this.btnTestReceiveTwice.Click += new System.EventHandler(this.btnTestReceiveTwice_Click);
            // 
            // btnReceivePO
            // 
            this.btnReceivePO.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceivePO.Location = new System.Drawing.Point(15, 25);
            this.btnReceivePO.Name = "btnReceivePO";
            this.btnReceivePO.Size = new System.Drawing.Size(165, 55);
            this.btnReceivePO.TabIndex = 0;
            this.btnReceivePO.Text = "Receive Selected PO\n(Update Stock Atomically)";
            this.btnReceivePO.UseVisualStyleBackColor = true;
            this.btnReceivePO.Click += new System.EventHandler(this.btnReceivePO_Click);
            // 
            // grpPOLineEntry
            // 
            this.grpPOLineEntry.Controls.Add(this.lblPOTotalAmount);
            this.grpPOLineEntry.Controls.Add(this.dgvPOLines);
            this.grpPOLineEntry.Controls.Add(this.btnAddPOLine);
            this.grpPOLineEntry.Controls.Add(this.nudPOLineCost);
            this.grpPOLineEntry.Controls.Add(this.lblPOLineCost);
            this.grpPOLineEntry.Controls.Add(this.nudPOLineQty);
            this.grpPOLineEntry.Controls.Add(this.lblPOLineQty);
            this.grpPOLineEntry.Controls.Add(this.cmbPOLineProduct);
            this.grpPOLineEntry.Controls.Add(this.lblPOLineProduct);
            this.grpPOLineEntry.Controls.Add(this.lblSelectedPO);
            this.grpPOLineEntry.Location = new System.Drawing.Point(620, 115);
            this.grpPOLineEntry.Name = "grpPOLineEntry";
            this.grpPOLineEntry.Size = new System.Drawing.Size(595, 510);
            this.grpPOLineEntry.TabIndex = 2;
            this.grpPOLineEntry.TabStop = false;
            this.grpPOLineEntry.Text = "Line Items for Selected Purchase Order";
            // 
            // lblPOTotalAmount
            // 
            this.lblPOTotalAmount.AutoSize = true;
            this.lblPOTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOTotalAmount.Location = new System.Drawing.Point(340, 475);
            this.lblPOTotalAmount.Name = "lblPOTotalAmount";
            this.lblPOTotalAmount.Size = new System.Drawing.Size(183, 20);
            this.lblPOTotalAmount.TabIndex = 9;
            this.lblPOTotalAmount.Text = "Total PO Amount: â‚± 0.00";
            // 
            // dgvPOLines
            // 
            this.dgvPOLines.AllowUserToAddRows = false;
            this.dgvPOLines.AllowUserToDeleteRows = false;
            this.dgvPOLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPOLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOLines.Location = new System.Drawing.Point(15, 110);
            this.dgvPOLines.MultiSelect = false;
            this.dgvPOLines.Name = "dgvPOLines";
            this.dgvPOLines.ReadOnly = true;
            this.dgvPOLines.RowHeadersVisible = false;
            this.dgvPOLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOLines.Size = new System.Drawing.Size(565, 355);
            this.dgvPOLines.TabIndex = 8;
            // 
            // btnAddPOLine
            // 
            this.btnAddPOLine.Location = new System.Drawing.Point(475, 55);
            this.btnAddPOLine.Name = "btnAddPOLine";
            this.btnAddPOLine.Size = new System.Drawing.Size(105, 45);
            this.btnAddPOLine.TabIndex = 7;
            this.btnAddPOLine.Text = "Add Line Item";
            this.btnAddPOLine.UseVisualStyleBackColor = true;
            this.btnAddPOLine.Click += new System.EventHandler(this.btnAddPOLine_Click);
            // 
            // nudPOLineCost
            // 
            this.nudPOLineCost.DecimalPlaces = 2;
            this.nudPOLineCost.Location = new System.Drawing.Point(350, 75);
            this.nudPOLineCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPOLineCost.Name = "nudPOLineCost";
            this.nudPOLineCost.Size = new System.Drawing.Size(110, 23);
            this.nudPOLineCost.TabIndex = 6;
            // 
            // lblPOLineCost
            // 
            this.lblPOLineCost.AutoSize = true;
            this.lblPOLineCost.Location = new System.Drawing.Point(350, 55);
            this.lblPOLineCost.Name = "lblPOLineCost";
            this.lblPOLineCost.Size = new System.Drawing.Size(77, 15);
            this.lblPOLineCost.TabIndex = 5;
            this.lblPOLineCost.Text = "Unit Cost (â‚±):";
            // 
            // nudPOLineQty
            // 
            this.nudPOLineQty.Location = new System.Drawing.Point(245, 75);
            this.nudPOLineQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPOLineQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPOLineQty.Name = "nudPOLineQty";
            this.nudPOLineQty.Size = new System.Drawing.Size(90, 23);
            this.nudPOLineQty.TabIndex = 4;
            this.nudPOLineQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPOLineQty
            // 
            this.lblPOLineQty.AutoSize = true;
            this.lblPOLineQty.Location = new System.Drawing.Point(245, 55);
            this.lblPOLineQty.Name = "lblPOLineQty";
            this.lblPOLineQty.Size = new System.Drawing.Size(56, 15);
            this.lblPOLineQty.TabIndex = 3;
            this.lblPOLineQty.Text = "Quantity:";
            // 
            // cmbPOLineProduct
            // 
            this.cmbPOLineProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOLineProduct.FormattingEnabled = true;
            this.cmbPOLineProduct.Location = new System.Drawing.Point(15, 75);
            this.cmbPOLineProduct.Name = "cmbPOLineProduct";
            this.cmbPOLineProduct.Size = new System.Drawing.Size(215, 23);
            this.cmbPOLineProduct.TabIndex = 2;
            this.cmbPOLineProduct.SelectedIndexChanged += new System.EventHandler(this.cmbPOLineProduct_SelectedIndexChanged);
            // 
            // lblPOLineProduct
            // 
            this.lblPOLineProduct.AutoSize = true;
            this.lblPOLineProduct.Location = new System.Drawing.Point(15, 55);
            this.lblPOLineProduct.Name = "lblPOLineProduct";
            this.lblPOLineProduct.Size = new System.Drawing.Size(86, 15);
            this.lblPOLineProduct.TabIndex = 1;
            this.lblPOLineProduct.Text = "Select Product:";
            // 
            // lblSelectedPO
            // 
            this.lblSelectedPO.AutoSize = true;
            this.lblSelectedPO.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPO.ForeColor = System.Drawing.Color.Navy;
            this.lblSelectedPO.Location = new System.Drawing.Point(15, 25);
            this.lblSelectedPO.Name = "lblSelectedPO";
            this.lblSelectedPO.Size = new System.Drawing.Size(241, 17);
            this.lblSelectedPO.TabIndex = 0;
            this.lblSelectedPO.Text = "Selected PO: None (Select from table)";
            // 
            // grpPOList
            // 
            this.grpPOList.Controls.Add(this.btnRefreshPOs);
            this.grpPOList.Controls.Add(this.dgvPurchaseOrders);
            this.grpPOList.Location = new System.Drawing.Point(15, 115);
            this.grpPOList.Name = "grpPOList";
            this.grpPOList.Size = new System.Drawing.Size(590, 510);
            this.grpPOList.TabIndex = 1;
            this.grpPOList.TabStop = false;
            this.grpPOList.Text = "Purchase Orders List (Click a row to manage line items)";
            // 
            // btnRefreshPOs
            // 
            this.btnRefreshPOs.Location = new System.Drawing.Point(465, 20);
            this.btnRefreshPOs.Name = "btnRefreshPOs";
            this.btnRefreshPOs.Size = new System.Drawing.Size(110, 25);
            this.btnRefreshPOs.TabIndex = 1;
            this.btnRefreshPOs.Text = "Refresh POs";
            this.btnRefreshPOs.UseVisualStyleBackColor = true;
            this.btnRefreshPOs.Click += new System.EventHandler(this.btnRefreshPOs_Click);
            // 
            // dgvPurchaseOrders
            // 
            this.dgvPurchaseOrders.AllowUserToAddRows = false;
            this.dgvPurchaseOrders.AllowUserToDeleteRows = false;
            this.dgvPurchaseOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseOrders.Location = new System.Drawing.Point(15, 55);
            this.dgvPurchaseOrders.MultiSelect = false;
            this.dgvPurchaseOrders.Name = "dgvPurchaseOrders";
            this.dgvPurchaseOrders.ReadOnly = true;
            this.dgvPurchaseOrders.RowHeadersVisible = false;
            this.dgvPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseOrders.Size = new System.Drawing.Size(560, 440);
            this.dgvPurchaseOrders.TabIndex = 0;
            this.dgvPurchaseOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseOrders_CellClick);
            // 
            // grpPOCreate
            // 
            this.grpPOCreate.Controls.Add(this.btnCreateDraftPO);
            this.grpPOCreate.Controls.Add(this.cmbPOSupplier);
            this.grpPOCreate.Controls.Add(this.lblPOSupplier);
            this.grpPOCreate.Controls.Add(this.btnGeneratePONumber);
            this.grpPOCreate.Controls.Add(this.txtPONumber);
            this.grpPOCreate.Controls.Add(this.lblPONumber);
            this.grpPOCreate.Location = new System.Drawing.Point(15, 10);
            this.grpPOCreate.Name = "grpPOCreate";
            this.grpPOCreate.Size = new System.Drawing.Size(590, 100);
            this.grpPOCreate.TabIndex = 0;
            this.grpPOCreate.TabStop = false;
            this.grpPOCreate.Text = "Create New Purchase Order (Header)";
            // 
            // btnCreateDraftPO
            // 
            this.btnCreateDraftPO.Location = new System.Drawing.Point(465, 30);
            this.btnCreateDraftPO.Name = "btnCreateDraftPO";
            this.btnCreateDraftPO.Size = new System.Drawing.Size(110, 50);
            this.btnCreateDraftPO.TabIndex = 5;
            this.btnCreateDraftPO.Text = "Create Draft PO";
            this.btnCreateDraftPO.UseVisualStyleBackColor = true;
            this.btnCreateDraftPO.Click += new System.EventHandler(this.btnCreateDraftPO_Click);
            // 
            // cmbPOSupplier
            // 
            this.cmbPOSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOSupplier.FormattingEnabled = true;
            this.cmbPOSupplier.Location = new System.Drawing.Point(265, 55);
            this.cmbPOSupplier.Name = "cmbPOSupplier";
            this.cmbPOSupplier.Size = new System.Drawing.Size(185, 23);
            this.cmbPOSupplier.TabIndex = 4;
            // 
            // lblPOSupplier
            // 
            this.lblPOSupplier.AutoSize = true;
            this.lblPOSupplier.Location = new System.Drawing.Point(265, 30);
            this.lblPOSupplier.Name = "lblPOSupplier";
            this.lblPOSupplier.Size = new System.Drawing.Size(53, 15);
            this.lblPOSupplier.TabIndex = 3;
            this.lblPOSupplier.Text = "Supplier:";
            // 
            // btnGeneratePONumber
            // 
            this.btnGeneratePONumber.Location = new System.Drawing.Point(155, 54);
            this.btnGeneratePONumber.Name = "btnGeneratePONumber";
            this.btnGeneratePONumber.Size = new System.Drawing.Size(95, 25);
            this.btnGeneratePONumber.TabIndex = 2;
            this.btnGeneratePONumber.Text = "Generate #";
            this.btnGeneratePONumber.UseVisualStyleBackColor = true;
            this.btnGeneratePONumber.Click += new System.EventHandler(this.btnGeneratePONumber_Click);
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(20, 55);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Size = new System.Drawing.Size(125, 23);
            this.txtPONumber.TabIndex = 1;
            // 
            // lblPONumber
            // 
            this.lblPONumber.AutoSize = true;
            this.lblPONumber.Location = new System.Drawing.Point(20, 30);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(73, 15);
            this.lblPONumber.TabIndex = 0;
            this.lblPONumber.Text = "PO Number:";
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.grpStockMovements);
            this.tabReports.Controls.Add(this.grpPOReport);
            this.tabReports.Controls.Add(this.grpLowStock);
            this.tabReports.Location = new System.Drawing.Point(4, 24);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(1232, 637);
            this.tabReports.TabIndex = 4;
            this.tabReports.Text = "Reports & Audit";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // grpStockMovements
            // 
            this.grpStockMovements.Controls.Add(this.btnRefreshMovements);
            this.grpStockMovements.Controls.Add(this.dgvStockMovements);
            this.grpStockMovements.Location = new System.Drawing.Point(15, 415);
            this.grpStockMovements.Name = "grpStockMovements";
            this.grpStockMovements.Size = new System.Drawing.Size(1200, 210);
            this.grpStockMovements.TabIndex = 2;
            this.grpStockMovements.TabStop = false;
            this.grpStockMovements.Text = "Stock Movement Audit Trail (StockMovements Table)";
            // 
            // btnRefreshMovements
            // 
            this.btnRefreshMovements.Location = new System.Drawing.Point(1040, 18);
            this.btnRefreshMovements.Name = "btnRefreshMovements";
            this.btnRefreshMovements.Size = new System.Drawing.Size(145, 25);
            this.btnRefreshMovements.TabIndex = 1;
            this.btnRefreshMovements.Text = "Refresh Movements";
            this.btnRefreshMovements.UseVisualStyleBackColor = true;
            this.btnRefreshMovements.Click += new System.EventHandler(this.btnRefreshMovements_Click);
            // 
            // dgvStockMovements
            // 
            this.dgvStockMovements.AllowUserToAddRows = false;
            this.dgvStockMovements.AllowUserToDeleteRows = false;
            this.dgvStockMovements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockMovements.Location = new System.Drawing.Point(15, 48);
            this.dgvStockMovements.MultiSelect = false;
            this.dgvStockMovements.Name = "dgvStockMovements";
            this.dgvStockMovements.ReadOnly = true;
            this.dgvStockMovements.RowHeadersVisible = false;
            this.dgvStockMovements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockMovements.Size = new System.Drawing.Size(1170, 150);
            this.dgvStockMovements.TabIndex = 0;
            // 
            // grpPOReport
            // 
            this.grpPOReport.Controls.Add(this.btnFilterPOReport);
            this.grpPOReport.Controls.Add(this.cmbFilterPOStatus);
            this.grpPOReport.Controls.Add(this.lblFilterPOStatus);
            this.grpPOReport.Controls.Add(this.dgvPOReport);
            this.grpPOReport.Location = new System.Drawing.Point(620, 15);
            this.grpPOReport.Name = "grpPOReport";
            this.grpPOReport.Size = new System.Drawing.Size(595, 390);
            this.grpPOReport.TabIndex = 1;
            this.grpPOReport.TabStop = false;
            this.grpPOReport.Text = "Purchase Order Status Report (usp_PurchaseOrder_Report)";
            // 
            // btnFilterPOReport
            // 
            this.btnFilterPOReport.Location = new System.Drawing.Point(235, 23);
            this.btnFilterPOReport.Name = "btnFilterPOReport";
            this.btnFilterPOReport.Size = new System.Drawing.Size(95, 25);
            this.btnFilterPOReport.TabIndex = 3;
            this.btnFilterPOReport.Text = "Filter";
            this.btnFilterPOReport.UseVisualStyleBackColor = true;
            this.btnFilterPOReport.Click += new System.EventHandler(this.btnFilterPOReport_Click);
            // 
            // cmbFilterPOStatus
            // 
            this.cmbFilterPOStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterPOStatus.FormattingEnabled = true;
            this.cmbFilterPOStatus.Items.AddRange(new object[] {
            "All",
            "Draft",
            "Approved",
            "Received",
            "Cancelled"});
            this.cmbFilterPOStatus.Location = new System.Drawing.Point(95, 24);
            this.cmbFilterPOStatus.Name = "cmbFilterPOStatus";
            this.cmbFilterPOStatus.Size = new System.Drawing.Size(130, 23);
            this.cmbFilterPOStatus.TabIndex = 2;
            // 
            // lblFilterPOStatus
            // 
            this.lblFilterPOStatus.AutoSize = true;
            this.lblFilterPOStatus.Location = new System.Drawing.Point(15, 27);
            this.lblFilterPOStatus.Name = "lblFilterPOStatus";
            this.lblFilterPOStatus.Size = new System.Drawing.Size(71, 15);
            this.lblFilterPOStatus.TabIndex = 1;
            this.lblFilterPOStatus.Text = "Filter Status:";
            // 
            // dgvPOReport
            // 
            this.dgvPOReport.AllowUserToAddRows = false;
            this.dgvPOReport.AllowUserToDeleteRows = false;
            this.dgvPOReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPOReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOReport.Location = new System.Drawing.Point(15, 60);
            this.dgvPOReport.MultiSelect = false;
            this.dgvPOReport.Name = "dgvPOReport";
            this.dgvPOReport.ReadOnly = true;
            this.dgvPOReport.RowHeadersVisible = false;
            this.dgvPOReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOReport.Size = new System.Drawing.Size(565, 315);
            this.dgvPOReport.TabIndex = 0;
            // 
            // grpLowStock
            // 
            this.grpLowStock.Controls.Add(this.btnRefreshLowStock);
            this.grpLowStock.Controls.Add(this.dgvLowStock);
            this.grpLowStock.Location = new System.Drawing.Point(15, 15);
            this.grpLowStock.Name = "grpLowStock";
            this.grpLowStock.Size = new System.Drawing.Size(590, 390);
            this.grpLowStock.TabIndex = 0;
            this.grpLowStock.TabStop = false;
            this.grpLowStock.Text = "Low-Stock Reorder Alert (usp_Inventory_LowStockReport)";
            // 
            // btnRefreshLowStock
            // 
            this.btnRefreshLowStock.Location = new System.Drawing.Point(425, 22);
            this.btnRefreshLowStock.Name = "btnRefreshLowStock";
            this.btnRefreshLowStock.Size = new System.Drawing.Size(150, 25);
            this.btnRefreshLowStock.TabIndex = 1;
            this.btnRefreshLowStock.Text = "Refresh Low Stock";
            this.btnRefreshLowStock.UseVisualStyleBackColor = true;
            this.btnRefreshLowStock.Click += new System.EventHandler(this.btnRefreshLowStock_Click);
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Location = new System.Drawing.Point(15, 60);
            this.dgvLowStock.MultiSelect = false;
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.RowHeadersVisible = false;
            this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.Size = new System.Drawing.Size(560, 315);
            this.dgvLowStock.TabIndex = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblAppTitle.Location = new System.Drawing.Point(15, 10);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(624, 25);
            this.lblAppTitle.TabIndex = 1;
            this.lblAppTitle.Text = "Inventory & Purchase Order Management System (Database: Bernado)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.lblAppTitle);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory & Purchase Order System - Database: Bernado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.grpProductSearch.ResumeLayout(false);
            this.grpProductSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.grpProductInfo.ResumeLayout(false);
            this.grpProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductReorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCost)).EndInit();
            this.tabSuppliers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.grpSupplierSearch.ResumeLayout(false);
            this.grpSupplierSearch.PerformLayout();
            this.grpSupplierInfo.ResumeLayout(false);
            this.grpSupplierInfo.PerformLayout();
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.grpCategoryInfo.ResumeLayout(false);
            this.grpCategoryInfo.PerformLayout();
            this.tabPurchaseOrders.ResumeLayout(false);
            this.grpPOActions.ResumeLayout(false);
            this.grpPOLineEntry.ResumeLayout(false);
            this.grpPOLineEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPOLineCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPOLineQty)).EndInit();
            this.grpPOList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).EndInit();
            this.grpPOCreate.ResumeLayout(false);
            this.grpPOCreate.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.grpStockMovements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMovements)).EndInit();
            this.grpPOReport.ResumeLayout(false);
            this.grpPOReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOReport)).EndInit();
            this.grpLowStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabSuppliers;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabPurchaseOrders;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.GroupBox grpProductInfo;
        private System.Windows.Forms.Button btnClearProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TextBox txtProductSKU;
        private System.Windows.Forms.Label lblProductSKU;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductCategory;
        private System.Windows.Forms.ComboBox cmbProductCategory;
        private System.Windows.Forms.ComboBox cmbProductSupplier;
        private System.Windows.Forms.Label lblProductSupplier;
        private System.Windows.Forms.NumericUpDown nudProductCost;
        private System.Windows.Forms.Label lblProductCost;
        private System.Windows.Forms.NumericUpDown nudProductReorder;
        private System.Windows.Forms.Label lblProductReorder;
        private System.Windows.Forms.NumericUpDown nudProductStock;
        private System.Windows.Forms.Label lblProductStock;
        private System.Windows.Forms.CheckBox chkProductIsActive;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.GroupBox grpProductSearch;
        private System.Windows.Forms.Button btnRefreshProducts;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Label lblProductSearch;
        private System.Windows.Forms.GroupBox grpSupplierInfo;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox txtSupplierEmail;
        private System.Windows.Forms.Label lblSupplierEmail;
        private System.Windows.Forms.ComboBox cmbSupplierStatus;
        private System.Windows.Forms.Label lblSupplierStatus;
        private System.Windows.Forms.Button btnClearSupplier;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Button btnUpdateSupplier;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.GroupBox grpSupplierSearch;
        private System.Windows.Forms.Button btnRefreshSuppliers;
        private System.Windows.Forms.Button btnSearchSupplier;
        private System.Windows.Forms.TextBox txtSupplierSearch;
        private System.Windows.Forms.Label lblSupplierSearch;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.GroupBox grpCategoryInfo;
        private System.Windows.Forms.Button btnClearCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.GroupBox grpPOCreate;
        private System.Windows.Forms.Label lblPONumber;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.Button btnGeneratePONumber;
        private System.Windows.Forms.ComboBox cmbPOSupplier;
        private System.Windows.Forms.Label lblPOSupplier;
        private System.Windows.Forms.Button btnCreateDraftPO;
        private System.Windows.Forms.GroupBox grpPOList;
        private System.Windows.Forms.DataGridView dgvPurchaseOrders;
        private System.Windows.Forms.Button btnRefreshPOs;
        private System.Windows.Forms.GroupBox grpPOLineEntry;
        private System.Windows.Forms.Label lblSelectedPO;
        private System.Windows.Forms.Label lblPOLineProduct;
        private System.Windows.Forms.ComboBox cmbPOLineProduct;
        private System.Windows.Forms.Label lblPOLineQty;
        private System.Windows.Forms.NumericUpDown nudPOLineQty;
        private System.Windows.Forms.Label lblPOLineCost;
        private System.Windows.Forms.NumericUpDown nudPOLineCost;
        private System.Windows.Forms.Button btnAddPOLine;
        private System.Windows.Forms.DataGridView dgvPOLines;
        private System.Windows.Forms.Label lblPOTotalAmount;
        private System.Windows.Forms.GroupBox grpPOActions;
        private System.Windows.Forms.Button btnReceivePO;
        private System.Windows.Forms.Button btnTestReceiveTwice;
        private System.Windows.Forms.Button btnTestDuplicateLine;
        private System.Windows.Forms.GroupBox grpLowStock;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Button btnRefreshLowStock;
        private System.Windows.Forms.GroupBox grpPOReport;
        private System.Windows.Forms.DataGridView dgvPOReport;
        private System.Windows.Forms.Label lblFilterPOStatus;
        private System.Windows.Forms.ComboBox cmbFilterPOStatus;
        private System.Windows.Forms.Button btnFilterPOReport;
        private System.Windows.Forms.GroupBox grpStockMovements;
        private System.Windows.Forms.DataGridView dgvStockMovements;
        private System.Windows.Forms.Button btnRefreshMovements;
    }
}
