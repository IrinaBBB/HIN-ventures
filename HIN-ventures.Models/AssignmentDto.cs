using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HIN_ventures.DataAccess.Entities;

namespace HIN_ventures.Models
{
    public class AssignmentDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1, 3000)]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime? Deadline { get; set; }

        public Freelancer Freelancer { get; set; }

        public virtual ICollection<CodeFile> CodeFiles { get; set; }
    }
}