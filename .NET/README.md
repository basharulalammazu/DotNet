# Advanced Programming with .NET - Lab Projects

## 📚 Course Overview
This repository contains all laboratory projects for the **Advanced Programming with .NET** course. Each lab builds upon the previous one, progressively introducing more advanced concepts in ASP.NET MVC development, from basic MVC patterns to complex enterprise-level features.

## 🎯 Course Learning Path

This course takes you through a comprehensive journey of ASP.NET MVC development:

```
Lab 1: MVC Fundamentals → Lab 2: Custom Validation → Lab 3: Entity Framework → Lab 4: DTOs & Security → MIDPractice: Complete Applications
```

## 📋 Lab Projects

### [Lab 1 - ASP.NET MVC Portfolio Application](./Lab%201/)
**Focus:** Introduction to ASP.NET MVC Architecture

**Topics Covered:**
- ✅ MVC Pattern (Model-View-Controller)
- ✅ Controllers and Action Methods
- ✅ Razor Views and Syntax
- ✅ ViewBag for data passing
- ✅ Strongly-typed views
- ✅ Routing basics
- ✅ Bootstrap integration
- ✅ Custom CSS styling

**Project Type:** Portfolio Website  
**Key Features:** Multiple pages, project listing, education display, responsive design

**Technologies:** ASP.NET MVC 5, .NET Framework 4.8, Bootstrap 5, jQuery 3.7.0

**Learning Outcomes:**
- Understanding separation of concerns
- Creating models, views, and controllers
- Passing data between controller and view
- Basic navigation and routing

---

### [Lab 2 - Custom Validation in ASP.NET MVC](./Lab2/)
**Focus:** Advanced Form Validation with Custom Attributes

**Topics Covered:**
- ✅ Custom ValidationAttribute classes
- ✅ Regular expressions for validation
- ✅ ValidationResult and ValidationContext
- ✅ Cross-property validation
- ✅ Server-side validation
- ✅ Error message handling
- ✅ ModelState.IsValid
- ✅ Validation display in views

**Project Type:** Student Registration System  
**Key Features:** Custom name/ID/email validators, pattern matching, validation messages

**Technologies:** ASP.NET MVC 5, .NET Framework 4.8, Custom Validation Attributes, Regex

**Custom Validators Implemented:**
- **NameValidation:** Allows only letters, spaces, dots, and dashes
- **IDValidation:** Enforces specific format (xx-xxxxx-xx)
- **EmailValidation:** Demonstrates cross-property validation

**Learning Outcomes:**
- Creating reusable validation logic
- Understanding ValidationAttribute base class
- Implementing complex validation rules
- Accessing model properties during validation

---

### [Lab 3 - Entity Framework Database First](./Lab3/)
**Focus:** Database Integration with Entity Framework

**Topics Covered:**
- ✅ Entity Framework Database First approach
- ✅ Entity Data Models (EDM)
- ✅ DbContext and DbSet
- ✅ CRUD operations with EF
- ✅ Navigation properties
- ✅ Foreign key relationships
- ✅ LINQ to Entities
- ✅ Connection string configuration
- ✅ TempData for cross-request data

**Project Type:** SuperShop Inventory Management  
**Key Features:** Product management, category system, full CRUD operations

**Technologies:** ASP.NET MVC 5, Entity Framework 5.0, SQL Server, .NET Framework 4.8

**Database Schema:**
- Categories (Id, Name)
- Products (Id, Name, Price, Qty, CId → Categories)
- One-to-Many relationship

**Entity Framework Operations:**
```csharp
// Create
db.Products.Add(product);
db.SaveChanges();

// Read
var products = db.Products.ToList();
var product = db.Products.Find(id);

// Update
product.Name = "Updated";
db.SaveChanges();

// Delete
db.Products.Remove(product);
db.SaveChanges();
```

**Learning Outcomes:**
- Setting up Entity Framework
- Creating EDM from existing database
- Implementing CRUD with EF
- Understanding entity relationships
- Using navigation properties

---

### [Lab 4 - DTOs, AutoMapper, Password Hashing & Advanced Validation](./Lab4/)
**Focus:** Enterprise Patterns and Security

**Topics Covered:**
- ✅ Data Transfer Objects (DTOs)
- ✅ AutoMapper configuration
- ✅ Object-to-object mapping
- ✅ MD5 password hashing
- ✅ Database-aware validation
- ✅ Cross-property validation
- ✅ Separation of concerns
- ✅ Security best practices
- ✅ Complex entity relationships

