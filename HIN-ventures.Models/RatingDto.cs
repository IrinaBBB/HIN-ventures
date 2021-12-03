using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.Models
{
    public class RatingDto
    {
        public int CustomerId { get; set; }

        public int FreelancerId { get; set; }

        public int RatingValue { get; set; }
    }
}
