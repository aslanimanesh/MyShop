﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace MyApp.Domain.ViewModels.Discounts
{
    public class CreateDiscountViewModel
    {
        [Required]
        [Range(0,100)]
        public decimal DiscountPercentage { get; set; }
        
        public DateTime? StartDate { get; set; } = null;

        public DateTime? EndDate { get; set; } = null;

        [Required]
        [MaxLength(50)]
        public string DiscountCode { get; set; } 

        public bool IsActive { get; set; } = true;
    }
}
