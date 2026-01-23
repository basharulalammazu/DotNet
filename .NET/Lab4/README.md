# Lab 4 - DTOs, AutoMapper, Password Hashing & Advanced Validation

## 📋 Project Overview
This lab demonstrates advanced ASP.NET MVC concepts including **Data Transfer Objects (DTOs)**, **AutoMapper** for object mapping, **MD5 password hashing** for security, and **database-aware custom validation**. The project is a Product Delivery System (PDS) with customer registration that showcases the separation between domain entities and presentation layer models, along with secure password storage and advanced validation techniques.

## 🎯 Learning Objectives
- Understanding Data Transfer Objects (DTOs) pattern
- Implementing AutoMapper for object-to-object mapping
- Hashing passwords using MD5 algorithm
- Creating database-aware custom validators
- Cross-property validation implementation
- Entity Framework with complex relationships
- Separation of concerns in MVC architecture
- Implementing CRUD operations with DTOs

## 🏗️ Project Structure

```
Lab4/
└── PDS/
    └── PDS/
        ├── Controllers/
        │   ├── RegistrationController.cs     # Customer registration & management
        │   └── HomeController.cs             # Home page controller
        ├── DTOs/
        │   └── CustomerDTO.cs                # Data Transfer Object for Customer
        ├── CustomValidation/
        │   ├── EmailValidation.cs            # Validates unique email (DB check)
        │   ├── UsernameValidation.cs         # Validates existing username (DB check)
        │   └── ConfirmPassword.cs            # Cross-property password validation
        ├── Entity Models/
        │   ├── Customer.cs                   # Customer entity (auto-generated)
        │   ├── Product.cs                    # Product entity
        │   ├── Order.cs                      # Order entity
        │   ├── OrderDetail.cs                # Order detail entity
        │   ├── Model1.edmx                   # Entity Data Model
        │   ├── Model1.Context.cs             # DbContext (PMSEntities)
        │   └── Model1.Designer.cs            # Designer code
        ├── Views/
        │   ├── Registration/
        │   │   ├── Index.cshtml              # Registration form
        │   │   └── Dashboard.cshtml          # Customer list dashboard
        │   ├── Home/
        │   │   ├── Index.cshtml              # Home page
        │   │   ├── About.cshtml              # About page
        │   │   └── Contact.cshtml            # Contact page
        │   └── Shared/
        │       ├── _Layout.cshtml            # Master layout
        │       └── Error.cshtml              # Error page
        ├── App_Start/
        │   ├── RouteConfig.cs                # Routing configuration
        │   ├── FilterConfig.cs               # Filter configuration
        │   └── BundleConfig.cs               # Bundle configuration
        ├── Content/                           # CSS files
        ├── Scripts/                           # JavaScript files
        ├── Web.config                         # Configuration
        └── Global.asax.cs                     # Application startup
```

## 🔧 Technologies Used
- **Framework:** ASP.NET MVC 5
- **Target Framework:** .NET Framework 4.8.1
- **ORM:** Entity Framework 5.0
- **Database:** SQL Server (PMS - Product Management System)
- **Mapping Library:** AutoMapper
- **Security:** MD5 Password Hashing
- **Approach:** Database First + DTOs
- **Frontend:** HTML5, CSS3, Bootstrap 5
- **JavaScript:** jQuery 3.7.0
- **Language:** C#
- **IDE:** Visual Studio

## 📦 Database Schema

### Tables

#### Customers Table
```sql
CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL
)
```

#### Products Table
```sql
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Qty INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL
)
```

#### Orders Table
```sql
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Status VARCHAR(50),
    Amout INT NOT NULL,
    Time INT,
    CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)
```

#### OrderDetails Table
```sql
CREATE TABLE OrderDetails (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PId INT FOREIGN KEY REFERENCES Products(Id),
    OId INT FOREIGN KEY REFERENCES Orders(Id),
    Qty INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL
)
```

### Relationships
- **Customer ↔ Orders:** One-to-Many
- **Order ↔ OrderDetails:** One-to-Many
- **Product ↔ OrderDetails:** One-to-Many

