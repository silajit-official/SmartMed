using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.Models
{
    public class NonActivePatient
    {
        [Key]
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfArrival { get; set; }
        public DateTime? ExpectedDateOfDischarge { get; set; }
        public string MedicineName { get; set; }
        public long? DoctorId { get; set; }
    }
}
