namespace JobPortal.Application.Pending
{
    public interface IPendingCompanyService
    {
        Task<PendingCompanyVM> AddPendingCompanyAsync(PendingCompanyVM model);
        Task<IEnumerable<PendingCompanyVM>> GetAllPendingCompanyAsync();
        Task<PendingCompanyVM> GetPendingCompanyByIdAsync(int id);
        Task DeletePendingCompanyAsync(int id);
    }
}
