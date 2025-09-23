﻿using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{
    public class Category : BaseEntity.BaseEntity  
    {
        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Arabic Name")]
        public string ArName { get; set; } 
        
        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "English Name")]
        public string EnName { get; set; }

    }

    public class CategoryLightVM
    {
        public int Id { get; set; }
        public string Name { get; set; } 
    }
}
