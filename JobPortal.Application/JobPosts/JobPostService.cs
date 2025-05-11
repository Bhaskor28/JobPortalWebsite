using AutoMapper;
using JobPortal.Application.Categories;
using JobPortal.Application.Common;
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

        public async Task<PagedResult<JobPostVM>> GetFilteredJobPostsAsync(string? categoryId, int page, int pageSize)
        {
            var allPosts = await _jobpostservice.GetAllAsync();
            var filteredPosts = allPosts.AsQueryable();

            if (!string.IsNullOrEmpty(categoryId) && int.TryParse(categoryId, out int catId))
            {
                filteredPosts = filteredPosts.Where(j => j.JobCategoryId == catId);
            }

            var totalItems = filteredPosts.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var paged = filteredPosts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResult<JobPostVM>
            {
                Items = _mapper.Map<List<JobPostVM>>(paged),
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page
            };
        }
    }
}
