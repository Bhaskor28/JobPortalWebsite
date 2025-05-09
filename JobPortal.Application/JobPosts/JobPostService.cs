using AutoMapper;
using JobPortal.Application.Categories;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.JobPosts
{
    public class JobPostService : IJobPostService
    {
        private readonly IBaseRepository<JobPost> _jobpostservice;
        private readonly IMapper _mapper;

        public JobPostService(IBaseRepository<JobPost> jobpostservice, IMapper mapper)
        {
            _jobpostservice = jobpostservice;
            _mapper = mapper;
        }
        public async Task<IList<JobPostVM>> GetAllJobPostAsync()
        {
            var jobPosts = await _jobpostservice.GetAllAsync();
            return _mapper.Map<IList<JobPostVM>>(jobPosts);
        }
    }
}
