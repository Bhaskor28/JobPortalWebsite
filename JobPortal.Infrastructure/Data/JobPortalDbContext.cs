using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure.Data
{
    public class JobPortalDbContext : DbContext
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobPortalDbContext).Assembly);
        }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PendingCompany> PendingCompanies { get; set; }

    }
}
