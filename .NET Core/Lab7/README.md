# Lab 7 - ASP.NET Core Web API with Entity Framework Core (Database First)

## 📚 Overview
Welcome to **Lab 7**, where we combine the power of **ASP.NET Core Web API** with **Entity Framework Core** using the **Database First** approach! This lab demonstrates how to scaffold a complete data access layer from an existing SQL Server database and expose data through RESTful APIs.

## 🎯 Learning Objectives

By the end of this lab, you will understand:

- ✅ **Entity Framework Core** - Modern ORM for .NET
- ✅ **Database First Approach** - Scaffolding models from existing database
- ✅ **DbContext** - Database connection and entity management
- ✅ **Navigation Properties** - Entity relationships (One-to-Many)
- ✅ **Connection Strings** - Database configuration in appsettings.json
- ✅ **Scaffold-DbContext** - Reverse engineering database to code
- ✅ **Fluent API** - Advanced entity configuration
- ✅ **Foreign Key Relationships** - Relational data modeling
- ✅ **Partial Classes** - Extensibility pattern
- ✅ **Integration** - Combining Web API with EF Core

## 🏗️ Project Structure

```
IntroCoreDBFAPI/
├── Controllers/
│   └── WeatherForecastController.cs   # Sample API controller
├── EF/
│   ├── BfuContext.cs                  # DbContext - Database connection
│   └── Tables/
│       ├── Department.cs              # Department entity
│       └── Student.cs                 # Student entity
├── Properties/
│   └── launchSettings.json            # Launch configurations
├── appsettings.json                   # App settings & connection strings
├── Program.cs                         # Application entry point
├── WeatherForecast.cs                 # Weather model
└── IntroCoreDBFAPI.csproj            # Project file with EF packages
```

## 🚀 Technology Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| ASP.NET Core | 10.0 | Web API framework |
| .NET | 10.0 | Runtime environment |
| Entity Framework Core | 10.0.1 | ORM (Object-Relational Mapper) |
| SQL Server | 2019+ | Database server |
| C# | 12.0 | Programming language |
| OpenAPI | Latest | API documentation |

## 📦 NuGet Packages

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.1" />
```

**Package Purposes:**
- **EntityFrameworkCore** - Core EF functionality
- **SqlServer** - SQL Server database provider
- **Tools** - Package Manager Console commands
- **Design** - Design-time support for scaffolding

## 📋 Key Concepts

### 1. Entity Framework Core

**Entity Framework Core (EF Core)** is a lightweight, extensible ORM that enables .NET developers to work with databases using .NET objects.

**Key Features:**
- ✅ **LINQ Queries** - Type-safe database queries
- ✅ **Change Tracking** - Automatic change detection
- ✅ **Migrations** - Database schema versioning (Code First)
- ✅ **Scaffolding** - Generate entities from database (Database First)
- ✅ **Relationships** - Navigation properties
- ✅ **Lazy/Eager Loading** - Flexible data loading strategies

### 2. Database First vs Code First

| Approach | When to Use | Workflow |
|----------|-------------|----------|
| **Database First** | Existing database | Database → Models → Code |
| **Code First** | New project | Code → Migrations → Database |

**Lab 7 uses Database First** - We scaffold entities from an existing BFU database.

### 3. DbContext

The **DbContext** is the primary class for interacting with the database:

```csharp
public partial class BfuContext : DbContext
{
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Student> Students { get; set; }
}
```

**Responsibilities:**
- Database connection management
- Entity tracking
- Query translation (LINQ to SQL)
- Transaction management
- Change tracking and SaveChanges()

### 4. Navigation Properties

Navigation properties establish relationships between entities:

**One-to-Many Relationship:**
- One Department → Many Students
- One Student → One Department

```csharp
// Department (One)
public virtual ICollection<Student> Students { get; set; }

