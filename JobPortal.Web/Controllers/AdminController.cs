using JobPortal.Application.Companies;
using JobPortal.Application.LocationList;
using JobPortal.Application.Pending;
using JobPortal.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ILocationService _locationService;
        private readonly IPendingCompanyService _pendingCompanyService;

        public AdminController(ICompanyService companyService, ILocationService locationService, IPendingCompanyService pendingCompanyService)
        {
            _companyService = companyService;
            _locationService = locationService;
            _pendingCompanyService = pendingCompanyService;
        }
        public async Task<IActionResult> Dashboard()
        {
            var item = await _pendingCompanyService.GetAllPendingCompanyAsync();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeCompanyStatus(int companyId, CompanyStatus status)
        {
            var pendingCompany = await _pendingCompanyService.GetPendingCompanyByIdAsync(companyId);
            if (pendingCompany == null)
                return NotFound();
            pendingCompany.Status = status;
            if (status == CompanyStatus.Approved)
            {
                var company = new CompanyVM
                {
                    Name = pendingCompany.Name,
                    Website = pendingCompany.Website,
                    Email = pendingCompany.Email,
                    Phone = pendingCompany.Phone,
                    Address = pendingCompany.Address,
                    CompanySize = pendingCompany.CompanySize,
                    About = pendingCompany.About,
                    LogoPath = pendingCompany.LogoPath,
                    Status = CompanyStatus.Approved
                };
                await _companyService.AddCompanyAsync(company);
                if (!string.IsNullOrWhiteSpace(company.Address))
                {
                    var locationExists = await _locationService.GetByNameAsync(company.Address);
                    if (locationExists == null)
                    {
                        await _locationService.AddLocationAsync(new LocationVM
                        {
                            Name = company.Address
                        });
                    }
                }
            }

            // Delete from pending table regardless of approval/decline
            await _pendingCompanyService.DeletePendingCompanyAsync(companyId);
            return RedirectToAction("Dashboard");
        }
        public async Task<IActionResult> ViewPendingCompany(int id)
        {
            var company = await _pendingCompanyService.GetPendingCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

    }
}
