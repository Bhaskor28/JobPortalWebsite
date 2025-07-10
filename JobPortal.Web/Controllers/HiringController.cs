using JobPortal.Application.Categories;
using JobPortal.Application.Companies;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.Experiences;
using JobPortal.Application.JobPosts;
using JobPortal.Application.LocationList;
using JobPortal.Application.Pending;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class HiringController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ICompanyService _companyService;
        private readonly IJobPostService _jobPostService;
        private readonly ICategoryService _categoryService;
        private readonly IEmploymentTypeService _employmentTypeService;
        private readonly IExperienceService _experienceService;
        private readonly IPendingCompanyService _pendingCompanyService;

        public HiringController(ILocationService locationService, ICompanyService companyService, IJobPostService jobPostService, ICategoryService CategoryService, IEmploymentTypeService employmentTypeService, IExperienceService experienceService, IPendingCompanyService pendingCompanyService)
        {
            _locationService = locationService;
            _companyService = companyService;
            _jobPostService = jobPostService;
            _categoryService = CategoryService;
            _employmentTypeService = employmentTypeService;
            _experienceService = experienceService;
            _pendingCompanyService = pendingCompanyService;
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
            ViewBag.Locations = await _locationService.GetAllLocationAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(JobPostVM jobpost)
        {
            ViewBag.Companies = await _companyService.GetAllCompanyAsync();
            ViewBag.JobCategories = await _categoryService.GetAllCategoryAsync();
            ViewBag.EmploymetTypes = await _employmentTypeService.GetAllEmploymentTypeAsync();
            ViewBag.Experience = await _experienceService.GetAllExperienceAsync();
            jobpost.CreatedAt = DateTime.Now;
            await _jobPostService.AddJobPostAsync(jobpost);
            
            return RedirectToAction("Index", "Job");
        }

        [HttpGet]
        public IActionResult RegisterCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCompany(PendingCompanyVM company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            company.CreatedAt = DateTime.Now;
            await _pendingCompanyService.AddPendingCompanyAsync(company);

            return RedirectToAction("CreatePost");
        }
    }
}
