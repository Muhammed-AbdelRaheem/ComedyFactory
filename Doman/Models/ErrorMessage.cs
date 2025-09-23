using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ErrorMessage : BaseEntity.BaseEntity
    {

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Error Key")]
        public string Key { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "English Error Message")]
        [UIHint("Textarea")]
        public string EnDescription { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Arabic Error Message")]
        [UIHint("Textarea")]
        public string ArDescription { get; set; }
    }
}
