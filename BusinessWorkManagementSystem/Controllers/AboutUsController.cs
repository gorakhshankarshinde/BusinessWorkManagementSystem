using Microsoft.AspNetCore.Mvc;

namespace BusinessWorkManagementSystem.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult GetAboutUs()
        {
            return View();
        }
    }
}
