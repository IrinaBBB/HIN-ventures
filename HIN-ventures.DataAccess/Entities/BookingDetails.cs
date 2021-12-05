using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.DataAccess.Entities
{
    public class BookingDetails
    {
        public int Id { get; set; }

        public Freelancer Freelancer { get; set; }
        public Customer Customer { get; set; }
        public Assignment Assignment { get; set; } 

        [Required] public string UserId { get; set; } //kunden
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Phone { get; set; }

        public string OrderStatus { get; set; }

    }
}
