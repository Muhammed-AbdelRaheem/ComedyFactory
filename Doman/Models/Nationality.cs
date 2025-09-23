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
    public class Nationality:BaseEntity.BaseEntity
    {

        [Required(ErrorMessage = "*")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "ArName")]
        public string? ArName { get; set; }
    }


    public class NationalityDataTable : BaseEntity.BaseEntity
    {
        [SearchableString]
        [Sortable(Default = false)]
        public int Id { get; set; }
        [IncludeInReport(Order = 1)]
        [SearchableString]
        [Sortable]
        public string Name { get; set; }
        [IncludeInReport(Order = 2)]
        [SearchableString]
        [Sortable]
        public string ArName { get; set; }
        [IncludeInReport(Order = 3)]
        [SearchableString]
        [Sortable]
        public DateTime CreatedOnUtc { get; set; }
        [IncludeInReport(Order = 4)]
        [SearchableString]
        [Sortable]
        public DateTime UpdatedOnUtc { get; set; }
        [IncludeInReport(Order = 5)]
        [SearchableString]
        [Sortable]
        public int? DisplayOrder { get; set; }
        [IncludeInReport(Order = 6)]
        [SearchableString]
        [Sortable]
        public bool Hidden { get; set; }

    }
}
