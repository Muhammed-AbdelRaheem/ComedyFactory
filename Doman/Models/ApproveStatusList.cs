using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum ApproveStatusList
    {
        [Display(Name = "Pending")]
        Pending = 0,
        [Display(Name = "Approved")]
        Approved = 1,
        [Display(Name = "Rejected")]
        Rejected = 2,
        [Display(Name = "New Upload")]
        NewUpload = 3,
        [Display(Name = "Canceled")]
        Canceled = 4,// Used in gate permits only
    }
}
