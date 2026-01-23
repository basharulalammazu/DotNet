# SuperShop Inventory System - Midterm Practice Project

## 📋 Project Overview
This is a comprehensive **SuperShop Inventory Management System** built as a practice project for the midterm examination. The application demonstrates mastery of ASP.NET MVC fundamentals, Entity Framework Database First approach, and complete CRUD (Create, Read, Update, Delete) operations. It manages products and categories for a retail super shop, providing a fully functional inventory tracking system.

## 🎯 Project Purpose
**Midterm Practice** - Consolidates concepts from Lab 1-4 into a single cohesive application:
- MVC architecture and routing (Lab 1)
- Form handling and validation (Lab 2)
- Entity Framework with relationships (Lab 3)
- Complete CRUD operations (Lab 3-4)

## 🏗️ Project Structure

```
SuperShopInventorySystem/
├── Controllers/
│   └── HomeController.cs              # Main controller with all CRUD operations
├── Database/
│   ├── Model1.edmx                    # Entity Data Model
│   ├── Model1.Context.cs              # DbContext class
│   ├── Product.cs                     # Product entity (auto-generated)
│   └── Category.cs                    # Category entity (auto-generated)
├── Views/
│   ├── Home/
│   │   ├── Registration.cshtml        # Add new product form
│   │   ├── List.cshtml                # Product list with actions
│   │   ├── Details.cshtml             # Product details view
│   │   ├── Update.cshtml              # Update product form
│   │   └── Delete.cshtml              # Delete confirmation
│   └── Shared/
│       └── _Layout.cshtml             # Master layout
├── Content/                            # CSS files (Bootstrap)
├── Scripts/                            # JavaScript files (jQuery)
├── App_Start/                          # Configuration files
├── Web.config                          # Configuration & connection string
└── Global.asax.cs                     # Application startup
```

## 🔧 Technologies Used
- **Framework:** ASP.NET MVC 5
- **Target Framework:** .NET Framework 4.8
- **ORM:** Entity Framework 5.0
- **Database:** SQL Server
- **Approach:** Database First
- **Frontend:** HTML5, CSS3, Bootstrap
- **JavaScript:** jQuery
- **Language:** C#
- **IDE:** Visual Studio

## 📦 Database Schema

### Tables

#### Categories Table
```sql
CREATE TABLE Categories (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL
)
```

**Fields:**
- `ID` - Primary key, auto-increment
- `Name` - Category name (e.g., Electronics, Groceries, Clothing)

#### Products Table
```sql
CREATE TABLE Products (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Price VARCHAR(50) NOT NULL,
    Category_ID INT FOREIGN KEY REFERENCES Categories(ID),
    Quantity INT NOT NULL
)
```

**Fields:**
- `ID` - Primary key, auto-increment
- `Name` - Product name
- `Price` - Product price (stored as string)
- `Category_ID` - Foreign key to Categories table
- `Quantity` - Stock quantity

### Entity Relationship
```
Categories (1) -----> (*) Products
   One Category has Many Products
   One Product belongs to One Category
```

## 📦 Entity Models

### Product Entity
```csharp
public partial class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public int Category_ID { get; set; }
    public int Quantity { get; set; }
    
    // Navigation Property
    public virtual Category Category { get; set; }
}
```

### Category Entity
```csharp
public partial class Category
{
    public Category()
    {
        this.Products = new HashSet<Product>();
    }
    
    public int ID { get; set; }
    public string Name { get; set; }
    
    // Navigation Property
    public virtual ICollection<Product> Products { get; set; }
}
```

### DbContext
```csharp
public partial class SuperShopInventorySystemEntities : DbContext
{
    public SuperShopInventorySystemEntities()
        : base("name=SuperShopInventorySystemEntities")
    {
    }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
```

## 🎨 Features & Functionality

### 1. Product Registration (CREATE)
**Route:** `/Home/Registration`

**Features:**
- ✅ Form to add new products
- ✅ Category dropdown (populated from database)
- ✅ Fields: Name, Price, Quantity, Category
- ✅ Success message after registration
- ✅ Redirects to product list

