using JobPortal.Application.Common.PaginatedLists;

namespace JobPortal.Application.EmploymentTypes
{
    public interface IEmploymentTypeService
    {
        Task<IEnumerable<EmploymentTypeVM>> GetAllEmploymentTypeAsync();
        Task<PaginatedList<EmploymentTypeVM>> GetPagedEmploymentTypeAsync(int pageNumber, int pageSize);
        Task<EmploymentTypeVM> GetEmploymentTypeByIdAsync(int employmentTypeId);
    }
}
