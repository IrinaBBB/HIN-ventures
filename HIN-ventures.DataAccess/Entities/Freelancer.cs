using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class Freelancer
    {
        [Key]
        public int FreelancerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Speciality { get; set; }
        public string Email { get; set; }

        public int TotalLinesOfCode{ get; set; } 

        public string CryptoAddress { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        [Required]
        public string IdentityId { get; set; }
    }
}
