using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Data
{
    public class JobPortalDbContext:DbContext
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
    }
}
