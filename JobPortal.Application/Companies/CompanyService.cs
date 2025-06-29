using AutoMapper;
using JobPortal.Application.Common.PaginatedLists;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IBaseRepository<Company> _companyService;
        private readonly IMapper _mapper;

        public CompanyService(IBaseRepository<Company> companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<CompanyVM> AddCompanyAsync(CompanyVM model)
        {
            var entity = _mapper.Map<Company>(model);
            var savedEntity = await _companyService.AddAsync(entity);
            return _mapper.Map<CompanyVM>(savedEntity);
        }

        public async Task<IEnumerable<CompanyVM>> GetAllCompanyAsync()
        {
            var companies = await _companyService.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyVM>>(companies);
        }

        public async Task<CompanyVM> GetCompanyByIdAsync(int compnayId)
        {
            var company = await _companyService.GetByIdAsync(compnayId);
            return _mapper.Map<CompanyVM>(company);

        }

        public Task<PaginatedList<CompanyVM>> GetPagedCompanyAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }


    }
}
