using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS.CustomValidation
{
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
}