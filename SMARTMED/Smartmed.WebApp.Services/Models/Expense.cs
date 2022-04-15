using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.Models
{
    public class Expense
    {
        [Key]
        public long Sno { get; set; }
        public string Field { get; set; }
        public decimal? Expense1 { get; set; }
        public DateTime? Dates { get; set; }
    }
}
