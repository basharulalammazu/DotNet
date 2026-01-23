# Lab 6 - Introduction to ASP.NET Core Web API

## 📚 Overview
Welcome to **Lab 6**, where we dive into the world of **RESTful Web APIs** using **ASP.NET Core**! This lab introduces the fundamentals of building modern, scalable web services that can power web applications, mobile apps, and IoT devices.

## 🎯 Learning Objectives

By the end of this lab, you will understand:

- ✅ **RESTful API Architecture** - Design principles and HTTP methods
- ✅ **ASP.NET Core Web API** - Building modern web services
- ✅ **API Controllers** - Creating endpoints with attribute routing
- ✅ **DTOs (Data Transfer Objects)** - Separating data models from presentation
- ✅ **HTTP Methods** - GET, POST, PUT, DELETE operations
- ✅ **Route Parameters** - Dynamic URL routing and parameter binding
- ✅ **Action Results** - Returning proper HTTP responses
- ✅ **Dependency Injection** - Built-in DI container usage
- ✅ **OpenAPI Integration** - Automatic API documentation

## 🏗️ Project Structure

```
IntroWebApi/
├── Controllers/
│   ├── StudentController.cs           # Student management endpoints
│   ├── DepartmentController.cs        # Department management endpoints
│   └── WeatherForecastController.cs   # Sample weather API
├── DTOs/
│   ├── StudentDTO.cs                  # Student data transfer object
│   └── DepartmentDTO.cs               # Department data transfer object
├── Properties/
│   └── launchSettings.json            # Launch configurations
├── appsettings.json                   # Application configuration
├── Program.cs                         # Application entry point
├── WeatherForecast.cs                 # Weather model
└── IntroWebApi.csproj                 # Project file
```

## 🚀 Technology Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| ASP.NET Core | 10.0 | Web API framework |
| .NET | 10.0 | Runtime environment |
| C# | 12.0 | Programming language |
| OpenAPI | Latest | API documentation |
| HTTP/REST | - | Communication protocol |

## 📋 Key Concepts

### 1. RESTful API Principles

**REST (Representational State Transfer)** is an architectural style for building web services:

- **Stateless** - Each request contains all necessary information
- **Resource-based** - URIs identify resources
- **HTTP Methods** - Standard operations (GET, POST, PUT, DELETE)
- **JSON Format** - Lightweight data exchange

### 2. API Controller

API Controllers handle HTTP requests and return responses:

```csharp
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    // Controller actions
}
```

**Key Attributes:**
- `[Route]` - Defines the base route
- `[ApiController]` - Enables API-specific behaviors
- `ControllerBase` - Base class for API controllers (no view support)

### 3. HTTP Methods

| Method | Purpose | Idempotent | Safe |
|--------|---------|------------|------|
| **GET** | Retrieve data | ✅ Yes | ✅ Yes |
| **POST** | Create new resource | ❌ No | ❌ No |
| **PUT** | Update entire resource | ✅ Yes | ❌ No |
| **PATCH** | Update partial resource | ❌ No | ❌ No |
| **DELETE** | Remove resource | ✅ Yes | ❌ No |

### 4. Data Transfer Objects (DTOs)

DTOs encapsulate data for transfer between layers:

**Benefits:**
- Separation of concerns
- API versioning support
- Security (hide sensitive data)
- Performance optimization

## 📁 Project Files Detailed

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

**Key Concepts:**
- **WebApplicationBuilder** - Configures services and middleware
- **AddControllers()** - Registers controller services
- **AddOpenApi()** - Enables OpenAPI documentation
- **MapControllers()** - Maps controller routes
- **Middleware Pipeline** - Request processing chain

---

### DTOs/StudentDTO.cs - Student Data Model

```csharp
namespace IntroWebApi.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
```

**Purpose:**
- Defines student data structure
- Used for API request/response
- Separates domain model from API contract

**Properties:**
- `Id` - Unique identifier
- `Name` - Student name
- `Email` - Contact email
- `Phone` - Contact number

---

### DTOs/DepartmentDTO.cs - Department Data Model

```csharp
namespace IntroWebApi.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Nullable reference type
    }
}
```

**Key Features:**
- **Nullable Reference Types** (`string?`) - Allows null values
- Simple structure for department data
- Used across multiple endpoints

---

