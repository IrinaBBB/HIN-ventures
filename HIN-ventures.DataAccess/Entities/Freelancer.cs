using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class Freelancer
    {
        [Key]
        public int FreelancerId { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public int TotalLinesOfCode{ get; set; }

        public string CryptoAddress { get; set; }

        public int LinesOfCodeMonth{ get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
