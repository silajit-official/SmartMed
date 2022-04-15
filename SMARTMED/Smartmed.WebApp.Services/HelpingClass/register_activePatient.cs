using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.HelpingClass
{
    public class register_activePatient
    {
        public string bedno { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long phone_no { get; set; }
        public long doctor_id { get; set; }
    }
}
