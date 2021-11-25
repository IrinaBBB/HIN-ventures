using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.DataAccess.Entities;

namespace HIN_ventures.Models
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the company name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the company's VAT number")]
        public string VAT_number { get; set; }

        [Required(ErrorMessage = "Please enter the company's email number")]
        public string Email { get; set; }
        public string CryptoAddress { get; set; }

        public int TotalLinesOfCode { get; set; }

        public int TotalCost { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
