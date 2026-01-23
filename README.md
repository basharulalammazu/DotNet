# ADVANCED PROGRAMMING WITH .NET

Course: **ADVANCED PROGRAMMING WITH .NET**  
Instructor: **TANVIR AHMED**  
Institution: **American International University - Bangladesh (AIUB)**  
Semester: **9** (Spring 2026)

---

## 📚 Repository Overview

This repository contains comprehensive lab work for the **Advanced Programming with .NET** course, covering both traditional **ASP.NET (.NET Framework)** and modern **ASP.NET Core** technologies. The labs progress from basic MVC concepts to production-ready 3-tier architectures with Entity Framework Core.

### 📁 Repository Structure

```
Lab/
├── .NET/                    # ASP.NET Framework Labs (MVC)
│   ├── Lab 1/              # Introduction to ASP.NET MVC
│   ├── Lab2/               # MVC Controllers & Views
│   ├── Lab3/               # Forms & Data Handling
│   ├── Lab4/               # Advanced MVC Features
│   └── MIDPractice/        # Mid-term preparation
│
├── .NET Core/              # ASP.NET Core Labs (Web API)
│   ├── Lab6/               # Web API Fundamentals
│   ├── Lab7/               # EF Core Database First
│   ├── Lab8/               # EF Core Code First
│   ├── Lab9/               # 3-Tier Architecture Intro
│   └── Lab10/              # Complete 3-Tier with Relations
│
└── README.md               # This file
```

---

## 🎯 Learning Paths

### Path 1: ASP.NET Framework (.NET Folder)
**Focus:** Traditional MVC web applications with Razor views  
**Technology:** ASP.NET MVC, .NET Framework, Razor, Entity Framework (optional)

**Topics Covered:**
- ✅ MVC Pattern (Model-View-Controller)
- ✅ Controllers and Action Results
- ✅ Razor Views and Layouts
- ✅ Form Handling and Validation
- ✅ Routing and URL patterns
- ✅ Partial Views and View Components
- ✅ State Management (Session, TempData)

**Best For:** Understanding traditional web application architecture

[→ View .NET Framework Labs README](.NET/README.md)

---

### Path 2: ASP.NET Core (.NET Core Folder)
**Focus:** Modern REST APIs with Entity Framework Core  
**Technology:** ASP.NET Core Web API, EF Core, AutoMapper, 3-Tier Architecture

**Topics Covered:**
- ✅ RESTful API Design
- ✅ Entity Framework Core (Database First & Code First)
- ✅ Code First Migrations
- ✅ DTOs and AutoMapper
- ✅ Repository Pattern
- ✅ Service Layer Pattern
- ✅ 3-Tier Architecture
- ✅ Entity Relationships and Foreign Keys

**Best For:** Building modern, scalable backend APIs

[→ View ASP.NET Core Labs README](.NET Core/README.md)

---

## 📊 Quick Comparison

| Feature | .NET Framework Labs | .NET Core Labs |
|---------|-------------------|----------------|
| **Framework** | ASP.NET MVC | ASP.NET Core Web API |
| **UI** | Razor Views (Server-side) | JSON API (REST) |
| **Architecture** | MVC Pattern | 3-Tier Architecture |
| **Database** | Optional / Basic | EF Core (DB First & Code First) |
| **Focus** | Web Pages | REST APIs |
| **Labs** | Lab 1-4, MID Practice | Lab 6-10 |
| **Complexity** | ⭐⭐ Beginner-Intermediate | ⭐⭐⭐⭐ Advanced |
| **Use Case** | Traditional web apps | Modern microservices |

---

## 🚀 Getting Started

### Prerequisites

**Required Software:**
- **For .NET Framework Labs:**
  - Visual Studio 2022 (with .NET Framework workload)
  - .NET Framework 4.7.2 or later
  
- **For .NET Core Labs:**
  - Visual Studio 2022 / VS Code / Rider
  - .NET 10.0 SDK or later
  - SQL Server 2019+ or LocalDB
  - SQL Server Management Studio (optional)

### Quick Navigation

