using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagementApp.Models;
using UserManagementApp.Models.ViewModels;

namespace UserManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dummyListofUsers = new List<UserToReturnViewModel>()
            {
                new UserToReturnViewModel{Id= "1",FirstName="Kenedy", LastName="Tariah", Email="Kenedyt@sample.com",PhotoUrl="" },
                new UserToReturnViewModel{Id= "2",FirstName="Murphy", LastName="Ogbeide", Email="Murphyo@sample.com",PhotoUrl="" },
                new UserToReturnViewModel{Id= "3",FirstName="Abereowo", LastName="Kayode", Email="Aberowok@sample.com",PhotoUrl="" },
                new UserToReturnViewModel{Id= "4",FirstName="Babatunde", LastName="Mustapha", Email="Babatundem@sample.com",PhotoUrl="" },
                new UserToReturnViewModel{Id= "5",FirstName="Godwin", LastName="Ozioko", Email="Godwino@sample.com",PhotoUrl="" }, 
                new UserToReturnViewModel{Id= "6",FirstName="Ozoeze", LastName="Boniface", Email="Ozoezeb@sample.com",PhotoUrl="" }

            };

            return View(dummyListofUsers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}