using JobPortal.Application.Categories;
using JobPortal.Application.Companies;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.Experiences;
using JobPortal.Application.JobPosts;
using JobPortal.Application.LocationList;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.Application
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IJobPostService, JobPostService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IEmploymentTypeService, EmploymentTypeService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            return services;
        }
    }
}