### Controllers/StudentController.cs - Student API Endpoints

```csharp
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    [HttpGet]
    public IActionResult GettAll()
    {
        var s1 = new StudentDTO
        {
            Id = 1,
            Name = "Basharul Alam",
            Email = "basha@gmail.com",
            Phone = "01711111111",
        };

        var s2 = new StudentDTO
        {
            Id = 2,
            Name = "Basharul Alam",
            Email = "basha@gmail.com",
            Phone = "01711111111",
        };

        var students = new List<StudentDTO> { s1, s2 };
        return Ok(students);
    }

    [HttpPost]
    public IActionResult DataPost(StudentDTO student)
    {
        return Ok(student);
    }
}
```

#### API Endpoints

**1. GET All Students**
```
GET /api/student
```
**Description:** Retrieves a list of all students

**Response:**
```json
[
  {
    "id": 1,
    "name": "Basharul Alam",
    "email": "basha@gmail.com",
    "phone": "01711111111"
  },
  {
    "id": 2,
    "name": "Basharul Alam",
    "email": "basha@gmail.com",
    "phone": "01711111111"
  }
]
```

**Status Code:** `200 OK`

---

**2. POST Create Student**
```
POST /api/student
```
**Description:** Creates or processes a new student

**Request Body:**
```json
{
  "id": 3,
  "name": "John Doe",
  "email": "john@example.com",
  "phone": "01755555555"
}
```

**Response:** Returns the posted student data

**Status Code:** `200 OK`

---

### Controllers/DepartmentController.cs - Department API Endpoints

```csharp
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() { ... }

    [HttpGet("Id/{id}")]
    public IActionResult Get(int id) { ... }

    [HttpGet("id/{id}/name/{name}")]
    public IActionResult GetByIdAndName(int id, string name) { ... }

    [HttpPost("Create")]
    public IActionResult Create(DepartmentDTO department) { ... }
}
```

#### API Endpoints

**1. GET All Departments**
```
GET /api/department
```
**Description:** Retrieves all departments

**Response:**
```json
[
  {
    "id": 1,
    "name": "CSE"
  },
  {
    "id": 2,
    "name": "EEE"
  }
]
```

**Status Code:** `200 OK`

---

**2. GET Department by ID**
```
GET /api/department/Id/{id}
```
**Description:** Retrieves a specific department by ID

**Parameters:**
- `id` (int) - Department ID

**Example:** `GET /api/department/Id/5`

**Response:**
```json
{
  "id": 5,
  "name": "CSE"
}
```

**Status Code:** `200 OK`

---

**3. GET Department by ID and Name**
```
GET /api/department/id/{id}/name/{name}
```
**Description:** Retrieves department using both ID and name

**Parameters:**
- `id` (int) - Department ID
- `name` (string) - Department name

**Example:** `GET /api/department/id/10/name/CSE`

**Response:**
```json
{
  "id": 10,
  "name": "CSE"
}
```

**Status Code:** `200 OK`

**Key Concepts:**
- **Multiple Route Parameters** - Combining ID and name
- **Complex Routing** - Custom URL patterns

---

**4. POST Create Department**
```
POST /api/department/Create
```
**Description:** Creates a new department

**Request Body:**
```json
{
  "id": 3,
  "name": "BBA"
}
```

**Response:** Returns the created department

**Status Code:** `200 OK`

**Key Concepts:**
- **Custom Route Template** - Using "Create" suffix
- **Model Binding** - Automatic JSON to object conversion

---

### Controllers/WeatherForecastController.cs - Weather API

```csharp
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
```

#### API Endpoint

**GET Weather Forecast**
```
GET /weatherforecast
```
**Description:** Returns 5-day weather forecast

**Response:**
```json
[
  {
    "date": "2026-01-24",
    "temperatureC": 15,
    "temperatureF": 58,
    "summary": "Mild"
  },
  {
    "date": "2026-01-25",
    "temperatureC": -5,
    "temperatureF": 23,
    "summary": "Chilly"
  }
]
```

**Key Features:**
- **Random Data Generation** - Uses `Random.Shared`
- **LINQ Projection** - `Select()` for data transformation
- **Named Routes** - `Name = "GetWeatherForecast"`
- **Collection Return** - `IEnumerable<T>`

---

### WeatherForecast.cs - Weather Model

