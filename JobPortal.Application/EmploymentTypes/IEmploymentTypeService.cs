namespace JobPortal.Application.EmploymentTypes
{
    public interface IEmploymentTypeService
    {
        Task<IList<EmploymentTypeVM>> GetAllEmploymentTypeAsync();
    }
}
