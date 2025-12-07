# PDS - Product Distribution System

An ASP.NET MVC web application built with .NET Framework 4.8.1 for managing customers, products, and orders in a product distribution system.

## 📋 Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Usage](#usage)
- [Project Components](#project-components)
- [License](#license)

## ✨ Features

- **Customer Registration**: User registration with custom validation
- **Customer Management**: CRUD operations for customer data
- **Order Management**: Track and manage customer orders
- **Product Management**: Manage product inventory
- **Order Details**: Detailed order tracking with product associations
- **Entity Framework Integration**: Database-first approach with Entity Framework 5
- **AutoMapper Integration**: Object-to-object mapping for DTOs
- **Custom Validation**: Email, username, and password validation
- **Responsive UI**: Bootstrap 5.2.3 integration

## 🛠 Technologies

### Backend
- **Framework**: ASP.NET MVC 5.2.9
- **.NET Framework**: 4.8.1
- **ORM**: Entity Framework 5.0.0
- **Mapping**: AutoMapper 10.0.0
- **JSON**: Newtonsoft.Json 13.0.3

### Frontend
- **CSS Framework**: Bootstrap 5.2.3
- **JavaScript**: jQuery 3.7.0
- **Validation**: jQuery Validation 1.19.5
- **Modernizr**: 2.8.3

### Tools & Utilities
- **Optimization**: ASP.NET Web Optimization 1.1.3
- **WebGrease**: 1.6.0
- **Roslyn Compiler**: Microsoft.CodeDom.Providers.DotNetCompilerPlatform 2.0.1

## 📁 Project Structure

```
PDS/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   └── RegistrationController.cs
├── Models/               # Entity Framework Models
│   ├── Customer.cs
│   ├── Order.cs
│   ├── OrderDetail.cs
│   └── Product.cs
├── DTOs/                 # Data Transfer Objects
│   └── CustomerDTO.cs
├── CustomValidation/     # Custom validation attributes
├── Views/                # Razor views
├── App_Start/            # Application configuration
│   ├── BundleConfig.cs
│   ├── FilterConfig.cs
│   └── RouteConfig.cs
├── Content/              # CSS and static content
├── Scripts/              # JavaScript files
├── App_Data/             # Database files
└── Web.config            # Application configuration
```

## 📦 Prerequisites

Before running this project, ensure you have the following installed:

- **Visual Studio 2017 or later** with ASP.NET and web development workload
- **.NET Framework 4.8.1 SDK**
- **SQL Server** (Express or higher) or **SQL Server LocalDB**
- **IIS Express** (usually comes with Visual Studio)
- **NuGet Package Manager**

## 🚀 Installation

1. **Clone or download the repository**
   ```powershell
   cd "d:\University\Semester 9\ADVANCED PROGRAMMING WITH .NET\Final\Lab\Lab1\PDS"
   ```

2. **Open the solution**
   - Open `PDS.sln` in Visual Studio

3. **Restore NuGet packages**
   ```powershell
   # In Visual Studio Package Manager Console
   Update-Package -Reinstall
   ```
   Or right-click on the solution in Solution Explorer and select "Restore NuGet Packages"

4. **Build the solution**
   - Press `Ctrl+Shift+B` or
   - Build → Build Solution

## 💾 Database Setup

1. **Update Connection String**
   - Open `Web.config`
   - Locate the connection string section
   - Update the connection string to point to your SQL Server instance

2. **Update Database from Model**
   - The project uses Entity Framework Database-First approach
   - Ensure the database exists and matches the Entity Data Model (`.edmx` file)

3. **Verify Database Context**
   - The `PMSEntities` class in `Model1.Context.cs` provides database access
   - Check that all entities (Customer, Order, OrderDetail, Product) are properly mapped

## ⚙ Configuration

### Web.config Settings

- **Connection Strings**: Configure your database connection
- **App Settings**: Application-specific settings
- **Compilation**: Debug mode for development

### IIS Express Settings

- **SSL Port**: 44304
- **Anonymous Authentication**: Enabled
- **URL**: Default localhost with port assigned by IIS Express

## 🎯 Usage

1. **Run the application**
   - Press `F5` in Visual Studio or
   - Debug → Start Debugging

2. **Access the application**
   - The application will open in your default browser
   - URL: `https://localhost:44304`

3. **Navigate the application**
   - **Home**: Landing page
   - **Registration**: Customer registration with validation
   - **About**: Application information
   - **Contact**: Contact page

## 🧩 Project Components

### Models

- **Customer**: Customer entity with Id, Name, Email, Username, Password
- **Order**: Order entity linked to customers
- **OrderDetail**: Order line items linked to orders and products
- **Product**: Product entity for inventory

### DTOs (Data Transfer Objects)

- **CustomerDTO**: Customer data transfer object with validation attributes
  - Name (Required)
  - Email (Custom email validation)
  - Username (Custom username validation)
  - Password (Required)
  - ConfirmPassword (Custom confirmation validation)

### Controllers

- **HomeController**: Handles home, about, and contact pages
- **RegistrationController**: Manages customer registration with AutoMapper integration

### Custom Validation

The project includes custom validation attributes for:
- Email validation
- Username validation
- Password confirmation

### AutoMapper Configuration

AutoMapper is configured to map between:
- `Customer` ↔ `CustomerDTO`

## 🔒 Security Considerations

- Passwords should be hashed before storing (implement password hashing)
- Use HTTPS in production
- Implement proper authentication and authorization
- Validate all user inputs
- Protect against SQL injection (Entity Framework provides protection)
- Implement CSRF protection

## 🐛 Troubleshooting

### Common Issues

1. **NuGet Package Restore Failed**
   - Clear NuGet cache: `dotnet nuget locals all --clear`
   - Restore packages manually from Package Manager Console

2. **Database Connection Issues**
   - Verify SQL Server is running
   - Check connection string in Web.config
   - Ensure database exists and is accessible

3. **Build Errors**
   - Clean solution: Build → Clean Solution
   - Rebuild: Build → Rebuild Solution
   - Check for missing references

4. **Roslyn Compiler Issues**
   - Ensure the `bin\roslyn` folder exists
   - Reinstall Microsoft.CodeDom.Providers.DotNetCompilerPlatform package

## 📝 License

This project is created for educational purposes as part of Advanced Programming with .NET coursework.

## 👥 Contributing

This is a university lab project. For educational purposes only.

---

**University**: Semester 9  
**Course**: Advanced Programming with .NET  
**Lab**: Lab 1  
**Project**: PDS (Product Distribution System)
