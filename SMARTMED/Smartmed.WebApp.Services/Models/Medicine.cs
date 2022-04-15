using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.Models
{
    public class Medicine
    {
        [Key]
        public string MedicineName { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? Cost { get; set; }
    }
}
