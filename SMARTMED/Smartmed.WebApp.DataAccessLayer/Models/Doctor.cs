using System;
using System.Collections.Generic;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            ActivePatient = new HashSet<ActivePatient>();
            NonActivePatient = new HashSet<NonActivePatient>();
        }

        public long DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string CertifiedIn { get; set; }
        public long PhoneNo { get; set; }

        public virtual ICollection<ActivePatient> ActivePatient { get; set; }
        public virtual ICollection<NonActivePatient> NonActivePatient { get; set; }
    }
}
