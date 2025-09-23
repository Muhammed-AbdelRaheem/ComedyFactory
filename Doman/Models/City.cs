using Fingers10.ExcelExport.Attributes;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    public class City : BaseEntity.BaseEntity
    {

        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Arabic Name")]
        public string ArName { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "English Name")]
        public string EnName { get; set; }

        public Country? Country { get; set; }

    }

    public class CityDataTable
    {
        [IncludeInReport(Order = 1)]
        public int Id { get; set; }


        //[SearchableString()]
        //[IncludeInReport(Order = 2)]
        //public string? CountryName { get; set; }   

        [SearchableString()]
        [IncludeInReport(Order = 3)]
        public string? EnName { get; set; }

        [SearchableString()]
        [IncludeInReport(Order = 3)]
        public string? ArName { get; set; }

        [IncludeInReport(Order = 5)]
        public int DisplayOrder { get; set; }

        [IncludeInReport(Order = 6)]
        public bool Hidden { get; set; }


        [IncludeInReport(Order = 7)]
        [SearchableString]
        public string? CreatedOnUtc { get; set; }

        [IncludeInReport(Order = 8)]
        [SearchableString]
        public string? UpdatedOnUtc { get; set; }
    }

}
