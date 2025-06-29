using JobPortal.Application.Common.PaginatedLists;
namespace JobPortal.Application.JobPosts
{
    public interface IJobPostService
    {
        Task<IEnumerable<JobPostVM>> GetAllJobPostAsync();
        Task<PaginatedList<JobPostVM>> GetPagedFilteredJobpostAsync(List<int> selectedEmploymentTypes, List<int> selectedExperienceList, int? categoryId, int? locationId, int pageNumber, int pageSize);
        Task<JobPostVM> GetJobpostByIdAsync(int jobId);
        Task<JobPostVM> AddJobPostAsync(JobPostVM jobPost);
    }
}
