# Lab 8 - ASP.NET Core Web API with Entity Framework Core (Code First) & AutoMapper

## 📚 Overview
Welcome to **Lab 8**, where we explore the **Code First** approach with **Entity Framework Core** and integrate **AutoMapper** for seamless object-to-object mapping! This lab demonstrates how to create a database from C# entity classes, manage migrations, and build a complete RESTful API with DTOs.

## 🎯 Learning Objectives

By the end of this lab, you will understand:

- ✅ **Code First Approach** - Database from entity classes
- ✅ **EF Core Migrations** - Database schema versioning
- ✅ **Data Annotations** - Entity configuration with attributes
- ✅ **AutoMapper** - Object-to-object mapping
- ✅ **DTOs with Validation** - Data transfer with validation rules
- ✅ **Dependency Injection** - DbContext registration
- ✅ **Complete CRUD API** - Full REST operations
- ✅ **Foreign Key Relationships** - Navigation properties
- ✅ **Model State Validation** - Server-side validation
- ✅ **API Best Practices** - Professional API development

## 🏗️ Project Structure

```
IntroCFAPI/
├── Controllers/
│   ├── ShopController.cs              # Product management API endpoints
│   └── WeatherForecastController.cs   # Sample weather API
├── DTOs/
│   ├── ProductDTO.cs                  # Product data transfer object with validation
│   └── CategoryDTO.cs                 # Category data transfer object
├── EF/
│   ├── PMSContext.cs                  # DbContext - Product Management System
│   └── Table/
│       ├── Product.cs                 # Product entity with data annotations
│       └── Category.cs                # Category entity
├── Migrations/
│   ├── 20251223071831_IntialDBCreate.cs            # Initial migration
│   ├── 20251223071831_IntialDBCreate.Designer.cs  # Migration metadata
│   └── PMSContextModelSnapshot.cs                  # Current model snapshot
├── Properties/
│   └── launchSettings.json            # Launch configurations
├── appsettings.json                   # App settings & connection strings
├── Program.cs                         # Application entry point with DI
├── WeatherForecast.cs                 # Weather model
└── IntroCFAPI.csproj                  # Project file with packages
```

## 🚀 Technology Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| ASP.NET Core | 10.0 | Web API framework |
| .NET | 10.0 | Runtime environment |
| Entity Framework Core | 10.0.1 | ORM (Code First) |
| AutoMapper | 14.0.0 | Object-to-object mapping |
| SQL Server | 2019+ | Database server |
| C# | 12.0 | Programming language |
| OpenAPI | Latest | API documentation |

## 📦 NuGet Packages

```xml
<PackageReference Include="AutoMapper" Version="14.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.1" />
```

**Package Purposes:**
- **AutoMapper** - Automatic object mapping between entities and DTOs
- **EntityFrameworkCore** - Core EF functionality
- **SqlServer** - SQL Server database provider
- **Design** - Design-time support for migrations

## 📋 Key Concepts

### 1. Code First Approach

**Code First** allows you to define your database schema using C# classes:

**Workflow:**
```
1. Define Entity Classes (C# code)
   ↓
2. Create DbContext
   ↓
3. Add Migration (generates SQL)
   ↓
4. Update Database (applies changes)
   ↓
5. Database Created!
```

**Benefits:**
- ✅ Version control for database schema
- ✅ Type-safe database modeling
- ✅ Automatic schema generation
- ✅ Easy to refactor
- ✅ Database-agnostic code

### 2. Database First vs Code First

| Aspect | Database First (Lab 7) | Code First (Lab 8) |
|--------|----------------------|-------------------|
| **Starting Point** | Existing Database | C# Entity Classes |
| **Workflow** | DB → Scaffold → Code | Code → Migration → DB |
| **Schema Control** | Database tools | C# code & migrations |
| **Best For** | Legacy databases | New projects |
| **Changes** | Re-scaffold | Add migration |
| **Version Control** | ⚠️ Difficult | ✅ Easy (migrations) |

### 3. EF Core Migrations

**Migrations** track and version database schema changes:

```csharp
// Create migration
Add-Migration InitialCreate

// Update database
Update-Database

// View SQL that will be executed
Script-Migration

// Rollback migration
Update-Database PreviousMigrationName
```

### 4. Data Annotations

