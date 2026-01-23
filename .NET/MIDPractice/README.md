# Midterm Practice Projects

## 📋 Overview
This folder contains comprehensive practice projects designed for midterm examination preparation in the **Advanced Programming with .NET** course. These projects consolidate concepts learned from Labs 1-4, providing hands-on experience with real-world ASP.NET MVC applications featuring complete CRUD operations, Entity Framework integration, and professional UI design.

## 🎯 Purpose
**Midterm Examination Preparation** - These projects serve as:
- Comprehensive review of course concepts
- Practical application of learned skills
- Full-stack development practice
- Preparation for exam scenarios
- Portfolio-ready applications

## 📁 Projects

### 1. [SuperShop Inventory System](./SuperShopInventorySystem/)
**Type:** Product & Inventory Management System  
**Complexity:** ⭐⭐ Intermediate

**Description:**  
A complete inventory management system for a retail super shop that manages products and categories with full CRUD operations.

**Key Features:**
- ✅ Product registration with category assignment
- ✅ Complete product listing with navigation
- ✅ Product details view
- ✅ Update product information
- ✅ Delete products from inventory
- ✅ Category management with dropdown selection
- ✅ Entity Framework Database First approach
- ✅ One-to-Many relationships (Categories → Products)

**Concepts Covered:**
- MVC architecture and routing
- Entity Framework Database First
- CRUD operations (Create, Read, Update, Delete)
- Navigation properties
- ViewBag for dynamic data
- TempData for success messages
- Form handling with GET/POST pattern
- Model binding

**Database Tables:**
- `Categories` (ID, Name)
- `Products` (ID, Name, Price, Category_ID, Quantity)

**Technologies:**
- ASP.NET MVC 5
- Entity Framework 5.0
- SQL Server
- Bootstrap
- jQuery

---

### 2. [BFU Student Management System](./BFU/)
**Type:** Educational Institution Management System  
**Complexity:** ⭐⭐⭐ Intermediate-Advanced

**Description:**  
A robust web-based student management system for Bright Future University (BFU) that streamlines student registration, department management, and academic record keeping.

**Key Features:**
- ✅ Student registration with complete information
- ✅ Student list with search functionality
- ✅ Student details view
- ✅ Update student records
- ✅ Delete student records with confirmation
- ✅ Department management
- ✅ Responsive Bootstrap 5 design
- ✅ Form validation
- ✅ Professional UI/UX

**Concepts Covered:**
- Advanced MVC patterns
- Entity Framework with relationships
- Search and filter functionality
- Form validation (client and server-side)
- Responsive web design
- Bootstrap 5 integration
- jQuery validation
- Professional UI design patterns

**Database Tables:**
- `Students` (ID, Name, Email, Phone, Department_ID)
- `Departments` (ID, Name)

**Technologies:**
- ASP.NET MVC 5.2.9
- Entity Framework 5.0
- .NET Framework 4.8.1
- Bootstrap 5.2.3
- jQuery 3.7.0
- jQuery Validation 1.19.5

**Real-World Scenario:**  
Simulates a university admin portal where administrators manage student enrollments, department assignments, and academic records efficiently.

---

## 🎓 Learning Objectives

### From Labs 1-4 Integration

**Lab 1 Concepts (MVC Fundamentals):**
- ✅ Controllers and Actions
- ✅ Views with Razor syntax
- ✅ Models
- ✅ Routing
- ✅ ViewBag usage

**Lab 2 Concepts (Validation):**
- ✅ Form validation
- ✅ ModelState validation
- ✅ Error handling
- ✅ Client-side validation

**Lab 3 Concepts (Entity Framework):**
- ✅ Database First approach
- ✅ Entity Data Models
- ✅ DbContext and DbSet
- ✅ Navigation properties
- ✅ One-to-Many relationships
- ✅ LINQ queries

**Lab 4 Concepts (Advanced Patterns):**
- ✅ Complete CRUD operations
- ✅ Data management patterns
- ✅ TempData for messages
- ✅ Form handling patterns
- ✅ Professional application structure

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.8+
- SQL Server (any edition)
- SQL Server Management Studio (optional)
- Basic understanding of:
  - C# programming
  - ASP.NET MVC
  - Entity Framework
  - SQL

### Quick Start Guide

#### 1. SuperShop Inventory System
```bash
cd SuperShopInventorySystem
# Open SuperShopInventorySystem.sln in Visual Studio
# Update connection string in Web.config
# Create database using SQL scripts in README
# Build and Run (F5)
```

