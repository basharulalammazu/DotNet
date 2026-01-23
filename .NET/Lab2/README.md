# Lab 2 - Custom Validation in ASP.NET MVC

## 📋 Project Overview
This lab demonstrates the implementation of custom validation attributes in ASP.NET MVC. The project showcases how to create custom validation logic beyond the built-in data annotations, specifically focusing on validating student registration forms with custom rules for names, IDs, and emails.

## 🎯 Learning Objectives
- Creating custom validation attributes
- Understanding the `ValidationAttribute` base class
- Implementing `IsValid()` method
- Using regular expressions for validation
- Accessing related properties within validators
- Implementing model validation in ASP.NET MVC
- Server-side form validation
- Displaying validation messages in views

## 🏗️ Project Structure

```
Lab2/
└── Validation/
    └── WebApplication1/
        ├── Controllers/
        │   └── HomeController.cs              # Main controller with registration
        ├── Models/
        │   └── Student.cs                     # Student model with validation
        ├── CustomValidation/
        │   ├── NameValidation.cs             # Custom name validator
        │   ├── IDValidation.cs               # Custom ID validator
        │   └── EmailValidation.cs            # Custom email validator
        ├── Views/
        │   ├── Home/
        │   │   ├── Index.cshtml              # Home page
        │   │   ├── Registration.cshtml       # Registration form
        │   │   ├── About.cshtml              # About page
        │   │   └── Contact.cshtml            # Contact page
        │   └── Shared/
        │       ├── _Layout.cshtml            # Master layout
        │       └── Error.cshtml              # Error page
        ├── App_Start/
        │   ├── RouteConfig.cs                # Route configuration
        │   ├── FilterConfig.cs               # Filter configuration
        │   └── BundleConfig.cs               # Bundle configuration
        ├── Content/                           # CSS files
        ├── Scripts/                           # JavaScript files
        └── Global.asax.cs                     # Application startup
```

## 🔧 Technologies Used
- **Framework:** ASP.NET MVC 5
- **Target Framework:** .NET Framework 4.8
- **Validation:** Custom ValidationAttribute
- **Frontend:** HTML5, CSS3, Bootstrap 5
- **JavaScript:** jQuery 3.7.0 with jQuery Validation
- **Language:** C#
- **IDE:** Visual Studio

## 📦 Key Components

### 1. Student Model

```csharp
public class Student
{
    [NameValidation]
    public string Name { get; set; }
    
    public string Username { get; set; }
    
    [IDValidation]
    public string Id { get; set; }
    
    public int DOB { get; set; }
    
    [EmailValidation]
    public string Email { get; set; }
}
```

**Properties:**
- `Name` - Student name with custom name validation
- `Username` - Username without specific validation
- `Id` - Student ID with custom format validation
- `DOB` - Date of birth (integer representation)
- `Email` - Email with custom email validation

### 2. Custom Validation Attributes

#### NameValidation
**Purpose:** Validates that names contain only alphabets, spaces, dots, and dashes

**Implementation:**
```csharp
public class NameValidation : ValidationAttribute
{
    public override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("Name is required.");

        string name = value.ToString();

        if (!Regex.IsMatch(name, @"^[A-Za-z.\-\s]+$"))
            return new ValidationResult("Only alphabets, spaces, dots, and dashes are allowed.");

        return ValidationResult.Success;
    }
}
```

**Validation Rules:**
- ✅ Name is required (not null/empty)
- ✅ Only alphabetic characters allowed
- ✅ Spaces, dots (.), and dashes (-) are permitted
- ❌ Numbers not allowed
- ❌ Special characters (except . and -) not allowed

**Valid Examples:**
- "John Doe"
- "Mary-Jane"
- "Dr. Smith"
- "Anne Marie"

**Invalid Examples:**
- "John123" (contains numbers)
- "John@Doe" (special character)
- "" (empty string)

#### IDValidation
**Purpose:** Validates student ID format (xx-xxxxx-xx pattern)

