# Lab 9 - Introduction to 3-Tier Architecture with ASP.NET Core Web API

## 📚 Overview
Welcome to **Lab 9**, where we explore the **3-Tier Architecture** pattern for building scalable, maintainable enterprise applications! This lab introduces the separation of concerns through distinct layers: **Presentation (API)**, **Business Logic (BLL)**, and **Data Access (DAL)**.

## 🎯 Learning Objectives

By the end of this lab, you will understand:

- ✅ **3-Tier Architecture** - Separation of concerns pattern
- ✅ **Multi-Project Solutions** - Organizing code into separate projects
- ✅ **Project References** - Dependencies between layers
- ✅ **Data Access Layer (DAL)** - Repository pattern for database operations
- ✅ **Business Logic Layer (BLL)** - Services with business rules
- ✅ **Presentation Layer (API)** - Controllers consuming services
- ✅ **Dependency Injection Across Layers** - Registering services from different projects
- ✅ **DTOs Across Layers** - Data transfer between layers
- ✅ **AutoMapper Integration** - Object mapping in services
- ✅ **Layered Testing** - Isolated unit testing

## 🏗️ 3-Tier Architecture

### Architecture Diagram

```
┌──────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                         │
│                    (AppLayerAPI Project)                      │
│  ┌────────────────────────────────────────────────────────┐  │
│  │  Controllers (StudentController.cs)                     │  │
│  │  - HTTP Request/Response handling                       │  │
│  │  - Routing and model binding                           │  │
│  │  - Calls Business Logic Layer services                 │  │
│  └────────────────────────────────────────────────────────┘  │
└──────────────────────────────────────────────────────────────┘
                            ↓ Depends on
┌──────────────────────────────────────────────────────────────┐
│                  BUSINESS LOGIC LAYER                         │
│                       (BLL Project)                           │
│  ┌────────────────────────────────────────────────────────┐  │
│  │  Services (StudentService.cs)                           │  │
│  │  - Business rules and validation                        │  │
│  │  - AutoMapper configuration                             │  │
│  │  - DTO transformations                                  │  │
│  │  - Orchestrates repository calls                        │  │
│  └────────────────────────────────────────────────────────┘  │
│  ┌────────────────────────────────────────────────────────┐  │
│  │  DTOs (StudentDTO.cs)                                   │  │
│  │  - Data Transfer Objects                                │  │
│  │  - API contract models                                  │  │
│  └────────────────────────────────────────────────────────┘  │
└──────────────────────────────────────────────────────────────┘
                            ↓ Depends on
┌──────────────────────────────────────────────────────────────┐
│                   DATA ACCESS LAYER                           │
│                      (DAL Project)                            │
│  ┌────────────────────────────────────────────────────────┐  │
│  │  Repositories (StudentRepo.cs)                          │  │
│  │  - Database operations (CRUD)                           │  │
│  │  - DbContext interaction                                │  │
│  │  - LINQ queries                                         │  │
│  └────────────────────────────────────────────────────────┘  │
│  ┌────────────────────────────────────────────────────────┐  │
│  │  EF Context (UMSContext)                                │  │
│  │  - DbContext configuration                              │  │
│  │  - Entity Framework setup                               │  │
│  └────────────────────────────────────────────────────────┘  │
│  ┌────────────────────────────────────────────────────────┐  │
│  │  Entities (Students.cs)                                 │  │
│  │  - Database table models                                │  │
│  │  - EF Core entities                                     │  │
│  └────────────────────────────────────────────────────────┘  │
└──────────────────────────────────────────────────────────────┘
                            ↓ Connects to
┌──────────────────────────────────────────────────────────────┐
│                      SQL SERVER DATABASE                      │
│                         (TierCF)                              │
│  - Tables: Students                                           │
│  - Relationships and constraints                              │
└──────────────────────────────────────────────────────────────┘
```

## 🚀 Technology Stack

| Technology | Version | Layer | Purpose |
|------------|---------|-------|---------|
| ASP.NET Core | 10.0 | API | Web API framework |
| .NET | 10.0 | All | Runtime environment |
| Entity Framework Core | 9.0.11 | DAL | ORM for database |
| AutoMapper | 9.0.0 | BLL | Object-to-object mapping |
| SQL Server | 2019+ | Database | Database server |
| C# | 12.0 | All | Programming language |

## 📁 Solution Structure

