using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BDProblems.Models
{
    public class User : IdentityUser
    {
        public string Username { get; set; }
    }
}
