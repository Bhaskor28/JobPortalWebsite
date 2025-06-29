namespace JobPortal.Application.Categories
{
    public interface ICategoryService
    {
        Task<IList<CategoryVM>> GetAllCategoryAsync();
    }
}
