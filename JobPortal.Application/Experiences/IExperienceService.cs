using JobPortal.Application.Common.PaginatedLists;

namespace JobPortal.Application.Experiences
{
    public interface IExperienceService
    {
        Task<IEnumerable<ExperienceVM>> GetAllExperienceAsync();
        Task<PaginatedList<ExperienceVM>> GetPagedExperienceAsync(int pageNumber, int pageSize);
        Task<ExperienceVM> GetExperienceByIdAsync(int experienceId);
    }
}