**Start with .NET Framework (Weeks 1-4):**
```powershell
cd ".NET"
# Follow individual lab README files
```

**Progress to .NET Core (Weeks 5-9):**
```powershell
cd ".NET Core"
# Follow comprehensive lab series
```

---

## 📖 Detailed Lab Information

### .NET Framework Labs (Lab 1-4)

**Lab 1: Introduction to ASP.NET MVC**
- Course setup and environment
- Understanding MVC architecture
- Creating first controller and view
- Basic routing

**Lab 2: Controllers & Views**
- Action methods and results
- View rendering
- Passing data to views
- ViewBag, ViewData, TempData

**Lab 3: Forms & Data Handling**
- HTML form submission
- Model binding
- Form validation
- POST/Redirect/GET pattern

**Lab 4: Advanced MVC Features**
- Partial views
- Layouts and sections
- Custom routing
- Error handling

**MID Practice:**
- Comprehensive review exercises
- Sample problems and solutions

---

### .NET Core Labs (Lab 6-10)

**Lab 6: Web API Fundamentals** ⭐⭐
- HTTP methods (GET, POST, PUT, DELETE)
- Controllers and routing
- DTOs (Data Transfer Objects)
- In-memory data storage
- API testing

**Lab 7: EF Core Database First** ⭐⭐⭐
- Scaffold DbContext from database
- Navigation properties
- LINQ queries
- Related data loading

**Lab 8: EF Core Code First** ⭐⭐⭐⭐
- Code First migrations
- AutoMapper configuration
- DTO validation
- Database schema versioning

**Lab 9: 3-Tier Architecture Intro** ⭐⭐⭐⭐
- Multi-project solution
- Layer separation (API, BLL, DAL)
- Repository pattern
- Service layer design

**Lab 10: Complete 3-Tier with Relations** ⭐⭐⭐⭐⭐
- Production-ready architecture
- Entity relationships (FK)
- Complete CRUD across layers
- Navigation properties
- Professional API design

---

## 🎓 Skills Progression

### Beginner Level (Weeks 1-2)
- [x] Understand MVC pattern
- [x] Create controllers and views
- [x] Handle basic routing
- [x] Work with forms

### Intermediate Level (Weeks 3-4)
- [x] Advanced view techniques
- [x] State management
- [x] Custom routing
- [x] Error handling

### Advanced Level (Weeks 5-7)
- [x] REST API design
- [x] Entity Framework Core
- [x] Code First migrations
- [x] AutoMapper integration

### Expert Level (Weeks 8-9)
- [x] 3-Tier architecture
- [x] Repository pattern
- [x] Service layer
- [x] Entity relationships
- [x] Production-ready code

---

## 📚 Purpose

This repository serves as a comprehensive learning journal for the course _ADVANCED PROGRAMMING WITH .NET_. Use it to:

- 📝 Record class notes and exercises
- 💻 Store code snippets and projects
- 📖 Track learning progress
- 🔍 Review concepts and implementations
- 🎯 Prepare for assessments

Update this repository regularly to maintain a complete record of your .NET development journey.


---

## 📝 Daily Learning Log

For tracking daily progress, add entries below using the template provided.

## How to structure daily updates

For every new class/lab day, add a new section using the format below. Keep entries chronological and prefix headings with the date (YYYY-MM-DD) so the log is sortable.

### Template for each day

**Format:**
```
### YYYY-MM-DD — Day N — [Short title]

- **Goals for today:** (what you want to learn / accomplish)
- **Topics covered:** (bullet list of lecture/lab topics)
- **Code / commands:** (short snippets or references to files/commits)
- **Resources & references:** (links to slides, docs, web pages)
- **Problems / issues encountered:** (bugs, confusion, TODOs)
- **What I learned (summary):** (2–4 concise bullets)
- **Next steps / Homework:** (what to prepare before next class)
```

### Example entry (Day 1)

### 2025-10-29 — Day 01 — Course intro & environment setup

- **Goals for today:** Get course overview and set up the development environment for .NET development.
- **Topics covered:**
  - Course syllabus and assessment (brief)
  - Overview of .NET ecosystem and CLR
  - Visual Studio and project templates (ASP.NET MVC) used in labs
  - NuGet packages and package.config
