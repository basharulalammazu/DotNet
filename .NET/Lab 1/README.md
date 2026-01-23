# Lab 1 - ASP.NET MVC Portfolio Application

## 📋 Project Overview
This is a basic ASP.NET MVC web application demonstrating fundamental concepts of the Model-View-Controller architecture pattern. The project showcases a portfolio website with multiple pages displaying personal information, education, projects, and references.

## 🎯 Learning Objectives
- Understanding ASP.NET MVC architecture
- Creating Controllers and Actions
- Working with Views and Razor syntax
- Implementing Models
- Using ViewBag for data passing
- Creating strongly-typed views
- Basic routing in ASP.NET MVC

## 🏗️ Project Structure

```
Lab 1/
├── Controllers/
│   ├── HomeController.cs         # Handles Home, About, and Contact pages
│   └── PortfolioController.cs    # Manages portfolio-related pages
├── Models/
│   ├── Education.cs              # Education entity model
│   └── Project.cs                # Project entity model
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml          # Home page
│   │   ├── About.cshtml          # About page
│   │   └── Contact.cshtml        # Contact page
│   ├── Portfolio/
│   │   ├── Index.cshtml          # Portfolio home page
│   │   ├── Project.cshtml        # Projects listing page
│   │   ├── Education.cshtml      # Education details page
│   │   └── Reference.cshtml      # Reference page
│   └── Shared/
│       ├── _Layout.cshtml        # Master layout page
│       └── Error.cshtml          # Error page
├── Content/                      # CSS files (Bootstrap)
├── Scripts/                      # JavaScript files (jQuery, Bootstrap)
└── Global.asax.cs               # Application startup configuration
```

## 🔧 Technologies Used
- **Framework:** ASP.NET MVC 5
- **Target Framework:** .NET Framework 4.8
- **Frontend:** HTML5, CSS3, Bootstrap 5
- **JavaScript:** jQuery 3.7.0
- **Language:** C#
- **IDE:** Visual Studio

## 📦 Key Components

### Controllers

#### HomeController
```csharp
- Index()      : Displays the home page
- About()      : Shows the about page with description
- Contact()    : Displays contact information
```

#### PortfolioController
```csharp
- Index()      : Portfolio landing page with ViewBag data
- Project()    : Lists 10 dummy projects with titles and languages
- Education()  : Displays education history (SSC and HSC)
- Reference()  : Shows reference information
```

### Models

#### Education Model
```csharp
- Name         : string (Education level name)
- Year         : int (Year of completion)
- Result       : float (Grade/Result)
```

#### Project Model
```csharp
- Title        : string (Project name)
- Language     : string (Programming language used)
```

## 🎨 Features

1. **Responsive Design**
   - Custom CSS styling with modern UI elements
   - Responsive navigation bar
   - Mobile-friendly layouts
   - Hover effects and transitions

2. **Navigation System**
   - Bootstrap navbar in layout
   - Custom navigation menu in portfolio pages
   - Consistent navigation across all pages

3. **Data Display**
   - Dynamic project listing using loops
   - Strongly-typed views for Education
   - ViewBag for passing simple data

4. **Styling**
   - Custom color scheme (Primary: #1abc9c, Secondary: #2c3e50)
   - Card-based layouts
   - Table formatting for projects
   - Responsive media queries

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.8
- IIS Express (included with Visual Studio)

### Installation & Running

1. **Clone or download the project**
   ```
   Open Lab 1 folder
   ```

2. **Open Solution**
   ```
   Double-click "Lab 1.sln" to open in Visual Studio
   ```

3. **Restore NuGet Packages**
   - Visual Studio will automatically restore packages
   - Or manually: Right-click solution → Restore NuGet Packages

4. **Build the Project**
   - Press `Ctrl + Shift + B` or
   - Build → Build Solution

5. **Run the Application**
   - Press `F5` or click the "IIS Express" button
   - Application will open in your default browser
   - Default URL: `https://localhost:44328/`

## 📍 Routes

### Home Routes
- `/` or `/Home/Index` - Home page
- `/Home/About` - About page
- `/Home/Contact` - Contact page

### Portfolio Routes
- `/Portfolio/Index` - Portfolio home
- `/Portfolio/Project` - Projects list
- `/Portfolio/Education` - Education details
- `/Portfolio/Reference` - References

## 🎓 Key Concepts Demonstrated

1. **MVC Pattern**
   - Separation of concerns
   - Model for data structure
   - View for presentation
   - Controller for logic

2. **Routing**
   - Convention-based routing
   - Default route pattern: `{controller}/{action}/{id}`

3. **View Features**
   - Razor syntax (`@` symbol)
   - ViewBag for dynamic data
   - Strongly-typed views with `@model`
   - Layouts and partial views

4. **Bootstrap Integration**
   - Responsive grid system
   - Navigation components
   - CSS utilities

5. **Data Handling**
   - Creating model instances
   - Passing collections to views
   - Iterating through collections in views

## 📝 Sample Code Snippets

### Creating and Passing Data to View
```csharp
public ActionResult Project()
{
    List<Project> projects = new List<Project>();
    for (int i = 0; i < 10; i++)
    {
        projects.Add(new Project() {
            Title = "Project " + (i + 1),
            Language = "Language " + (i + 1)
        });
    }
    return View(projects);
}
```

### Using ViewBag
```csharp
ViewBag.title2 = "Welcome to Advance ASP.NET!";
ViewBag.subTitle = "This is the home page of the Advance ASP.NET application.";
```

## 🎨 UI Features
- Clean and modern interface
- Teal/Green color scheme (#1abc9c)
- Smooth hover transitions
- Shadow effects on cards
- Responsive tables
- Professional typography

## 📚 Learning Notes

This lab exercise covers:
- ✅ Setting up an ASP.NET MVC project
- ✅ Creating multiple controllers
- ✅ Defining models with properties
- ✅ Creating views with Razor syntax
- ✅ Using strongly-typed views
- ✅ Implementing navigation between pages
- ✅ Styling with custom CSS
- ✅ Working with collections in views

## 🔍 Troubleshooting

**Issue:** Application doesn't start
- **Solution:** Check if IIS Express is installed and the SSL port (44328) is available

**Issue:** Views not found
- **Solution:** Ensure view files are in correct folders matching controller names

**Issue:** Styling not applied
- **Solution:** Check if Bundle configuration is correct in `BundleConfig.cs`

## 👨‍💻 Author
Created as part of Advanced Programming with .NET course, Semester 9

## 📄 License
Educational project for learning purposes

---

**Course:** Advanced Programming with .NET  
**Lab:** Lab 1 - Introduction to ASP.NET MVC  
**Date:** January 2026
