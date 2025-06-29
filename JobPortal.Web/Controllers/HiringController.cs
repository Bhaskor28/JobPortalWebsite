using JobPortal.Application.Categories;
using JobPortal.Application.Companies;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.Experiences;
using JobPortal.Application.JobPosts;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class HiringController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IJobPostService _jobPostService;
        private readonly ICategoryService _categoryService;
        private readonly IEmploymentTypeService _employmentTypeService;
        private readonly IExperienceService _experienceService;

        public HiringController(ICompanyService companyService, IJobPostService jobPostService, ICategoryService CategoryService, IEmploymentTypeService employmentTypeService, IExperienceService experienceService)
        {
            _companyService = companyService;
            _jobPostService = jobPostService;
            _categoryService = CategoryService;
            _employmentTypeService = employmentTypeService;
            _experienceService = experienceService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreatePost()
        {
            ViewBag.Companies = await _companyService.GetAllCompanyAsync();
            ViewBag.JobCategories = await _categoryService.GetAllCategoryAsync();
            ViewBag.EmploymetTypes = await _employmentTypeService.GetAllEmploymentTypeAsync();
            ViewBag.Experience = await _experienceService.GetAllExperienceAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(JobPostVM jobpost)
        {
            ViewBag.Companies = await _companyService.GetAllCompanyAsync();
            ViewBag.JobCategories = await _categoryService.GetAllCategoryAsync();
            ViewBag.EmploymetTypes = await _employmentTypeService.GetAllEmploymentTypeAsync();
            ViewBag.Experience = await _experienceService.GetAllExperienceAsync();
            await _jobPostService.AddJobPostAsync(jobpost);
            return RedirectToAction("Index", "Job");
        }

        [HttpGet]
        public IActionResult RegisterCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCompany(CompanyVM company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            await _companyService.AddCompanyAsync(company);

            return RedirectToAction("CreatePost");
        }
    }
}
