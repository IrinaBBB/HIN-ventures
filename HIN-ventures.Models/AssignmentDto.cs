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

        public bool IsActive { get; set; }//Tells if the assigment has a freelancer working on it and not available to others. <---ny

        public bool IsCompleted { get; set; } //Tells if the assignment is completed. Set by admin/Hin-Ventures. Related to senior control. <---ny

        [Range(1, 3000)]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime? Deadline { get; set; }

        public int? FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<CodeFile> CodeFiles { get; set; }
    }
}