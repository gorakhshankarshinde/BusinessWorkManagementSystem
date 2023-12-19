using BusinessWorkManagementSystem.DataAccess.Models;
using BusinessWorkManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BusinessWorkManagementSystem.Controllers
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
            var currentUser = HttpContext.Session.GetObjectFromJson<UserModel>("CurrentUser");

            if (currentUser == null)
            {
                return RedirectToAction("UserLogin", "UserLogin");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            var currentUser = HttpContext.Session.GetObjectFromJson<UserModel>("CurrentUser");

            if (currentUser == null)
            {
                return RedirectToAction("UserLogin", "UserLogin");
            }

            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}