**Project Type:** Product Delivery System (PDS) with Customer Registration  
**Key Features:** Secure registration, hashed passwords, unique email validation, DTO pattern

**Technologies:** ASP.NET MVC 5, Entity Framework 5.0, AutoMapper, MD5 Hashing, SQL Server

**Database Schema (4 Tables):**
- Customers (Id, Name, Email, Username, Password)
- Products (Id, Name, Qty, Price)
- Orders (Id, Status, Amount, Time, CustomerId)
- OrderDetails (Id, PId, OId, Qty, Price)

**Key Patterns Demonstrated:**

**1. DTO Pattern:**
```csharp
// Entity (Database Model)
public class Customer {
    public int Id { get; set; }
    public string Password { get; set; }
}

// DTO (Presentation Model)
public class CustomerDTO {
    public int Id { get; set; }
    [Required]
    public string Password { get; set; }
    [ConfirmPassword]
    public string ConPass { get; set; }  // Not in database
}
```

**2. AutoMapper:**
```csharp
cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
var customer = mapper.Map<Customer>(customerDTO);
```

**3. Password Hashing:**
```csharp
customer.Password = CreateMD5(customer.Password);
// "myPassword" → "6c9f14e8b2f5e62e..."
```

**4. Database-Aware Validation:**
```csharp
[EmailValidation]  // Queries DB to check if email exists
public string Email { get; set; }
```

**Learning Outcomes:**
- Implementing DTO pattern
- Using AutoMapper for conversions
- Securing passwords with hashing
- Creating database-aware validators
- Implementing cross-property validation
- Understanding separation of concerns

---

### [MIDPractice - Midterm Examination Practice Projects](./MIDPractice/)
**Focus:** Comprehensive Review & Exam Preparation

**Topics Covered:**
- ✅ All Lab 1-4 concepts consolidated
- ✅ Complete CRUD operations
- ✅ Entity Framework Database First
- ✅ Real-world application scenarios
- ✅ Professional UI/UX design
- ✅ Search and filter functionality
- ✅ Form validation patterns
- ✅ Bootstrap responsive design

**Project Type:** Two Complete Web Applications  
**Key Projects:**

**1. SuperShop Inventory System**
- Product and category management
- Full CRUD operations
- One-to-Many relationships
- Inventory tracking

**2. BFU Student Management System**
- Student registration and management
- Department organization
- Search functionality
- Advanced UI with Bootstrap 5
- Professional admin portal design

**Technologies:** ASP.NET MVC 5, Entity Framework 5.0, SQL Server, Bootstrap 5, jQuery 3.7.0

**Purpose:**
- Consolidate all learned concepts
- Practice for midterm examination
- Build portfolio-ready applications
- Demonstrate full-stack development skills

**Learning Outcomes:**
- Implementing complete web applications from scratch
- Integrating all course concepts in real projects
- Building professional user interfaces
- Managing complex database relationships
- Preparing for exam scenarios

---

## 🛠️ Technology Stack

### Frameworks & Libraries
| Technology | Version | Purpose |
|------------|---------|---------|
| ASP.NET MVC | 5 | Web application framework |
| .NET Framework | 4.8 / 4.8.1 | Runtime environment |
| Entity Framework | 5.0 | ORM for database operations |
| Bootstrap | 5 | Responsive UI framework |
| jQuery | 3.7.0 | JavaScript library |
| AutoMapper | Latest | Object-to-object mapping |

### Development Tools
- **IDE:** Visual Studio 2017 or later
- **Database:** SQL Server (any edition)
- **Version Control:** Git
- **Package Manager:** NuGet

## 📊 Progression Matrix

