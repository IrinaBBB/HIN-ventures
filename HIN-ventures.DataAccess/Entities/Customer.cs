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

        [Required(ErrorMessage = "Please enter the company's VAT number")]
        public string VAT_number { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

       public virtual ICollection<Rating> Ratings { get; set; }

    }
}
