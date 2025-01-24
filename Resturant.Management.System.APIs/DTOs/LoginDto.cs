﻿using System.ComponentModel.DataAnnotations;

namespace Resturant.Management.System.APIs.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
