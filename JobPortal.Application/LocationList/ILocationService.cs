using JobPortal.Application.Common.PaginatedLists;
using JobPortal.Application.JobPosts;

namespace JobPortal.Application.LocationList
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationVM>> GetAllLocationAsync();
        Task<PaginatedList<LocationVM>> GetPagedLocationeAsync(int pageNumber, int pageSize);
        Task<LocationVM> GetLocationByIdAsync(int locationId);
        Task<LocationVM?> GetByNameAsync(string name);
        Task<LocationVM> AddLocationAsync(LocationVM location);
    }
}
