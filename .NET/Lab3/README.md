# Lab 3 - Entity Framework Database First in ASP.NET MVC

## 📋 Project Overview
This lab demonstrates the implementation of **Entity Framework Database First** approach in ASP.NET MVC. The project is a SuperShop inventory management system that allows users to manage products and categories with full CRUD (Create, Read, Update, Delete) operations using Entity Framework to interact with a SQL Server database.

## 🎯 Learning Objectives
- Understanding Entity Framework Database First approach
- Creating Entity Data Models (EDM) from existing databases
- Working with DbContext and DbSet
- Implementing CRUD operations using Entity Framework
- Using navigation properties and relationships
- Understanding foreign key relationships
- Working with TempData for cross-request data
- Database connection string configuration

## 🏗️ Project Structure

```
Lab3/
└── SuperShop/
    └── SuperShop/
        ├── Controllers/
        │   └── HomeController.cs          # Main controller with CRUD operations
        ├── EF/
        │   ├── Model1.edmx                # Entity Data Model
        │   ├── Model1.edmx.diagram        # Visual diagram
        │   ├── Model1.Context.cs          # DbContext class
        │   ├── Model1.Designer.cs         # Designer generated code
        │   ├── Product.cs                 # Product entity
        │   └── Category.cs                # Category entity
        ├── Views/
        │   ├── Home/
        │   │   ├── Index.cshtml           # Product list view
        │   │   ├── ProductRegistration.cshtml  # Add product form
        │   │   ├── Details.cshtml         # Product details view
        │   │   ├── Update.cshtml          # Update product form
        │   │   ├── About.cshtml           # About page
        │   │   └── Contact.cshtml         # Contact page
        │   └── Shared/
        │       ├── _Layout.cshtml         # Master layout
        │       └── Error.cshtml           # Error page
        ├── App_Start/
        │   ├── RouteConfig.cs             # Routing configuration
        │   ├── FilterConfig.cs            # Filter configuration
        │   └── BundleConfig.cs            # Bundle configuration
        ├── Content/                        # CSS files
        ├── Scripts/                        # JavaScript files
        ├── Web.config                      # Configuration with connection string
        └── Global.asax.cs                 # Application startup
```

## 🔧 Technologies Used
- **Framework:** ASP.NET MVC 5
- **Target Framework:** .NET Framework 4.8.1
- **ORM:** Entity Framework 5.0
- **Database:** SQL Server (ShopManagement)
- **Approach:** Database First
- **Frontend:** HTML5, CSS3, Bootstrap 5
- **JavaScript:** jQuery 3.7.0
- **Language:** C#
- **IDE:** Visual Studio

## 📦 Database Schema

### Tables

#### Categories Table
```sql
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL
)
```

#### Products Table
```sql
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Price INT NOT NULL,
    Qty INT NOT NULL,
    CId INT FOREIGN KEY REFERENCES Categories(Id)
)
```

### Relationship
- **One-to-Many:** One Category can have many Products
- **Foreign Key:** `Products.CId` → `Categories.Id`

## 📦 Key Components

### 1. Entity Models

#### Product Entity
```csharp
public partial class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Qty { get; set; }
    public Nullable<int> CId { get; set; }
    
    // Navigation Property
    public virtual Category Category { get; set; }
}
```

**Properties:**
- `Id` - Auto-generated primary key
- `Name` - Product name (VARCHAR 50)
- `Price` - Product price (INT)
- `Qty` - Quantity in stock (INT)
- `CId` - Foreign key to Category (Nullable)
- `Category` - Navigation property to Category entity

#### Category Entity
```csharp
public partial class Category
{
    public Category()
    {
        this.Products = new HashSet<Product>();
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Navigation Property
    public virtual ICollection<Product> Products { get; set; }
}
```

**Properties:**
- `Id` - Auto-generated primary key
- `Name` - Category name (VARCHAR 50)
- `Products` - Collection of products in this category

### 2. DbContext Class

```csharp
public partial class ShopManagementEntities : DbContext
{
    public ShopManagementEntities()
        : base("name=ShopManagementEntities")
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

**Key Points:**
- Inherits from `DbContext`
- Connection string: `ShopManagementEntities`
- Two DbSets for Categories and Products
- OnModelCreating throws exception (Database First, not Code First)

### 3. HomeController with CRUD Operations

```csharp
public class HomeController : Controller
{
    ShopManagementEntities db = new ShopManagementEntities();
    
    // READ - List all products
    public ActionResult Index()
    {
        var product = db.Products.ToList();
        return View(product);
    }
    
    // CREATE - GET
    [HttpGet]
    public ActionResult ProductRegistration()
    {
        var cat = db.Categories.ToList();
        return View(cat);
    }
    
    // CREATE - POST
    [HttpPost]
    public ActionResult ProductRegistration(Product product)
    {
        if (ModelState.IsValid)
        {
            db.Products.Add(product);
            db.SaveChanges();
            TempData["Msg"] = "Product Added";
            return RedirectToAction("Index");
        }
        
        var cat = db.Categories.ToList();
        return View(cat);
    }
    
