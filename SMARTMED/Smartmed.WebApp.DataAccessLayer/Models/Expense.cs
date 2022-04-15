using System;
using System.Collections.Generic;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class Expense
    {
        public long Sno { get; set; }
        public string Field { get; set; }
        public decimal? Expense1 { get; set; }
        public DateTime? Dates { get; set; }
    }
}
