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
        
        [Required] public string UserId { get; set; } //the customer

        
        //public int FreelancerId; //the freelancer customer is hiring

        //nav properties
        //[ForeignKey("FreelancerId")]
        public Freelancer Freelancer { get; set; } //kan bare booke en frilanser om gangen

        //[ForeignKey("Id")]
        public Assignment Assignment { get; set; } //må opprette en ny assignment

        //additional info on the customer who is booking
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Phone { get; set; }

        public string OrderStatus { get; set; }

    }
}
