using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Login")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Database name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string DbName { get; set; }

        [Required]
        [DisplayName("Login Database")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string DbLogin { get; set; }

        [Required]
        [DisplayName("Database password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string DbPassword { get; set; }

        [Required]
        [DisplayName("Naam Organisatie")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string OrganisationName { get; set; }

        [Required]
        [DisplayName("Address")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}