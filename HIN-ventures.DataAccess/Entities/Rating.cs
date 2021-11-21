using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HIN_ventures.DataAccess.Entities
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        public int CustomerId { get; set; }

        public int FreelancerId { get; set; }

        public int RatingValue { get; set; }

    }
}