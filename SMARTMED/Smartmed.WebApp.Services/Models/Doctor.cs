using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.Models
{
    public class Doctor
    {
        public Doctor()
        {
            ActivePatient = new HashSet<ActivePatient>();
            NonActivePatient = new HashSet<NonActivePatient>();
        }
        [Key]
        public long DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string CertifiedIn { get; set; }
        public long PhoneNo { get; set; }

        public virtual ICollection<ActivePatient> ActivePatient { get; set; }
        public virtual ICollection<NonActivePatient> NonActivePatient { get; set; }
    }
}