```
IntroTierArc.slnx                           # Solution file
├── AppLayerAPI/                            # Presentation Layer
│   ├── Controllers/
│   │   ├── StudentController.cs            # Student API endpoints
│   │   └── WeatherForecastController.cs    # Sample controller
│   ├── appsettings.json                    # Configuration & connection string
│   ├── Program.cs                          # DI and middleware configuration
│   ├── WeatherForecast.cs                  # Sample model
│   └── AppLayerAPI.csproj                  # API project file
│       └── References: BLL project
│
├── BLL/                                    # Business Logic Layer
│   ├── Services/
│   │   └── StudentService.cs               # Business logic and AutoMapper
│   ├── DTOs/
│   │   └── StudentDTO.cs                   # Data transfer object
│   ├── Class1.cs                           # Template file
│   └── BLL.csproj                          # BLL project file
│       ├── References: DAL project
│       └── Packages: AutoMapper
│
└── DAL/                                    # Data Access Layer
    ├── Repos/
    │   └── StudentRepo.cs                  # Repository for database operations
    ├── Ef/
    │   └── Tables/
    │       └── Students.cs                 # Entity model
    ├── Class1.cs                           # Template file
    └── DAL.csproj                          # DAL project file
        └── Packages: EF Core, SQL Server
```

## 📋 Key Concepts

### 1. 3-Tier Architecture Benefits

**Separation of Concerns:**
- ✅ Each layer has a single responsibility
- ✅ Changes in one layer don't affect others
- ✅ Easier to understand and maintain

**Testability:**
- ✅ Unit test each layer independently
- ✅ Mock dependencies easily
- ✅ Test business logic without database

**Scalability:**
- ✅ Scale layers independently
- ✅ Deploy layers to different servers
- ✅ Optimize each layer separately

**Maintainability:**
- ✅ Clear code organization
- ✅ Easier to modify and extend
- ✅ Multiple developers can work simultaneously

**Reusability:**
- ✅ BLL can be used by different frontends
- ✅ DAL can be shared across applications
- ✅ Common logic in one place

### 2. Layer Responsibilities

**Presentation Layer (API):**
- HTTP request/response handling
- Routing and model binding
- Authentication/Authorization
- Input validation
- Calling services from BLL

**Business Logic Layer (BLL):**
- Business rules enforcement
- Data validation
- DTO transformations
- Service orchestration
- Cross-cutting concerns

**Data Access Layer (DAL):**
- Database operations (CRUD)
- Entity Framework context
- Query optimization
- Transaction management
- Data persistence

### 3. Dependency Flow

```
API → BLL → DAL → Database

- API depends on BLL (Project Reference)
- BLL depends on DAL (Project Reference)
- DAL depends on EF Core (NuGet Package)
- No circular dependencies
- Lower layers don't know about upper layers
```

## 📁 Project Files Detailed

### AppLayerAPI/Program.cs - Entry Point with Multi-Layer DI

```csharp
using BLL.Services;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register services from BLL
builder.Services.AddScoped<StudentService>();

// Register repositories from DAL
builder.Services.AddScoped<StudentRepo>();

// Register DbContext from DAL
builder.Services.AddDbContext<UMSContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
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

**Key Features:**

**1. Multi-Layer Dependency Injection:**
```csharp
// BLL layer
builder.Services.AddScoped<StudentService>();

// DAL layer
builder.Services.AddScoped<StudentRepo>();
builder.Services.AddDbContext<UMSContext>(...);
```
- Services from all layers registered in API layer
- Scoped lifetime - one instance per request
- Automatic dependency resolution

**2. DbContext Configuration:**
```csharp
builder.Services.AddDbContext<UMSContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});
```
- DbContext from DAL registered in API
- Connection string from appsettings.json
- Available for injection in repositories

**3. Layer Access:**
- API can access BLL (via project reference)
- API can access DAL types (through BLL reference chain)
- Proper dependency injection setup

---

### AppLayerAPI/appsettings.json - Configuration

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
    "DbConn": "data source=BASHARULALAMMAZ; initial catalog=TierCF; TrustServerCertificate=True; Integrated Security=True;"
  }
}
```

**Configuration Details:**
- **Database:** TierCF (Tier Code First)
- **Connection:** Windows Authentication
- Update `data source` with your SQL Server instance

---

### AppLayerAPI/Controllers/StudentController.cs - Presentation Layer

```csharp
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentService service;
        
        public StudentController(StudentService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult GettAll()
        {
            var data = service.Get();
            return Ok(data);
        }
    }
}
```

**Key Features:**

