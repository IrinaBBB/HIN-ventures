using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.DataAccess.Entities;

namespace HIN_ventures.Models
{
    public class BookingDetailsDto
    {
        public int Id { get; set; } //Order id
        
        public string UserId { get; set; } //the customer

        [Required] public int FreelancerId; //the freelancer customer is hiring

        public Freelancer Freelancer { get; set; } //kan bare booke en frilanser om gangen

        public Assignment Assignment { get; set; } //assignment som frilanseren skal bookes til

        //additional info on the customer who is booking
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Phone { get; set; }

        public string OrderStatus { get; set; }
    }
}
