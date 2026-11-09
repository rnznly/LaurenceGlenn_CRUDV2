# LaurenceGlenn_CRUDV2
### Inventory, Suppliers, and Purchase Order Management System
**Practical Exam — SET D (Inventory, Suppliers, and Purchase Orders)**

---

## 📌 Project Overview
A complete desktop database application developed in **C# Windows Forms (.NET Framework 4.7.2)** using **LINQ to SQL (`.dbml`)** and **Microsoft SQL Server**.

This system manages inventory restocking workflows from suppliers through draft creation, line item addition, and atomic receiving transactions.

---

## 🛠️ Tech Stack & Architecture
- **Language**: C# (.NET Framework 4.7.2)
- **UI Framework**: Windows Forms (Standard Visual Studio Controls)
- **Data Access**: LINQ to SQL (`BernadoDataContext` / `BernadoDataClasses.dbml`)
- **Database**: Microsoft SQL Server / LocalDB (`Bernado`)
- **Deployment**: Published ClickOnce Installer (`setup.exe`) with embedded database package

---

## ✨ Features
1. **Products CRUD**:
   - Create, Read, Update, Delete products with SKU, Unit Cost, Reorder Level, and Stock on Hand.
   - Search products by SKU or Name.
2. **Suppliers CRUD**:
   - Manage supplier profiles, unique Supplier Codes, and Active/Inactive statuses.
3. **Categories CRUD**:
   - Categorize inventory with unique category constraint enforcement.
4. **Purchase Orders & Lines**:
   - Create draft purchase orders assigned to suppliers.
   - Add line items with validation (rejection of duplicate products on the same PO).
   - Receive purchase orders via atomic transactions (updates stock levels and logs stock movement `IN`).
5. **Set-Specific Challenge Demonstrations**:
   - Rollback and rejection when attempting to add duplicate product lines to an order.
   - Rollback and prohibition when attempting to receive an already received purchase order twice.
6. **Reports & Audit**:
   - Low stock report with deficit calculation and automatic reorder alerts.
   - Purchase order summary report filtered by status (Draft, Received, Cancelled).

---

## 🚀 How to Run

### Method 1: Published Installer (No Visual Studio Required)
1. Go to the `Published_Installer/` folder.
2. Run **`setup.exe`**.
3. The installer will automatically install the application and configure the embedded `Bernado.mdf` database.

### Method 2: From Visual Studio (Development Mode)
1. Open **`LaurenceGlenn_CRUDV2.sln`** in Visual Studio 2022.
2. Ensure SQL Server Express (`.\SQLEXPRESS`) or LocalDB is running.
3. If setting up a fresh database, execute `Bernado_Schema.sql` in SQL Server Management Studio (SSMS) or Visual Studio.
4. Press **F5** (or click **▶ Start**) to build and run.

---

## 👤 Author
- **Student**: Laurence Glenn Bernado
