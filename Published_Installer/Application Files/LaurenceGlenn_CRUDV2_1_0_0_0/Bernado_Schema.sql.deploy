USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Bernado')
BEGIN
    CREATE DATABASE Bernado;
END
GO

USE Bernado;
GO

-- 1.Maka drop og existing objects (safe order) if they exist
IF OBJECT_ID('usp_Inventory_LowStockReport', 'P') IS NOT NULL DROP PROCEDURE usp_Inventory_LowStockReport;
IF OBJECT_ID('usp_PurchaseOrder_Receive', 'P') IS NOT NULL DROP PROCEDURE usp_PurchaseOrder_Receive;
IF OBJECT_ID('usp_PurchaseOrder_AddLine', 'P') IS NOT NULL DROP PROCEDURE usp_PurchaseOrder_AddLine;
IF OBJECT_ID('usp_PurchaseOrder_CreateDraft', 'P') IS NOT NULL DROP PROCEDURE usp_PurchaseOrder_CreateDraft;
IF OBJECT_ID('usp_Supplier_GetAll', 'P') IS NOT NULL DROP PROCEDURE usp_Supplier_GetAll;
IF OBJECT_ID('usp_Supplier_CRUD', 'P') IS NOT NULL DROP PROCEDURE usp_Supplier_CRUD;
IF OBJECT_ID('usp_Product_Search', 'P') IS NOT NULL DROP PROCEDURE usp_Product_Search;
IF OBJECT_ID('usp_Product_CRUD', 'P') IS NOT NULL DROP PROCEDURE usp_Product_CRUD;
IF OBJECT_ID('usp_Category_CRUD', 'P') IS NOT NULL DROP PROCEDURE usp_Category_CRUD;
IF OBJECT_ID('usp_PurchaseOrder_Report', 'P') IS NOT NULL DROP PROCEDURE usp_PurchaseOrder_Report;

IF OBJECT_ID('StockMovements', 'U') IS NOT NULL DROP TABLE StockMovements;
IF OBJECT_ID('PurchaseOrderLines', 'U') IS NOT NULL DROP TABLE PurchaseOrderLines;
IF OBJECT_ID('PurchaseOrders', 'U') IS NOT NULL DROP TABLE PurchaseOrders;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Suppliers', 'U') IS NOT NULL DROP TABLE Suppliers;
IF OBJECT_ID('Categories', 'U') IS NOT NULL DROP TABLE Categories;
GO

--Table og ilang required constraints and schema.

-- Categories ni dapita
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) NOT NULL,
    CategoryName NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED (CategoryId ASC),
    CONSTRAINT UQ_Categories_CategoryName UNIQUE (CategoryName)
);
GO

-- Supplier ni dapita
CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) NOT NULL,
    SupplierCode NVARCHAR(50) NOT NULL,
    SupplierName NVARCHAR(150) NOT NULL,
    ContactEmail NVARCHAR(100) NOT NULL,
    SupplierStatus NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT PK_Suppliers PRIMARY KEY CLUSTERED (SupplierId ASC),
    CONSTRAINT UQ_Suppliers_SupplierCode UNIQUE (SupplierCode),
    CONSTRAINT UQ_Suppliers_SupplierName UNIQUE (SupplierName),
    CONSTRAINT UQ_Suppliers_ContactEmail UNIQUE (ContactEmail),
    CONSTRAINT CK_Suppliers_SupplierStatus CHECK (SupplierStatus IN ('Active', 'Inactive'))
);
GO

-- Prodokto
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) NOT NULL,
    SKU NVARCHAR(50) NOT NULL,
    ProductName NVARCHAR(150) NOT NULL,
    CategoryId INT NOT NULL,
    SupplierId INT NOT NULL,
    UnitCost DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    ReorderLevel INT NOT NULL DEFAULT 0,
    StockOnHand INT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_Products PRIMARY KEY CLUSTERED (ProductId ASC),
    CONSTRAINT UQ_Products_SKU UNIQUE (SKU),
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
    CONSTRAINT FK_Products_Suppliers FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId),
    CONSTRAINT CK_Products_UnitCost CHECK (UnitCost >= 0),
    CONSTRAINT CK_Products_ReorderLevel CHECK (ReorderLevel >= 0),
    CONSTRAINT CK_Products_StockOnHand CHECK (StockOnHand >= 0)
);
GO

