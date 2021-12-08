using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.Models
{
    public class RatingDto
    {
        public int CustomerId { get; set; }

        public int FreelancerId { get; set; }

        [Range(0,5)]
        public int RatingValue { get; set; }
    }
}
