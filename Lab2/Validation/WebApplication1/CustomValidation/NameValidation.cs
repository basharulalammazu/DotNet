using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebApplication1.Models;

namespace WebApplication1.CustomValidation
{
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
}