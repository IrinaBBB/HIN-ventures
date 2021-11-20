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

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<CodeFile> CodeFiles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Portal> Portals { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customer")
                .HasMany(a => a.Portals);
            modelBuilder.Entity<Customer>().ToTable("Customer")
                .HasMany(a => a.Assignments);
            modelBuilder.Entity<Customer>().ToTable("Customer")
                .HasMany(a => a.Ratings);

            modelBuilder.Entity<Freelancer>().ToTable("Freelancer")
                .HasMany(a => a.Assignments);

            modelBuilder.Entity<Assignment>().ToTable("Assignments")
                .HasOne(f => f.Freelancer)
                .WithMany(a => a.Assignments)
                .HasForeignKey(k => k.FreelancerId);

        }
    }
}