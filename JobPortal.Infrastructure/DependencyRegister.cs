using JobPortal.Application.Categories;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.JobPosts;
using JobPortal.Application.Repository;
using JobPortal.Infrastructure.Data;
using JobPortal.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.Infrastructure
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobPortalDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Connection"));
            });
            services.AddScoped<IJobPostService, JobPostService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IEmploymentTypeService, EmploymentTypeService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
