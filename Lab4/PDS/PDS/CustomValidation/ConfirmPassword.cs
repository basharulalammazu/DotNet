using PDS.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS.CustomValidation
{
    public class ConfirmPassword : ValidationAttribute // Ensure the class inherits from ValidationAttribute
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
}