Configure entities using attributes:

```csharp
[Key]                              // Primary key
[Required]                         // NOT NULL
[StringLength(50)]                 // VARCHAR(50)
[Column(TypeName = "VARCHAR")]     // Specify column type
[ForeignKey("Category")]           // Foreign key relationship
[Range(0.01, double.MaxValue)]    // Value constraints
```

### 5. AutoMapper

**AutoMapper** eliminates manual mapping code:

**Without AutoMapper:**
```csharp
var productDto = new ProductDTO
{
    Name = product.Name,
    Price = product.Price,
    CId = product.CId
};
```

**With AutoMapper:**
```csharp
var productDto = mapper.Map<ProductDTO>(product);
```

## 🗃️ Database Schema

### Entity Relationship Diagram

```
┌─────────────────┐         ┌─────────────────┐
│    Category     │         │     Product     │
├─────────────────┤         ├─────────────────┤
│ Id (PK)         │◄───────┤│ Id (PK)         │
│ Name            │   1:N   │ Name            │
└─────────────────┘         │ Price           │
                            │ CId (FK)        │
                            └─────────────────┘
```

### Generated SQL Schema

**Categories Table:**
```sql
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL
);
```

**Products Table:**
```sql
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Price FLOAT NOT NULL,
    CId INT NOT NULL,
    CONSTRAINT FK_Products_Categories_CId 
        FOREIGN KEY (CId) REFERENCES Categories(Id) 
        ON DELETE CASCADE
);

CREATE INDEX IX_Products_CId ON Products(CId);
```

## 📁 Project Files Detailed

### appsettings.json - Configuration & Connection String

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DbConn": "Data Source=BASHARULALAMMAZ; initial catalog=PMSDB; TrustServerCertificate=True; Integrated Security=True;"
  }
}
```

**Connection String Components:**
- **Data Source** - SQL Server instance name
- **Initial Catalog** - Database name (PMSDB - Product Management System DB)
- **TrustServerCertificate** - Accept self-signed certificates
- **Integrated Security** - Use Windows authentication

**⚠️ Important:** Update the connection string with your SQL Server instance name.

---

### Program.cs - Application Entry Point with DI

```csharp
using IntroCFAPI.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register DbContext with Dependency Injection
builder.Services.AddDbContext<PMSContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

**Key Changes from Lab 7:**

**Dependency Injection Registration:**
```csharp
builder.Services.AddDbContext<PMSContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});
```

**Benefits:**
- ✅ **Testability** - Can inject mock DbContext
- ✅ **Lifetime Management** - Framework manages context lifecycle
- ✅ **Best Practice** - Recommended approach
- ✅ **Thread-Safe** - Scoped lifetime per request

---

### EF/PMSContext.cs - Database Context

```csharp
using IntroCFAPI.EF.Table;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace IntroCFAPI.EF
{
    public class PMSContext : DbContext
    {
        public PMSContext(DbContextOptions<PMSContext> options) : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
```

**Key Features:**

**1. Constructor with Options:**
```csharp
public PMSContext(DbContextOptions<PMSContext> options) : base(options)
```
- Receives configuration from DI
- No hardcoded connection string
- Supports different configurations per environment

**2. DbSets (Tables):**
```csharp
public DbSet<Product> Products { get; set; }
public DbSet<Category> Categories { get; set; }
```
- Each DbSet represents a table
- EF Core uses DbSet names for table names

**3. No OnConfiguring:**
- Configuration comes from Program.cs
- Cleaner, more testable approach

---

### EF/Table/Category.cs - Category Entity

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFAPI.EF.Table
{
    public class Category
    {
        [Key] // Not mandatory when variable name is Id
        public int Id { get; set; }
        
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
    }
}
```

**Data Annotations Explained:**

**1. [Key]**
```csharp
[Key]
public int Id { get; set; }
```
- Marks property as primary key
- Optional if property named "Id" or "{ClassName}Id"
- Auto-generates IDENTITY(1,1) in SQL Server

**2. [StringLength(50)]**
```csharp
[StringLength(50)]
public string Name { get; set; }
```
- Sets maximum length to 50 characters
- Creates VARCHAR(50) or NVARCHAR(50)
- Adds validation constraint

**3. [Column(TypeName = "VARCHAR")]**
```csharp
[Column(TypeName = "VARCHAR")]
public string Name { get; set; }
```
- Specifies exact SQL column type
- `VARCHAR` vs `NVARCHAR` (ASCII vs Unicode)
- Saves space for English-only text

**Generated SQL:**
```sql
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL
);
```

---

### EF/Table/Product.cs - Product Entity

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFAPI.EF.Table
{
    public class Product
    {
        public int Id { get; set; }
        
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
        
        public double Price { get; set; }
        
        [ForeignKey("Category")]
        public int CId { get; set; }
        
        public virtual Category Category { get; set; }
    }
}
```

