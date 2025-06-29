using JobPortal.Application.Categories;
using JobPortal.Application.Companies;
using JobPortal.Application.EmploymentTypes;
using JobPortal.Application.Experiences;
using JobPortal.Application.JobPosts;
using JobPortal.Application.LocationList;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobPostService _jobposts;
        private readonly ICategoryService _categories;
        private readonly ICompanyService _company;
        private readonly IEmploymentTypeService _employment;
        private readonly ILocationService _locationService;
        private readonly IExperienceService _experienceService;

        public JobController(IJobPostService jobposts, ICategoryService category, ICompanyService company, IEmploymentTypeService employment, ILocationService locationService, IExperienceService experienceService)
        {
            _jobposts = jobposts;
            _categories = category;
            _company = company;
            _employment = employment;
            _locationService = locationService;
            _experienceService = experienceService;
        }
        public async Task<IActionResult> Index(List<int> selectedEmploymentTypes, List<int> selectedExperienceList, int categoryId, int locationId, int pageNumber = 1)
        {
            int pageSize = 7;
            ViewBag.Categories = await _categories.GetAllCategoryAsync();
            ViewBag.EmploymentTypes = await _employment.GetAllEmploymentTypeAsync();
            ViewBag.Locations = await _locationService.GetAllLocationAsync();
            ViewBag.Experiences = await _experienceService.GetAllExperienceAsync();
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.SelectedLocationId = locationId;
            ViewBag.SelectedEmploymentTypes = selectedEmploymentTypes;
            ViewBag.SelectedExperienceList = selectedExperienceList;
            var pagedJobposts = await _jobposts.GetPagedFilteredJobpostAsync(selectedEmploymentTypes, selectedExperienceList, categoryId, locationId, pageNumber, pageSize);
            return View(pagedJobposts);
        }
        public async Task<IActionResult> Details(int id)
        {
            var jobpost = await _jobposts.GetJobpostByIdAsync(id);
            if (jobpost == null)
            {
                return NotFound();
            }
            ViewBag.Company = await _company.GetCompanyByIdAsync(jobpost.CompanyId);
            ViewBag.EmploymentType = await _employment.GetEmploymentTypeByIdAsync(jobpost.EmploymentTypeId);
            ViewBag.Locations = await _locationService.GetLocationByIdAsync(jobpost.LocationId);
            return View(jobpost);
        }

    }
}

