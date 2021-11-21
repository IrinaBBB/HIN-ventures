using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class Freelancer
    {
        [Key]
        public int FreelancerId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your speciality")]
        public string Speciality { get; set; }

        public int AverageRating{ get; set; } //denne må ha egen entitet. Rating entity. Så legger vi en liste med rating her. halil
        
        public int TotalLinesOfCode{ get; set; }

        public int LinesOfCodeMonth{ get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