**Controller Action:**
```csharp
[HttpGet]
public ActionResult Registration()
{
    var categories = db.Categories.ToList();
    ViewBag.Categories = categories;
    return View(new Product());
}

[HttpPost]
public ActionResult Registration(Product product)
{
    if (ModelState.IsValid && product != null)
    {
        db.Products.Add(product);
        db.SaveChanges();
    }
    TempData["Message"] = "Product Registered Successfully!";
    return RedirectToAction("List");
}
```

### 2. Product List (READ)
**Route:** `/Home/List`

**Features:**
- ✅ Displays all products in a table
- ✅ Shows Name, Price, Quantity, Category
- ✅ Navigation property to display category name
- ✅ Action links: Details, Update, Delete
- ✅ Search functionality (UI only)
- ✅ Success messages via TempData

**Controller Action:**
```csharp
public ActionResult List()
{
    var products = db.Products.ToList();
    return View(products);
}
```

**View Features:**
- Table layout with all product information
- Links to Registration page
- Category name displayed using navigation property
- Action buttons for each product

### 3. Product Details (READ Single)
**Route:** `/Home/Details/{id}`

**Features:**
- ✅ Displays individual product information
- ✅ Shows Name, Price, Quantity, Category
- ✅ Read-only view

**Controller Action:**
```csharp
public ActionResult Details(int id)
{
    var product = db.Products.Find(id);
    return View(product);
}
```

### 4. Update Product (UPDATE)
**Route:** `/Home/Update/{id}`

**Features:**
- ✅ Pre-populated form with existing data
- ✅ Category dropdown with current selection
- ✅ Updates all product fields
- ✅ Success message after update
- ✅ Redirects to list

**Controller Actions:**
```csharp
[HttpGet]
public ActionResult Update(int id)
{
    var product = db.Products.Find(id);
    var categories = db.Categories.ToList();
    ViewBag.Categories = categories;
    return View(product);
}

[HttpPost]
public ActionResult Update(Product product)
{
    if (ModelState.IsValid && product != null)
    {
        var prodToUpdate = db.Products.Find(product.ID);
        db.Entry(prodToUpdate).CurrentValues.SetValues(product);
        db.SaveChanges();
    }
    TempData["Message"] = "Product Updated Successfully!";
    return RedirectToAction("List");
}
```

**Update Pattern:**
- Find existing product by ID
- Use `db.Entry().CurrentValues.SetValues()` to update
- Save changes to database

### 5. Delete Product (DELETE)
**Route:** `/Home/Delete/{id}`

**Features:**
- ✅ Deletes product by ID
- ✅ Success message
- ✅ Redirects to list

**Controller Action:**
```csharp
public ActionResult Delete(int id)
{
    var product = db.Products.Find(id);
    db.Products.Remove(product);
    db.SaveChanges();
    
    TempData["Message"] = "Deleted";
    return RedirectToAction("List");
}
```

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.8
- SQL Server (any edition)
- SQL Server Management Studio (optional)

### Database Setup

1. **Create Database**
   ```sql
   CREATE DATABASE SuperShopInventoryDB;
   ```

2. **Create Categories Table**
   ```sql
   USE SuperShopInventoryDB;
   
   CREATE TABLE Categories (
       ID INT PRIMARY KEY IDENTITY(1,1),
       Name VARCHAR(100) NOT NULL
   );
   ```

3. **Create Products Table**
   ```sql
   CREATE TABLE Products (
       ID INT PRIMARY KEY IDENTITY(1,1),
       Name VARCHAR(100) NOT NULL,
       Price VARCHAR(50) NOT NULL,
       Category_ID INT FOREIGN KEY REFERENCES Categories(ID),
       Quantity INT NOT NULL
   );
   ```

4. **Insert Sample Categories**
   ```sql
   INSERT INTO Categories (Name) VALUES 
   ('Electronics'),
   ('Groceries'),
   ('Clothing'),
   ('Home & Kitchen'),
   ('Books'),
   ('Toys'),
   ('Sports'),
   ('Beauty & Personal Care');
   ```

