using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.Data.Configurations
{
    public class JobPostConfiguration : IEntityTypeConfiguration<JobPost>
    {
        public void Configure(EntityTypeBuilder<JobPost> builder)
        {
            builder.HasOne(j => j.Category)
                .WithMany(c => c.JobPosts)
                .HasForeignKey(j => j.JobCategoryId);


            builder.HasOne(j => j.Company)
                .WithMany(c => c.JobPosts)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