```csharp
public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}
```

**Key Features:**
- **DateOnly** - .NET 6+ date type (without time)
- **Calculated Property** - `TemperatureF` auto-converts from Celsius
- **Read-only Property** - No setter for TemperatureF
- **Nullable String** - Summary can be null

---

## 🎨 Routing Patterns

### 1. Convention-based Routing
```csharp
[Route("api/[controller]")]
```
- `[controller]` replaced with controller name (minus "Controller")
- `StudentController` → `/api/student`

### 2. Custom Route Templates
```csharp
[HttpGet("Id/{id}")]
```
- Explicit route definition
- Route parameters in curly braces

### 3. Multiple Parameters
```csharp
[HttpGet("id/{id}/name/{name}")]
```
- Complex URL patterns
- Multiple route constraints

### 4. Action-specific Routes
```csharp
[HttpPost("Create")]
```
- Adds suffix to base route
- Better semantic URLs

## 🔄 Action Results

### Common Action Results

| Result Type | HTTP Code | Usage |
|-------------|-----------|-------|
| `Ok(data)` | 200 | Success with data |
| `Created()` | 201 | Resource created |
| `NoContent()` | 204 | Success, no data |
| `BadRequest()` | 400 | Invalid request |
| `NotFound()` | 404 | Resource not found |
| `Unauthorized()` | 401 | Authentication required |

### Example Usage

```csharp
// Return data with 200 OK
return Ok(students);

// Return 404 if not found
if (student == null)
    return NotFound();

// Return 400 for invalid input
if (!ModelState.IsValid)
    return BadRequest(ModelState);
```

## 🧪 Testing the API

### Using Browser (GET only)

**Weather Forecast:**
```
https://localhost:5001/weatherforecast
```

**All Students:**
```
https://localhost:5001/api/student
```

**All Departments:**
```
https://localhost:5001/api/department
```

**Department by ID:**
```
https://localhost:5001/api/department/Id/5
```

**Department by ID and Name:**
```
https://localhost:5001/api/department/id/10/name/CSE
```

---

### Using PowerShell (All Methods)

**1. GET All Students:**
```powershell
Invoke-RestMethod -Uri "https://localhost:5001/api/student" -Method Get
```

**2. POST New Student:**
```powershell
$body = @{
    id = 3
    name = "John Doe"
    email = "john@example.com"
    phone = "01755555555"
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:5001/api/student" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"
```

**3. GET Department by ID:**
```powershell
Invoke-RestMethod -Uri "https://localhost:5001/api/department/Id/5" -Method Get
```

**4. POST New Department:**
```powershell
$body = @{
    id = 5
    name = "BBA"
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:5001/api/department/Create" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"
```

---

### Using cURL

**1. GET All Students:**
```bash
curl -X GET https://localhost:5001/api/student
```

**2. POST New Student:**
```bash
curl -X POST https://localhost:5001/api/student \
  -H "Content-Type: application/json" \
  -d '{"id":3,"name":"John Doe","email":"john@example.com","phone":"01755555555"}'
```

**3. GET Department by ID and Name:**
```bash
curl -X GET https://localhost:5001/api/department/id/10/name/CSE
```

---

### Using Postman

**Setup:**
1. Create new request
2. Set method (GET/POST)
3. Enter URL
4. For POST: Add JSON body in Body → raw → JSON

**Example POST Request:**
```
Method: POST
URL: https://localhost:5001/api/student
Headers: Content-Type: application/json
Body:
{
  "id": 4,
  "name": "Jane Smith",
  "email": "jane@example.com",
  "phone": "01766666666"
}
```

## 📊 API Endpoints Summary

| Method | Endpoint | Description | Parameters |
|--------|----------|-------------|------------|
| GET | `/api/student` | Get all students | - |
| POST | `/api/student` | Create student | Body: StudentDTO |
| GET | `/api/department` | Get all departments | - |
| GET | `/api/department/Id/{id}` | Get department by ID | id: int |
| GET | `/api/department/id/{id}/name/{name}` | Get by ID & name | id: int, name: string |
| POST | `/api/department/Create` | Create department | Body: DepartmentDTO |
| GET | `/weatherforecast` | Get weather forecast | - |

## 🎓 Key Learning Points

