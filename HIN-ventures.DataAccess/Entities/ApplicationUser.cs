using Microsoft.AspNetCore.Identity;

namespace HIN_ventures.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? FreelancerId { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}