-- PurchaseOrders
CREATE TABLE PurchaseOrders (
    PurchaseOrderId INT IDENTITY(1,1) NOT NULL,
    PONumber NVARCHAR(50) NOT NULL,
    SupplierId INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    POStatus NVARCHAR(20) NOT NULL DEFAULT 'Draft',
    TotalAmount DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    CONSTRAINT PK_PurchaseOrders PRIMARY KEY CLUSTERED (PurchaseOrderId ASC),
    CONSTRAINT UQ_PurchaseOrders_PONumber UNIQUE (PONumber),
    CONSTRAINT FK_PurchaseOrders_Suppliers FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId),
    CONSTRAINT CK_PurchaseOrders_POStatus CHECK (POStatus IN ('Draft', 'Approved', 'Received', 'Cancelled')),
    CONSTRAINT CK_PurchaseOrders_TotalAmount CHECK (TotalAmount >= 0)
);
GO

-- PurchaseOrderLines
CREATE TABLE PurchaseOrderLines (
    POLineId INT IDENTITY(1,1) NOT NULL,
    PurchaseOrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitCost DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_PurchaseOrderLines PRIMARY KEY CLUSTERED (POLineId ASC),
    CONSTRAINT FK_PurchaseOrderLines_PurchaseOrders FOREIGN KEY (PurchaseOrderId) REFERENCES PurchaseOrders(PurchaseOrderId) ON DELETE CASCADE,
    CONSTRAINT FK_PurchaseOrderLines_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    CONSTRAINT CK_PurchaseOrderLines_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_PurchaseOrderLines_UnitCost CHECK (UnitCost >= 0),
    CONSTRAINT UQ_PurchaseOrderLines_PO_Product UNIQUE (PurchaseOrderId, ProductId)
);
GO

-- StockMovements
CREATE TABLE StockMovements (
    MovementId INT IDENTITY(1,1) NOT NULL,
    ProductId INT NOT NULL,
    MovementType NVARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    ReferenceNo NVARCHAR(100) NOT NULL,
    MovementDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_StockMovements PRIMARY KEY CLUSTERED (MovementId ASC),
    CONSTRAINT FK_StockMovements_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    CONSTRAINT CK_StockMovements_MovementType CHECK (MovementType IN ('IN', 'OUT', 'ADJUSTMENT')),
    CONSTRAINT CK_StockMovements_Quantity CHECK (Quantity > 0)
);
GO

--    STORED PROCEDURES

--usp_Category_CRUD
CREATE PROCEDURE usp_Category_CRUD
    @Action NVARCHAR(20),
    @CategoryId INT = NULL,
    @CategoryName NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @Action = 'CREATE'
    BEGIN
        INSERT INTO Categories (CategoryName)
        VALUES (@CategoryName);
        SELECT SCOPE_IDENTITY() AS NewCategoryId;
    END
    ELSE IF @Action = 'READ' OR @Action = 'GETALL'
    BEGIN
        SELECT CategoryId, CategoryName FROM Categories ORDER BY CategoryName ASC;
    END
    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE Categories
        SET CategoryName = @CategoryName
        WHERE CategoryId = @CategoryId;
    END
    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM Categories WHERE CategoryId = @CategoryId;
    END
END;
GO

-- usp_Supplier_GetAll
CREATE PROCEDURE usp_Supplier_CRUD
    @Action NVARCHAR(20),
    @SupplierId INT = NULL,
    @SupplierCode NVARCHAR(50) = NULL,
    @SupplierName NVARCHAR(150) = NULL,
    @ContactEmail NVARCHAR(100) = NULL,
    @SupplierStatus NVARCHAR(20) = 'Active',
    @SearchTerm NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @Action = 'CREATE'
    BEGIN
        INSERT INTO Suppliers (SupplierCode, SupplierName, ContactEmail, SupplierStatus)
        VALUES (@SupplierCode, @SupplierName, @ContactEmail, @SupplierStatus);
        SELECT SCOPE_IDENTITY() AS NewSupplierId;
    END
    ELSE IF @Action = 'READ' OR @Action = 'GETALL'
    BEGIN
        SELECT SupplierId, SupplierCode, SupplierName, ContactEmail, SupplierStatus
        FROM Suppliers
        ORDER BY SupplierName ASC;
    END
    ELSE IF @Action = 'SEARCH'
    BEGIN
        SELECT SupplierId, SupplierCode, SupplierName, ContactEmail, SupplierStatus
        FROM Suppliers
        WHERE SupplierCode LIKE '%' + ISNULL(@SearchTerm, '') + '%'
           OR SupplierName LIKE '%' + ISNULL(@SearchTerm, '') + '%'
           OR ContactEmail LIKE '%' + ISNULL(@SearchTerm, '') + '%'
        ORDER BY SupplierName ASC;
    END
    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE Suppliers
        SET SupplierCode = @SupplierCode,
            SupplierName = @SupplierName,
            ContactEmail = @ContactEmail,
            SupplierStatus = @SupplierStatus
        WHERE SupplierId = @SupplierId;
    END
    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM Suppliers WHERE SupplierId = @SupplierId;
    END
