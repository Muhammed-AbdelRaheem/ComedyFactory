using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FilterVM
    {
        public string? Email { get; set; }

        public string? Name { get; set; }
        public int? Age { get; set; }
        public double? Weight { get; set; }
        public string? Phone { get; set; }
        public string? IdNo { get; set; }

    }
}