**1. Service Injection:**
```csharp
StudentService service;

public StudentController(StudentService service)
{
    this.service = service;
}
```
- Receives `StudentService` from BLL via DI
- No direct database access
- Clean separation of concerns

**2. Thin Controller:**
```csharp
[HttpGet("all")]
public IActionResult GettAll()
{
    var data = service.Get();
    return Ok(data);
}
```
- Minimal logic in controller
- Delegates to service layer
- Only handles HTTP concerns

**3. API Endpoint:**
```
GET /api/student/all
```
**Response:**
```json
[
  {
    "id": 1,
    "name": "John Doe"
  },
  {
    "id": 2,
    "name": "Jane Smith"
  }
]
```

---

### BLL/DTOs/StudentDTO.cs - Data Transfer Object

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
```

**Purpose:**
- API contract - what clients see
- Simplified data structure
- Hides database entity complexity
- Can differ from entity structure

**Why DTOs?**
- ✅ **Security** - Don't expose entity structure
- ✅ **Flexibility** - Different representation than database
- ✅ **Versioning** - API changes independent of database
- ✅ **Performance** - Only send needed data

---

### BLL/Services/StudentService.cs - Business Logic Layer

```csharp
using AutoMapper;
using BLL.DTOs;
using DAL.Ef.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo repo;

        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Students, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public List<StudentDTO> Get()
        {
            var students = repo.Get();
            var ret = GetMapper().Map<List<StudentDTO>>(students);
            return ret;
        }
    }
}
```

**Key Components:**

**1. Repository Injection:**
```csharp
StudentRepo repo;

public StudentService(StudentRepo repo)
{
    this.repo = repo;
}
```
- Receives repository from DAL via DI
- Service doesn't create repository
- Testable - can inject mock repository

**2. AutoMapper Configuration:**
```csharp
Mapper GetMapper()
{
    var config = new MapperConfiguration(cfg => {
        cfg.CreateMap<Students, StudentDTO>().ReverseMap();
    });
    return new Mapper(config);
}
```
- Maps entity to DTO
- `.ReverseMap()` allows DTO → Entity
- Eliminates manual mapping code

**3. Business Logic:**
```csharp
public List<StudentDTO> Get()
{
    var students = repo.Get();                          // Get entities from DAL
    var ret = GetMapper().Map<List<StudentDTO>>(students);  // Map to DTOs
    return ret;                                          // Return to API
}
```
- Calls repository to get data
- Transforms entities to DTOs
- Returns data to controller

**Responsibilities:**
- Data transformation (Entity ↔ DTO)
- Business rules (not shown, but would go here)
- Orchestration of multiple repositories
- Transaction coordination

---

### DAL/Repos/StudentRepo.cs - Data Access Layer

```csharp
using DAL.Ef.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        public List<Students> Get()
        {
            return db.Students.ToList();
        }
    }
}
```

**⚠️ Note:** This code references `db` but doesn't declare it. The complete implementation should be:

**Corrected Version:**
```csharp
using DAL.Ef.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        private readonly UMSContext db;
        
        public StudentRepo(UMSContext db)
        {
            this.db = db;
        }

        public List<Students> Get()
        {
            return db.Students.ToList();
        }
    }
}
```

**Key Features:**

**1. DbContext Injection:**
```csharp
private readonly UMSContext db;

public StudentRepo(UMSContext db)
{
    this.db = db;
}
```
- Receives DbContext via DI
- No manual context creation
- Framework manages lifecycle

**2. Data Access:**
```csharp
public List<Students> Get()
{
    return db.Students.ToList();
}
```
- LINQ query to database
- Returns entity objects
- No DTOs at this layer

**Repository Pattern Benefits:**
- ✅ Abstracts database operations
- ✅ Centralized data access
- ✅ Easier to test (mock repository)
- ✅ Can switch databases without changing BLL

---

### DAL/Ef/Tables/Students.cs - Entity Model

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Ef.Tables
{
    public class Students
    {
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
```

**Entity Features:**

**1. Data Annotations:**
```csharp
[Column(TypeName = "varchar(100)")]
public string Name { get; set; }
```
- Specifies SQL column type
- VARCHAR(100) instead of NVARCHAR

**2. Entity Properties:**
- `Id` - Primary key (convention-based)
- `Name` - Student name

**Generated SQL:**
```sql
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL
);
```

---

### DAL/EF/UMSContext.cs - Database Context (Expected)

**⚠️ Note:** This file is missing in Lab 9 but should exist:

```csharp
using DAL.Ef.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UMSContext : DbContext
    {
        public UMSContext(DbContextOptions<UMSContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
    }
}
```