END;
GO

CREATE PROCEDURE usp_Supplier_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    EXEC usp_Supplier_CRUD @Action = 'GETALL';
END;
GO

--usp_Product_CRUD and usp_Product_Search
CREATE PROCEDURE usp_Product_CRUD
    @Action NVARCHAR(20),
    @ProductId INT = NULL,
    @SKU NVARCHAR(50) = NULL,
    @ProductName NVARCHAR(150) = NULL,
    @CategoryId INT = NULL,
    @SupplierId INT = NULL,
    @UnitCost DECIMAL(18,2) = 0.00,
    @ReorderLevel INT = 0,
    @StockOnHand INT = 0,
    @IsActive BIT = 1,
    @SearchTerm NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @Action = 'CREATE'
    BEGIN
        INSERT INTO Products (SKU, ProductName, CategoryId, SupplierId, UnitCost, ReorderLevel, StockOnHand, IsActive)
        VALUES (@SKU, @ProductName, @CategoryId, @SupplierId, @UnitCost, @ReorderLevel, @StockOnHand, @IsActive);
        SELECT SCOPE_IDENTITY() AS NewProductId;
    END
    ELSE IF @Action = 'READ' OR @Action = 'GETALL'
    BEGIN
        SELECT 
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
        FROM Products p
        INNER JOIN Categories c ON p.CategoryId = c.CategoryId
        INNER JOIN Suppliers s ON p.SupplierId = s.SupplierId
        ORDER BY p.ProductName ASC;
    END
    ELSE IF @Action = 'SEARCH'
    BEGIN
        SELECT 
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
        FROM Products p
        INNER JOIN Categories c ON p.CategoryId = c.CategoryId
        INNER JOIN Suppliers s ON p.SupplierId = s.SupplierId
        WHERE p.SKU LIKE '%' + ISNULL(@SearchTerm, '') + '%'
           OR p.ProductName LIKE '%' + ISNULL(@SearchTerm, '') + '%'
           OR c.CategoryName LIKE '%' + ISNULL(@SearchTerm, '') + '%'
           OR s.SupplierName LIKE '%' + ISNULL(@SearchTerm, '') + '%'
        ORDER BY p.ProductName ASC;
    END
    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE Products
        SET SKU = @SKU,
            ProductName = @ProductName,
            CategoryId = @CategoryId,
            SupplierId = @SupplierId,
            UnitCost = @UnitCost,
            ReorderLevel = @ReorderLevel,
            StockOnHand = @StockOnHand,
            IsActive = @IsActive
        WHERE ProductId = @ProductId;
    END
    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM Products WHERE ProductId = @ProductId;
    END
END;
GO

CREATE PROCEDURE usp_Product_Search
    @SearchTerm NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    EXEC usp_Product_CRUD @Action = 'SEARCH', @SearchTerm = @SearchTerm;
END;
GO

--usp_PurchaseOrder_CreateDraft
CREATE PROCEDURE usp_PurchaseOrder_CreateDraft
    @PONumber NVARCHAR(50),
    @SupplierId INT,
    @NewPurchaseOrderId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Ensure PO Number is not duplicate
    IF EXISTS (SELECT 1 FROM PurchaseOrders WHERE PONumber = @PONumber)
    BEGIN
        RAISERROR('PO Number already exists.', 16, 1);
        RETURN;
    END

    INSERT INTO PurchaseOrders (PONumber, SupplierId, OrderDate, POStatus, TotalAmount)
    VALUES (@PONumber, @SupplierId, GETDATE(), 'Draft', 0.00);

    SET @NewPurchaseOrderId = SCOPE_IDENTITY();
END;
GO