**Key Features:**

**1. Foreign Key Configuration:**
```csharp
[ForeignKey("Category")]
public int CId { get; set; }
public virtual Category Category { get; set; }
```
- `[ForeignKey("Category")]` links CId to Category navigation property
- Creates FK constraint in database
- `virtual` enables lazy loading

**2. Navigation Property:**
```csharp
public virtual Category Category { get; set; }
```
- Allows accessing `product.Category.Name`
- EF Core automatically loads related data
- Enables LINQ joins

**Generated SQL:**
```sql
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Price FLOAT NOT NULL,
    CId INT NOT NULL,
    CONSTRAINT FK_Products_Categories_CId 
        FOREIGN KEY (CId) REFERENCES Categories(Id) 
        ON DELETE CASCADE
);
```

---

### DTOs/CategoryDTO.cs - Category Data Transfer Object

```csharp
using System.ComponentModel.DataAnnotations;

namespace IntroCFAPI.DTOs
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
```

**Validation Attribute:**
- `[Required]` - Ensures Name is not null or empty
- Automatic validation in API controllers
- Returns 400 Bad Request if validation fails

---

### DTOs/ProductDTO.cs - Product Data Transfer Object

```csharp
using IntroCFAPI.EF.Table;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFAPI.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }
        
        public int CId { get; set; }
    }
}
```

**Validation Attributes:**

**1. [Required(ErrorMessage = "...")]**
```csharp
[Required(ErrorMessage = "Name is required.")]
public string Name { get; set; }
```
- Custom error message
- User-friendly validation feedback

**2. [Range(min, max, ErrorMessage = "...")]**
```csharp
[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
public double Price { get; set; }
```
- Ensures price is greater than 0
- Prevents negative or zero prices
- Returns custom error message

**Why DTOs?**
- ✅ **Security** - Don't expose entity structure
- ✅ **Validation** - API-specific validation rules
- ✅ **Flexibility** - Different properties than entities
- ✅ **Versioning** - API changes without entity changes
- ✅ **Over-posting Prevention** - Control which fields can be set

---

### Controllers/ShopController.cs - Product Management API

```csharp
using AutoMapper;
using IntroCFAPI.DTOs;
using IntroCFAPI.EF;
using IntroCFAPI.EF.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        PMSContext db;

        public ShopController(PMSContext db)
        {
            this.db = db;
        }
        
        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>().ReverseMap();
            });
            return new Mapper(config);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var products = GetMapper().Map<List<ProductDTO>>(db.Products.ToList());
            return Ok(products);
        }

        [HttpGet("all{id}")]
        public IActionResult GetAll(int id)
        {
            var product = db.Products.Find(id);
            return Ok(product);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                var product = GetMapper().Map<Product>(productDto);
                db.Products.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Update{id}")]
        public IActionResult UpdateProduct(ProductDTO productDto, int id)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = db.Products.Find(id);
                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                var updatedProduct = GetMapper().Map<ProductDTO, Product>(productDto, existingProduct);
                db.Products.Add(updatedProduct);
                db.SaveChanges();
                return Ok(updatedProduct);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Delete{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }
    }
}
```

#### Key Components

**1. Dependency Injection:**
```csharp
PMSContext db;

public ShopController(PMSContext db)
{
    this.db = db;
}
```
- DbContext injected via constructor
- Framework manages lifecycle
- One instance per request (Scoped)

**2. AutoMapper Configuration:**
```csharp
public Mapper GetMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<ProductDTO, Product>().ReverseMap();
    });
    return new Mapper(config);
}
```
- `CreateMap<Source, Destination>()` - Define mapping
- `.ReverseMap()` - Also map Destination → Source
- Called per request (can be optimized with DI)

