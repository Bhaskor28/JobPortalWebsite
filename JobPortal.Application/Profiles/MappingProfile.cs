using AutoMapper;
using JobPortal.Application.Categories;
using JobPortal.Application.Companies;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.Experiences;

using JobPortal.Application.JobPosts;
using JobPortal.Application.LocationList;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobPost, JobPostVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<EmploymentType, EmploymentTypeVM>().ReverseMap();
            CreateMap<Company, CompanyVM>().ReverseMap();
            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<Experience, ExperienceVM>().ReverseMap();

        }
    }
}