-- usp_PurchaseOrder_AddLine
CREATE PROCEDURE usp_PurchaseOrder_AddLine
    @PurchaseOrderId INT,
    @ProductId INT,
    @Quantity INT,
    @UnitCost DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Check PO Status
        DECLARE @CurrentStatus NVARCHAR(20);
        SELECT @CurrentStatus = POStatus FROM PurchaseOrders WHERE PurchaseOrderId = @PurchaseOrderId;

        IF @CurrentStatus IS NULL
        BEGIN
            RAISERROR('Purchase order does not exist.', 16, 1);
        END

        IF @CurrentStatus <> 'Draft'
        BEGIN
            RAISERROR('Cannot add lines to a purchase order that is not in Draft status.', 16, 1);
        END

        -- Check duplicate product on same PO (reject duplicate products)
        IF EXISTS (SELECT 1 FROM PurchaseOrderLines WHERE PurchaseOrderId = @PurchaseOrderId AND ProductId = @ProductId)
        BEGIN
            RAISERROR('Duplicate product detected! Product already exists on this purchase order.', 16, 1);
        END

        IF @Quantity <= 0
        BEGIN
            RAISERROR('Quantity must be greater than zero.', 16, 1);
        END

        IF @UnitCost < 0
        BEGIN
            RAISERROR('Unit cost cannot be negative.', 16, 1);
        END

        -- Insert line
        INSERT INTO PurchaseOrderLines (PurchaseOrderId, ProductId, Quantity, UnitCost)
        VALUES (@PurchaseOrderId, @ProductId, @Quantity, @UnitCost);

        -- Recalculate total amount on header
        UPDATE PurchaseOrders
        SET TotalAmount = (SELECT ISNULL(SUM(Quantity * UnitCost), 0.00) FROM PurchaseOrderLines WHERE PurchaseOrderId = @PurchaseOrderId)
        WHERE PurchaseOrderId = @PurchaseOrderId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrSev INT = ERROR_SEVERITY();
        DECLARE @ErrState INT = ERROR_STATE();
        RAISERROR(@ErrMsg, @ErrSev, @ErrState);
    END CATCH
END;
GO

-- usp_PurchaseOrder_Receive (Atomic with Rollback on error)
CREATE PROCEDURE usp_PurchaseOrder_Receive
    @PurchaseOrderId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @CurrentStatus NVARCHAR(20), @PONumber NVARCHAR(50);
        SELECT @CurrentStatus = POStatus, @PONumber = PONumber
        FROM PurchaseOrders WITH (UPDLOCK, HOLDLOCK)
        WHERE PurchaseOrderId = @PurchaseOrderId;

        IF @CurrentStatus IS NULL
        BEGIN
            RAISERROR('Purchase Order not found.', 16, 1);
        END

        -- Prevent receiving twice or receiving cancelled order
        IF @CurrentStatus = 'Received'
        BEGIN
            RAISERROR('Purchase order has ALREADY been received. Duplicate receive is prohibited.', 16, 1);
        END

        IF @CurrentStatus = 'Cancelled'
        BEGIN
            RAISERROR('Cannot receive a cancelled purchase order.', 16, 1);
        END

        -- Ensure PO has lines to receive
        IF NOT EXISTS (SELECT 1 FROM PurchaseOrderLines WHERE PurchaseOrderId = @PurchaseOrderId)
        BEGIN
            RAISERROR('Cannot receive an empty purchase order with no line items.', 16, 1);
        END

        -- Update PO Status
        UPDATE PurchaseOrders
        SET POStatus = 'Received'
        WHERE PurchaseOrderId = @PurchaseOrderId;

        -- Atomically update StockOnHand in Products
        UPDATE p
        SET p.StockOnHand = p.StockOnHand + pol.Quantity
        FROM Products p
        INNER JOIN PurchaseOrderLines pol ON p.ProductId = pol.ProductId
        WHERE pol.PurchaseOrderId = @PurchaseOrderId;

        -- Atomically record Stock Movements (MovementType = 'IN')
        INSERT INTO StockMovements (ProductId, MovementType, Quantity, ReferenceNo, MovementDate)
        SELECT 
            pol.ProductId,
            'IN',
            pol.Quantity,
            @PONumber,
            GETDATE()
        FROM PurchaseOrderLines pol
        WHERE pol.PurchaseOrderId = @PurchaseOrderId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        DECLARE @Msg NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @Sev INT = ERROR_SEVERITY();
        DECLARE @St INT = ERROR_STATE();
        RAISERROR(@Msg, @Sev, @St);
    END CATCH
END;
GO

