using AutoMapper;
using JobPortal.Application.Categories;
using JobPortal.Application.JobPosts;
using JobPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobPost, JobPostVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
        }
    }
}