### 1. API Controller Basics
- Controllers inherit from `ControllerBase` (not `Controller`)
- No view support - only data
- Automatic JSON serialization

### 2. Attribute Routing
```csharp
[Route("api/[controller]")]  // Base route
[HttpGet("Id/{id}")]         // GET with parameter
[HttpPost("Create")]         // POST with custom route
```

### 3. Model Binding
- Automatic parameter binding from route
- Automatic JSON deserialization for body
- Type conversion handled by framework

### 4. Return Types
```csharp
IActionResult           // Flexible return type
ActionResult<T>         // Typed result
IEnumerable<T>          // Collection return
Task<IActionResult>     // Async operations
```

### 5. DTOs vs Models
- **DTOs** - Data transfer (API layer)
- **Models** - Domain logic (business layer)
- **Entities** - Database mapping (data layer)

## 🚀 Getting Started

### Prerequisites
- **.NET 10.0 SDK** or later
- **Visual Studio 2022** or **VS Code**
- **Postman** or similar API testing tool (optional)

### Running the Project

**1. Navigate to Project Directory:**
```powershell
cd "d:\University\Semester 9\ADVANCED PROGRAMMING WITH .NET\Lab\.NET Core\Lab6\IntroWebApi"
```

**2. Restore Dependencies:**
```powershell
dotnet restore
```

**3. Build the Project:**
```powershell
dotnet build
```

**4. Run the Application:**
```powershell
dotnet run
```

**5. Access the API:**
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`
- OpenAPI: `https://localhost:5001/openapi/v1.json` (Development only)

### Project Configuration

**Port Configuration (launchSettings.json):**
```json
{
  "profiles": {
    "https": {
      "applicationUrl": "https://localhost:5001;http://localhost:5000"
    }
  }
}
```

## 🔧 Configuration Files

### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Purpose:**
- Application settings
- Logging configuration
- Environment-specific settings

### IntroWebApi.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.1" />
  </ItemGroup>
</Project>
```

**Key Features:**
- **Target Framework:** .NET 10.0
- **Nullable Reference Types:** Enabled
- **Implicit Usings:** Common namespaces auto-imported
- **OpenAPI Package:** API documentation support

## 💡 Best Practices Demonstrated

### 1. Separation of Concerns
✅ Controllers handle HTTP logic  
✅ DTOs handle data transfer  
✅ Models handle business logic (when added)

### 2. RESTful Design
✅ Resource-based URLs (`/api/student`)  
✅ Proper HTTP methods (GET, POST)  
✅ Consistent naming conventions  
✅ JSON format for data exchange

### 3. Code Organization
✅ Controllers in Controllers folder  
✅ DTOs in DTOs folder  
✅ Clear naming conventions  
✅ Namespace organization

### 4. Modern C# Features
✅ Nullable reference types (`string?`)  
✅ Collection expressions (`[...]`)  
✅ DateOnly type  
✅ Top-level statements (Program.cs)  
✅ Implicit usings

### 5. API Documentation
✅ OpenAPI integration  
✅ Named routes  
✅ Clear endpoint naming

## 🔍 Common Patterns

### 1. Controller Pattern
```csharp
[Route("api/[controller]")]
[ApiController]
public class EntityController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(data);
    
    [HttpGet("{id}")]
    public IActionResult Get(int id) => Ok(data);
    
    [HttpPost]
    public IActionResult Create(DTO dto) => Ok(dto);
}
```

### 2. DTO Pattern
```csharp
public class EntityDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Only properties needed for transfer
}
```

### 3. Response Pattern
```csharp
// Success with data
return Ok(data);

// Not found
return NotFound();

// Bad request
return BadRequest("Error message");