| Concept | Lab 1 | Lab 2 | Lab 3 | Lab 4 | MIDPractice |
|---------|-------|-------|-------|-------|-------------|
| MVC Pattern | ✅ Basic | ✅ | ✅ | ✅ Advanced | ✅ Mastery |
| Models | ✅ Simple | ✅ | ✅ Entities | ✅ DTOs | ✅ Entities |
| Views | ✅ Basic | ✅ | ✅ | ✅ | ✅ Professional |
| Controllers | ✅ Basic | ✅ | ✅ CRUD | ✅ Advanced | ✅ Full CRUD |
| Validation | ❌ | ✅ Custom | ✅ | ✅ DB-Aware | ✅ Mixed |
| Database | ❌ | ❌ | ✅ EF | ✅ EF | ✅ EF |
| Relationships | ❌ | ❌ | ✅ 1-to-Many | ✅ Complex | ✅ 1-to-Many |
| Security | ❌ | ❌ | ❌ | ✅ Hashing | ⚠️ Basic |
| DTOs | ❌ | ❌ | ❌ | ✅ | ❌ |
| AutoMapper | ❌ | ❌ | ❌ | ✅ | ❌ |
| Search | ❌ | ❌ | ❌ | ❌ | ✅ |
| UI/UX | ✅ Basic | ✅ | ✅ | ✅ | ✅ Advanced |

## 🎓 Key Concepts Across Labs

### 1. MVC Architecture
- **Separation of Concerns:** Models, Views, Controllers each have distinct responsibilities
- **Routing:** URL mapping to controller actions
- **Action Methods:** Handle HTTP requests and return results

### 2. Data Management
- **ViewBag/ViewData:** Temporary data storage (Lab 1)
- **Strongly-typed Views:** Type-safe data binding (Lab 1+)
- **Entity Framework:** ORM for database operations (Lab 3+)
- **DTOs:** Separation between domain and presentation (Lab 4)

### 3. Validation
- **Built-in Attributes:** Required, StringLength, Range (All Labs)
- **Custom Validators:** ValidationAttribute inheritance (Lab 2+)
- **Cross-property Validation:** Accessing other properties (Lab 2, Lab 4)
- **Database-aware Validation:** Real-time DB checks (Lab 4)

### 4. Security
- **Password Hashing:** One-way encryption (Lab 4)
- **Validation:** Input sanitization (Lab 2+)
- **ModelState:** Server-side validation (Lab 2+)

### 5. Database Patterns
- **Database First:** Design DB, generate models (Lab 3, Lab 4)
- **Navigation Properties:** Entity relationships (Lab 3+)
- **LINQ to Entities:** Query databases (Lab 3+)
- **CRUD Operations:** Create, Read, Update, Delete (Lab 3+)

## 🚀 Getting Started

### Prerequisites
1. **Visual Studio 2017+** (Community Edition is free)
2. **SQL Server** (Express Edition or LocalDB)
3. **.NET Framework 4.8+**
4. **SQL Server Management Studio** (optional, for database management)

### Setup Instructions

1. **Clone Repository**
   ```bash
   cd "d:\University\Semester 9\ADVANCED PROGRAMMING WITH .NET\Lab\.NET"
   ```

2. **For Each Lab:**
   - Navigate to the lab folder
   - Open the `.sln` file in Visual Studio
   - Restore NuGet packages (automatic)
   - Update database connection strings (Lab 3, Lab 4)
   - Build solution (`Ctrl + Shift + B`)
   - Run (`F5`)

3. **Database Setup (Lab 3 & Lab 4):**
   - Execute SQL scripts from lab READMEs
   - Update connection string in `Web.config`
   - Test database connectivity

## 📝 Lab Recommendations

### Start Here (Beginners)
**Lab 1** → Learn MVC basics, routing, and views

### Next Steps
**Lab 2** → Master custom validation and form handling

### Database Integration
**Lab 3** → Understand Entity Framework and CRUD operations

### Advanced Concepts
**Lab 4** → Implement enterprise patterns (DTOs, AutoMapper, Security)

### Exam Preparation
**MIDPractice** → Build complete applications, consolidate all concepts, prepare for midterm

## 🔍 Common Patterns Across Labs

### Controller Actions
```csharp
// GET - Display form
[HttpGet]
public ActionResult Action()
{
    return View(new Model());
}

// POST - Process form
[HttpPost]
public ActionResult Action(Model model)
{
    if (ModelState.IsValid)
    {
        // Process data
        return RedirectToAction("Success");
    }
    return View(model);
}
```

### View Structure
```cshtml
@model ModelType

@{
    ViewBag.Title = "Page Title";
}

<h2>@ViewBag.Title</h2>

<form method="post">
    @Html.ValidationSummary()
    
    <!-- Form fields -->
    
    <input type="submit" value="Submit" />
</form>
```