## 📦 Key Components

### 1. Entity Models

#### Customer Entity
```csharp
public partial class Customer
{
    public Customer()
    {
        this.Orders = new HashSet<Order>();
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public virtual ICollection<Order> Orders { get; set; }
}
```

#### Product Entity
```csharp
public partial class Product
{
    public Product()
    {
        this.OrderDetails = new HashSet<OrderDetail>();
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
```

#### Order Entity
```csharp
public partial class Order
{
    public Order()
    {
        this.OrderDetails = new HashSet<OrderDetail>();
    }
    
    public int Id { get; set; }
    public string Status { get; set; }
    public int Amout { get; set; }
    public int Time { get; set; }
    public int CustomerId { get; set; }
    
    public virtual Customer Customer { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
```

#### OrderDetail Entity
```csharp
public partial class OrderDetail
{
    public int Id { get; set; }
    public int PId { get; set; }
    public int OId { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    
    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
}
```

### 2. Data Transfer Object (DTO)

#### CustomerDTO
```csharp
public class CustomerDTO
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [EmailValidation]
    public string Email { get; set; }
    
    [UsernameValidation]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    [ConfirmPassword]
    public string ConPass { get; set; }
}
```

**Why DTO?**
- ✅ Separates database entities from presentation layer
- ✅ Adds validation attributes without modifying entity classes
- ✅ Includes properties not in database (e.g., ConPass)
- ✅ Prevents over-posting attacks
- ✅ Allows different validation rules for different scenarios

### 3. AutoMapper Configuration

```csharp
public static Mapper GetMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
    });
    
    return new Mapper(config);
}
```

**Usage:**
```csharp
// DTO to Entity
var customer = GetMapper().Map<Customer>(customerDTO);

// Entity to DTO
var customerDTO = GetMapper().Map<CustomerDTO>(customer);
```

**Benefits:**
- ✅ Reduces boilerplate code
- ✅ Automatic property mapping
- ✅ Type-safe conversions
- ✅ Bi-directional mapping with ReverseMap()

### 4. Password Hashing (MD5)

```csharp
public static string CreateMD5(string input)
{
    using (MD5 md5 = MD5.Create())
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("x2"));
        }
        return sb.ToString();
    }
}
```

**Example:**
```csharp
string password = "myPassword123";
string hashedPassword = CreateMD5(password);
// Result: "6c9f14e8b2f5e62e4d5f9c3b1a2e8d7f"
```

**Security Features:**
- ✅ One-way hashing (cannot be reversed)
- ✅ Same input always produces same hash
- ✅ Password never stored in plain text
- ⚠️ Note: MD5 is considered weak; use BCrypt/SHA256 in production

### 5. Custom Validation Attributes

#### EmailValidation (Database Uniqueness Check)
```csharp
public class EmailValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            PMSEntities db = new PMSEntities();
            string email = value.ToString();
            
            var dbEmail = (from customer in db.Customers
                          where customer.Email == email
                          select customer).FirstOrDefault();
            
            if (dbEmail == null)
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("Email is already exist");
        }
        return new ValidationResult("Email is required");
    }
}
```

**Features:**
- Queries database to check if email exists
- Ensures email uniqueness
- Returns appropriate error messages

#### UsernameValidation (Database Existence Check)
```csharp
public class UsernameValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            PMSEntities db = new PMSEntities();
            string username = value.ToString();
            
            var user = (from userObj in db.Customers
                       where userObj.Username == username
                       select userObj).FirstOrDefault();
            
            if (user != null)
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("Username does not exit");
        }
        return new ValidationResult("Username is required");
    }
}
```

**Note:** This validator checks if username **exists** (unusual pattern - typically checks for uniqueness)

#### ConfirmPassword (Cross-Property Validation)
```csharp
public class ConfirmPassword : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = validationContext.ObjectInstance as CustomerDTO;
        
        if (password != null && value != null)
        {
            var conPass = value.ToString();
            if (password.Password.Equals(conPass))
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("Password and Confirm Password do not match");
        }
        
        return new ValidationResult("Confirm Password is required");
    }
}
```