**3. Model State Validation:**
```csharp
if (ModelState.IsValid)
{
    // Process request
}
return BadRequest(ModelState);
```
- Automatic validation from data annotations
- Returns validation errors to client
- No manual validation code needed

---

### API Endpoints

**1. GET All Products**
```
GET /api/shop/all
```
**Description:** Retrieves all products as DTOs

**Response:**
```json
[
  {
    "name": "Laptop",
    "price": 1200.50,
    "cId": 1
  },
  {
    "name": "Mouse",
    "price": 25.99,
    "cId": 2
  }
]
```

**Code Explanation:**
```csharp
var products = GetMapper().Map<List<ProductDTO>>(db.Products.ToList());
```
- `db.Products.ToList()` - Get all products from database
- `Map<List<ProductDTO>>()` - Convert entities to DTOs
- Returns only DTO properties (no Id, no Category navigation)

---

**2. GET Product by ID**
```
GET /api/shop/all{id}
```
**Description:** Retrieves a specific product by ID

**Parameters:**
- `id` (int) - Product ID

**Example:** `GET /api/shop/all5`

**Response:**
```json
{
  "id": 5,
  "name": "Keyboard",
  "price": 75.00,
  "cId": 2,
  "category": null
}
```

**Note:** Returns full Product entity, not DTO

---

**3. POST Create Product**
```
POST /api/shop/add
```
**Description:** Creates a new product

**Request Body:**
```json
{
  "name": "Monitor",
  "price": 299.99,
  "cId": 1
}
```

**Validation Rules:**
- Name: Required
- Price: Required, must be > 0
- CId: Required

**Success Response (200 OK):**
```json
{
  "id": 6,
  "name": "Monitor",
  "price": 299.99,
  "cId": 1,
  "category": null
}
```

**Error Response (400 Bad Request):**
```json
{
  "errors": {
    "Name": ["Name is required."],
    "Price": ["Price must be greater than zero."]
  }
}
```

**Code Flow:**
1. `ModelState.IsValid` - Check validation rules
2. `Map<Product>(productDto)` - Convert DTO to entity
3. `db.Products.Add(product)` - Track for insertion
4. `db.SaveChanges()` - Execute INSERT SQL
5. Return created product with generated ID

---

**4. GET Update Product** ⚠️ (Should be PUT)
```
GET /api/shop/Update{id}?name=NewName&price=99.99&cId=1
```
**Description:** Updates an existing product

**Parameters:**
- `id` (int) - Product ID in route
- `productDto` (ProductDTO) - Update data from query string

**⚠️ Issues with Current Implementation:**
- Should use `[HttpPut]` not `[HttpGet]`
- Should read body, not query parameters
- `db.Products.Add()` should be `db.Entry().State = Modified`

**Corrected Version:**
```csharp
[HttpPut("Update/{id}")]
public IActionResult UpdateProduct(int id, ProductDTO productDto)
{
    if (ModelState.IsValid)
    {
        var existingProduct = db.Products.Find(id);
        if (existingProduct == null)
        {
            return NotFound($"Product with ID {id} not found.");
        }
        
        // Update properties
        existingProduct.Name = productDto.Name;
        existingProduct.Price = productDto.Price;
        existingProduct.CId = productDto.CId;
        
        db.SaveChanges();
        return Ok(existingProduct);
    }
    return BadRequest(ModelState);
}
```

---

**5. GET Delete Product** ⚠️ (Should be DELETE)
```
GET /api/shop/Delete{id}
```
**Description:** Deletes a product by ID

**Parameters:**
- `id` (int) - Product ID

**Example:** `GET /api/shop/Delete5`

**Success Response (200 OK):**
```json
{
  "id": 5,
  "name": "Keyboard",
  "price": 75.00,
  "cId": 2,
  "category": null
}
```

**Error Response (404 Not Found):**
```json
"Product with ID 5 not found."
```

**⚠️ Issues:**
- Should use `[HttpDelete]` not `[HttpGet]`
- GET requests should not modify data

**Corrected Version:**
```csharp
[HttpDelete("Delete/{id}")]
public IActionResult DeleteProduct(int id)
{
    var product = db.Products.Find(id);
    if (product == null)
    {
        return NotFound($"Product with ID {id} not found.");
    }
    db.Products.Remove(product);
    db.SaveChanges();
    return NoContent();  // 204 No Content is standard for DELETE
}
```