5. **Insert Sample Products**
   ```sql
   INSERT INTO Products (Name, Price, Category_ID, Quantity) VALUES 
   ('Samsung TV 55"', '45000', 1, 15),
   ('Rice (5kg)', '450', 2, 200),
   ('Men''s T-Shirt', '500', 3, 50),
   ('Pressure Cooker', '2500', 4, 30),
   ('The Alchemist', '350', 5, 40),
   ('LEGO Set', '3500', 6, 25),
   ('Football', '800', 7, 60),
   ('Face Cream', '650', 8, 80);
   ```

### Project Setup

1. **Open Solution**
   ```
   Navigate to SuperShopInventorySystem folder
   Double-click SuperShopInventorySystem.sln
   ```

2. **Update Connection String**
   - Open `Web.config`
   - Find `<connectionStrings>` section
   - Update with your SQL Server details:
   ```xml
   <connectionStrings>
     <add name="SuperShopInventorySystemEntities" 
          connectionString="metadata=res://*/Database.Model1.csdl|res://*/Database.Model1.ssdl|res://*/Database.Model1.msl;
          provider=System.Data.SqlClient;
          provider connection string=&quot;
          data source=YOUR_SERVER_NAME;
          initial catalog=SuperShopInventoryDB;
          integrated security=True;
          MultipleActiveResultSets=True;
          App=EntityFramework&quot;" 
          providerName="System.Data.EntityClient" />
   </connectionStrings>
   ```

3. **Restore NuGet Packages**
   - Right-click solution → Restore NuGet Packages
   - Or Tools → NuGet Package Manager → Package Manager Console → `Update-Package -reinstall`

4. **Build Project**
   - Press `Ctrl + Shift + B`
   - Or Build → Build Solution

5. **Run Application**
   - Press `F5`
   - Application opens in browser
   - Start URL: `http://localhost:{port}/Home/List`

## 📍 Application Routes

| Route | Action | Description |
|-------|--------|-------------|
| `/Home/Registration` | GET/POST | Add new product form |
| `/Home/List` | GET | View all products |
| `/Home/Details/{id}` | GET | View single product details |
| `/Home/Update/{id}` | GET/POST | Update existing product |
| `/Home/Delete/{id}` | GET | Delete product |

## 🎓 Key Concepts Demonstrated

### 1. Entity Framework Database First
- ✅ Create database and tables first
- ✅ Add ADO.NET Entity Data Model
- ✅ Generate entities from database
- ✅ Auto-generated entity classes

### 2. CRUD Operations
```csharp
// CREATE
db.Products.Add(product);
db.SaveChanges();

// READ
var products = db.Products.ToList();
var product = db.Products.Find(id);

// UPDATE
var prod = db.Products.Find(id);
db.Entry(prod).CurrentValues.SetValues(updatedProduct);
db.SaveChanges();

// DELETE
var product = db.Products.Find(id);
db.Products.Remove(product);
db.SaveChanges();
```

### 3. Navigation Properties
```csharp
// Accessing related data
@product.Category.Name  // Lazy loading of category
```

### 4. ViewBag for Dynamic Data
```csharp
// Controller
ViewBag.Categories = db.Categories.ToList();

// View
@foreach (var category in ViewBag.Categories)
{
    <option value="@category.ID">@category.Name</option>
}
```

### 5. TempData for Messages
```csharp
// Controller
TempData["Message"] = "Product Registered Successfully!";

// View
<span>@TempData["message"]</span>
```

### 6. Model Binding
```csharp
// Form posts to controller
[HttpPost]
public ActionResult Registration(Product product)
{
    // product object automatically populated from form
}
```

## 💡 Code Patterns

### GET/POST Pattern
```csharp
// GET - Display form
[HttpGet]
public ActionResult Action(int id)
{
    var data = db.Entity.Find(id);
    return View(data);
}

// POST - Process form
[HttpPost]
public ActionResult Action(Entity entity)
{
    if (ModelState.IsValid)
    {
        // Process
        db.SaveChanges();
        return RedirectToAction("Success");
    }
    return View(entity);
}
```

### Find-Update Pattern
```csharp
var existing = db.Products.Find(id);
db.Entry(existing).CurrentValues.SetValues(updated);
db.SaveChanges();
```

