using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal.Application.Common.PaginatedLists;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;

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

        public async Task<JobPostVM> AddJobPostAsync(JobPostVM jobPost)
        {
            var newPost = _mapper.Map<JobPost>(jobPost);
            var savePost = await _jobpostservice.AddAsync(newPost);
            return _mapper.Map<JobPostVM>(savePost);

        }

        public async Task<IEnumerable<JobPostVM>> GetAllJobPostAsync()
        {
            var jobPosts = await _jobpostservice.GetAllAsync();
            return _mapper.Map<IEnumerable<JobPostVM>>(jobPosts);
        }

        public async Task<JobPostVM> GetJobpostByIdAsync(int jobId)
        {
            var jobpost = await _jobpostservice.GetByIdAsync(jobId);
            return _mapper.Map<JobPostVM>(jobpost);
        }

        public async Task<PaginatedList<JobPostVM>> GetPagedFilteredJobpostAsync(List<int> selectedEmploymentTypes, List<int> selectedExperienceList, int? categoryId, int? locationId, int pageNumber, int pageSize)
        {
            var query = _jobpostservice.GetQueryable();
            if (categoryId.HasValue && categoryId.Value > 0)
            {

                query = query.Where(j => j.JobCategoryId == categoryId.Value);
            }

            if (locationId.HasValue && locationId.Value > 0)
            {

                query = query.Where(j => j.LocationId == locationId.Value);
            }
            if (selectedEmploymentTypes != null && selectedEmploymentTypes.Count > 0)
            {
                if (!selectedEmploymentTypes.Contains(0)) // "Any-Type" means skip filter
                {
                    query = query.Where(j => selectedEmploymentTypes.Contains(j.EmploymentTypeId));
                }
            }
            if (selectedExperienceList != null && selectedExperienceList.Count > 0)
            {
                if (!selectedExperienceList.Contains(0)) // "Any-Type" means skip filter
                {
                    query = query.Where(j => selectedExperienceList.Contains(j.ExperienceId));
                }
            }

            var projectedQuery = query.ProjectTo<JobPostVM>(_mapper.ConfigurationProvider);
            var pagedJobposts = PaginatedList<JobPostVM>.CreatePagination(projectedQuery, pageNumber, pageSize);
            return await Task.FromResult(pagedJobposts);
        }
    }
}
