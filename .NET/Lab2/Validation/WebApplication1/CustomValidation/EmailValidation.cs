using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using WebApplication1.Models;

namespace WebApplication1.CustomValidation
{
	public class EmailValidation : ValidationAttribute
	{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as Student; // unboxing
            var id = obj.Id; // By this access the id

            return base.IsValid(value, validationContext);
        }
    }
}