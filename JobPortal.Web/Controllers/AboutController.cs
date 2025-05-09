using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
