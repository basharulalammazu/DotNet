using PDS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS.DTOs
{
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
}