**Implementation:**
```csharp
public class IDValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(Object obj, ValidationContext validationContext)
    {
        if (obj == null) return new ValidationResult("ID is required.");
        
        string id = obj.ToString();
        // ID must be exactly xx-xxxxx-xx format (2 digits - 5 digits - 2 digits)
        if (!Regex.IsMatch(id, @"^\d{2}-\d{5}-\d{2}$"))
            return new ValidationResult("ID must be in format: xx-xxxxx-xx");
            
        return ValidationResult.Success;
    }
}
```

**Validation Rules:**
- ✅ ID is required
- ✅ Must follow pattern: `xx-xxxxx-xx`
- ✅ First segment: 2 digits
- ✅ Second segment: 5 digits
- ✅ Third segment: 2 digits
- ✅ Segments separated by dashes

**Valid Examples:**
- "12-34567-89"
- "01-00001-01"
- "99-99999-99"

**Invalid Examples:**
- "123-4567-89" (wrong format)
- "12-3456-78" (missing digit)
- "AB-12345-CD" (letters instead of numbers)

#### EmailValidation
**Purpose:** Demonstrates accessing other properties during validation

**Implementation:**
```csharp
public class EmailValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var obj = validationContext.ObjectInstance as Student; // Unboxing
        var id = obj.Id; // Access related property (ID)
        
        // Additional validation logic can be implemented here
        // For example: checking if email domain matches student ID pattern
        
        return base.IsValid(value, validationContext);
    }
}
```

**Key Concept:**
- Shows how to access other properties of the model during validation
- Uses `ValidationContext.ObjectInstance` to get the entire model
- Enables cross-property validation scenarios

### 3. HomeController

```csharp
public class HomeController : Controller
{
    [HttpGet]
    public ActionResult Registration()
    {
        ViewBag.Message = "Student Registration Page";
        return View(new Student());
    }
    
    [HttpPost]
    public ActionResult Registration(Student student)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Student Registered Successfully";
        }
        return View(student);
    }
}
```

**Actions:**
- `Registration (GET)` - Displays empty registration form
- `Registration (POST)` - Processes submitted form and validates

### 4. Registration View

```cshtml
@model Student

<form class="form form-control" action="" method="post">
    <label>ID</label>
    <input name="Id" value="@Model.Id" placeholder="Enter your ID" />
    <span class="text-danger">@Html.ValidationMessage("Id")</span>
    
    <label>Name</label>
    <input name="Name" value="@Model.Name" placeholder="Enter your name" />
    <span class="text-danger">@Html.ValidationMessage("Name")</span>
    
    <label>Username</label>
    <input name="Username" value="@Model.Username" placeholder="Enter your username" />
    
    <label>Email</label>
    <input name="Email" value="@Model.Email" placeholder="Enter your email" />
    <span class="text-danger">@Html.ValidationMessage("Email")</span>
    
    <input type="submit" value="Submit" />
</form>
```

## 🎨 Features

### 1. Custom Validation
- ✅ Server-side validation using custom attributes
- ✅ Regular expression pattern matching
- ✅ Custom error messages
- ✅ Cross-property validation capability

### 2. Form Handling
- ✅ GET/POST pattern for form submission
- ✅ Model binding
- ✅ ModelState validation
- ✅ Validation message display

### 3. User Feedback
- ✅ Error messages displayed in red
- ✅ Field-specific validation messages
- ✅ Success message on valid submission

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.8
- IIS Express

### Installation & Running

1. **Navigate to Project Directory**
   ```
   cd Lab2/Validation
   ```

2. **Open Solution**
   ```
   Open WebApplication1.sln in Visual Studio
   ```

3. **Restore NuGet Packages**
   - Right-click solution → Restore NuGet Packages

4. **Build the Project**
   - Press `Ctrl + Shift + B`

5. **Run the Application**
   - Press `F5`
   - Navigate to `/Home/Registration`

## 📍 Routes

- `/` or `/Home/Index` - Home page
- `/Home/About` - About page
- `/Home/Contact` - Contact page
- `/Home/Registration` - Student registration form

## 🎓 Key Concepts Demonstrated