**Features:**
- Accesses other properties via ValidationContext
- Compares Password and ConPass fields
- Ensures passwords match before registration

### 6. RegistrationController

```csharp
public class RegistrationController : Controller
{
    PMSEntities db = new PMSEntities();
    
    // GET: Registration
    [HttpGet]
    public ActionResult Index()
    {
        return View(new CustomerDTO());
    }
    
    // POST: Registration
    [HttpPost]
    public ActionResult Index(CustomerDTO customerDTO)
    {
        if (ModelState.IsValid)
        {
            // Map DTO to Entity using AutoMapper
            var customer = GetMapper().Map<Customer>(customerDTO);
            
            // Hash the password
            customer.Password = CreateMD5(customer.Password);
            
            // Save to database
            db.Customers.Add(customer);
            db.SaveChanges();
            
            ViewBag.Message = "Registration Successful";
            ModelState.Clear();
            
            return RedirectToAction("Dashboard");
        }
        return View(customerDTO);
    }
    
    // Customer Dashboard
    public ActionResult Dashboard()
    {
        var customer = db.Customers.ToList();
        return View(customer);
    }
    
    // Delete Customer
    public ActionResult Delete(int id)
    {
        var dbobj = db.Customers.Find(id);
        db.Customers.Remove(dbobj);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }
}
```

### 7. Manual Conversion Methods (Alternative to AutoMapper)

```csharp
// Convert DTO to Entity
public static Customer Convert(CustomerDTO customerDTO)
{
    return new Customer
    {
        Name = customerDTO.Name,
        Email = customerDTO.Email,
        Username = customerDTO.Username,
        Password = customerDTO.Password
    };
}

// Convert Entity to DTO
public static CustomerDTO Convert(Customer customer)
{
    return new CustomerDTO
    {
        Name = customer.Name,
        Email = customer.Email,
        Username = customer.Username,
        Password = customer.Password
    };
}

// Convert List<Entity> to List<DTO>
public static List<CustomerDTO> Convert(List<Customer> customers)
{
    var data = new List<CustomerDTO>();
    foreach (var customer in customers)
    {
        data.Add(Convert(customer));
    }
    return data;
}
```

## 🎨 Features

### 1. Customer Registration
- ✅ Form with validation
- ✅ Real-time database validation
- ✅ Password confirmation
- ✅ Secure password hashing
- ✅ Automatic mapping with AutoMapper
- ✅ Success message display

### 2. Customer Dashboard
- ✅ Display all registered customers
- ✅ Shows hashed passwords (for demo)
- ✅ Delete functionality
- ✅ Navigation to registration

### 3. Validation Features
- ✅ Required field validation
- ✅ Email uniqueness validation
- ✅ Username existence validation
- ✅ Password match validation
- ✅ Custom error messages

### 4. Security
- ✅ MD5 password hashing
- ✅ One-way encryption
- ✅ No plain text passwords stored

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.8.1
- SQL Server
- AutoMapper NuGet package

### Database Setup

1. **Create Database**
   ```sql
   CREATE DATABASE PMS;
   ```

2. **Create Customers Table**
   ```sql
   USE PMS;
   
   CREATE TABLE Customers (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Name VARCHAR(100) NOT NULL,
       Email VARCHAR(100) NOT NULL UNIQUE,
       Username VARCHAR(50) NOT NULL UNIQUE,
       Password VARCHAR(255) NOT NULL
   );
   ```

3. **Create Products Table**
   ```sql
   CREATE TABLE Products (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Name VARCHAR(100) NOT NULL,
       Qty INT NOT NULL,
       Price DECIMAL(18,2) NOT NULL
   );
   ```

4. **Create Orders Table**
   ```sql
   CREATE TABLE Orders (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Status VARCHAR(50),
       Amout INT NOT NULL,
       Time INT,
       CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
   );
   ```

