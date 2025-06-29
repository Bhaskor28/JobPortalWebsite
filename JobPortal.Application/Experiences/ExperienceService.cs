using AutoMapper;
using JobPortal.Application.Common.PaginatedLists;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private readonly IBaseRepository<Experience> _experienceService;
        private readonly IMapper _mapper;

        public ExperienceService(IBaseRepository<Experience> experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExperienceVM>> GetAllExperienceAsync()
        {
            var experiences = await _experienceService.GetAllAsync();
            return _mapper.Map<IEnumerable<ExperienceVM>>(experiences);
        }

        public async Task<ExperienceVM> GetExperienceByIdAsync(int experienceId)
        {
            var experience = await _experienceService.GetByIdAsync(experienceId);
            return _mapper.Map<ExperienceVM>(experience);
        }

        public Task<PaginatedList<ExperienceVM>> GetPagedExperienceAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