### ViewBag Pattern for Dropdowns
```csharp
// Controller
ViewBag.Items = db.Items.ToList();

// View
<select name="Item_ID">
    @foreach (var item in ViewBag.Items)
    {
        <option value="@item.ID">@item.Name</option>
    }
</select>
```

## 🎯 Midterm Preparation Checklist

This project covers essential midterm topics:

- ✅ **MVC Architecture:** Controllers, Views, Models
- ✅ **Entity Framework:** Database First approach
- ✅ **DbContext:** Configuration and usage
- ✅ **CRUD Operations:** Complete Create, Read, Update, Delete
- ✅ **Navigation Properties:** One-to-Many relationships
- ✅ **Form Handling:** GET/POST pattern
- ✅ **Model Binding:** Automatic data binding
- ✅ **TempData:** Cross-request data storage
- ✅ **ViewBag:** Dynamic view data
- ✅ **Razor Syntax:** Views and forms
- ✅ **Routing:** Convention-based routing
- ✅ **LINQ:** Entity Framework queries

## 📝 Common Operations Reference

### Adding New Product
1. Navigate to `/Home/Registration`
2. Fill in: Name, Price, Quantity
3. Select Category from dropdown
4. Click "Register Product"
5. Redirected to product list with success message

### Viewing Products
1. Navigate to `/Home/List`
2. See all products in table format
3. View category name for each product

### Viewing Product Details
1. From List page, click "Details" link
2. See complete product information

### Updating Product
1. From List page, click "Update" link
2. Form pre-populated with current data
3. Modify fields as needed
4. Click "Update Product"
5. Redirected to list with success message

### Deleting Product
1. From List page, click "Delete" link
2. Product removed from database
3. Redirected to list with confirmation message

## 🐛 Troubleshooting

**Issue:** Connection string error
- **Solution:** Update `data source` in Web.config with your SQL Server instance

**Issue:** Tables not found
- **Solution:** Ensure database and tables are created before running application

**Issue:** Category dropdown empty
- **Solution:** Insert categories into Categories table

**Issue:** Navigation property returns null
- **Solution:** Ensure foreign key is properly set and data exists

**Issue:** Update not working
- **Solution:** Verify hidden ID field is present in update form

## 🎨 Features Summary

| Feature | Status | Description |
|---------|--------|-------------|
| Add Product | ✅ | Register new products with category |
| View Products | ✅ | List all products in table |
| Product Details | ✅ | View individual product info |
| Update Product | ✅ | Edit existing product details |
| Delete Product | ✅ | Remove products from inventory |
| Category Management | ✅ | Dropdown selection from database |
| Success Messages | ✅ | TempData feedback messages |
| Navigation Properties | ✅ | Display related category data |
| Search (UI) | ⚠️ | Search box present but not implemented |

## 📊 Database Statistics

- **Tables:** 2 (Categories, Products)
- **Relationships:** 1 (One-to-Many)
- **Sample Categories:** 8
- **Sample Products:** 8
- **CRUD Operations:** Full implementation

## 🔜 Potential Enhancements

Future improvements for practice:
1. Implement search functionality
2. Add pagination for product list
3. Add data validation attributes
4. Implement sorting by column
5. Add product images
6. Create category management page
7. Add authentication/authorization
8. Implement low stock alerts
9. Add sales tracking
10. Generate reports

## 💼 Exam Preparation Notes

**Key Areas to Review:**
- Entity Framework Database First steps
- CRUD operation implementation
- Navigation properties usage
- TempData vs ViewBag vs ViewData
- Model binding mechanism
- Routing conventions
- DbContext lifecycle
- LINQ to Entities

**Common Exam Questions:**
- How to create Entity Data Model?
- Difference between Find() and Where()?
- How to update entities?
- What are navigation properties?
- How to pass data from controller to view?

## 👨‍💻 Author
Created as midterm practice for Advanced Programming with .NET course, Semester 9

## 📄 License
Educational project for learning purposes

---

**Course:** Advanced Programming with .NET  
**Project Type:** Midterm Practice  
**Status:** ✅ Complete  
**Date:** January 2026

**Note:** This project consolidates concepts from Labs 1-4 and serves as comprehensive practice for the midterm examination.
