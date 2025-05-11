using JobPortal.Application.Categories;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.JobPosts;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobPostService _jobpostservice;
        private readonly ICategoryService _categoryservice;
        private readonly IEmploymentTypeService _employmentTypeService;

        public JobController(IJobPostService jobpostservice, ICategoryService categoryservice, IEmploymentTypeService employmentTypeService)
        {
            _jobpostservice = jobpostservice;
            _categoryservice = categoryservice;
            _employmentTypeService = employmentTypeService;
        }
        public async Task<IActionResult> Index(string categoryId, int page = 1, int pageSize = 10)
        {
            var result = await _jobpostservice.GetFilteredJobPostsAsync(categoryId, page, pageSize);

            var categories = await _categoryservice.GetAllCategoryAsync();
            var jobTypes = await _employmentTypeService.GetAllEmploymentTypeAsync();

            if (!string.IsNullOrEmpty(categoryId) && int.TryParse(categoryId, out int catId))
            {
                var selectedCategory = categories.FirstOrDefault(c => c.Id == catId);
                ViewBag.CategoryName = selectedCategory?.Name ?? "Unknown";
            }
            else
            {
                ViewBag.CategoryName = "All";
            }

            ViewBag.JobTypes = jobTypes;
            ViewBag.Categories = categories;
            ViewBag.TotalPages = result.TotalPages;
            ViewBag.CurrentPage = result.CurrentPage;
            ViewBag.TotalItems = result.TotalItems;

            return View(result.Items);
        }

    }
}

