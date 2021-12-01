using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HIN_ventures.DataAccess.Entities;

namespace HIN_ventures.Models
{
    public class FreelancerDto
    {
        public int FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public string Speciality { get; set; }

        public int AverageRating{ get ; set ; }

        public int TotalLinesOfCode { get; set; }

        public string CryptoAddress { get; set; }

        public int LinesOfCodeMonth { get; set; }

        public bool IsActive { get; set; } = false;

        public virtual ICollection<Assignment> Assignments { get; set; }
      
        public virtual ICollection<Rating> Ratings { get; set; }

        public static implicit operator FreelancerDto(Freelancer v)
        {
            throw new NotImplementedException();
        }

        [Required]
        public string IdentityId { get; set; }

    }
}