// Student (Many)
public virtual Department Deparment { get; set; }
```

## 🗃️ Database Schema

### Tables

**Department Table:**
```sql
CREATE TABLE Department (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL
)
```

**Student Table:**
```sql
CREATE TABLE Student (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(50) NOT NULL,
    DeparmentID INT NOT NULL,
    CONSTRAINT FK_Student_Department 
        FOREIGN KEY (DeparmentID) REFERENCES Department(ID)
)
```

### Entity Relationship Diagram

```
┌─────────────────┐         ┌─────────────────┐
│   Department    │         │     Student     │
├─────────────────┤         ├─────────────────┤
│ ID (PK)         │◄───────┤│ ID (PK)         │
│ Name            │   1:N   │ Name            │
└─────────────────┘         │ Email           │
                            │ PhoneNumber     │
                            │ DeparmentID (FK)│
                            └─────────────────┘
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
    "UMSDB": "Data Source=BASHARULALAMMAZ; Initial Catalog=BFU; TrustServerCertificate=True; Integrated Security=True;"
  }
}
```

**Connection String Components:**
- **Data Source** - SQL Server instance name
- **Initial Catalog** - Database name (BFU)
- **TrustServerCertificate** - Accept self-signed certificates
- **Integrated Security** - Use Windows authentication

**⚠️ Important:** Update the connection string with your SQL Server instance name.

---

### EF/BfuContext.cs - Database Context

```csharp
using System;
using System.Collections.Generic;
using IntroCoreDBFAPI.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace IntroCoreDBFAPI.EF;

public partial class BfuContext : DbContext
{
    public BfuContext()
    {
    }

