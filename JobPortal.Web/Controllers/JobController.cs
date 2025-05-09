using JobPortal.Application.Categories;
using JobPortal.Application.JobPosts;
using JobPortal.Application.Repository;
using JobPortal.Domain.Entities;
using JobPortal.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobPostService _jobpostservice;
        private readonly ICategoryService _categoryservice;

        public JobController(IJobPostService jobpostservice,ICategoryService categoryservice)
        {
            _jobpostservice = jobpostservice;
            _categoryservice = categoryservice;
        }
        public async Task<IActionResult> Index(string categoryId,int page = 1, int pageSize = 10)
        {
            IEnumerable<JobPostVM> allItems = await _jobpostservice.GetAllJobPostAsync();
            var categories = await _categoryservice.GetAllCategoryAsync();
            if (!string.IsNullOrEmpty(categoryId))
            {
                int catId = int.Parse(categoryId);
                allItems = allItems.Where(j => j.JobCategoryId == catId);
                
                var selectedCategory = categories.FirstOrDefault(c => c.Id == catId);
                ViewBag.CategoryName = selectedCategory?.Name ?? "Unknown";
            }
            else
            {
                ViewBag.CategoryName = "All";
            }
            var totalItems = allItems.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var pagedItems = allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.Categories = categories;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItems = totalItems;
            return View(pagedItems);
        }
    }
}
