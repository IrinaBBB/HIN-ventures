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

        public int FreelancerId; //the freelancer customer is hiring

        public FreelancerDto FreelancerDto { get; set; } //kan bare booke en frilanser om gangen

        public AssignmentDto AssignmentDto { get; set; } //assignment som frilanseren skal bookes til

        //additional info on the customer who is booking
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string OrderStatus { get; set; }
    }
}