    public BfuContext(DbContextOptions<BfuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=UMSDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DeparmentId).HasColumnName("DeparmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Deparment).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeparmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
```

#### Key Components

**1. Constructors:**
```csharp
public BfuContext() { }  // Parameterless for scaffolding
public BfuContext(DbContextOptions<BfuContext> options) : base(options) { }  // DI support
```

**2. DbSets (Tables as Properties):**
```csharp
public virtual DbSet<Department> Departments { get; set; }
public virtual DbSet<Student> Students { get; set; }
```
- `virtual` enables lazy loading
- Each DbSet represents a table

**3. OnConfiguring - Connection String:**
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Name=UMSDB");
```
- References connection string from appsettings.json
- `Name=UMSDB` looks up `ConnectionStrings:UMSDB`

**4. OnModelCreating - Fluent API Configuration:**

**Department Configuration:**
```csharp
entity.ToTable("Department");                    // Table name
entity.Property(e => e.Id).HasColumnName("ID");  // Map C# property to DB column
entity.Property(e => e.Name)
    .HasMaxLength(50)                            // Max length constraint
    .IsUnicode(false);                           // VARCHAR (not NVARCHAR)
```

**Student Configuration:**
```csharp
entity.HasOne(d => d.Deparment)           // One Department
    .WithMany(p => p.Students)            // Many Students
    .HasForeignKey(d => d.DeparmentId)    // Foreign key
    .OnDelete(DeleteBehavior.ClientSetNull)  // No cascade delete
    .HasConstraintName("FK_Student_Department");
```

**5. Partial Class:**
```csharp
partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
```
- Allows extending configuration in separate file
- Won't be overwritten during re-scaffolding

---

### EF/Tables/Department.cs - Department Entity

```csharp
using System;
using System.Collections.Generic;

namespace IntroCoreDBFAPI.EF.Tables;

public partial class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
```

**Key Features:**

**1. Properties:**
- `Id` - Primary key
- `Name` - Department name (required, non-nullable)

**2. Null-forgiving Operator (`= null!`):**
- Tells compiler "This will be initialized by EF, trust me"
- Satisfies nullable reference types

**3. Navigation Property:**
```csharp
public virtual ICollection<Student> Students { get; set; } = new List<Student>();
```
- Collection of related students
- `virtual` enables lazy loading
- Initialized to empty list

**4. Partial Class:**
- Allows adding custom logic in separate file

---

### EF/Tables/Student.cs - Student Entity

```csharp
using System;
using System.Collections.Generic;

namespace IntroCoreDBFAPI.EF.Tables;

public partial class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int DeparmentId { get; set; }
    
    public virtual Department Deparment { get; set; } = null!;
}
```

**Key Features:**

**1. Properties:**
- `Id` - Primary key
- `Name` - Student name (required)
- `Email` - Email address (required)
- `PhoneNumber` - Contact number (required)
- `DeparmentId` - Foreign key to Department

**2. Navigation Property:**
```csharp
public virtual Department Deparment { get; set; } = null!;
```
- References parent Department
- Enables accessing `student.Deparment.Name`
- Note: Typo in original DB - "Deparment" instead of "Department"

**3. Partial Class:**
- Extensibility for custom properties/methods

---

### Program.cs - Application Entry Point

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

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

**Standard ASP.NET Core Web API setup** - No EF-specific configuration needed here since `OnConfiguring` is used in DbContext.

**For Production (Recommended):**
```csharp
// Register DbContext with DI
builder.Services.AddDbContext<BfuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UMSDB")));
```

---

### IntroCoreDBFAPI.csproj - Project Configuration

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.1">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.1">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

**Key EF Core Packages:**
- **EntityFrameworkCore** - Core functionality
- **SqlServer** - SQL Server provider
- **Tools** - CLI tools for scaffolding
- **Design** - Design-time components

---

## 🛠️ Database First Scaffolding Process

### Prerequisites

**1. SQL Server Database:**
- Create BFU database
- Create Department and Student tables with relationship

**2. Connection String:**
- Update appsettings.json with your SQL Server instance

### Scaffolding Commands

**Method 1: Package Manager Console (Visual Studio)**

```powershell
Scaffold-DbContext "Data Source=YOUR_SERVER; Initial Catalog=BFU; TrustServerCertificate=True; Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EF -ContextDir EF -Context BfuContext -Tables Department,Student
```

**Method 2: .NET CLI (Command Line)**

```bash
dotnet ef dbcontext scaffold "Data Source=YOUR_SERVER; Initial Catalog=BFU; TrustServerCertificate=True; Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir EF --context-dir EF --context BfuContext --table Department --table Student
```

### Scaffold Command Breakdown

| Parameter | Purpose | Example |
|-----------|---------|---------|
| Connection String | Database to connect | `"Data Source=...;"` |
| Provider | Database provider | `Microsoft.EntityFrameworkCore.SqlServer` |
| `-OutputDir` | Entity classes folder | `EF/Tables` |
| `-ContextDir` | DbContext folder | `EF` |
| `-Context` | DbContext class name | `BfuContext` |
| `-Tables` | Specific tables to scaffold | `Department,Student` |
| `-Force` | Overwrite existing files | Add if re-scaffolding |

### Post-Scaffolding Steps

**1. Move Entity Classes (Optional):**
```powershell
# Move to Tables subfolder for organization
Move-Item EF/*.cs EF/Tables/ -Exclude BfuContext.cs
```

**2. Update Namespaces:**
```csharp
// Add to entities if moved
namespace IntroCoreDBFAPI.EF.Tables;
```

**3. Update Connection String:**
```csharp
// In BfuContext.cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Name=UMSDB");
```

---

## 💻 Using Entity Framework Core in APIs

### Basic CRUD Operations

**Example: Student Controller (Not in current lab, but next steps)**

```csharp
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly BfuContext _context;

    public StudentController(BfuContext context)
    {
        _context = context;
    }

    // GET: api/Student
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        return await _context.Students
            .Include(s => s.Deparment)  // Eager loading
            .ToListAsync();
    }

    // GET: api/Student/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _context.Students
            .Include(s => s.Deparment)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
            return NotFound();

        return student;
    }

    // POST: api/Student
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT: api/Student/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
            return BadRequest();

        _context.Entry(student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Student/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StudentExists(int id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}
```

---

## 🎓 Key Learning Points

### 1. Entity Framework Core Concepts

**DbContext:**
```csharp
using (var context = new BfuContext())
{
    var students = context.Students.ToList();
}
```

**DbSet:**
```csharp
public virtual DbSet<Student> Students { get; set; }
// Represents the Student table
```

**LINQ Queries:**
```csharp
// Get all students from CSE department
var cseStudents = context.Students
    .Where(s => s.Deparment.Name == "CSE")
    .ToList();
```

### 2. Navigation Properties

**Accessing Related Data:**
```csharp
// Get student with department
var student = context.Students
    .Include(s => s.Deparment)  // Eager loading
    .FirstOrDefault(s => s.Id == 1);

Console.WriteLine($"{student.Name} - {student.Deparment.Name}");
```

**Reverse Navigation:**
```csharp
// Get department with all students
var department = context.Departments
    .Include(d => d.Students)
    .FirstOrDefault(d => d.Id == 1);

foreach (var student in department.Students)
{
    Console.WriteLine(student.Name);
}
```

### 3. Loading Strategies

| Strategy | When Loaded | Usage |
|----------|-------------|-------|
| **Eager Loading** | With parent query | `Include()` |
| **Lazy Loading** | When accessed | `virtual` navigation properties |
| **Explicit Loading** | Manually triggered | `Entry().Load()` |

**Examples:**
```csharp
// Eager Loading
var students = context.Students.Include(s => s.Deparment).ToList();

// Lazy Loading (requires virtual properties)
var student = context.Students.Find(1);
var deptName = student.Deparment.Name;  // Loaded on access

// Explicit Loading
var student = context.Students.Find(1);
context.Entry(student).Reference(s => s.Deparment).Load();
```

### 4. Fluent API vs Data Annotations

**Fluent API (Used in Lab 7):**
```csharp
modelBuilder.Entity<Student>(entity =>
{
    entity.HasOne(d => d.Deparment)
        .WithMany(p => p.Students)
        .HasForeignKey(d => d.DeparmentId);
});
```

**Data Annotations (Alternative):**
```csharp
public class Student
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [ForeignKey("Deparment")]
    public int DeparmentId { get; set; }
    
    public virtual Department Deparment { get; set; }
}
```

---

## 🚀 Getting Started

### Prerequisites

**1. Software:**
- .NET 10.0 SDK or later
- Visual Studio 2022 or VS Code
- SQL Server 2019+ or LocalDB
- SQL Server Management Studio (optional)

**2. Database Setup:**

**Create Database:**
```sql
CREATE DATABASE BFU;
GO

USE BFU;
GO
```

**Create Department Table:**
```sql
CREATE TABLE Department (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL
);
```

**Create Student Table:**
```sql
CREATE TABLE Student (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(50) NOT NULL,
    DeparmentID INT NOT NULL,
    CONSTRAINT FK_Student_Department 
        FOREIGN KEY (DeparmentID) REFERENCES Department(ID)
);
```

**Insert Sample Data:**
```sql
-- Insert Departments
INSERT INTO Department (Name) VALUES ('CSE');
INSERT INTO Department (Name) VALUES ('EEE');
INSERT INTO Department (Name) VALUES ('BBA');

-- Insert Students
INSERT INTO Student (Name, Email, PhoneNumber, DeparmentID) 
VALUES ('John Doe', 'john@example.com', '01711111111', 1);

INSERT INTO Student (Name, Email, PhoneNumber, DeparmentID) 
VALUES ('Jane Smith', 'jane@example.com', '01722222222', 1);

INSERT INTO Student (Name, Email, PhoneNumber, DeparmentID) 
VALUES ('Bob Johnson', 'bob@example.com', '01733333333', 2);
```

### Running the Project

**1. Update Connection String:**
```json
// In appsettings.json
"ConnectionStrings": {
  "UMSDB": "Data Source=YOUR_SERVER_NAME; Initial Catalog=BFU; TrustServerCertificate=True; Integrated Security=True;"
}
```

**2. Navigate to Project:**
```powershell
cd "d:\University\Semester 9\ADVANCED PROGRAMMING WITH .NET\Lab\.NET Core\Lab7\IntroCoreDBFAPI\IntroCoreDBFAPI"
```

**3. Restore & Build:**
```powershell
dotnet restore
dotnet build
```

**4. Run Application:**
```powershell
dotnet run
```

**5. Test Connection:**
- Access: `https://localhost:5001/weatherforecast`
- Add Student/Department controllers to test EF functionality

---

## 🧪 Testing Entity Framework

### Using Package Manager Console

**Open Package Manager Console in Visual Studio:**

**Test Database Connection:**
```powershell
# In Visual Studio, Tools → NuGet Package Manager → Package Manager Console
Update-Database -Verbose
```

**Test LINQ Queries:**
```csharp
// In C# Interactive or Controller
using var context = new BfuContext();

// Get all departments
var departments = context.Departments.ToList();

// Get all students with departments
var students = context.Students.Include(s => s.Deparment).ToList();

// Get CSE students
var cseStudents = context.Students
    .Where(s => s.Deparment.Name == "CSE")
    .ToList();
```

### Using PowerShell

**Test with EF Core CLI:**
```powershell
# Check EF Core version
dotnet ef --version

# List DbContexts
dotnet ef dbcontext list

# View DbContext info
dotnet ef dbcontext info --context BfuContext
```

---

## 🎨 Database First Workflow

### Complete Development Cycle

```
1. Design Database (SQL Server)
   ↓
2. Create Tables & Relationships
   ↓
3. Scaffold DbContext & Entities
   ↓
4. Update Connection String
   ↓
5. Create API Controllers
   ↓
6. Implement CRUD Operations
   ↓
7. Test with Postman/Swagger
   ↓
8. [Database Changes?]
   ↓
9. Re-scaffold with -Force flag
```

### When Database Schema Changes

**Option 1: Re-scaffold (Overwrites)**
```powershell
Scaffold-DbContext "..." Microsoft.EntityFrameworkCore.SqlServer -OutputDir EF -Context BfuContext -Force
```

**Option 2: Manual Updates**
- Update entity classes manually
- Update OnModelCreating configurations
- Test thoroughly

**Best Practice:**
- Use partial classes for custom code
- Keep custom logic separate from scaffolded code

---

## 💡 Best Practices Demonstrated

### 1. Project Organization
✅ Entities in `EF/Tables` folder  
✅ DbContext in `EF` folder  
✅ Clear namespace structure  
✅ Separation of concerns

### 2. Entity Configuration
✅ Fluent API in `OnModelCreating`  
✅ Explicit column mappings  
✅ Foreign key constraints defined  
✅ Navigation properties configured

### 3. Connection Management
✅ Connection string in appsettings.json  
✅ Named connection string reference  
✅ Secure connection (Integrated Security)  
✅ Trust server certificate configured

### 4. Code Quality
✅ Nullable reference types enabled  
✅ Virtual navigation properties  
✅ Partial classes for extensibility  
✅ Null-forgiving operators used appropriately

### 5. Database Design
✅ Primary keys on all tables  
✅ Foreign key constraints  
✅ Proper data types  
✅ NOT NULL constraints where appropriate

---

## 🔍 Common Patterns & Examples

### 1. Basic Query Patterns

```csharp
using var context = new BfuContext();

// Get all
var allStudents = context.Students.ToList();

// Get by ID
var student = context.Students.Find(1);

// Where clause
var cseStudents = context.Students
    .Where(s => s.DeparmentId == 1)
    .ToList();

// Include navigation property
var studentsWithDept = context.Students
    .Include(s => s.Deparment)
    .ToList();

// Multiple includes
var result = context.Departments
    .Include(d => d.Students)
    .ToList();
```

### 2. Async Operations

```csharp
// Get all async
var students = await context.Students.ToListAsync();

// Find async
var student = await context.Students.FindAsync(1);

// FirstOrDefault async
var student = await context.Students
    .FirstOrDefaultAsync(s => s.Id == 1);

// Any async
bool exists = await context.Students
    .AnyAsync(s => s.Email == "test@example.com");
```

### 3. Insert Operations

```csharp
// Create new student
var newStudent = new Student
{
    Name = "Alice Brown",
    Email = "alice@example.com",
    PhoneNumber = "01744444444",
    DeparmentId = 1
};

context.Students.Add(newStudent);
await context.SaveChangesAsync();

// ID is automatically set after SaveChanges
Console.WriteLine($"New student ID: {newStudent.Id}");
```

### 4. Update Operations

```csharp
// Method 1: Find and modify
var student = await context.Students.FindAsync(1);
if (student != null)
{
    student.Email = "newemail@example.com";
    await context.SaveChangesAsync();
}

// Method 2: Attach and mark modified
var student = new Student { Id = 1, Email = "new@example.com" };
context.Students.Attach(student);
context.Entry(student).Property(s => s.Email).IsModified = true;
await context.SaveChangesAsync();
```

### 5. Delete Operations

```csharp
// Method 1: Find and remove
var student = await context.Students.FindAsync(1);
if (student != null)
{
    context.Students.Remove(student);
    await context.SaveChangesAsync();
}

// Method 2: Remove without loading
var student = new Student { Id = 1 };
context.Students.Attach(student);
context.Students.Remove(student);
await context.SaveChangesAsync();
```

---

## 📊 Comparison: Lab 6 vs Lab 7

| Feature | Lab 6 (API Only) | Lab 7 (API + EF Core) |
|---------|------------------|----------------------|
| **Data Source** | Hardcoded objects | SQL Server database |
| **Data Persistence** | ❌ None | ✅ Database |
| **ORM** | ❌ Not used | ✅ Entity Framework Core |
| **Relationships** | Manual | ✅ Navigation properties |
| **CRUD** | Manual implementation | ✅ EF tracked changes |
| **Query** | LINQ to Objects | ✅ LINQ to Entities |
| **Scalability** | ⚠️ Limited | ✅ Production-ready |

---

## 🚧 Next Steps & Enhancements

### Recommended Improvements

**1. Add Student & Department Controllers**
```csharp
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly BfuContext _context;
    
    public StudentController(BfuContext context)
    {
        _context = context;
    }
    
    // Implement GET, POST, PUT, DELETE
}
```

**2. Implement Dependency Injection**
```csharp
// Program.cs
builder.Services.AddDbContext<BfuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UMSDB")));
```

**3. Add DTOs**
```csharp
public class StudentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string DepartmentName { get; set; }  // Flattened
}
```

**4. Implement AutoMapper**
```csharp
// Map Student entity to StudentDTO
var dto = _mapper.Map<StudentDTO>(student);
```

**5. Add Validation**
```csharp
public class Student
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
```

**6. Add Error Handling**
```csharp
try
{
    await _context.SaveChangesAsync();
}
catch (DbUpdateException ex)
{
    return StatusCode(500, "Database update failed");
}
```

**7. Add Swagger Documentation**
```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

app.UseSwagger();
app.UseSwaggerUI();
```

**8. Implement Repository Pattern**
```csharp
public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(int id);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(int id);
}
```

---

## 📚 Additional Resources

### Official Documentation
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Database First](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding)
- [DbContext](https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/)
- [Relationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships)

### EF Core Commands Reference

**Package Manager Console:**
```powershell
Scaffold-DbContext "..." Provider -OutputDir Folder
Update-Database
Add-Migration MigrationName
```

**.NET CLI:**
```bash
dotnet ef dbcontext scaffold "..." Provider --output-dir Folder
dotnet ef database update
dotnet ef migrations add MigrationName
```

### Recommended Reading
- **Entity Framework Core in Action** by Jon P Smith
- **Programming Entity Framework Core** by Julia Lerman
- **ASP.NET Core in Action** by Andrew Lock

---

## 🐛 Troubleshooting

### Issue: Scaffold Command Not Found
**Solution:**
```powershell
dotnet tool install --global dotnet-ef
dotnet restore
```

### Issue: Cannot Connect to Database
**Solution:**
- Verify SQL Server is running
- Check connection string
- Test with SQL Server Management Studio
- Ensure Windows Authentication enabled

### Issue: Foreign Key Violation
**Solution:**
```csharp
// Ensure DeparmentId exists before creating student
var departmentExists = await context.Departments.AnyAsync(d => d.Id == departmentId);
if (!departmentExists)
    return BadRequest("Department not found");
```

### Issue: Navigation Property Always Null
**Solution:**
```csharp
// Use Include for eager loading
var student = await context.Students
    .Include(s => s.Deparment)  // Load navigation property
    .FirstOrDefaultAsync(s => s.Id == id);
```

### Issue: Circular Reference in JSON
**Solution:**
```csharp
// Program.cs
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = 
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
```

### Issue: SaveChanges Not Persisting
**Solution:**
```csharp
// Ensure SaveChanges is called
context.Students.Add(student);
await context.SaveChangesAsync();  // Don't forget this!

// Check if entity is being tracked
var state = context.Entry(student).State;  // Should be Added/Modified
```

---

## 📊 Project Statistics

| Metric | Value |
|--------|-------|
| **Controllers** | 1 (WeatherForecast) |
| **Entities** | 2 (Student, Department) |
| **DbContext** | 1 (BfuContext) |
| **Database Tables** | 2 |
| **Relationships** | 1 (One-to-Many) |
| **Lines of Code** | ~200 |
| **Target Framework** | .NET 10.0 |
| **EF Core Version** | 10.0.1 |
| **Complexity** | ⭐⭐⭐ Intermediate-Advanced |

---

## 🎓 Learning Outcomes Achieved

✅ **Understand Entity Framework Core fundamentals**  
✅ **Scaffold entities from existing database (Database First)**  
✅ **Configure DbContext and connection strings**  
✅ **Work with navigation properties and relationships**  
✅ **Use Fluent API for entity configuration**  
✅ **Understand One-to-Many relationships**  
✅ **Use LINQ to query database**  
✅ **Integrate EF Core with ASP.NET Core Web API**  
✅ **Apply partial classes for extensibility**  
✅ **Configure nullable reference types**

---

## 🏆 Key Takeaways

1. **EF Core simplifies database access** - LINQ instead of SQL
2. **Database First is ideal for existing databases** - Quick scaffolding
3. **Navigation properties enable easy relationship access** - No JOIN needed
4. **Fluent API provides powerful configuration** - More control than attributes
5. **Partial classes allow customization** - Won't be overwritten
6. **Connection strings should be externalized** - appsettings.json
7. **Virtual properties enable lazy loading** - Load on demand
8. **SaveChanges commits all tracked changes** - Unit of work pattern

---

## 🔗 Quick Links

- [BfuContext](#efbfucontextcs---database-context) - Database connection
- [Student Entity](#eftablesstudentcs---student-entity) - Student model
- [Department Entity](#eftablesdepartmentcs---department-entity) - Department model
- [Scaffolding Guide](#️-database-first-scaffolding-process) - How to scaffold
- [CRUD Examples](#-using-entity-framework-core-in-apis) - Code samples
- [Troubleshooting](#-troubleshooting) - Common issues

---

## 👨‍💻 Author
**Course:** Advanced Programming with .NET  
**Lab:** Lab 7 - ASP.NET Core Web API with Entity Framework Core  
**Institution:** American International University - Bangladesh (AIUB)  
**Semester:** 9  
**Academic Year:** 2025-2026

## 📄 License
This project is created for educational purposes as part of university coursework.

---

**Last Updated:** January 23, 2026  
**Status:** ✅ Complete  
**Framework:** ASP.NET Core 10.0 + EF Core 10.0.1

---

**Ready to integrate databases with Web APIs? Let's build data-driven applications! 🚀**