**Purpose:**
- Database connection configuration
- Entity set definitions
- Model configuration

---

### Project Files (.csproj)

**AppLayerAPI.csproj - API Layer:**
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.11" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\BLL\BLL.csproj" />
  </ItemGroup>
</Project>
```
- References BLL project
- Contains EF Core packages for migrations

**BLL.csproj - Business Logic Layer:**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="AutoMapper" Version="9.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\DAL\DAL.csproj" />
  </ItemGroup>
</Project>
```
- References DAL project
- Contains AutoMapper package

**DAL.csproj - Data Access Layer:**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.11" />
  </ItemGroup>
</Project>
```
- Contains EF Core packages
- No project references (lowest layer)

---

## 🎓 Key Learning Points

### 1. Request Flow

```
1. Client sends HTTP request
   ↓
2. StudentController receives request
   ↓
3. Controller calls StudentService.Get()
   ↓
4. Service calls StudentRepo.Get()
   ↓
5. Repository queries database via EF Core
   ↓
6. Entities returned to Service
   ↓
7. Service maps Entities → DTOs
   ↓
8. DTOs returned to Controller
   ↓
9. Controller returns HTTP response
   ↓
10. Client receives JSON data
```

### 2. Dependency Injection Chain

```csharp
// Program.cs registers all services
builder.Services.AddScoped<StudentService>();     // BLL
builder.Services.AddScoped<StudentRepo>();        // DAL
builder.Services.AddDbContext<UMSContext>(...);   // DAL

// DI Container resolves:
StudentController
    → needs StudentService
        → needs StudentRepo
            → needs UMSContext
                → configured with connection string
```

### 3. Layer Isolation

**API Layer (AppLayerAPI):**
- Knows about BLL (StudentService, StudentDTO)
- Doesn't directly access DAL
- Doesn't know about entities

**BLL Layer:**
- Knows about DAL (StudentRepo, Students entity)
- Knows about DTOs
- Performs transformations

**DAL Layer:**
- Knows about database (EF Core, entities)
- No knowledge of API or DTOs
- Pure data access

### 4. Project References

```
AppLayerAPI.csproj
  → References BLL.csproj
    → References DAL.csproj
      → No project references

One-way dependency flow
No circular references
```

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

### Setup Steps

**1. Update Connection String:**
```json
// In AppLayerAPI/appsettings.json
"ConnectionStrings": {
  "DbConn": "data source=YOUR_SERVER_NAME; initial catalog=TierCF; TrustServerCertificate=True; Integrated Security=True;"
}
```

**2. Create UMSContext.cs (if missing):**

Create file: `DAL/EF/UMSContext.cs`
```csharp
using DAL.Ef.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UMSContext : DbContext
    {
        public UMSContext(DbContextOptions<UMSContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
    }
}
```

**3. Fix StudentRepo.cs:**

Update `DAL/Repos/StudentRepo.cs`:
```csharp
using DAL.Ef.Tables;

namespace DAL.Repos
{
    public class StudentRepo
    {
        private readonly UMSContext db;
        
        public StudentRepo(UMSContext db)
        {
            this.db = db;
        }

        public List<Students> Get()
        {
            return db.Students.ToList();
        }
    }
}
```

**4. Create Migration:**
```powershell
cd DAL
dotnet ef migrations add InitialCreate --startup-project ..\AppLayerAPI\AppLayerAPI.csproj
```

**5. Update Database:**
```powershell
dotnet ef database update --startup-project ..\AppLayerAPI\AppLayerAPI.csproj
```

**6. Navigate to API Project:**
```powershell
cd ..\AppLayerAPI
```

**7. Restore & Build:**
```powershell
dotnet restore
dotnet build
```

**8. Run Application:**
```powershell
dotnet run
```

**9. Test API:**
```
GET https://localhost:5001/api/student/all
```

---

## 🧪 Testing the API

### Using Browser

```
https://localhost:5001/api/student/all
```

### Using PowerShell

```powershell
Invoke-RestMethod -Uri "https://localhost:5001/api/student/all" -Method Get
```

### Using Postman

```
Method: GET
URL: https://localhost:5001/api/student/all
```

**Expected Response:**
```json
[
  {
    "id": 1,
    "name": "John Doe"
  },
  {
    "id": 2,
    "name": "Jane Smith"
  }
]
```

---

## 💡 Best Practices & Improvements

### Recommended Enhancements

**1. Add More CRUD Operations:**

**StudentRepo.cs:**
```csharp
public Students GetById(int id)
{
    return db.Students.Find(id);
}