5. **Create OrderDetails Table**
   ```sql
   CREATE TABLE OrderDetails (
       Id INT PRIMARY KEY IDENTITY(1,1),
       PId INT FOREIGN KEY REFERENCES Products(Id),
       OId INT FOREIGN KEY REFERENCES Orders(Id),
       Qty INT NOT NULL,
       Price DECIMAL(18,2) NOT NULL
   );
   ```

### Project Setup

1. **Clone/Download Project**
   ```
   Navigate to Lab4/PDS
   ```

2. **Install NuGet Packages**
   ```
   Install-Package AutoMapper
   Install-Package EntityFramework
   ```

3. **Update Connection String**
   - Open `Web.config`
   - Update PMSEntities connection string with your SQL Server details

4. **Build & Run**
   - Press `Ctrl + Shift + B` to build
   - Press `F5` to run

## 📍 Routes

- `/` or `/Home/Index` - Home page
- `/Registration/Index` - Customer registration form
- `/Registration/Dashboard` - View all customers
- `/Registration/Delete/{id}` - Delete customer by ID
- `/Home/About` - About page
- `/Home/Contact` - Contact page

## 🎓 Key Concepts Demonstrated

### 1. DTO Pattern

**Purpose:**
- Separate data structure from domain model
- Add presentation-specific properties
- Apply different validation rules
- Prevent over-posting attacks

**Implementation:**
```csharp
// DTO with extra property (ConPass) not in database
public class CustomerDTO
{
    public string Password { get; set; }
    public string ConPass { get; set; }  // Not in Customer entity
}
```

### 2. AutoMapper

**Configuration:**
```csharp
cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
```

**Mapping:**
```csharp
var customer = mapper.Map<Customer>(customerDTO);
```

**Advantages:**
- Eliminates manual property copying
- Maintains type safety
- Reduces code duplication
- Easy to configure complex mappings

### 3. Password Hashing

**Process:**
1. User enters password: `"myPassword123"`
2. MD5 hash computed: `"6c9f14e8..."`
3. Hash stored in database
4. Login: Hash entered password and compare

**Security Best Practices:**
- ✅ Never store plain text passwords
- ✅ Use salt for additional security
- ⚠️ MD5 is weak; prefer BCrypt or SHA256
- ✅ Use HTTPS in production

### 4. Database-Aware Validation

**Traditional Validation:**
```csharp
[Required]
[StringLength(50)]
```

**Database-Aware Validation:**
```csharp
[EmailValidation]  // Queries database to check uniqueness
```

**Benefits:**
- Real-time database validation
- Ensures data integrity
- Better user experience
- Prevents duplicate entries

### 5. Cross-Property Validation

```csharp
var model = validationContext.ObjectInstance as CustomerDTO;
var password = model.Password;
var confirmPassword = value.ToString();
```

**Use Cases:**
- Password confirmation
- Date range validation
- Conditional requirements
- Field interdependencies

## 💡 Best Practices

### 1. DTO Usage
```csharp
✅ Use DTOs for API/View models
✅ Keep DTOs in separate folder/namespace
✅ Apply validation to DTOs, not entities
✅ Use AutoMapper for conversions
❌ Don't expose entities directly to views
❌ Don't add business logic to DTOs
```

### 2. Password Security
```csharp
✅ Hash passwords before storing
✅ Use strong hashing algorithms (BCrypt, SHA256)
✅ Add salt for additional security
✅ Never log or display passwords
❌ Don't use MD5 in production (deprecated)
❌ Don't store plain text passwords
```

### 3. Custom Validation
```csharp
✅ Create reusable validation attributes
✅ Provide clear error messages
✅ Handle null/empty values
✅ Dispose DbContext properly
❌ Don't create DbContext at class level
❌ Don't perform expensive operations
```

### 4. AutoMapper
```csharp
✅ Configure mapping once at startup
✅ Use ReverseMap() when appropriate
✅ Test mappings
✅ Keep mappings simple
❌ Don't map everything automatically
❌ Don't ignore mismatched properties
```

## 🔍 Workflow

### Registration Flow

