using System;
using System.Collections.Generic;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class Bill
    {
        public long Sno { get; set; }
        public string BedNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Reason { get; set; }
        public DateTime? Dates { get; set; }
    }
}
