﻿using System.ComponentModel.DataAnnotations;

namespace VicStelmak.CIAA.WebUI.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