1. **User accesses `/Registration/Index`**
2. **Empty CustomerDTO displayed in form**
3. **User fills out form and submits**
4. **Server-side validation executes:**
   - Required fields checked
   - Email uniqueness validated (DB query)
   - Username existence validated (DB query)
   - Passwords compared
5. **If valid:**
   - DTO mapped to Customer entity (AutoMapper)
   - Password hashed (MD5)
   - Saved to database
   - Redirect to Dashboard
6. **If invalid:**
   - Return form with error messages

### Dashboard Flow

1. **Load all customers from database**
2. **Display in table format**
3. **Show hashed passwords**
4. **Provide delete links**

## 🐛 Troubleshooting

**Issue:** AutoMapper not found
- **Solution:** Install via NuGet: `Install-Package AutoMapper`

**Issue:** Validation always fails
- **Solution:** Check database connection
- Verify validation logic in custom validators

**Issue:** Password hash doesn't match
- **Solution:** Ensure consistent encoding (UTF8)
- Hash comparison must use same algorithm

**Issue:** ConPass property not binding
- **Solution:** Ensure input name matches property name exactly
- Check model binding in form

**Issue:** DbContext disposal errors
- **Solution:** Use `using` statement or dispose manually
- Don't keep DbContext alive too long

## 📚 Additional Notes

### Why DTOs?

**Scenario 1: Over-Posting Attack Prevention**
```csharp
// Without DTO - vulnerable
public ActionResult Edit(Customer customer) 
{
    // Attacker could modify IsAdmin property
}

// With DTO - safe
public ActionResult Edit(CustomerDTO dto)
{
    // Only allowed properties can be modified
}
```

**Scenario 2: Different Validation Rules**
```csharp
// Registration: Password + Confirm Password required
public class CustomerRegistrationDTO
{
    [Required] public string Password { get; set; }
    [Required] public string ConPass { get; set; }
}

// Login: Only Password required
public class CustomerLoginDTO
{
    [Required] public string Password { get; set; }
}
```

### AutoMapper vs Manual Mapping

**AutoMapper:**
```csharp
✅ Less code
✅ Convention-based
✅ Easy for simple mappings
❌ Performance overhead
❌ Complex mappings can be confusing
```

**Manual Mapping:**
```csharp
✅ Full control
✅ Better performance
✅ Explicit and clear
❌ More boilerplate code
❌ Tedious for many properties
```

### Password Hashing Algorithms

| Algorithm | Security | Speed | Recommendation |
|-----------|----------|-------|----------------|
| MD5 | ⚠️ Weak | Fast | ❌ Don't use in production |
| SHA256 | ✅ Good | Fast | ✅ Acceptable |
| BCrypt | ✅ Strong | Slow | ✅ Recommended |
| Argon2 | ✅ Very Strong | Configurable | ✅ Best choice |

## 🔜 Next Steps

To extend this project:
1. Implement login functionality
2. Add session management
3. Use BCrypt instead of MD5
4. Implement email verification
5. Add "Forgot Password" feature
6. Create admin panel
7. Add role-based authorization
8. Implement product ordering system
9. Create order management
10. Add profile editing

## 🎯 Learning Outcomes

After completing this lab, you should understand:

✅ Data Transfer Objects (DTOs) pattern  
✅ AutoMapper configuration and usage  
✅ Password hashing with MD5  
✅ Database-aware custom validation  
✅ Cross-property validation  
✅ Entity Framework with multiple relationships  
✅ Separation of concerns  
✅ Security best practices  
✅ DTO vs Entity differences  
✅ Manual vs AutoMapper mapping  

## 🔗 Related Concepts
- Data Transfer Objects (DTOs)
- AutoMapper
- Password Hashing
- Custom Validation Attributes
- Entity Framework
- Database-Aware Validation
- Cross-Property Validation
- Security Best Practices
- Separation of Concerns

## 👨‍💻 Author
Created as part of Advanced Programming with .NET course, Semester 9

## 📄 License
Educational project for learning purposes

---

**Course:** Advanced Programming with .NET  
**Lab:** Lab 4 - DTOs, AutoMapper, Password Hashing & Advanced Validation  
**Date:** January 2026
