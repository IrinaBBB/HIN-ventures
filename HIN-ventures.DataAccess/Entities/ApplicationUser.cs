using Microsoft.AspNetCore.Identity;

namespace HIN_ventures.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FieldOfExpertise { get; set; }   
    }
}