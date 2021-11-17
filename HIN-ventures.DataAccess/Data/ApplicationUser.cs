using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HIN_ventures.DataAccess.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
