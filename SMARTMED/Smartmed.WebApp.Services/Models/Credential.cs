using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartmed.WebApp.Services.Models
{
    public class Credential
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public decimal? PhoneNumber { get; set; }
        public decimal? JobRole { get; set; }
    }
}
