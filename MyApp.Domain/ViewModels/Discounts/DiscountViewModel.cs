﻿using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.ViewModels.Discounts
{
    public class DiscountViewModel
    {
        #region Properties

        public int Id { get; set; }

        [Required]
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; } = null;

        public DateTime? EndDate { get; set; } = null;

        public string? DiscountCode { get; set; } = null;

        public int? UsableCount { get; set; } = null;

        public bool IsActive { get; set; } = true;

        #endregion
    }
}
