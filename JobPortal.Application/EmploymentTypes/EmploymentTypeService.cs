using AutoMapper;
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
        public async Task<IList<EmploymentTypeVM>> GetAllEmploymentTypeAsync()
        {
            var employments = await _employment.GetAllAsync();
            return _mapper.Map<IList<EmploymentTypeVM>>(employments);
        }
    }
}
