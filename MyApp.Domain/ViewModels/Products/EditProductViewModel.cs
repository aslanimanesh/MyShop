﻿using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.ViewModels.Products
{
    public class EditProductViewModel
    {

        #region Properties

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? ImageName { get; set; } = null;

        #endregion

    }
}