// Created
return Created($"/api/entity/{id}", entity);
```

## 🎯 Comparison: MVC vs Web API

| Feature | MVC (Lab 1-4) | Web API (Lab 6) |
|---------|---------------|-----------------|
| **Base Class** | `Controller` | `ControllerBase` |
| **Returns** | Views (HTML) | Data (JSON) |
| **Purpose** | Web pages | Data services |
| **Routing** | Convention + Attribute | Attribute routing |
| **Client** | Browser | Any (Mobile, Web, IoT) |
| **Content Type** | HTML | JSON/XML |

## 🚧 Next Steps & Enhancements

### Recommended Improvements

**1. Add Database Integration**
```csharp
// Entity Framework Core
public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
}
```

**2. Implement CRUD Operations**
- Complete Create, Read, Update, Delete
- Add validation
- Error handling

**3. Add Authentication**
```csharp
builder.Services.AddAuthentication();
app.UseAuthentication();
```

**4. Implement Dependency Injection**
```csharp
public interface IStudentService { }
builder.Services.AddScoped<IStudentService, StudentService>();
```

**5. Add Swagger Documentation**
```csharp
builder.Services.AddSwaggerGen();
app.UseSwagger();
app.UseSwaggerUI();
```

**6. Implement Error Handling**
```csharp
app.UseExceptionHandler("/error");
```

**7. Add Validation**
```csharp
public class StudentDTO
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
}
```

## 📚 Additional Resources

### Official Documentation
- [ASP.NET Core Web API](https://docs.microsoft.com/en-us/aspnet/core/web-api/)
- [RESTful API Design](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design)
- [HTTP Status Codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status)

### Recommended Tools
- **Postman** - API testing and documentation
- **Swagger/OpenAPI** - API documentation
- **curl** - Command-line HTTP client
- **REST Client** (VS Code extension)

### Further Learning
- Entity Framework Core integration
- Authentication & Authorization (JWT)
- API versioning
- Rate limiting
- CORS configuration
- Caching strategies

## 🐛 Troubleshooting

### Issue: Port Already in Use
**Solution:**
```powershell
# Change port in launchSettings.json
"applicationUrl": "https://localhost:5002;http://localhost:5001"
```

### Issue: HTTPS Certificate Warning
**Solution:**
```powershell
dotnet dev-certs https --trust
```

### Issue: Cannot Access API
**Solution:**
- Check if application is running
- Verify correct URL and port
- Check firewall settings

### Issue: JSON Not Serializing
**Solution:**
- Ensure properties have getters/setters
- Check for circular references
- Verify content type is `application/json`

## 📊 Project Statistics

| Metric | Value |
|--------|-------|
| **Controllers** | 3 |
| **DTOs** | 2 |
| **API Endpoints** | 7 |
| **Lines of Code** | ~300 |
| **Target Framework** | .NET 10.0 |
| **Complexity** | ⭐⭐ Intermediate |

## 🎓 Learning Outcomes Achieved

✅ **Understand RESTful API principles**  
✅ **Create API controllers with attribute routing**  
✅ **Implement GET and POST endpoints**  
✅ **Use DTOs for data transfer**  
✅ **Handle route parameters**  
✅ **Return proper HTTP responses**  
✅ **Test APIs using various tools**  
✅ **Configure ASP.NET Core Web API project**  
✅ **Apply modern C# features**  
✅ **Structure API projects professionally**

## 🏆 Key Takeaways

1. **Web APIs are stateless** - Each request is independent
2. **Use appropriate HTTP methods** - GET for retrieval, POST for creation
3. **DTOs separate concerns** - API contract vs domain model
4. **Routing is flexible** - Convention-based and attribute routing
5. **Action Results matter** - Return proper HTTP status codes
6. **Testing is crucial** - Use tools like Postman, curl, or PowerShell
7. **OpenAPI provides documentation** - Automatic API documentation

## 👨‍💻 Author
**Course:** Advanced Programming with .NET  
**Lab:** Lab 6 - Introduction to ASP.NET Core Web API  
**Institution:** American International University - Bangladesh (AIUB)  
**Semester:** 9  
**Academic Year:** 2025-2026

## 📄 License
This project is created for educational purposes as part of university coursework.

---

**Last Updated:** January 23, 2026  
**Status:** ✅ Complete  
**Framework:** ASP.NET Core 10.0

---

## 🔗 Quick Links

- [Program.cs](#programcs---application-entry-point) - Application configuration
- [StudentController](#controllersstudentcontrollercs---student-api-endpoints) - Student API
- [DepartmentController](#controllersdepartmentcontrollercs---department-api-endpoints) - Department API
- [DTOs](#dtostudentdtocs---student-data-model) - Data Transfer Objects
- [Testing Guide](#-testing-the-api) - How to test the API
- [Best Practices](#-best-practices-demonstrated) - Coding standards

---

**Ready to build modern Web APIs? Start developing! 🚀**
