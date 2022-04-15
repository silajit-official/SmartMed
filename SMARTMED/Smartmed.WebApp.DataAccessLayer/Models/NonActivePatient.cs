using System;
using System.Collections.Generic;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class NonActivePatient
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfArrival { get; set; }
        public DateTime? ExpectedDateOfDischarge { get; set; }
        public string MedicineName { get; set; }
        public long? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