### Entity Framework Pattern
```csharp
public class Controller : Controller
{
    DbContextClass db = new DbContextClass();
    
    public ActionResult List()
    {
        var items = db.Items.ToList();
        return View(items);
    }
}
```

## 📚 Additional Resources

### Official Documentation
- [ASP.NET MVC Documentation](https://docs.microsoft.com/en-us/aspnet/mvc/)
- [Entity Framework Documentation](https://docs.microsoft.com/en-us/ef/)
- [AutoMapper Documentation](https://docs.automapper.org/)

### Recommended Reading
- **Pro ASP.NET MVC 5** by Adam Freeman
- **Entity Framework Core in Action** by Jon P Smith
- **C# in Depth** by Jon Skeet

### Online Resources
- [Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/)
- [Stack Overflow](https://stackoverflow.com/questions/tagged/asp.net-mvc)
- [Pluralsight](https://www.pluralsight.com/) - ASP.NET MVC courses

## 🎯 Learning Outcomes

By completing all four labs, students will be able to:

✅ Design and implement MVC applications  
✅ Create custom validation logic  
✅ Integrate databases using Entity Framework  
✅ Implement CRUD operations  
✅ Use DTOs for separation of concerns  
✅ Map objects with AutoMapper  
✅ Implement secure password storage  
✅ Create database-aware validations  
✅ Work with complex entity relationships  
✅ Apply enterprise design patterns  
✅ Build secure web applications  
✅ Debug and troubleshoot MVC applications  

## 🔜 Future Topics

Potential extensions and advanced topics:
- Authentication & Authorization (Identity Framework)
- API Development (Web API)
- Asynchronous Programming (async/await)
- Dependency Injection
- Unit Testing
- Code First Migrations
- Repository Pattern
- SOLID Principles
- Logging and Error Handling
- Performance Optimization

## 📊 Project Statistics

| Lab | Files | Lines of Code | Complexity | Projects |
|-----|-------|---------------|------------|----------|
| Lab 1 | ~30 | ~1,200 | ⭐ Beginner | 1 |
| Lab 2 | ~35 | ~1,500 | ⭐⭐ Intermediate | 1 |
| Lab 3 | ~40 | ~1,800 | ⭐⭐ Intermediate | 1 |
| Lab 4 | ~50 | ~2,500 | ⭐⭐⭐ Advanced | 1 |
| MIDPractice | ~60 | ~2,000 | ⭐⭐⭐ Advanced | 2 |
| **Total** | **~215** | **~9,000** | **Mixed** | **6** |

## 🏆 Best Practices Demonstrated

### Code Organization
- Separation of concerns (MVC pattern)
- Folder structure conventions
- Naming conventions

### Data Handling
- Strongly-typed views
- Model validation
- DTOs for data transfer
- Entity relationships

### Security
- Password hashing
- Input validation
- SQL injection prevention (EF)
- Over-posting prevention (DTOs)

### Performance
- Eager loading (Include)
- Lazy loading (virtual properties)
- Efficient queries (LINQ)

## 🐛 Common Issues & Solutions

### Issue: Connection String Errors
**Solution:** Update `Web.config` with correct SQL Server instance name

### Issue: NuGet Package Errors
**Solution:** Restore packages via Package Manager Console or Visual Studio

### Issue: Entity Framework Not Found
**Solution:** Install via NuGet: `Install-Package EntityFramework`

### Issue: AutoMapper Configuration
**Solution:** Configure mapping before first use in controller

### Issue: Validation Not Working
**Solution:** Ensure `ModelState.IsValid` is checked before processing

## 👨‍💻 Contributors

**Course:** Advanced Programming with .NET  
**Institution:** American International University - Bangladesh(AIUB) 
**Academic Year:** 2025-2026

## 📄 License

These projects are created for educational purposes as part of university coursework.

---

## 🗂️ Repository Structure

```
.NET/
├── Lab 1/                      # MVC Fundamentals
│   └── README.md              # Detailed lab documentation
├── Lab2/                       # Custom Validation
│   └── README.md
├── Lab3/                       # Entity Framework
│   └── README.md
├── Lab4/                       # DTOs & Security
│   └── README.md
├── MIDPractice/               # Midterm practice materials
└── README.md                  # This file (Overview)
```

---

**Last Updated:** January 2026  
**Status:** ✅ All Labs Complete

For detailed information about each lab, please refer to the individual README files in each lab folder.
