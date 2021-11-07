using HIN_ventures.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HIN_ventures.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}