### 1. Custom Validation Attributes
```csharp
public class CustomValidator : ValidationAttribute
{
    public override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Validation logic
        return ValidationResult.Success; // or new ValidationResult("Error message")
    }
}
```

### 2. ValidationAttribute Methods
- `IsValid(object value, ValidationContext validationContext)` - Main validation method
- `ValidationResult.Success` - Returns success
- `new ValidationResult("message")` - Returns error with message

### 3. ValidationContext Usage
- Access the entire model: `validationContext.ObjectInstance`
- Get property name: `validationContext.MemberName`
- Implement cross-property validation

### 4. Regular Expressions in Validation
```csharp
Regex.IsMatch(value, pattern)
```

**Common Patterns:**
- `^[A-Za-z.\-\s]+$` - Letters, spaces, dots, dashes
- `^\d{2}-\d{5}-\d{2}$` - Specific number format
- `^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$` - Email

### 5. Model State Validation
```csharp
if (ModelState.IsValid)
{
    // Process valid data
}
else
{
    // Return view with errors
}
```

## 📝 Validation Flow

1. **User submits form** → POST request to controller
2. **Model binding** → Form data mapped to Student object
3. **Validation triggered** → Custom validators execute
4. **ModelState updated** → Validation results stored
5. **Controller checks** → `ModelState.IsValid`
6. **View displays** → Success or validation errors

## 💡 Best Practices

### 1. Custom Validation Attributes
```csharp
✅ Inherit from ValidationAttribute
✅ Override IsValid method
✅ Return ValidationResult
✅ Provide clear error messages
✅ Handle null/empty values
✅ Use regular expressions for pattern matching
```

### 2. Error Messages
```csharp
✅ Be specific and user-friendly
✅ Indicate what went wrong
✅ Suggest correct format if applicable
❌ Don't use technical jargon
❌ Don't expose system details
```

### 3. Validation Display
```cshtml
✅ Use @Html.ValidationMessage("PropertyName")
✅ Apply .text-danger class for visibility
✅ Place messages near related fields
```

## 🔍 Testing the Validation

### Test Case 1: Valid Input
**Input:**
- ID: `22-45673-3`
- Name: `John Doe`
- Username: `johndoe`
- Email: `john@example.com`

**Expected:** ✅ Success message

### Test Case 2: Invalid Name
**Input:**
- Name: `John123` (contains numbers)

**Expected:** ❌ "Only alphabets, spaces, dots, and dashes are allowed."

### Test Case 3: Invalid ID Format
**Input:**
- ID: `123-456-78` (wrong format)

**Expected:** ❌ "ID must be in format: xx-xxxxx-xx"

### Test Case 4: Empty Fields
**Input:**
- Name: `` (empty)

**Expected:** ❌ "Name is required."

## 🐛 Troubleshooting

**Issue:** Validation not triggering
- **Solution:** Ensure validation attributes are properly applied to model properties
- Check that jQuery validation scripts are loaded

**Issue:** Error messages not displaying
- **Solution:** Verify `@Html.ValidationMessage()` is in the view
- Check that property names match exactly (case-sensitive)

**Issue:** Regex pattern not working
- **Solution:** Test regex pattern separately
- Escape special characters properly
- Use verbatim strings (`@"pattern"`)

## 📚 Additional Notes

### When to Use Custom Validation
- Built-in validators insufficient
- Complex business rules
- Cross-property validation needed
- Specific format requirements
- Database-dependent validation

### Alternative Approaches
1. **IValidatableObject Interface**
   ```csharp
   public class Student : IValidatableObject
   {
       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
       {
           // Validation logic
       }
   }
   ```

2. **Remote Validation** - For AJAX-based validation

3. **Fluent Validation** - External library for complex scenarios

## 🔗 Related Concepts
- Data Annotations
- Model Validation
- Regular Expressions
- Form Processing
- Error Handling
- ModelState

## 👨‍💻 Author
Created as part of Advanced Programming with .NET course, Semester 9

## 📄 License
Educational project for learning purposes

---

**Course:** Advanced Programming with .NET  
**Lab:** Lab 2 - Custom Validation in ASP.NET MVC  
**Date:** January 2026