public bool Add(Students student)
{
    db.Students.Add(student);
    return db.SaveChanges() > 0;
}

public bool Update(Students student)
{
    var existing = GetById(student.Id);
    db.Entry(existing).CurrentValues.SetValues(student);
    return db.SaveChanges() > 0;
}

public bool Delete(int id)
{
    var student = GetById(id);
    db.Students.Remove(student);
    return db.SaveChanges() > 0;
}
```

**StudentService.cs:**
```csharp
public StudentDTO GetById(int id)
{
    var student = repo.GetById(id);
    return GetMapper().Map<StudentDTO>(student);
}

public bool Create(StudentDTO dto)
{
    var student = GetMapper().Map<Students>(dto);
    return repo.Add(student);
}

public bool Update(StudentDTO dto)
{
    var student = GetMapper().Map<Students>(dto);
    return repo.Update(student);
}

public bool Delete(int id)
{
    return repo.Delete(id);
}
```

**StudentController.cs:**
```csharp
[HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var data = service.GetById(id);
    if (data == null) return NotFound();
    return Ok(data);
}

[HttpPost]
public IActionResult Create(StudentDTO dto)
{
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var success = service.Create(dto);
    return success ? Ok(dto) : StatusCode(500);
}

[HttpPut("{id}")]
public IActionResult Update(int id, StudentDTO dto)
{
    dto.Id = id;
    var success = service.Update(dto);
    return success ? Ok(dto) : NotFound();
}

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var success = service.Delete(id);
    return success ? NoContent() : NotFound();
}
```

**2. Register AutoMapper Properly:**
```csharp
// BLL/MappingProfile.cs
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Students, StudentDTO>().ReverseMap();
    }
}

// Program.cs
builder.Services.AddAutoMapper(typeof(MappingProfile));
```

**3. Use Interfaces for Loose Coupling:**

**IStudentRepo.cs (DAL):**
```csharp
public interface IStudentRepo
{
    List<Students> Get();
    Students GetById(int id);
    bool Add(Students student);
    bool Update(Students student);
    bool Delete(int id);
}

public class StudentRepo : IStudentRepo
{
    // Implementation
}
```

**IStudentService.cs (BLL):**
```csharp
public interface IStudentService
{
    List<StudentDTO> Get();
    StudentDTO GetById(int id);
    bool Create(StudentDTO dto);
    bool Update(StudentDTO dto);
    bool Delete(int id);
}

public class StudentService : IStudentService
{
    // Implementation
}
```

**Register interfaces:**
```csharp
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
```

**4. Add Async Operations:**
```csharp
// Repository
public async Task<List<Students>> GetAsync()
{
    return await db.Students.ToListAsync();
}

// Service
public async Task<List<StudentDTO>> GetAsync()
{
    var students = await repo.GetAsync();
    return GetMapper().Map<List<StudentDTO>>(students);
}

// Controller
[HttpGet("all")]
public async Task<IActionResult> GetAll()
{
    var data = await service.GetAsync();
    return Ok(data);
}
```

**5. Add Logging:**
```csharp
public class StudentService : IStudentService
{
    private readonly IStudentRepo repo;
    private readonly ILogger<StudentService> logger;
    
    public StudentService(IStudentRepo repo, ILogger<StudentService> logger)
    {
        this.repo = repo;
        this.logger = logger;
    }
    
