using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the company name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the company's VAT number")]
        public string VAT_number { get; set; }

        public string CryptoAddress { get; set; }

        public int SubscriptionType { get; set; }

        public int TotalLinesOfCode { get; set; }

        public int TotalCost { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

    }
}
