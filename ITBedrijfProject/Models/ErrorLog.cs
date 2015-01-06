using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.Models
{
    public class Errorlog
    {
        public int RegisterID { get; set; }
        [DisplayName("Timestamp")]
        public DateTime Timestamp { get; set; }
                [DisplayName("Message")]

        public string Message { get; set; }
                [DisplayName("Stacktrace")]

        public string Stacktrace { get; set; }
    }
}