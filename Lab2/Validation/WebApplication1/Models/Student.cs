using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.CustomValidation;

namespace WebApplication1.Models
{
	public class Student
	{
        [NameValidation]
        public string Name { set; get; }
        public string Username { get; set; }

        public string Id { get; set; }
        public int DOB { get; set; }
        [EmailValidation]
        public string Email { get; set; }
    }
}