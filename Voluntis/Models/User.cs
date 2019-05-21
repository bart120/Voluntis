using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Models
{
    public class User : IdentityUser
    {
        
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
