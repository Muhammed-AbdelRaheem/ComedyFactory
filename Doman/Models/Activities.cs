using Fingers10.ExcelExport.Attributes;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Activities:BaseEntity.BaseEntity
    {
        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "ArName")]
        public string ArName { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "EnName")]
        public string EnName { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Arabic Content")]
        [UIHint("Editor")]
        public string ArContent { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "English Content")]
        [UIHint("Editor")]
        public string EnContent { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Icon")]
        [UIHint("FileUploader")]
        public string? Picture { get; set; }

        [Display(Name = "Main Picture")]
        [UIHint("PicUploader")]
        public string? MainPicture { get; set; }

    }





    public class ActivityTableData
    {
        [IncludeInReport(Order = 1)]
        public int Id { get; set; }


        [SearchableString()]
        [IncludeInReport(Order = 2)]
        public string ArName { get; set; }

        [SearchableString()]
        [IncludeInReport(Order = 3)]
        public string EnName { get; set; }

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







    public class ActivityVM
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "ArName")]
        public string ArName { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "EnName")]
        public string EnName { get; set; }



        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Arabic Content")]
        [UIHint("Editor")]
        public string ArContent { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "English Content")]
        [UIHint("Editor")]
        public string EnContent { get; set; }
        [Required(ErrorMessage = "This {0} field is required")]
        [Display(Name = "Icon")]
        [UIHint("FileUploader")]
        public string? Picture { get; set; }

        [Display(Name = "Main Picture")]
        [UIHint("PicUploader")]
        public string? MainPicture { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "*")]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [Display(Name = "Created On Utc")]
        public DateTime CreatedOnUtc { get; set; } = Extantion.AddUtcTime();

        [Display(Name = "Updated On Utc")]
        public DateTime UpdatedOnUtc { get; set; } = Extantion.AddUtcTime();

        [Display(Name = "Display Order")]
        [DefaultValue(1)]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Hidden")]
        [DefaultValue(false)]
        public bool Hidden { get; set; }

    }







}
