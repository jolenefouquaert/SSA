using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITBedrijfProject.PresentationModels
{
    public class PMOrganisationRegister : OrganisationRegister
    {
        public MultiSelectList NewOrganisation { get; set; }
        public MultiSelectList NewRegister { get; set; }
    }
}