using JobPortal.Application.Common.PaginatedLists;

namespace JobPortal.Application.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyVM>> GetAllCompanyAsync();
        Task<PaginatedList<CompanyVM>> GetPagedCompanyAsync(int pageNumber, int pageSize);
        Task<CompanyVM> GetCompanyByIdAsync(int compnayId);
        Task<CompanyVM> AddCompanyAsync(CompanyVM model);
        Task<CompanyVM> UpdateCompanyAsync(CompanyVM model);

    }
}
