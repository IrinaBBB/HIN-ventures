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

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        
        public string Speciality { get; set; }

        public int AverageRating{ get ; set ; }

        public int TotalLinesOfCode { get; set; }

        public string CryptoAddress { get; set; }

        public int LinesOfCodeMonth { get; set; }

        public bool IsAvailable { get; set; } = true; 

        public virtual ICollection<Assignment> Assignments { get; set; }
      
        public virtual ICollection<Rating> Ratings { get; set; }

        [Required]
        public string IdentityId { get; set; }

    }
}