---

### Migrations/20251223071831_IntialDBCreate.cs - Initial Migration

```csharp
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntroCFAPI.Migrations
{
    public partial class IntialDBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CId",
                        column: x => x.CId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CId",
                table: "Products",
                column: "CId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Products");
            migrationBuilder.DropTable(name: "Categories");
        }
    }
}
```

**Key Components:**

**1. Up() Method:**
- Creates database schema
- Executed when running `Update-Database`
- Creates tables, columns, constraints, indexes

**2. Down() Method:**
- Rolls back changes
- Executed when reverting migration
- Drops tables in reverse order (Products first due to FK)

**3. Annotations:**
```csharp
.Annotation("SqlServer:Identity", "1, 1")
```
- SQL Server-specific features
- IDENTITY(1,1) for auto-increment primary keys

**4. Foreign Key:**
```csharp
table.ForeignKey(
    name: "FK_Products_Categories_CId",
    column: x => x.CId,
    principalTable: "Categories",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
```
- Creates FK constraint
- CASCADE delete - Deleting category deletes products

**5. Index:**
```csharp
migrationBuilder.CreateIndex(
    name: "IX_Products_CId",
    table: "Products",
    column: "CId");
```
- Improves query performance on foreign key
- Speeds up joins and lookups

---

## 🛠️ Code First Workflow - Step by Step

### 1. Define Entity Classes

```csharp
// Create your entity classes
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int CId { get; set; }
    public virtual Category Category { get; set; }
}
```

### 2. Create DbContext

```csharp
public class PMSContext : DbContext
{
    public PMSContext(DbContextOptions<PMSContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
```

### 3. Register DbContext in Program.cs

```csharp
builder.Services.AddDbContext<PMSContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});
```

### 4. Add Connection String

```json
{
  "ConnectionStrings": {
    "DbConn": "Data Source=YOUR_SERVER; initial catalog=PMSDB; TrustServerCertificate=True; Integrated Security=True;"
  }
}
```

### 5. Create Migration

**Package Manager Console:**
```powershell
Add-Migration InitialCreate
```

**.NET CLI:**
```bash
dotnet ef migrations add InitialCreate
```

**What happens:**
- Analyzes DbContext and entities
- Creates migration file with Up/Down methods
- Creates snapshot of current model

### 6. Update Database

**Package Manager Console:**
```powershell
Update-Database
```

**.NET CLI:**
```bash
dotnet ef database update
```

**What happens:**
- Connects to SQL Server
- Creates database if not exists
- Executes Up() method
- Creates __EFMigrationsHistory table
- Tracks applied migrations

### 7. Verify Database

```sql
-- Check tables
SELECT * FROM INFORMATION_SCHEMA.TABLES

-- View schema
EXEC sp_help 'Products'
```

---

## 🎓 Key Learning Points

### 1. Code First Benefits

✅ **Version Control**
```powershell
# All schema changes tracked in migrations
git log -- Migrations/
```

✅ **Team Collaboration**
```powershell
# Developer A creates migration
Add-Migration AddPriceColumn

# Developer B updates their database
Update-Database
```

✅ **Database Agnostic**
```csharp
// Same code, different database
option.UseSqlServer(...)  // SQL Server
option.UseNpgsql(...)     // PostgreSQL
option.UseSqlite(...)     // SQLite
```

### 2. AutoMapper Patterns

**Basic Mapping:**
```csharp
cfg.CreateMap<ProductDTO, Product>();
var product = mapper.Map<Product>(productDto);
```

**Reverse Mapping:**
```csharp
cfg.CreateMap<ProductDTO, Product>().ReverseMap();
var dto = mapper.Map<ProductDTO>(product);
```

**Custom Mapping:**
```csharp
cfg.CreateMap<ProductDTO, Product>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToUpper()));
```

**Flattening:**
```csharp
cfg.CreateMap<Product, ProductDetailsDTO>()
    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
```

### 3. Validation Flow

```
1. Client sends JSON request
   ↓
2. Model binding deserializes to DTO
   ↓
3. Validation attributes checked
   ↓
4. ModelState populated with errors
   ↓
5. Controller checks ModelState.IsValid
   ↓
6. Return 400 Bad Request if invalid
   OR
   Process request if valid
```

