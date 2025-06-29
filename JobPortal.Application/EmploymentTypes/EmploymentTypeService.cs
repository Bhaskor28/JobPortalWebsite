using AutoMapper;
using JobPortal.Application.Common.PaginatedLists;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.EmploymentTypes
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly IBaseRepository<EmploymentType> _employment;
        private readonly IMapper _mapper;

        public EmploymentTypeService(IBaseRepository<EmploymentType> employment, IMapper mapper)
        {
            _employment = employment;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmploymentTypeVM>> GetAllEmploymentTypeAsync()
        {
            var employmentTypes = await _employment.GetAllAsync();
            return _mapper.Map<IEnumerable<EmploymentTypeVM>>(employmentTypes);
        }

        public async Task<EmploymentTypeVM> GetEmploymentTypeByIdAsync(int employmentTypeId)
        {
            var employmentType = await _employment.GetByIdAsync(employmentTypeId);
            return _mapper.Map<EmploymentTypeVM>(employmentType);
        }

        public Task<PaginatedList<EmploymentTypeVM>> GetPagedEmploymentTypeAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
