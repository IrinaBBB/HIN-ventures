using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    [Table("portal")]
    public class Portal
    {
        [Column("portal_id")]
        [Key]
        public int PortalId { get; set; }

        [Required(ErrorMessage = "Please enter the portal name")]
        [Column("portal_name")]
        public string Name { get; set; }

        [Column("assignments")] public virtual ICollection<Assignment> Assignments { get; set; }

        [Column("customers")] public virtual ICollection<Customer> Customers { get; set; }

    }
}