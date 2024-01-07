using Microsoft.AspNetCore.Mvc;

namespace UserManagementApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManageUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManageRole()
        {
            return View();
        }
    }
}