#### 2. BFU Student Management System
```bash
cd BFU
# Open BFU.sln in Visual Studio
# Update connection string in Web.config
# Create database using SQL scripts in README
# Build and Run (F5)
```

### Common Setup Steps

1. **Open Project**
   - Navigate to project folder
   - Double-click `.sln` file
   - Visual Studio will open the project

2. **Restore NuGet Packages**
   - Right-click solution → Restore NuGet Packages
   - Or let Visual Studio restore automatically

3. **Configure Database**
   - Create database in SQL Server
   - Execute SQL scripts (found in each project's README)
   - Update connection string in `Web.config`

4. **Build & Run**
   - Press `Ctrl + Shift + B` to build
   - Press `F5` to run
   - Application opens in browser

## 📊 Project Comparison

| Feature | SuperShop Inventory | BFU Student Management |
|---------|-------------------|----------------------|
| **Complexity** | Intermediate | Intermediate-Advanced |
| **Tables** | 2 (Categories, Products) | 2 (Departments, Students) |
| **Main Entity** | Products | Students |
| **CRUD Operations** | ✅ Full | ✅ Full |
| **Search** | ⚠️ UI Only | ✅ Implemented |
| **Validation** | Basic | Advanced |
| **UI Framework** | Bootstrap | Bootstrap 5 |
| **Design** | Functional | Professional |
| **Real-world Scenario** | Retail Shop | University Admin |

## 🎯 Midterm Exam Topics Covered

### Core ASP.NET MVC (40%)
- ✅ MVC architecture pattern
- ✅ Controllers and action methods
- ✅ Views and Razor syntax
- ✅ Models and data binding
- ✅ Routing (convention-based)
- ✅ ViewBag and TempData
- ✅ Form handling (GET/POST)

### Entity Framework (30%)
- ✅ Database First approach
- ✅ Entity Data Models (EDM)
- ✅ DbContext configuration
- ✅ DbSet usage
- ✅ Navigation properties
- ✅ Relationships (One-to-Many)
- ✅ LINQ to Entities

### CRUD Operations (20%)
- ✅ Create (INSERT)
- ✅ Read (SELECT)
- ✅ Update (UPDATE)
- ✅ Delete (DELETE)
- ✅ Find operations
- ✅ List operations

### Additional Topics (10%)
- ✅ Client-side validation
- ✅ Server-side validation
- ✅ Bootstrap integration
- ✅ jQuery usage
- ✅ Responsive design
- ✅ Error handling

## 📝 Exam Preparation Checklist

### Technical Skills
- [ ] Can create ASP.NET MVC project from scratch
- [ ] Can set up Entity Framework Database First
- [ ] Can implement full CRUD operations
- [ ] Can create relationships between entities
- [ ] Can use navigation properties
- [ ] Can handle forms with GET/POST
- [ ] Can use ViewBag and TempData
- [ ] Can configure connection strings
- [ ] Can use LINQ queries

### Conceptual Understanding
- [ ] Understand MVC pattern
- [ ] Know difference between ViewBag, ViewData, TempData
- [ ] Understand Entity Framework lifecycle
- [ ] Know when to use Find() vs Where()
- [ ] Understand navigation properties
- [ ] Know model binding process
- [ ] Understand routing conventions

### Practical Skills
- [ ] Can debug ASP.NET MVC applications
- [ ] Can read and fix error messages
- [ ] Can create and modify views
- [ ] Can write LINQ queries
- [ ] Can update database schemas
- [ ] Can test CRUD operations

## 🔍 Common Exam Scenarios

### Scenario 1: Create New Entity
**Task:** Add a new entity to existing project  
**Projects to Practice:** Both projects  
**Skills Required:**
- Create database table
- Update EDM
- Create controller actions
- Create views

### Scenario 2: Add Relationship
**Task:** Create relationship between entities  
**Projects to Practice:** Both projects  
**Skills Required:**
- Foreign key configuration
- Navigation properties
- Update queries
- Modify views

### Scenario 3: Implement Search
**Task:** Add search functionality  
**Projects to Practice:** BFU (already implemented)  
**Skills Required:**
- LINQ Where clause
- Form handling
- Query parameters
- View updates

### Scenario 4: Add Validation
**Task:** Implement form validation  
**Projects to Practice:** Both projects  
**Skills Required:**
- Data annotations
- ModelState validation
- Error display
- Client-side validation

## 💡 Tips for Success

### Before the Exam
1. ✅ Practice both projects multiple times
2. ✅ Understand every line of code
3. ✅ Review controller actions
4. ✅ Study Entity Framework patterns
5. ✅ Memorize common LINQ queries
6. ✅ Practice database setup
7. ✅ Review error handling

### During the Exam
1. ✅ Read requirements carefully
2. ✅ Plan before coding
3. ✅ Test each feature after implementation
4. ✅ Check connection strings
5. ✅ Verify database tables
6. ✅ Test CRUD operations
7. ✅ Handle errors gracefully

### Common Mistakes to Avoid
- ❌ Forgetting to update connection string
- ❌ Missing navigation properties
- ❌ Incorrect foreign key names
- ❌ Not checking ModelState.IsValid
- ❌ Forgetting to SaveChanges()
- ❌ Wrong routing patterns
- ❌ Not testing before submission

## 📚 Reference Materials

### Quick Reference

**CRUD Operations:**
```csharp
// CREATE
db.Entity.Add(entity);
db.SaveChanges();

// READ
var list = db.Entity.ToList();
var item = db.Entity.Find(id);

// UPDATE
var entity = db.Entity.Find(id);
db.Entry(entity).CurrentValues.SetValues(updatedEntity);
db.SaveChanges();

// DELETE
var entity = db.Entity.Find(id);
db.Entity.Remove(entity);
db.SaveChanges();
```

**Navigation Properties:**
```csharp
// One-to-Many
public class Category {
    public virtual ICollection<Product> Products { get; set; }
}

public class Product {
    public virtual Category Category { get; set; }
}
```

**ViewBag vs TempData:**
```csharp
// ViewBag - One request only
ViewBag.Message = "Hello";

// TempData - Survives redirect
TempData["Message"] = "Success!";
```

### Documentation Links
- [ASP.NET MVC Documentation](https://docs.microsoft.com/en-us/aspnet/mvc/)
- [Entity Framework Documentation](https://docs.microsoft.com/en-us/ef/)
- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.2/)

## 🎓 Practice Exercises

### Exercise 1: Extend SuperShop
1. Add supplier management
2. Create supplier-product relationship
3. Add stock alert for low inventory
4. Implement sales tracking

### Exercise 2: Enhance BFU
1. Add course management
2. Create student-course enrollment
3. Add grade tracking
4. Implement attendance system

### Exercise 3: Combined Project
1. Create library management system
2. Implement book borrowing
3. Add member management
4. Track due dates

## 🔗 Project Structure

```
MIDPractice/
├── SuperShopInventorySystem/
│   ├── SuperShopInventorySystem/        # Main project
│   ├── SuperShopInventorySystem.sln     # Solution file
│   └── README.md                        # Project documentation
├── BFU/
│   ├── BFU/                            # Main project
│   ├── BFU.sln                         # Solution file
│   └── README.md                       # Project documentation
└── README.md                           # This file
```

## 📊 Statistics

| Metric | SuperShop | BFU | Total |
|--------|-----------|-----|-------|
| Controllers | 1 | 2+ | 3+ |
| Entity Models | 2 | 2 | 4 |
| Views | 5 | 8+ | 13+ |
| Database Tables | 2 | 2 | 4 |
| CRUD Operations | Full | Full | Full |
| Lines of Code | ~800 | ~1200 | ~2000 |

## 🏆 Success Criteria

### Project Mastery
- [ ] Can run both projects without errors
- [ ] Can explain all CRUD operations
- [ ] Can modify existing features
- [ ] Can add new features
- [ ] Can debug issues independently

### Exam Readiness
- [ ] Completed both projects
- [ ] Practiced all scenarios
- [ ] Reviewed all concepts
- [ ] Tested all features
- [ ] Confident with Entity Framework
- [ ] Confident with MVC pattern

## 🔜 Next Steps

1. **Complete Both Projects**
   - SuperShop Inventory System
   - BFU Student Management System

2. **Practice Modifications**
   - Add new features
   - Modify existing features
   - Create new relationships

3. **Review Concepts**
   - MVC architecture
   - Entity Framework
   - CRUD operations
   - Validation

4. **Take Practice Tests**
   - Timed coding exercises
   - Mock exam scenarios
   - Debug challenges

## 👨‍💻 Author
Created for midterm preparation in Advanced Programming with .NET course, Semester 9

## 📄 License
Educational projects for learning purposes

---

**Course:** Advanced Programming with .NET  
**Purpose:** Midterm Examination Practice  
**Semester:** 9  
**Academic Year:** 2025-2026  
**Status:** ✅ Ready for Practice  
**Last Updated:** January 2026

---

**Note:** These projects are designed to provide comprehensive practice for the midterm examination. Complete both projects, understand all concepts, and practice multiple times for best results. Good luck with your exam! 🎓
