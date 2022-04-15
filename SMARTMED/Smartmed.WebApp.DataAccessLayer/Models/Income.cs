using System;
using System.Collections.Generic;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class Income
    {
        public long Sno { get; set; }
        public string Field { get; set; }
        public decimal? Income1 { get; set; }
        public DateTime? Dates { get; set; }
    }
}
