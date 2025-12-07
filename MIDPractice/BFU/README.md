# BFU Student Management System

A comprehensive web-based student management system built with ASP.NET MVC 5 and Entity Framework, designed to streamline student registration, department management, and academic record keeping.

## 📋 Overview

The BFU Student Management System provides a robust platform for educational institutions to manage student information efficiently. The application features a clean, responsive interface built with Bootstrap 5 and implements CRUD operations for student and department management.

## 🎓 Project Scenario

At **Bright Future University**, the admin, Mr. Rahman, uses the Student Management Portal to manage all students and departments efficiently. Here's how the system works in practice:

### Daily Operations
- When a new student, **Hasan Ali**, joins the CSE department, Mr. Rahman easily adds his details to the system through the intuitive registration form
- He views all students along with their department names in a well-organized table, making it simple to track enrollment
- When Hasan's phone number changes, Mr. Rahman quickly updates the record without any hassle
- When **Rumi Akter** transfers to another university, Mr. Rahman removes her record to keep the database current

### Department Management
- The portal allows Mr. Rahman to add new departments like **Software Engineering** as the university expands
- He can rename existing departments, such as updating **Electrical Engineering** to **EEE** for standardization
- Unused departments like **Textile** can be removed to maintain a clean and organized system

The Student Management Portal keeps Bright Future University's records **organized, accurate, and up to date**, enabling efficient administration and better student services.

## ✨ Features

- **Student Registration**: Add new students with complete information including name, email, phone number, and department assignment
- **Student List Management**: View all registered students with search functionality
- **Student Details**: Access detailed information for individual students
- **Update Records**: Modify existing student information
- **Delete Records**: Remove student records with confirmation
- **Department Management**: Organize students by academic departments
- **Search Functionality**: Quickly find students by name
- **Responsive Design**: Bootstrap 5-powered UI that works across all devices

## 🛠️ Technologies Used

### Backend
- **ASP.NET MVC 5.2.9** - Web application framework
- **Entity Framework 5.0** - ORM for database operations
- **.NET Framework 4.8.1** - Runtime environment
- **C#** - Primary programming language

### Frontend
- **Bootstrap 5.2.3** - UI framework
- **jQuery 3.7.0** - JavaScript library
- **jQuery Validation 1.19.5** - Client-side form validation

### Additional Libraries
- **Newtonsoft.Json 13.0.3** - JSON serialization
- **Microsoft.AspNet.Web.Optimization 1.1.3** - Bundling and minification
- **Modernizr 2.8.3** - Feature detection

## 📁 Project Structure

```
BFU/
├── Controllers/
│   └── HomeController.cs          # Main application controller
├── DataBase/
│   ├── Model1.edmx                # Entity Framework data model
│   ├── Student.cs                 # Student entity
│   └── Department.cs              # Department entity
├── Models/
│   └── Da/                        # Data access layer
├── Views/
│   └── Home/                      # View templates
├── Content/                       # CSS and stylesheets
├── Scripts/                       # JavaScript files
├── App_Start/
│   ├── RouteConfig.cs             # URL routing configuration
│   ├── BundleConfig.cs            # Script/CSS bundling
│   └── FilterConfig.cs            # Action filters
└── Web.config                     # Application configuration
```

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2017 or later
- .NET Framework 4.8.1 SDK
- SQL Server 2012 or later
- IIS Express (included with Visual Studio)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/basharulalammazu/DotNet.git
   cd BFU
   ```

2. **Open the solution**
   - Open `BFU.sln` in Visual Studio

3. **Configure the database connection**
   - Update the connection string in `Web.config` to point to your SQL Server instance
   ```xml
   <connectionStrings>
     <add name="BFUEntities" 
          connectionString="your-connection-string-here" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

4. **Restore NuGet packages**
   ```powershell
   Update-Package -reinstall
   ```

5. **Build the solution**
   - Press `Ctrl+Shift+B` or use `Build > Build Solution`

6. **Update the database**
   - Open Package Manager Console
   - Run: `Update-Database`

7. **Run the application**
   - Press `F5` or click the IIS Express button
   - The application will launch at `https://localhost:44395`

## 📊 Database Schema

The application uses a relational database with two main tables connected through a foreign key relationship.

### Department Table
| Column Name | Data Type | Constraints | Description |
|-------------|-----------|-------------|-------------|
| `ID` | int | PRIMARY KEY, IDENTITY | Unique identifier for each department |
| `Name` | string | NOT NULL | Name of the department (e.g., CSE, EEE, Software Engineering) |

### Student Table
| Column Name | Data Type | Constraints | Description |
|-------------|-----------|-------------|-------------|
| `StudentID` | int | PRIMARY KEY, IDENTITY | Unique identifier for each student |
| `Name` | string | NOT NULL | Full name of the student |
| `Email` | string | NOT NULL | Student's email address |
| `PhoneNumber` | string | NOT NULL | Contact phone number |
| `DeparmentID` | int | FOREIGN KEY | References `Department.ID` - Links student to their department |

### Entity Relationships
```
Department (1) ──────< (Many) Student
    ID                      DeparmentID
```

**Relationship Type**: One-to-Many
- One department can have multiple students
- Each student belongs to exactly one department
- Foreign key constraint ensures referential integrity

## 🎯 Usage

### Registering a Student
1. Navigate to the Registration page
2. Fill in the student details (Name, Email, Phone Number)
3. Select a department from the dropdown
4. Click "Submit" to register the student

### Viewing Students
- Navigate to the List page to view all registered students
- Use the search box to filter students by name

### Updating Student Information
1. Click "Edit" next to a student's record
2. Modify the desired fields
3. Click "Update" to save changes

### Deleting a Student
1. Click "Delete" next to a student's record
2. Confirm the deletion
3. The student will be removed from the system

## 🔒 Configuration

### Connection Strings
Edit the `Web.config` file to configure your database connection:

```xml
<connectionStrings>
  <add name="BFUEntities" 
       connectionString="metadata=res://*/DataBase.Model1.csdl|res://*/DataBase.Model1.ssdl|res://*/DataBase.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=YOUR_SERVER;initial catalog=YOUR_DATABASE;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" 
       providerName="System.Data.EntityClient" />
</connectionStrings>
```

### App Settings
Customize application behavior by modifying settings in `Web.config`.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is part of academic coursework for Advanced Programming with .NET (Semester 9).

## 👨‍💻 Author

**Basharul Alam Mazu**
- GitHub: [@basharulalammazu](https://github.com/basharulalammazu)

## 🙏 Acknowledgments

- Built as part of the Advanced Programming with .NET course
- Utilizes Microsoft's ASP.NET MVC framework
- Bootstrap framework for responsive design

## 📞 Support

For support, please open an issue in the GitHub repository or contact the maintainer.

---

**Note**: This is an educational project developed for learning purposes as part of university coursework.