    // READ - Single product details
    public ActionResult Details(int id)
    {
        var product = db.Products.Find(id);
        return View(product);
    }
}
```

## 🎨 Features

### 1. Product Management
- ✅ **List Products** - Display all products in a table
- ✅ **Add Product** - Register new products with category selection
- ✅ **View Details** - See individual product information
- ✅ **Update Product** - Edit existing product (placeholder)
- ✅ **Delete Product** - Remove products (placeholder)

### 2. Category Management
- ✅ Categories loaded from database
- ✅ Dropdown selection in product registration
- ✅ Foreign key relationship maintained

### 3. Data Validation
- ✅ ModelState validation
- ✅ Required field validation
- ✅ Success messages using TempData

### 4. Navigation
- ✅ Links for Update, Delete, View operations
- ✅ Redirect after successful add
- ✅ Back to list navigation

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.8.1
- SQL Server (any edition)
- SQL Server Management Studio (optional)

### Database Setup

1. **Create Database**
   ```sql
   CREATE DATABASE ShopManagement;
   ```

2. **Create Categories Table**
   ```sql
   USE ShopManagement;
   
   CREATE TABLE Categories (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Name VARCHAR(50) NOT NULL
   );
   ```

3. **Create Products Table**
   ```sql
   CREATE TABLE Products (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Name VARCHAR(50) NOT NULL,
       Price INT NOT NULL,
       Qty INT NOT NULL,
       CId INT FOREIGN KEY REFERENCES Categories(Id)
   );
   ```

4. **Insert Sample Categories**
   ```sql
   INSERT INTO Categories (Name) VALUES 
   ('Electronics'),
   ('Clothing'),
   ('Food'),
   ('Books'),
   ('Toys');
   ```

5. **Insert Sample Products**
   ```sql
   INSERT INTO Products (Name, Price, Qty, CId) VALUES 
   ('Laptop', 50000, 10, 1),
   ('T-Shirt', 500, 50, 2),
   ('Rice', 60, 100, 3),
   ('Novel', 300, 25, 4),
   ('Action Figure', 800, 30, 5);
   ```

### Project Setup

1. **Clone/Download Project**
   ```
   Navigate to Lab3/SuperShop
   ```

2. **Update Connection String**
   - Open `Web.config`
   - Update the connection string with your SQL Server instance:
   ```xml
   <connectionStrings>
     <add name="ShopManagementEntities" 
          connectionString="metadata=res://*/EF.Model1.csdl|res://*/EF.Model1.ssdl|res://*/EF.Model1.msl;
          provider=System.Data.SqlClient;
          provider connection string=&quot;
          data source=YOUR_SERVER_NAME;
          initial catalog=ShopManagement;
          integrated security=True;
          trustservercertificate=True;
          MultipleActiveResultSets=True;
          App=EntityFramework&quot;" 
          providerName="System.Data.EntityClient" />
   </connectionStrings>
   ```

3. **Open Solution**
   ```
   Double-click SuperShop.sln
   ```

4. **Restore NuGet Packages**
   - Right-click solution → Restore NuGet Packages

5. **Build the Project**
   - Press `Ctrl + Shift + B`

6. **Run the Application**
   - Press `F5`

## 📍 Routes

- `/` or `/Home/Index` - Product list (main page)
- `/Home/ProductRegistration` - Add new product
- `/Home/Details/{id}` - View product details
- `/Home/Update/{id}` - Update product (placeholder)
- `/Home/Delete/{id}` - Delete product (placeholder)
- `/Home/About` - About page
- `/Home/Contact` - Contact page

## 🎓 Key Concepts Demonstrated

### 1. Database First Approach

**Steps:**
1. Create database and tables first
2. Add ADO.NET Entity Data Model to project
3. Select "EF Designer from database"
4. Choose connection and tables
5. Entity Framework generates classes automatically

### 2. Entity Framework CRUD Operations

#### Create (Insert)
```csharp
db.Products.Add(product);
db.SaveChanges();
```

#### Read (Select)
```csharp
// Get all
var products = db.Products.ToList();

// Get by ID
var product = db.Products.Find(id);

// Get with Where
var electronics = db.Products.Where(p => p.CId == 1).ToList();
```

#### Update
```csharp
var product = db.Products.Find(id);
product.Name = "Updated Name";
db.SaveChanges();
```

#### Delete
```csharp
var product = db.Products.Find(id);
db.Products.Remove(product);
db.SaveChanges();
```

### 3. Navigation Properties

**Lazy Loading:**
```csharp
var product = db.Products.Find(1);
var categoryName = product.Category.Name; // Loads category when accessed
```

**Eager Loading:**
```csharp
var products = db.Products.Include("Category").ToList();
```

### 4. TempData Usage

```csharp
// Set in action
TempData["Msg"] = "Product Added";

