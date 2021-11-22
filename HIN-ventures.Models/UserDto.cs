using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.Models
{
    public class UserDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
