using Domain.Models.BaseEntity;
using Fingers10.ExcelExport.Attributes;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PersonalData : BaseEntity.BaseEntity
    {

        [Display(Name = "Full name")]
        public string? Name { get; set; }


        [Display(Name = "Phone")]
        public string? Phone { get; set; }


        [Display(Name = "Birth place")]
        public string? BirthPlace { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "City")]
        public string? Country { get; set; }

        [Display(Name = "City")]
        public string? Nationality { get; set; }

        [Display(Name = "Personal photo")]
        public string? Photo { get; set; }

        [Display(Name = "Desire To Register")]
        public DesireToRegister DesireToRegister { get; set; }

        public Gendar Genders { get; set; }

        public int? NationalityId { get; set; }
        public Nationality? Nationalities { get; set; }


        public int? CountryId { get; set; }
        public Country? Countries { get; set; }

        public int? CityId { get; set; }
        public City? Cities { get; set; }

        public int? DesireId { get; set; }
        public Desire? Desire { get; set; }



    }
    public class PersonalDataTable
    {

        [IncludeInReport(Order = 1)]
        [SearchableString]
        [Sortable]
        public string? Name { get; set; }
        [IncludeInReport(Order = 2)]
        [SearchableString]
        [Sortable]
        public string? Email { get; set; }
        [IncludeInReport(Order = 3)]
        [SearchableString]
        [Sortable]
        public string? Phone { get; set; }
        [IncludeInReport(Order = 4)]
        [SearchableString]
        [Sortable]
        [Display(Name = "Age")]
        public int? Age { get; set; }
        [IncludeInReport(Order = 5)]
        [SearchableString]
        [Sortable]
        [Display(Name = "City")]
        public string? Cities { get; set; }
        [IncludeInReport(Order = 6)]
        [SearchableString]
        [Sortable]
        [Display(Name = "Desire")]
        public string? Desire { get; set; }

        [IncludeInReport(Order = 7)]
        [SearchableString]
        [Sortable]
        public Gendar Genders { get; set; }
        [IncludeInReport(Order = 8)]
        [SearchableString]
        [Sortable]
        public string? CreatedOnUtc { get; set; }
    }


    public class PersonalDataVM
    {

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 40 character")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(80, ErrorMessage = "Maximum characters is 80 character")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter a valid e-mail address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid e-mail address")]
        public string Email { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "This {0} field is required")]
        [RegularExpression(@"^(\+?\d{8,18})$", ErrorMessage = "MobileNumberRequired")]
        public string Phone { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "This {0} field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The {0} must be at least 1")]
        public int? Age { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        //[Display(Name = "Desire")]
        //[Required(ErrorMessage = "This {0} field is required")]
        //public string? Desire { get; set; }
        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Genders")]
        public Gendar Genders { get; set; }
        //[Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Nationality")]
        public int? NationalityId { get; set; }

        //[Display(Name = "Country")]
        //public int? CountryId { get; set; }


        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Desire")]
        public int? DesireId { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "City")]
        public int? CityId { get; set; }
    }


    public enum DesireToRegister
    {
        [Display(Name = "Writing WorkShop")]
        WritingWorkShop = 0,
        [Display(Name = "Acting WorkShop")]
        ActingWorkShop = 1,


    }
}
