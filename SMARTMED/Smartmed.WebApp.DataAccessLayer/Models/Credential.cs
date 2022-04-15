using System;
using System.Collections.Generic;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class Credential
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public decimal? PhoneNumber { get; set; }
        public decimal? JobRole { get; set; }
    }
}
