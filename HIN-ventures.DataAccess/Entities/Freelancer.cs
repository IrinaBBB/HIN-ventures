using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.DataAccess.Entities
{
    [Table("freelancer")]
    public class Freelancer
    {
        [Column("freelancerid")]
        [Key]
        public int FreelancerId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your speciality")]
        [Column("Speciality")]
        public string Speciality { get; set; }

        [Column("averagerating")]
        public int AverageRating{ get; set; }
        
        [Column("totallinesofcode")]
        public int TotalLinesOfCode{ get; set; }

        [Column("linesofcodemonth")]
        public int LinesOfCodeMonth{ get; set; }

        [Column("assignments")]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
