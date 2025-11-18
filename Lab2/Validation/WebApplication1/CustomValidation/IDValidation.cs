using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace WebApplication1.CustomValidation
{
	public class IDValidation : ValidationAttribute
	{
        protected override ValidationResult IsValid(Object obj, ValidationContext validationContext)
		{
            if (obj == null) return false;
            string id = obj.ToString();
            // Example: ID must be exactly xx-xxxxx-xx
            return System.Text.RegularExpressions.Regex.IsMatch(id, @"^\d{2}-d{5}-d{2}$");
        }
	}
}