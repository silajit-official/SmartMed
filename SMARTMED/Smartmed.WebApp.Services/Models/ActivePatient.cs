using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.Models
{
    public class ActivePatient
    {
        [Key]
        public long Sno { get; set; }
        public string BedNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfArrival { get; set; }
        public DateTime? ExpectedDateOfDischarge { get; set; }
        public decimal? Bill { get; set; }
        public string MedicineName { get; set; }
        public decimal? PhoneNo { get; set; }
        public decimal? MedicineCost { get; set; }
        public long? DoctorId { get; set; }

       
    }
}
