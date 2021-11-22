using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class Freelancer
    {
        [Key]
        public int FreelancerId { get; set; }

        public string Speciality { get; set; }

        public int TotalLinesOfCode{ get; set; }

        public int LinesOfCodeMonth{ get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
