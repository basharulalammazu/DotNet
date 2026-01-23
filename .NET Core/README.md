# .NET Core Lab Series - Complete Overview

## 📚 Course Information

**Course:** Advanced Programming with .NET  
**Institution:** American International University - Bangladesh (AIUB)  
**Semester:** 9  
**Academic Year:** 2025-2026  
**Framework:** ASP.NET Core 10.0 / Entity Framework Core 9.0.11

---

## 🎯 Learning Journey Overview

This lab series takes you from **basic Web API development** to **production-ready 3-tier architecture** with entity relationships. Each lab builds upon the previous one, introducing new concepts and best practices.

```
Lab 6  →  Lab 7  →  Lab 8  →  Lab 9  →  Lab 10
 API      DB First   Code First  3-Tier    Complete
Basics    +Scaffold  +Migrations +Layers   +Relations
```

---

## 📁 Labs Overview

| Lab | Topic | Complexity | Status | Key Technologies |
|-----|-------|------------|--------|------------------|
| [Lab 6](#lab-6---aspnet-core-web-api-fundamentals) | ASP.NET Core Web API Fundamentals | ⭐⭐ Basic | ✅ Complete | Web API, DTOs, Routing |
| [Lab 7](#lab-7---entity-framework-core-database-first) | Entity Framework Core Database First | ⭐⭐⭐ Intermediate | ✅ Complete | EF Core, Scaffolding, Navigation |
| [Lab 8](#lab-8---entity-framework-core-code-first) | Entity Framework Core Code First | ⭐⭐⭐⭐ Advanced | ✅ Complete | Migrations, AutoMapper, Validation |
| [Lab 9](#lab-9---introduction-to-3-tier-architecture) | Introduction to 3-Tier Architecture | ⭐⭐⭐⭐ Advanced | ⚠️ Template | Multi-Project, Layers, Repository |
| [Lab 10](#lab-10---complete-3-tier-architecture) | Complete 3-Tier with Relationships | ⭐⭐⭐⭐⭐ Production | ✅ Complete | Full CRUD, FK, Navigation |

---

## 📖 Detailed Lab Descriptions

### Lab 6 - ASP.NET Core Web API Fundamentals

**📁 Directory:** `Lab6/`  
**🎯 Focus:** Introduction to ASP.NET Core Web API, HTTP methods, routing, and DTOs

#### Learning Objectives
- ✅ Create ASP.NET Core Web API project
- ✅ Understand MVC pattern in Web API
- ✅ Implement HTTP methods (GET, POST, PUT, DELETE)
- ✅ Use route attributes and parameters
- ✅ Work with Data Transfer Objects (DTOs)
- ✅ In-memory data management
- ✅ Testing APIs with various tools

#### Key Features
- **Controllers:** StudentController with full CRUD
- **Models:** Student, Department (in-memory)
- **DTOs:** StudentDTO for data transfer
- **Routing:** Attribute-based routing
- **HTTP Methods:** GET, POST, PUT, DELETE
- **Data Storage:** Static collections (no database)

#### Technologies
- ASP.NET Core Web API 10.0
- C# 12.0
- OpenAPI/Swagger
- LINQ for data operations

#### Key Endpoints
```
GET    /api/student              → Get all students
GET    /api/student/{id}         → Get student by ID
POST   /api/student              → Create student
PUT    /api/student/{id}         → Update student
DELETE /api/student/{id}         → Delete student
GET    /api/student/dept/{id}    → Get students by department
```

#### What You'll Learn
- HTTP protocol basics
- RESTful API design
- Controller structure
- Model binding
- Status code handling
- API testing strategies

---

### Lab 7 - Entity Framework Core Database First

**📁 Directory:** `Lab7/`  
**🎯 Focus:** Database First approach with EF Core, scaffolding, and relationships

#### Learning Objectives
- ✅ Understand Database First workflow
- ✅ Scaffold DbContext from existing database
- ✅ Work with navigation properties
- ✅ Query related data with LINQ
- ✅ Implement repository pattern (basic)
- ✅ Manage database connections

#### Key Features
- **Database:** EF_CF_Learning (existing database)
- **Entities:** Student, Department with navigation
- **DbContext:** EFCFLearningContext (scaffolded)
- **Controllers:** StudentController, DepartmentController
- **Operations:** CRUD with related data
- **Scaffold Command:** Database → Code

#### Technologies
- ASP.NET Core Web API 10.0
- Entity Framework Core 10.0.1
- SQL Server
- Scaffold-DbContext command
- LINQ to Entities

#### Database Schema
```
Departments (1) ──────── (*) Students
    Id                        DeptId (FK)
    Name                      → Department (Navigation)
```

#### Key Endpoints
```
GET    /api/student           → All students with departments
GET    /api/student/{id}      → Student with department
POST   /api/student           → Create student
PUT    /api/student/{id}      → Update student
DELETE /api/student/{id}      → Delete student
GET    /api/department        → All departments
```

#### What You'll Learn
- Database First approach
- Scaffolding from database
- DbContext configuration
- Navigation properties usage
- Include() for eager loading
- Connection string management
- Existing database integration

---

### Lab 8 - Entity Framework Core Code First

**📁 Directory:** `Lab8/`  
**🎯 Focus:** Code First migrations, AutoMapper, DTOs with validation

#### Learning Objectives
- ✅ Understand Code First workflow
- ✅ Create and apply migrations
- ✅ Design entities with data annotations
- ✅ Implement AutoMapper for object mapping
- ✅ Add validation attributes to DTOs
- ✅ Handle validation errors
- ✅ Database schema version control

#### Key Features
- **Approach:** Code First (Code → Database)
- **Entities:** Student, Department with attributes
- **DTOs:** StudentDTO, DepartmentDTO with validation
- **AutoMapper:** Bidirectional entity ↔ DTO mapping
- **Migrations:** Multiple migrations for schema changes
- **Validation:** Data annotations on DTOs

#### Technologies
- ASP.NET Core Web API 10.0
- Entity Framework Core 9.0.11
- AutoMapper 14.0.0
- SQL Server
- Data Annotations
- EF Core Migrations

#### Migration Workflow
```
1. Design Entities (Code)
2. Add-Migration (Create migration)
3. Update-Database (Apply to DB)
4. Database Created/Updated
```

#### Key Features Highlight
```csharp
// Data Annotations
[Required(ErrorMessage = "Name is required")]
[StringLength(100, MinimumLength = 2)]
public string Name { get; set; }

// AutoMapper Configuration
cfg.CreateMap<Student, StudentDTO>().ReverseMap();

// Validation in Controller
if (!ModelState.IsValid) return BadRequest(ModelState);
```

#### What You'll Learn
- Code First approach
- Migration creation and application
- Data annotations for schema
- AutoMapper configuration
- DTO validation
- ModelState handling
- Schema version control
- Migration rollback

---

### Lab 9 - Introduction to 3-Tier Architecture

**📁 Directory:** `Lab9/`  
**🎯 Focus:** Multi-project solution, layer separation, architectural patterns

#### Learning Objectives
- ✅ Understand 3-Tier architecture pattern
- ✅ Create multi-project solutions
- ✅ Implement Repository pattern properly
- ✅ Build Service layer for business logic
- ✅ Configure dependency injection across layers
- ✅ Separate concerns by project
- ✅ Manage project references

#### Key Features
- **Projects:** 3 separate projects (API, BLL, DAL)
- **Presentation Layer:** AppLayerAPI (Controllers)
- **Business Logic:** BLL (Services, DTOs, AutoMapper)
- **Data Access:** DAL (Repositories, EF Core, Entities)
- **Pattern:** Repository + Service Layer
- **Status:** ⚠️ Template/Incomplete (missing UMSContext)

#### Technologies
- ASP.NET Core Web API 10.0
- Entity Framework Core 9.0.11
- AutoMapper 9.0.0
- Multi-project solution
- Dependency Injection

#### Architecture Layers
```
┌─────────────────────────────┐
│  AppLayerAPI (Presentation)  │  → StudentController
├─────────────────────────────┤
│  BLL (Business Logic)        │  → StudentService, DTOs
├─────────────────────────────┤
│  DAL (Data Access)           │  → StudentRepo, Entities
└─────────────────────────────┘
         ↓
    Database (SQL Server)
```

#### Project References
```
AppLayerAPI → BLL → DAL
(One-way dependency flow)
```

#### What You'll Learn
- 3-Tier architecture benefits
- Multi-project solution structure
- Layer separation strategies
- Repository pattern implementation
- Service layer design
- Cross-project dependency injection
- Project reference management
- Separation of concerns

#### Note
Lab 9 is a **template/demonstration** showing architecture structure. Lab 10 provides the complete, production-ready implementation.

---

### Lab 10 - Complete 3-Tier Architecture with Relationships

**📁 Directory:** `Lab10/`  
**🎯 Focus:** Production-ready 3-tier architecture with full CRUD and entity relationships

#### Learning Objectives
- ✅ Build production-ready 3-tier architecture
- ✅ Implement complete CRUD across all layers
- ✅ Create entity relationships with foreign keys
- ✅ Use navigation properties effectively
- ✅ Apply Code First migrations with relationships
- ✅ Configure cascade delete behavior
- ✅ Design professional REST APIs

#### Key Features
- **Complete Implementation:** All CRUD operations functional
- **Entity Relationships:** Student → Department (FK)
- **Navigation Properties:** Student.Department
- **Full Repository:** Complete StudentRepo with DbContext
- **Complete Service:** All CRUD with AutoMapper
- **API Endpoints:** GET, POST with proper HTTP verbs
- **Migrations:** Complete with relationship setup
- **Database:** TierCF_A (Code First)

#### Technologies
- ASP.NET Core Web API 10.0
- Entity Framework Core 9.0.11
- AutoMapper 14.0.0
- SQL Server
- Code First Migrations
- Cascade Delete

#### Complete Stack
```
API Layer:     StudentController (3 endpoints)
               ↓
BLL Layer:     StudentService (5 CRUD methods + AutoMapper)
               ↓
DAL Layer:     StudentRepo (5 CRUD methods)
               ↓
DbContext:     UMSContext (2 DbSets)
               ↓
Database:      TierCF_A (2 tables with FK)
```

#### Database Schema
```sql
Departments                    Students
├─ Id (PK)                    ├─ Id (PK)
└─ Name                       ├─ Name VARCHAR(100)
                              └─ DeptId (FK → Departments.Id)
                                 └─ ON DELETE CASCADE
```

#### CRUD Operations (All 5)
```csharp
// Repository
GetAll()      → List<Student>
GetAll(id)    → Student
Add(student)  → bool
Update(student) → bool
Delete(id)    → bool

// Service (with AutoMapper)
GetAll()      → List<StudentDTO>
GetAll(id)    → StudentDTO
Add(dto)      → bool
Update(dto)   → bool
Delete(id)    → bool
```

#### What You'll Learn
- Complete 3-tier implementation
- Entity relationships (1-to-many)
- Foreign key constraints
- Navigation properties
- Cascade delete configuration
- Full CRUD implementation
- Production-ready architecture
- Professional API design
- Code First with relationships
- Index creation on foreign keys

---

## 🔄 Progressive Learning Path

### Complexity Progression

```
Lab 6: Foundation
└─ Basic Web API concepts
   └─ HTTP methods, routing, DTOs
      └─ In-memory data

Lab 7: Database Integration
└─ Database First approach
   └─ EF Core scaffolding
      └─ Navigation properties

Lab 8: Advanced EF Core
└─ Code First migrations
   └─ AutoMapper integration
      └─ DTO validation

Lab 9: Architecture Introduction
└─ 3-Tier structure
   └─ Multi-project solution
      └─ Layer separation

Lab 10: Production Ready
└─ Complete implementation
   └─ Entity relationships
      └─ Full CRUD across tiers
```

---

## 📊 Comprehensive Comparison Table

| Feature | Lab 6 | Lab 7 | Lab 8 | Lab 9 | Lab 10 |
|---------|-------|-------|-------|-------|--------|
| **Architecture** | Single Layer | Single Layer | Single Layer | 3-Tier | 3-Tier |
| **Projects** | 1 | 1 | 1 | 3 | 3 |
| **Data Storage** | In-Memory | Database | Database | Database | Database |
| **EF Core** | ❌ None | ✅ Database First | ✅ Code First | ✅ Code First | ✅ Code First |
| **Migrations** | ❌ None | ❌ None | ✅ Yes | ⚠️ Template | ✅ Complete |
| **AutoMapper** | ❌ None | ❌ None | ✅ Yes | ✅ Yes | ✅ Yes |
| **DTOs** | ✅ Basic | ❌ None | ✅ Validated | ✅ Yes | ✅ Yes |
| **Repository** | ❌ None | ⚠️ Basic | ⚠️ Basic | ⚠️ Partial | ✅ Complete |
| **Service Layer** | ❌ None | ❌ None | ❌ None | ⚠️ Partial | ✅ Complete |
| **Relationships** | ❌ None | ✅ Navigation | ✅ Navigation | ❌ None | ✅ FK + Navigation |
| **CRUD** | ✅ All 5 | ✅ All 5 | ✅ All 5 | ⚠️ Read Only | ✅ All 5 |
| **Validation** | ❌ None | ❌ None | ✅ Yes | ❌ None | ⚠️ Basic |
| **Status** | Complete | Complete | Complete | Template | Complete |
| **Best For** | Learning API | DB Integration | Migrations | Architecture | Production |

---

## 🎓 Skills Progression Matrix

### Lab 6 Skills
- [x] Create Web API project
- [x] Implement HTTP methods
- [x] Use route attributes
- [x] Create DTOs
- [x] Handle requests/responses
- [x] Test APIs

### Lab 7 Skills (Lab 6 +)
- [x] Connect to SQL Server
- [x] Scaffold DbContext
- [x] Use navigation properties
- [x] Query with LINQ
- [x] Eager loading with Include()
- [x] Manage connection strings

### Lab 8 Skills (Lab 7 +)
- [x] Design entities with annotations
- [x] Create migrations
- [x] Apply migrations
- [x] Configure AutoMapper
- [x] Validate DTOs
- [x] Handle validation errors
- [x] Version control database schema

### Lab 9 Skills (Lab 8 +)
- [x] Design 3-tier architecture
- [x] Create multi-project solutions
- [x] Configure project references
- [x] Implement repository pattern
- [x] Build service layer
- [x] Configure DI across layers
- [x] Separate concerns

### Lab 10 Skills (Lab 9 +)
- [x] Create entity relationships
- [x] Configure foreign keys
- [x] Use navigation properties
- [x] Configure cascade delete
- [x] Complete CRUD in all layers
- [x] Professional API design
- [x] Production-ready code

---

## 🚀 Quick Start Guide

### Prerequisites

**Required Software:**
- .NET 10.0 SDK or later
- Visual Studio 2022 / VS Code / Rider
- SQL Server 2019+ or LocalDB
- SQL Server Management Studio (optional)
- Postman or similar API testing tool

**Knowledge Prerequisites:**
- C# basics
- Object-oriented programming
- HTTP protocol fundamentals
- SQL basics
- REST API concepts

### Getting Started with Any Lab

**1. Navigate to Lab Directory:**
```powershell
cd "d:\University\Semester 9\ADVANCED PROGRAMMING WITH .NET\Lab\.NET Core\Lab6"
# Replace Lab6 with Lab7, Lab8, Lab9, or Lab10
```

**2. Open README:**
```powershell
# Each lab has detailed README with specific instructions
notepad README.md
```

**3. Update Connection String (Lab 7, 8, 9, 10):**
```json
// In appsettings.json
"ConnectionStrings": {
  "DbConn": "data source=YOUR_SERVER_NAME; initial catalog=DATABASE_NAME; ..."
}
```

**4. Restore and Build:**
```powershell
dotnet restore
dotnet build
```

**5. Run Migrations (Lab 8, 10):**
```powershell
dotnet ef database update
```

**6. Run Application:**
```powershell
dotnet run
```

**7. Test APIs:**
```
https://localhost:5001/swagger
```

---

## 📚 Key Concepts Covered

### 1. ASP.NET Core Web API
- Controllers and actions
- Routing and route parameters
- HTTP methods (GET, POST, PUT, DELETE)
- Status codes (200, 201, 400, 404, 500)
- Model binding
- Content negotiation
- OpenAPI/Swagger documentation

### 2. Entity Framework Core
- **Database First:** Scaffold from existing database
- **Code First:** Create database from code
- DbContext configuration
- Entity configurations
- LINQ to Entities
- Change tracking
- SaveChanges()

### 3. Migrations
- Add-Migration command
- Update-Database command
- Migration files structure
- Up/Down methods
- Schema versioning
- Migration history
- Rollback strategies

### 4. Repository Pattern
- Data access abstraction
- CRUD operations encapsulation
- DbContext injection
- Testability improvement
- Query centralization

### 5. Service Layer Pattern
- Business logic separation
- DTO transformations
- Repository orchestration
- Transaction management
- Business rules enforcement

### 6. AutoMapper
- Object-to-object mapping
- Configuration profiles
- Bidirectional mapping
- Collection mapping
- Projection mapping

### 7. 3-Tier Architecture
- **Presentation Layer:** Controllers, API endpoints
- **Business Logic Layer:** Services, DTOs, business rules
- **Data Access Layer:** Repositories, entities, DbContext
- Dependency flow
- Layer communication
- Separation of concerns

### 8. Entity Relationships
- One-to-many relationships
- Foreign keys
- Navigation properties
- Eager loading (Include)
- Lazy loading
- Cascade delete

### 9. Data Transfer Objects (DTOs)
- API contracts
- Data encapsulation
- Validation attributes
- Mapping strategies
- Security benefits

### 10. Dependency Injection
- Service registration
- Constructor injection
- Lifetime management (Scoped)
- Cross-layer DI
- Interface-based design

---

## 🎯 Recommended Learning Order

### For Complete Beginners
```
1. Lab 6  → Understand Web API fundamentals (2-3 days)
   ├─ HTTP methods
   ├─ Routing
   └─ DTOs

2. Lab 7  → Learn database integration (2-3 days)
   ├─ EF Core basics
   ├─ Scaffolding
   └─ Navigation

3. Lab 8  → Master Code First (3-4 days)
   ├─ Migrations
   ├─ AutoMapper
   └─ Validation

4. Lab 9  → Understand architecture (2-3 days)
   ├─ Layer separation
   ├─ Multi-project
   └─ Repository pattern

5. Lab 10 → Build production apps (3-4 days)
   ├─ Complete CRUD
   ├─ Relationships
   └─ Best practices
```

### For Experienced Developers
```
1. Lab 6  → Quick review (1 day)
2. Lab 7  → Database First approach (1 day)
3. Lab 8  → Code First + AutoMapper (1-2 days)
4. Lab 9  → Architecture patterns (1 day)
5. Lab 10 → Production implementation (2 days)
```

---

## 💡 Best Practices Learned

### API Design
✅ Use appropriate HTTP methods  
✅ Return correct status codes  
✅ Use DTOs for API contracts  
✅ Implement proper error handling  
✅ Version your APIs  
✅ Document with OpenAPI/Swagger

### Entity Framework
✅ Use async operations  
✅ Eager load related data when needed  
✅ Avoid N+1 query problems  
✅ Use proper data annotations  
✅ Configure relationships explicitly  
✅ Handle migrations properly

### Architecture
✅ Separate concerns by layer  
✅ Use dependency injection  
✅ Program to interfaces  
✅ Keep controllers thin  
✅ Put business logic in services  
✅ Abstract data access in repositories

### Code Quality
✅ Follow naming conventions  
✅ Use meaningful variable names  
✅ Add XML documentation  
✅ Validate input data  
✅ Handle exceptions gracefully  
✅ Write testable code

---

## 🔧 Common Tools & Commands

### .NET CLI Commands
```powershell
# Create new Web API project
dotnet new webapi -n ProjectName

# Add NuGet packages
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package AutoMapper

# Build project
dotnet build

# Run project
dotnet run

# Restore packages
dotnet restore
```

### EF Core Commands
```powershell
# Scaffold from database (Database First)
dotnet ef dbcontext scaffold "ConnectionString" Microsoft.EntityFrameworkCore.SqlServer -o Models

# Create migration (Code First)
dotnet ef migrations add MigrationName

# Apply migrations
dotnet ef database update

# Remove last migration
dotnet ef migrations remove

# List migrations
dotnet ef migrations list
```

### Testing APIs
```powershell
# Using PowerShell
Invoke-RestMethod -Uri "https://localhost:5001/api/student" -Method Get

# Using curl
curl https://localhost:5001/api/student

# Using Postman (GUI tool)
# Import OpenAPI definition from /swagger/v1/swagger.json
```

---

## 📊 Lab Statistics

| Lab | Files | Lines of Code | API Endpoints | Entities | DTOs | Projects |
|-----|-------|---------------|---------------|----------|------|----------|
| **Lab 6** | ~10 | ~400 | 7 | 2 | 1 | 1 |
| **Lab 7** | ~12 | ~600 | 8 | 2 | 0 | 1 |
| **Lab 8** | ~15 | ~800 | 8 | 2 | 2 | 1 |
| **Lab 9** | ~12 | ~200 | 1 | 1 | 1 | 3 |
| **Lab 10** | ~15 | ~500 | 3 | 2 | 2 | 3 |
| **Total** | **64** | **2,500+** | **27** | **9** | **6** | **9** |

---

## 🎓 Learning Outcomes

By completing all labs in this series, you will be able to:

### Technical Skills
✅ Build RESTful APIs with ASP.NET Core  
✅ Use Entity Framework Core (Database First & Code First)  
✅ Create and apply database migrations  
✅ Implement repository and service layer patterns  
✅ Design and implement 3-tier architecture  
✅ Use AutoMapper for object mapping  
✅ Validate data with data annotations  
✅ Manage entity relationships and foreign keys  
✅ Configure dependency injection  
✅ Test APIs with various tools

### Architectural Skills
✅ Design layered applications  
✅ Implement separation of concerns  
✅ Create multi-project solutions  
✅ Manage project dependencies  
✅ Apply SOLID principles  
✅ Use design patterns effectively

### Professional Skills
✅ Read and write technical documentation  
✅ Debug and troubleshoot issues  
✅ Use version control with migrations  
✅ Write production-ready code  
✅ Follow best practices and conventions  
✅ Test and validate implementations

---

## 🐛 Common Issues & Solutions

### Issue: Connection Failed
**Labs Affected:** 7, 8, 9, 10  
**Solution:**
```json
// Update appsettings.json with your SQL Server instance
"ConnectionStrings": {
  "DbConn": "data source=YOUR_SERVER_NAME; ..."
}
```

### Issue: Migration Commands Fail
**Labs Affected:** 8, 10  
**Solution:**
```powershell
# For multi-project solutions, specify startup project
dotnet ef migrations add MigrationName --startup-project ..\AppLayerAPI
dotnet ef database update --startup-project ..\AppLayerAPI
```

### Issue: AutoMapper Not Configured
**Labs Affected:** 8, 9, 10  
**Solution:**
```csharp
// Register AutoMapper in Program.cs
builder.Services.AddAutoMapper(typeof(Program));

// Or manually configure
var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<Entity, DTO>().ReverseMap();
});
```

### Issue: Foreign Key Constraint Violation
**Labs Affected:** 7, 10  
**Solution:**
- Ensure parent record exists before creating child
- Check foreign key values are valid
- Insert parent records first

### Issue: Navigation Property is Null
**Labs Affected:** 7, 8, 10  
**Solution:**
```csharp
// Use eager loading
var students = db.Students
    .Include(s => s.Department)
    .ToList();
```

---

## 📖 Additional Resources

### Official Documentation
- [ASP.NET Core Web API](https://docs.microsoft.com/en-us/aspnet/core/web-api/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [EF Core Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [Dependency Injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [AutoMapper](https://docs.automapper.org/en/stable/)

### Recommended Books
- **ASP.NET Core in Action** by Andrew Lock
- **Entity Framework Core in Action** by Jon P. Smith
- **Clean Architecture** by Robert C. Martin
- **Design Patterns** by Gang of Four

### Video Tutorials
- Microsoft Learn (learn.microsoft.com)
- Pluralsight .NET Courses
- YouTube: Nick Chapsas, Tim Corey
- Channel 9 Microsoft

### Community
- Stack Overflow (.net, asp.net-core, entity-framework-core tags)
- Reddit: r/dotnet, r/csharp
- .NET Foundation Forums
- GitHub Discussions

---

## 🎯 Next Steps

### After Completing All Labs

**1. Enhance Lab 10:**
- Add authentication (JWT)
- Implement authorization
- Add logging (Serilog)
- Create unit tests
- Add API versioning
- Implement HATEOAS
- Add pagination
- Create comprehensive error handling

**2. Build Your Own Project:**
- Design a real-world application
- Apply 3-tier architecture
- Implement complete CRUD
- Add authentication/authorization
- Deploy to Azure/AWS

**3. Explore Advanced Topics:**
- Microservices architecture
- CQRS pattern
- Event sourcing
- Message queues (RabbitMQ)
- Docker containerization
- Kubernetes orchestration

**4. Learn Testing:**
- Unit testing (xUnit, NUnit)
- Integration testing
- Mocking (Moq)
- Test-driven development (TDD)

**5. DevOps & Deployment:**
- CI/CD pipelines
- Azure DevOps
- GitHub Actions
- Docker deployment
- Cloud hosting (Azure, AWS)

---

## 📊 Project Timeline

| Week | Labs | Focus | Time Estimate |
|------|------|-------|---------------|
| **Week 1** | Lab 6 | Web API Basics | 2-3 days |
| **Week 2** | Lab 7 | Database First | 2-3 days |
| **Week 3** | Lab 8 | Code First + AutoMapper | 3-4 days |
| **Week 4** | Lab 9 | 3-Tier Architecture | 2-3 days |
| **Week 5** | Lab 10 | Complete Implementation | 3-4 days |
| **Week 6** | Review | Practice & Enhancement | 5-7 days |

**Total Estimated Time:** 4-6 weeks (part-time study)

---

## 🏆 Certification & Skills

### Skills Gained
- ASP.NET Core Web API Development
- Entity Framework Core Mastery
- Architectural Pattern Implementation
- Database Design & Management
- RESTful API Design
- Object-Relational Mapping
- Dependency Injection
- Test-Driven Development
- Version Control (Migrations)
- Production Deployment

### Relevant Certifications
- Microsoft Certified: Azure Developer Associate
- Microsoft Certified: .NET Developer
- AWS Certified Developer - Associate

---

## 👨‍💻 Author & Credits

**Institution:** American International University - Bangladesh (AIUB)  
**Department:** Computer Science & Engineering  
**Course Code:** CSE-XXXX  
**Instructor:** [Instructor Name]  
**Semester:** 9 (Spring 2026)

**Lab Series Created:** January 2026  
**Last Updated:** January 23, 2026  
**Documentation Status:** Complete

---

## 📄 License

This lab series and all associated materials are created for educational purposes as part of university coursework at AIUB.

**Usage Guidelines:**
- ✅ Study and learn from the code
- ✅ Modify for personal learning
- ✅ Share with classmates
- ❌ Do not plagiarize
- ❌ Do not redistribute commercially

---

## 🔗 Quick Navigation

- [Lab 6 - Web API Fundamentals](Lab6/README.md)
- [Lab 7 - Database First](Lab7/README.md)
- [Lab 8 - Code First](Lab8/README.md)
- [Lab 9 - 3-Tier Introduction](Lab9/README.md)
- [Lab 10 - Complete 3-Tier](Lab10/README.md)

---

## 📞 Support & Feedback

**Questions?** Review individual lab README files for detailed instructions.

**Issues?** Check the troubleshooting section in each lab.

**Suggestions?** Contact course instructor or teaching assistants.

---

**Happy Learning! 🚀**

**Master ASP.NET Core, build production-ready APIs, and become a proficient .NET developer!**

---

**Total Labs:** 5  
**Total Documentation:** 10,000+ lines  
**Total Code:** 2,500+ lines  
**Coverage:** Beginner → Production Ready  
**Status:** ✅ Complete Series

---

*Last Updated: January 23, 2026 - All labs documented and ready for learning!*