// Read in view
@TempData["msg"]
```

**Characteristics:**
- Survives one redirect
- Cleared after being read
- Stored in session state

### 5. Connection String Anatomy

```
Provider: System.Data.EntityClient
Metadata: res://*/EF.Model1.csdl|res://*/EF.Model1.ssdl|res://*/EF.Model1.msl
Data Source: SQL Server instance name
Initial Catalog: Database name
Integrated Security: Windows Authentication
```

## 📝 Views Implementation

### Index View (Product List)
```cshtml
<table class="table-bordered">
    <tr>
        <th>Name</th>
        <th>Price</th>
        <th>Quantity</th>
    </tr>
    @foreach(var item in Model)
    {
        <tr>
            <td>@item.Name</td>
            <td>@item.Price</td>
            <td>@item.Qty</td>
            <td>
                <a href="Home/Update/@item.Id">Update</a>
                <a href="Home/Delete/@item.Id">Delete</a>
                <a href="Home/Details/@item.Id">View</a>
            </td>
        </tr>
    }
</table>
```

### Product Registration View
```cshtml
<form action="" method="post">
    <input type="text" name="Name" placeholder="Enter product name" />
    <input type="text" name="Price" placeholder="Enter price" />
    <input type="text" name="Quantity" placeholder="Enter quantity" />
    
    <select name="Type">
        @foreach(var item in Model)
        {
            <option value="@item.Id">@item.Name</option>
        }
    </select>
    
    <input type="submit" value="Submit" />
</form>
```

### Details View
```cshtml
<div>
    <label>Name: @Model.Name</label>
    <label>Price: @Model.Price</label>
    <label>Quantity: @Model.Qty</label>
    <a href="Home/index">Back to list</a>
</div>
```

## 💡 Best Practices

### 1. DbContext Management
```csharp
✅ Create one DbContext instance per request
✅ Dispose DbContext after use (or use 'using' statement)
❌ Don't create DbContext at class level for web apps
❌ Don't keep DbContext alive too long
```

### 2. Querying Best Practices
```csharp
✅ Use ToList() only when needed
✅ Use Find() for single entity by primary key
✅ Use FirstOrDefault() for safe single retrieval
✅ Use Include() for eager loading related data
❌ Avoid multiple database calls in loops
```

### 3. Model Validation
```csharp
✅ Always check ModelState.IsValid
✅ Return view with model on validation failure
✅ Show validation errors in view
```

### 4. Entity Relationships
```csharp
✅ Use virtual for navigation properties (enables lazy loading)
✅ Initialize collections in constructor (Category example)
✅ Use Nullable<int> for optional foreign keys
```

## 🔍 Entity Framework Features

### 1. LINQ Support
```csharp
// Method syntax
var products = db.Products.Where(p => p.Price > 1000).ToList();

// Query syntax
var products = (from p in db.Products
                where p.Price > 1000
                select p).ToList();
```

### 2. Change Tracking
```csharp
var product = db.Products.Find(1);
product.Price = 5000;
// Entity Framework tracks this change
db.SaveChanges(); // Updates database
```

### 3. Automatic SQL Generation
Entity Framework automatically generates SQL commands:
- INSERT for Add()
- SELECT for queries
- UPDATE for modified entities
- DELETE for Remove()

## 🐛 Troubleshooting

**Issue:** Connection string error
- **Solution:** Update `data source` with your SQL Server instance name
- Check database name matches your database

**Issue:** Entity Framework not found
- **Solution:** Install via NuGet: `Install-Package EntityFramework`

**Issue:** Tables not showing in EDM wizard
- **Solution:** Ensure database connection is successful
- Check user has permissions on database

**Issue:** Navigation properties null
- **Solution:** Check foreign key is properly set
- Verify relationship in EDMX designer
- Try eager loading with Include()

**Issue:** SaveChanges() doesn't update database
- **Solution:** Ensure entity is being tracked
- Check ModelState.IsValid
- Verify connection string is correct

## 🎯 Learning Outcomes

After completing this lab, you should understand:

✅ Database First vs Code First approaches  
✅ Creating EDM from existing database  
✅ DbContext and DbSet classes  
✅ CRUD operations with Entity Framework  
✅ Navigation properties and relationships  
✅ Foreign key constraints  
✅ Connection string configuration  
✅ Entity tracking and change detection  
✅ LINQ to Entities queries  
✅ Model binding in forms  

## 🔗 Related Concepts
- Entity Framework
- Database First Approach
- LINQ (Language Integrated Query)
- DbContext
- Navigation Properties
- Foreign Keys
- Model Binding
- TempData
- ADO.NET Entity Data Model

## 📚 Additional Notes

### Entity Framework Approaches

**Database First (This Lab)**
- Database exists first
- Generate models from database
- Good for legacy databases
- Database changes require model updates

**Code First**
- Write classes first
- EF generates database
- Good for new projects
- Easy migrations

**Model First**
- Design model visually
- Generate both database and classes
- Less commonly used

## 🔜 Next Steps

To extend this project:
1. Implement Update functionality
2. Implement Delete functionality
3. Add search and filter options
4. Implement pagination
5. Add more validations
6. Create separate views for categories
7. Add authentication and authorization
8. Implement error handling

## 👨‍💻 Author
Created as part of Advanced Programming with .NET course, Semester 9

## 📄 License
Educational project for learning purposes

---

**Course:** Advanced Programming with .NET  
**Lab:** Lab 3 - Entity Framework Database First  
**Date:** January 2026
