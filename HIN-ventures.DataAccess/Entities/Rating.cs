using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HIN_ventures.DataAccess.Entities
{
    [Table("rating")]
    public class Rating
    {
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Column("freelancer_id")]
        [Key]
        public int FreelancerId { get; set; }

        [Column("rating")]
        public int RatingValue { get; set; }

    }
}