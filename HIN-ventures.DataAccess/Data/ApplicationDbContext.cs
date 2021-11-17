using HIN_ventures.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HIN_ventures.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CodeFile> CodeFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Freelancer>().ToTable("freelancer")
                .HasMany(a => a.Assignments);

            modelBuilder.Entity<Assignment>().ToTable("assignment")
                .HasOne(f => f.Freelancer)
                .WithMany(a => a.Assignments)
                .HasForeignKey(k => k.FreelancerId);
                
                

        }
    }
}