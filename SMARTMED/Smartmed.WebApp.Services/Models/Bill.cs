using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.Models
{
    public class Bill
    {
        [Key]
        public long Sno { get; set; }
        public string BedNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Reason { get; set; }
        public DateTime? Dates { get; set; }
    }
}