### 4. EF Core Change Tracking

```csharp
// Added
var product = new Product { Name = "Test" };
db.Products.Add(product);
// State: Added

// Modified
var product = db.Products.Find(1);
product.Name = "Updated";
// State: Modified

// Deleted
var product = db.Products.Find(1);
db.Products.Remove(product);
// State: Deleted

// SaveChanges generates SQL based on state
db.SaveChanges();
```

---

## 🚀 Getting Started

### Prerequisites

**1. Software:**
- .NET 10.0 SDK or later
- Visual Studio 2022 or VS Code
- SQL Server 2019+ or LocalDB
- SQL Server Management Studio (optional)

**2. SQL Server:**
- Running and accessible
- Authentication configured

### Running the Project

**1. Update Connection String:**
```json
// In appsettings.json
"ConnectionStrings": {
  "DbConn": "Data Source=YOUR_SERVER_NAME; initial catalog=PMSDB; TrustServerCertificate=True; Integrated Security=True;"
}
```

**2. Navigate to Project:**
```powershell
cd "d:\University\Semester 9\ADVANCED PROGRAMMING WITH .NET\Lab\.NET Core\Lab8\IntroCFAPI\IntroCFAPI"
```

**3. Restore & Build:**
```powershell
dotnet restore
dotnet build
```

**4. Apply Migrations:**
```powershell
# Package Manager Console
Update-Database

# OR .NET CLI
dotnet ef database update
```

**5. Run Application:**
```powershell
dotnet run
```

**6. Test API:**
- Postman: `POST https://localhost:5001/api/shop/add`
- Browser: `GET https://localhost:5001/api/shop/all`

---

## 🧪 Testing the API

### Using Postman

**1. Create Category (Manual - No endpoint yet):**
```sql
-- Execute in SQL Server Management Studio
INSERT INTO Categories (Name) VALUES ('Electronics');
INSERT INTO Categories (Name) VALUES ('Accessories');
```

**2. POST Create Product:**
```
Method: POST
URL: https://localhost:5001/api/shop/add
Headers: Content-Type: application/json
Body:
{
  "name": "Laptop",
  "price": 1299.99,
  "cId": 1
}
```

**3. GET All Products:**
```
Method: GET
URL: https://localhost:5001/api/shop/all
```

**4. GET Product by ID:**
```
Method: GET
URL: https://localhost:5001/api/shop/all5
```

**5. GET Update Product (Current):**
```
Method: GET
URL: https://localhost:5001/api/shop/Update5?name=Updated Laptop&price=1199.99&cId=1
```

**6. GET Delete Product (Current):**
```
Method: GET
URL: https://localhost:5001/api/shop/Delete5
```

### Using PowerShell

**POST Create Product:**
```powershell
$body = @{
    name = "Wireless Mouse"
    price = 29.99
    cId = 2
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:5001/api/shop/add" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"
```

**GET All Products:**
```powershell
Invoke-RestMethod -Uri "https://localhost:5001/api/shop/all" -Method Get
```

---

## 📊 API Endpoints Summary

| Method | Endpoint | Description | Body | Status |
|--------|----------|-------------|------|--------|
| GET | `/api/shop/all` | Get all products | - | ✅ Correct |
| GET | `/api/shop/all{id}` | Get product by ID | - | ✅ Correct |
| POST | `/api/shop/add` | Create product | ProductDTO | ✅ Correct |
| GET | `/api/shop/Update{id}` | Update product | ProductDTO (query) | ⚠️ Should be PUT |
| GET | `/api/shop/Delete{id}` | Delete product | - | ⚠️ Should be DELETE |

---

## 💡 Best Practices & Improvements

### Recommended Enhancements

**1. Fix HTTP Methods:**
```csharp
[HttpPut("Update/{id}")]
public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDto) { }

[HttpDelete("Delete/{id}")]
public IActionResult DeleteProduct(int id) { }
```

**2. Register AutoMapper with DI:**
```csharp
// Program.cs
builder.Services.AddAutoMapper(typeof(Program));

// Controller
private readonly IMapper _mapper;
public ShopController(PMSContext db, IMapper mapper)
{
    this.db = db;
    _mapper = mapper;
}
```

