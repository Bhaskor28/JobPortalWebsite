using AutoMapper;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _context;
        private readonly IMapper _mapper;

        public CategoryService(IBaseRepository<Category> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<CategoryVM>> GetAllCategoryAsync()
        {
            var categories = await _context.GetAllAsync();
            return _mapper.Map<IList<CategoryVM>>(categories);
        }
    }
}
