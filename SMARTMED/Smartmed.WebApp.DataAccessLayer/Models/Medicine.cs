using System;
using System.Collections.Generic;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class Medicine
    {
        public string MedicineName { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? Cost { get; set; }
    }
}