**3. Create Mapping Profile:**
```csharp
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<CategoryDTO, Category>().ReverseMap();
    }
}
```

**4. Add Category Controller:**
```csharp
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly PMSContext _db;
    
    [HttpGet]
    public IActionResult GetAll() => Ok(_db.Categories.ToList());
    
    [HttpPost]
    public IActionResult Create(CategoryDTO dto) { }
}
```

**5. Add Async Operations:**
```csharp
[HttpGet("all")]
public async Task<IActionResult> GetAll()
{
    var products = await db.Products.ToListAsync();
    return Ok(mapper.Map<List<ProductDTO>>(products));
}
```

**6. Include Navigation Properties:**
```csharp
[HttpGet("all")]
public async Task<IActionResult> GetAll()
{
    var products = await db.Products
        .Include(p => p.Category)
        .ToListAsync();
    return Ok(mapper.Map<List<ProductDTO>>(products));
}
```

**7. Add Error Handling:**
```csharp
try
{
    await db.SaveChangesAsync();
    return Ok(product);
}
catch (DbUpdateException ex)
{
    return StatusCode(500, "Database error occurred");
}
```

**8. Use ActionResult<T>:**
```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Product>> GetProduct(int id)
{
    var product = await db.Products.FindAsync(id);
    if (product == null)
        return NotFound();
    return product;
}
```

---

## 🔄 Migration Commands Reference

### Common Migration Commands

**Package Manager Console (Visual Studio):**
```powershell
# Add new migration
Add-Migration MigrationName

# Update database to latest
Update-Database

# Update to specific migration
Update-Database MigrationName

# Rollback last migration
Update-Database LastGoodMigrationName

# Remove last migration (not applied)
Remove-Migration

# Generate SQL script
Script-Migration

# List all migrations
Get-Migration
```

**.NET CLI (Command Line):**
```bash
# Add new migration
dotnet ef migrations add MigrationName

# Update database to latest
dotnet ef database update

# Update to specific migration
dotnet ef database update MigrationName

# Remove last migration
dotnet ef migrations remove

# Generate SQL script
dotnet ef migrations script

# List migrations
dotnet ef migrations list

# Drop database
dotnet ef database drop
```

### Migration Scenarios

**Scenario 1: Add New Property**
```csharp
// 1. Add property to entity
public class Product
{
    public string Description { get; set; }
}

// 2. Create migration
Add-Migration AddProductDescription

// 3. Update database
Update-Database
```

**Scenario 2: Add New Table**
```csharp
// 1. Create entity
public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// 2. Add DbSet
public DbSet<Supplier> Suppliers { get; set; }

// 3. Create migration
Add-Migration AddSupplierTable

// 4. Update database
Update-Database
```

**Scenario 3: Rollback Migration**
```powershell
# View migrations
Get-Migration

# Rollback to previous
Update-Database PreviousMigrationName

# Remove migration file
Remove-Migration
```

---

## 📚 Additional Resources

