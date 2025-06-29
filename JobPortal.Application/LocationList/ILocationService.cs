using JobPortal.Application.Common.PaginatedLists;

namespace JobPortal.Application.LocationList
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationVM>> GetAllLocationAsync();
        Task<PaginatedList<LocationVM>> GetPagedLocationeAsync(int pageNumber, int pageSize);
        Task<LocationVM> GetLocationByIdAsync(int locationId);
    }
}
