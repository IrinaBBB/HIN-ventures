using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    [Table("freelancer")]
    public class Freelancer
    {
        [Column("freelancer_id")]
        [Key]
        public int FreelancerId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your speciality")]
        [Column("speciality")]
        public string Speciality { get; set; }

        [Column("average_rating")]
        public int AverageRating{ get; set; } //denne må ha egen entitet. Rating entity. Så legger vi en liste med rating her. halil
        
        [Column("total_lines_of_code")]
        public int TotalLinesOfCode{ get; set; }

        [Column("lines_of_code_month")]
        public int LinesOfCodeMonth{ get; set; }

        [Column("assignments")]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
