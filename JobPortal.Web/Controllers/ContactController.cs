using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