    public List<StudentDTO> Get()
    {
        logger.LogInformation("Getting all students");
        var students = repo.Get();
        logger.LogInformation($"Retrieved {students.Count} students");
        return GetMapper().Map<List<StudentDTO>>(students);
    }
}
```

**6. Add Error Handling:**
```csharp
public class StudentService : IStudentService
{
    public List<StudentDTO> Get()
    {
        try
        {
            var students = repo.Get();
            return GetMapper().Map<List<StudentDTO>>(students);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving students");
            throw;
        }
    }
}
```

---

## 📊 Comparison: Lab 8 vs Lab 9

| Feature | Lab 8 (Single Project) | Lab 9 (3-Tier) |
|---------|----------------------|----------------|
| **Projects** | 1 (API only) | 3 (API, BLL, DAL) |
| **Architecture** | Monolithic | Layered (3-Tier) |
| **Separation** | ⚠️ Folders | ✅ Projects |
| **Testing** | ⚠️ Difficult | ✅ Easy (isolated) |
| **Scalability** | ⚠️ Limited | ✅ High |
| **Maintainability** | ⚠️ Medium | ✅ Excellent |
| **Reusability** | ❌ Low | ✅ High |
| **Dependencies** | Internal | Project references |
| **Best For** | Small projects | Enterprise apps |

---

## 📚 Additional Resources

### Official Documentation
- [Multi-Project Solutions](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln)
- [N-Tier Architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#traditional-n-layer-architecture-applications)
- [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)

### Recommended Reading
- **Clean Architecture** by Robert C. Martin
- **Domain-Driven Design** by Eric Evans
- **Patterns of Enterprise Application Architecture** by Martin Fowler

---

## 🐛 Troubleshooting

### Issue: UMSContext Not Found
**Solution:** Create the missing DbContext file in DAL project (see Setup Steps)

### Issue: db Variable Not Declared
**Solution:** Add DbContext injection to StudentRepo constructor

### Issue: Cannot Reference BLL from API
**Solution:** Add project reference in AppLayerAPI.csproj
```xml
<ItemGroup>
  <ProjectReference Include="..\BLL\BLL.csproj" />
</ItemGroup>
```

### Issue: Migration Commands Fail
**Solution:** Specify startup project
```powershell
dotnet ef migrations add InitialCreate --startup-project ..\AppLayerAPI
```

### Issue: Service Not Found During DI
**Solution:** Ensure all services registered in Program.cs
```csharp
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<StudentRepo>();
builder.Services.AddDbContext<UMSContext>(...);
```

---

## 📊 Project Statistics

| Metric | Value |
|--------|-------|
| **Projects** | 3 (API, BLL, DAL) |
| **Controllers** | 1 (Student) |
| **Services** | 1 (StudentService) |
| **Repositories** | 1 (StudentRepo) |
| **Entities** | 1 (Students) |
| **DTOs** | 1 (StudentDTO) |
| **API Endpoints** | 1 (GET all students) |
| **Lines of Code** | ~200 |
| **Target Framework** | .NET 10.0 |
| **EF Core Version** | 9.0.11 |
| **AutoMapper Version** | 9.0.0 |
| **Complexity** | ⭐⭐⭐⭐ Advanced |

---

## 🎓 Learning Outcomes Achieved

✅ **Understand 3-tier architecture pattern**  
✅ **Create multi-project solutions**  
✅ **Implement repository pattern**  
✅ **Build service layer with business logic**  
✅ **Use DTOs for data transfer**  
✅ **Apply AutoMapper in services**  
✅ **Configure DI across multiple projects**  
✅ **Separate concerns by layer**  
✅ **Implement proper project references**  
✅ **Build scalable, maintainable applications**

---

## 🏆 Key Takeaways

1. **3-Tier Architecture promotes clean separation** - Each layer has specific responsibility
2. **Projects enforce boundaries** - Stronger than folders
3. **DI works across layers** - Register and inject from any layer
4. **Repository pattern abstracts data access** - Testable, swappable
5. **Services contain business logic** - Not in controllers or repositories
6. **DTOs provide API contracts** - Different from entities
7. **AutoMapper eliminates boilerplate** - Clean transformations
8. **Lower layers don't reference upper layers** - One-way dependency flow
9. **Testability increases** - Mock dependencies easily
10. **Scalability improves** - Deploy layers independently

---

## 🔗 Quick Links

- [Program.cs](#applayerapiprogramcs---entry-point-with-multi-layer-di) - DI configuration
- [StudentController](#applayerapicontrollersstudentcontrollercs---presentation-layer) - API endpoints
- [StudentService](#bllservicesstudentservicecs---business-logic-layer) - Business logic
- [StudentRepo](#dalreposstudentrepocs---data-access-layer) - Repository
- [Students Entity](#daleftablesstudentscs---entity-model) - Entity model
- [Best Practices](#-best-practices--improvements) - Improvements

---

## 👨‍💻 Author
**Course:** Advanced Programming with .NET  
**Lab:** Lab 9 - Introduction to 3-Tier Architecture  
**Institution:** American International University - Bangladesh (AIUB)  
**Semester:** 9  
**Academic Year:** 2025-2026

## 📄 License
This project is created for educational purposes as part of university coursework.

---

**Last Updated:** January 23, 2026  
**Status:** ⚠️ Incomplete (Missing UMSContext)  
**Framework:** ASP.NET Core 10.0 + EF Core 9.0.11 + AutoMapper 9.0.0

---

**Ready to build enterprise applications with 3-tier architecture? Let's scale up! 🚀**