--usp_Inventory_LowStockReport
CREATE PROCEDURE usp_Inventory_LowStockReport
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        p.ProductId,
        p.SKU,
        p.ProductName,
        c.CategoryName,
        s.SupplierName,
        p.UnitCost,
        p.ReorderLevel,
        p.StockOnHand,
        (p.ReorderLevel - p.StockOnHand) AS Deficit,
        CASE 
            WHEN p.StockOnHand = 0 THEN 'OUT OF STOCK'
            ELSE 'LOW STOCK'
        END AS StockAlert
    FROM Products p
    INNER JOIN Categories c ON p.CategoryId = c.CategoryId
    INNER JOIN Suppliers s ON p.SupplierId = s.SupplierId
    WHERE p.StockOnHand <= p.ReorderLevel
      AND p.IsActive = 1
    ORDER BY (p.ReorderLevel - p.StockOnHand) DESC, p.ProductName ASC;
END;
GO

--usp_PurchaseOrder_Report
CREATE PROCEDURE usp_PurchaseOrder_Report
    @Status NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        po.PurchaseOrderId,
        po.PONumber,
        s.SupplierName,
        po.OrderDate,
        po.POStatus,
        po.TotalAmount,
        (SELECT COUNT(*) FROM PurchaseOrderLines pol WHERE pol.PurchaseOrderId = po.PurchaseOrderId) AS TotalLines,
        (SELECT ISNULL(SUM(Quantity), 0) FROM PurchaseOrderLines pol WHERE pol.PurchaseOrderId = po.PurchaseOrderId) AS TotalQuantity
    FROM PurchaseOrders po
    INNER JOIN Suppliers s ON po.SupplierId = s.SupplierId
    WHERE (@Status IS NULL OR @Status = 'All' OR po.POStatus = @Status)
    ORDER BY po.PurchaseOrderId DESC;
END;
GO

-- SAMPLE SEED DATA
-- Insert Categories
INSERT INTO Categories (CategoryName) VALUES 
('Laptops & Computers'),
('Office Electronics'),
('Computer Accessories');

-- Insert Suppliers
INSERT INTO Suppliers (SupplierCode, SupplierName, ContactEmail, SupplierStatus) VALUES
('SUP-001', 'TechGlobal Distribution', 'orders@techglobal.com', 'Active'),
('SUP-002', 'Apex Hardware Ltd.', 'sales@apexhardware.com', 'Active'),
('SUP-003', 'Prime Components Corp.', 'info@primecomponents.com', 'Active');

-- Insert Products (including some with low stock to demonstrate low stock report)
INSERT INTO Products (SKU, ProductName, CategoryId, SupplierId, UnitCost, ReorderLevel, StockOnHand, IsActive) VALUES
('SKU-1001', 'Dell Latitude 3520 Laptop', 1, 1, 32000.00, 5, 2, 1),
('SKU-1002', 'Logitech Wireless Mouse M185', 3, 2, 450.00, 20, 15, 1),
('SKU-1003', 'HP LaserJet Pro M404dn', 2, 2, 14500.00, 3, 0, 1), 
('SKU-1004', 'Kingston 16GB DDR4 RAM', 3, 3, 1850.00, 10, 25, 1),
('SKU-1005', 'Samsung 24-inch IPS Monitor', 3, 1, 6200.00, 8, 12, 1);

-- Insert a Draft Purchase Order with items ready to test receiving
DECLARE @DraftPOId INT;
EXEC usp_PurchaseOrder_CreateDraft @PONumber = 'PO-2026-0001', @SupplierId = 1, @NewPurchaseOrderId = @DraftPOId OUTPUT;
EXEC usp_PurchaseOrder_AddLine @PurchaseOrderId = @DraftPOId, @ProductId = 1, @Quantity = 10, @UnitCost = 32000.00;
EXEC usp_PurchaseOrder_AddLine @PurchaseOrderId = @DraftPOId, @ProductId = 5, @Quantity = 5, @UnitCost = 6200.00;

-- Insert a second Purchase Order for demonstration
DECLARE @DraftPOId2 INT;
EXEC usp_PurchaseOrder_CreateDraft @PONumber = 'PO-2026-0002', @SupplierId = 2, @NewPurchaseOrderId = @DraftPOId2 OUTPUT;
EXEC usp_PurchaseOrder_AddLine @PurchaseOrderId = @DraftPOId2, @ProductId = 2, @Quantity = 50, @UnitCost = 450.00;
EXEC usp_PurchaseOrder_AddLine @PurchaseOrderId = @DraftPOId2, @ProductId = 3, @Quantity = 10, @UnitCost = 14500.00;

PRINT 'Bernado Database and Schema Initialized Successfully!';
GO
