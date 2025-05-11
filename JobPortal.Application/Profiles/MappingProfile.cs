using AutoMapper;
using JobPortal.Application.Categories;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.JobPosts;
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
        }
    }
}
