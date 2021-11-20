using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.DataAccess.Entities
{
    [Table("customer")]
    public class Customer
    {
        [Column("customer_id")] 
        [Key] 
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the company name")]
        [Column("customer_name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the company's VAT number")]
        [Column("vat")]
        public string VAT_number { get; set; }

        [Required(ErrorMessage = "Please enter the company's email number")]
        [Column("email")]
        public string Email { get; set; }

        [Column("total_lines_of_code")]
        public int TotalLinesOfCode { get; set; }

        [Column("total_cost")]
        public int TotalCost { get; set; }

        [Column("portals")] public virtual ICollection<Portal> Portals { get; set; } //der denne kunden er abonnert på, halil
        
        [Column("assignments")] public virtual ICollection<Assignment> Assignments { get; set; }

        [Column("ratings")] public virtual ICollection<Rating> Ratings { get; set; }


    }
}