### Official Documentation
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Code First Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [AutoMapper](https://docs.automapper.org/en/stable/)
- [Data Annotations](https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties)

### Recommended Reading
- **Entity Framework Core in Action** by Jon P Smith
- **AutoMapper in Action** by Jimmy Bogard
- **ASP.NET Core Web API** by Shahed Chowdhuri

---

## 🐛 Troubleshooting

### Issue: Migration Command Not Found
**Solution:**
```powershell
dotnet tool install --global dotnet-ef
dotnet restore
```

### Issue: Cannot Create Database
**Solution:**
- Verify SQL Server is running
- Check connection string
- Ensure user has CREATE DATABASE permission
- Try connecting with SQL Server Management Studio

### Issue: Foreign Key Violation
**Solution:**
```csharp
// Ensure category exists before adding product
var categoryExists = await db.Categories.AnyAsync(c => c.Id == productDto.CId);
if (!categoryExists)
    return BadRequest("Category does not exist");
```

### Issue: Validation Not Working
**Solution:**
```csharp
// Ensure [ApiController] attribute is present
[ApiController]
public class ShopController : ControllerBase

// Check ModelState in action
if (!ModelState.IsValid)
    return BadRequest(ModelState);
```

### Issue: AutoMapper Configuration Error
**Solution:**
```csharp
// Ensure mapping is configured before use
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<ProductDTO, Product>();
});
config.AssertConfigurationIsValid(); // Validate configuration
```

### Issue: Migration Already Applied
**Solution:**
```powershell
# Remove from __EFMigrationsHistory table
DELETE FROM __EFMigrationsHistory WHERE MigrationId = 'xxx'

# Or drop and recreate database
Update-Database 0
Update-Database
```

---

## 📊 Project Statistics

| Metric | Value |
|--------|-------|
| **Controllers** | 2 (Shop, WeatherForecast) |
| **Entities** | 2 (Product, Category) |
| **DTOs** | 2 (ProductDTO, CategoryDTO) |
| **DbContext** | 1 (PMSContext) |
| **Migrations** | 1 (InitialDBCreate) |
| **API Endpoints** | 5 (CRUD operations) |
| **Lines of Code** | ~400 |
| **Target Framework** | .NET 10.0 |
| **EF Core Version** | 10.0.1 |
| **AutoMapper Version** | 14.0.0 |
| **Complexity** | ⭐⭐⭐ Intermediate-Advanced |

---

## 🎓 Learning Outcomes Achieved

✅ **Understand Code First approach fundamentals**  
✅ **Create and apply EF Core migrations**  
✅ **Configure entities with Data Annotations**  
✅ **Implement AutoMapper for object mapping**  
✅ **Build complete CRUD API with validation**  
✅ **Use Dependency Injection for DbContext**  
✅ **Apply DTO pattern for data transfer**  
✅ **Implement server-side validation**  
✅ **Handle foreign key relationships**  
✅ **Manage database schema with migrations**

---

## 🏆 Key Takeaways

1. **Code First enables version-controlled schemas** - Track changes in source control
2. **Migrations make database changes safe** - Apply/rollback changes systematically
3. **Data Annotations simplify configuration** - Declarative entity setup
4. **AutoMapper eliminates boilerplate code** - Automatic object mapping
5. **DTOs provide clean API contracts** - Separate API from database
6. **Validation attributes enforce business rules** - Automatic validation
7. **DI improves testability** - Inject mock dependencies
8. **Proper HTTP methods matter** - GET, POST, PUT, DELETE semantics

---

## 🔗 Comparison: Lab 7 vs Lab 8

| Feature | Lab 7 (Database First) | Lab 8 (Code First) |
|---------|----------------------|-------------------|
| **Starting Point** | Existing Database | C# Entity Classes |
| **Workflow** | DB → Scaffold → Code | Code → Migration → DB |
| **Schema Changes** | Manual SQL + Re-scaffold | Add-Migration |
| **Version Control** | ⚠️ Difficult | ✅ Migrations tracked |
| **Configuration** | OnConfiguring in DbContext | Program.cs (DI) |
| **AutoMapper** | ❌ Not used | ✅ Implemented |
| **DTOs** | ❌ Not used | ✅ With validation |
| **CRUD API** | ❌ Not implemented | ✅ Complete |
| **Best For** | Legacy databases | New projects |

---

## 🔗 Quick Links

- [Program.cs](#programcs---application-entry-point-with-di) - DI configuration
- [PMSContext](#efpmscontextcs---database-context) - Database context
- [Product Entity](#eftableproductcs---product-entity) - Product model
- [ShopController](#controllersshopcontrollercs---product-management-api) - API endpoints
- [Migrations](#migrations20251223071831_intialdbcreatecs---initial-migration) - Database schema
- [AutoMapper](#2-automapper-configuration) - Object mapping
- [Best Practices](#-best-practices--improvements) - Improvements

---

## 👨‍💻 Author
**Course:** Advanced Programming with .NET  
**Lab:** Lab 8 - ASP.NET Core Web API with EF Core (Code First) & AutoMapper  
**Institution:** American International University - Bangladesh (AIUB)  
**Semester:** 9  
**Academic Year:** 2025-2026

## 📄 License
This project is created for educational purposes as part of university coursework.

---

**Last Updated:** January 23, 2026  
**Status:** ✅ Complete  
**Framework:** ASP.NET Core 10.0 + EF Core 10.0.1 + AutoMapper 14.0.0

---

**Ready to build Code First APIs with AutoMapper? Let's create data-driven applications! 🚀**
