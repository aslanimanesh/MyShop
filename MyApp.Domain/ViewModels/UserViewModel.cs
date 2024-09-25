﻿using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
