using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.PresentationModels
{
    public class PMOrganisation : Organisation
    {
        [Required]
        [DisplayName("Control Password")]
        [Compare("Password", ErrorMessage = "The password and the control password are not the same.")]
        public string ControlPassword { get; set; }

        [Required]
        [DisplayName("Database Control Password")]
        [Compare("DbPassword", ErrorMessage = "The database password and the database control password are not the same.")]
        public string DbControlPassword { get; set; }
        
    }
}