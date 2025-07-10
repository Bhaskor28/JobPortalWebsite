using AutoMapper;
using JobPortal.Application.Common.PaginatedLists;
using JobPortal.Application.JobPosts;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.LocationList
{
    public class LocationService : ILocationService
    {
        private readonly IBaseRepository<Location> _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(IBaseRepository<Location> locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LocationVM>> GetAllLocationAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LocationVM>>(locations);
        }

        public async Task<LocationVM> GetLocationByIdAsync(int locationId)
        {
            var location = await _locationRepository.GetByIdAsync(locationId);
            return _mapper.Map<LocationVM>(location);
        }

        public Task<PaginatedList<LocationVM>> GetPagedLocationeAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<LocationVM?> GetByNameAsync(string name)
        {
            var location = await _locationRepository.FindAsync(loc => loc.Name.ToLower() == name.ToLower());
            return _mapper.Map<LocationVM>(location);
        }
        public async Task<LocationVM> AddLocationAsync(LocationVM location)
        {
            var newLocation = _mapper.Map<Location>(location);
            var saveLocation = await _locationRepository.AddAsync(newLocation);
            return _mapper.Map<LocationVM>(saveLocation);

        }

    }
}
