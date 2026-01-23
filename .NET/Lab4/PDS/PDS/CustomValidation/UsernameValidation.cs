using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PDS.CustomValidation
{
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
}