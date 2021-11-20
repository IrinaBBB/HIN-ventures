using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    [Table("Assignment")]
    public class Assignment
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }

        [Column("category")]
        [Required]
        public string Category { get; set; }

        [Column("deadline")]
        [Required]
        public DateTime? Deadline { get; set; }

        [Column("created_by")]
        public string CreatedBy { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("updated_by")]
        public string UpdatedBy { get; set; }

        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("FreelancerId")]
        public int FreelancerId { get; set; }

        [Column("freelancer")]
        public Freelancer Freelancer { get; set; }

        public virtual ICollection<CodeFile> CodeFiles { get; set; }

    }
}