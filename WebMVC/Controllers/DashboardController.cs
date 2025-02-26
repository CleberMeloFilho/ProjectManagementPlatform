using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementPlatform.WebMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}