using AutoMapper;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.Pending
{
    public class PendingCompanyService : IPendingCompanyService
    {
        private readonly IBaseRepository<PendingCompany> _repository;
        private readonly IMapper _mapper;

        public PendingCompanyService(IBaseRepository<PendingCompany> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PendingCompanyVM> AddPendingCompanyAsync(PendingCompanyVM model)
        {
            var entity = _mapper.Map<PendingCompany>(model);
            var saved = await _repository.AddAsync(entity);
            return _mapper.Map<PendingCompanyVM>(saved);
        }

        public async Task<IEnumerable<PendingCompanyVM>> GetAllPendingCompanyAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PendingCompanyVM>>(entities);
        }

        public async Task<PendingCompanyVM> GetPendingCompanyByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<PendingCompanyVM>(entity);
        }

        public async Task DeletePendingCompanyAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}
