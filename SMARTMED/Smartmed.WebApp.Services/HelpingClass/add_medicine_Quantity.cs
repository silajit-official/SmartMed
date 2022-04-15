using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.HelpingClass
{
    public class add_medicine_Quantity
    {
        public string MedicineName { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? Cost { get; set; }
        public int Rebate { get; set; }
    }
}