- **Code / commands:**
  - Created a new ASP.NET MVC project in Visual Studio (see project `Lab 1/`)
  - Basic git usage to save daily logs (example commands below)
- **Resources & references:**
  - Official .NET docs: https://learn.microsoft.com/dotnet/
  - ASP.NET MVC docs: https://learn.microsoft.com/aspnet/mvc
- **Problems / issues encountered:**
  - None major — Visual Studio project opened successfully.
- **What I learned (summary):**
  - Course structure and expectations.
  - Project template used for labs is an ASP.NET MVC application.
- **Next steps / Homework:**
  - Review MVC controllers and views prior to the next lab.
  - Implement a small controller action and commit the change.

---

## 🛠️ Development Workflow
  - Implement a small controller action and commit the change.

## Quick instructions — Updating this README daily (PowerShell examples)

1. Open a PowerShell terminal in the repository root.
2. Edit this `README.md` and add a new section for the current date following the template above.
3. Save and commit with a clear message:

```powershell
git add README.md
git commit -m "chore: daily log 2025-10-30 — Day 02 — [short title]"
git push
```

### Tips for commit messages

- Use the prefix `chore: daily log` followed by the ISO date and a short title. This keeps daily updates discoverable in the commit history.

---

## 📂 File Organization

### Suggested small conventions

- Start each heading with the ISO date (YYYY-MM-DD) and a Day counter.
- Keep summaries short and actionable.
- If code is substantial, place it in the repository (e.g., under `.NET/Lab2/` or `.NET Core/Lab7/`) and reference the path here.

### Where to add files and exercises

- Use a clear folder structure for lab artifacts
- Reference files by relative path in this README for quick navigation
- Each lab has its own detailed README with specific instructions

**Example structure:**
```
.NET/
├── Lab 1/
│   ├── Controllers/
│   ├── Views/
│   └── README.md
└── Lab2/
    └── ...

.NET Core/
├── Lab6/
│   ├── Controllers/
│   ├── Models/
│   └── README.md
└── Lab7/
    └── ...
```

---

## 📖 Additional Resources

### Official Documentation
- [.NET Framework Documentation](https://docs.microsoft.com/en-us/dotnet/framework/)
- [ASP.NET MVC Documentation](https://docs.microsoft.com/en-us/aspnet/mvc)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/)

### Learning Resources
- Microsoft Learn: [learn.microsoft.com](https://learn.microsoft.com)
- .NET YouTube Channel
- Stack Overflow (.net, asp.net-core tags)
- GitHub .NET samples

---

## 🎯 Course Milestones

- [ ] Complete .NET Framework Labs (Lab 1-4)
- [ ] Mid-term examination preparation
- [ ] Complete ASP.NET Core Labs (Lab 6-10)
- [ ] Master 3-Tier Architecture
- [ ] Build final project
- [ ] Course completion

---

## 🏆 Learning Outcomes

By the end of this course, you will be able to:

✅ Build web applications using ASP.NET MVC  
✅ Create RESTful APIs with ASP.NET Core  
✅ Use Entity Framework Core for database operations  
✅ Implement 3-Tier architecture  
✅ Apply design patterns (Repository, Service Layer)  
✅ Use AutoMapper for object mapping  
✅ Handle entity relationships and migrations  
✅ Write production-ready .NET applications  

---

## 👨‍💻 Author

**Institution:** American International University - Bangladesh (AIUB)  
**Department:** Computer Science & Engineering  
**Course:** Advanced Programming with .NET  
**Instructor:** Tanvir Ahmed  
**Semester:** 9 (Spring 2026)

---

## 📄 License

This repository and all associated materials are created for educational purposes as part of university coursework at AIUB.

---

**Last Updated:** January 23, 2026  
**Status:** Active Learning  
**Total Labs:** 9 (4 ASP.NET MVC + 5 ASP.NET Core)

---

**Happy Learning! Master both ASP.NET Framework and ASP.NET Core! 🚀**
