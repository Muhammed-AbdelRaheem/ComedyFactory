using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ApiClient : BaseEntity.BaseEntity
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "API Type")]
        public string? APIType { get; set; }

        [Display(Name = "Client")]
        [Required]
        public string Client { get; set; }

        [Display(Name = "Client Id")]
        public string? ClientId { get; set; }

        [Display(Name = "Client Token")]
        public string? ClientToken { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Full Access")]
        public bool FullAccess { get; set; }

        [Display(Name = "Sliding Expiration")]
        public bool SlidingExpiration { get; set; }

        [Display(Name = "AT Expiry/M")]
        public int AccessTokenExpiry { get; set; }

        [Display(Name = "RT Expiry/D")]
        public int RefreshTokenExpiry { get; set; }

    }

}
