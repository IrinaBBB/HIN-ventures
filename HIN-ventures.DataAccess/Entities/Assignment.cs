using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsActive { get; set; }

        public bool IsCompleted { get; set; } 

        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime? Deadline { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        [ForeignKey("FreelancerId")]
        public int? FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }

        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<CodeFile> CodeFiles { get; set; }

    }
}