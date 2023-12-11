using BusinessWorkManagementSystem.DataAccess;
using BusinessWorkManagementSystem.DataAccess.Models;
using BusinessWorkManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessWorkManagementSystem.Controllers
{
    public class UserController : Controller
    {
        IUserData userData;

        public UserController() 
        {
            userData = new UserData();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            UserMaster userMaster = new UserMaster();
            userMaster.users = userData.GetUserList();

            //ViewData["UserList"] = userData.GetUserList();
            return View(userMaster);
        }
    }
}
