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
            var currentUser = HttpContext.Session.GetObjectFromJson<UserModel>("CurrentUser");

            if (currentUser == null)
            {
                return RedirectToAction("UserLogin", "UserLogin");
            }

            return View();
        }

        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var currentUser = HttpContext.Session.GetObjectFromJson<UserModel>("CurrentUser");

            if(currentUser == null)
            {
                return RedirectToAction("UserLogin","UserLogin");
            }

            int loginUserId = Convert.ToInt32(currentUser.UserId);
            string loginUserName = Convert.ToString(currentUser.UserFirstName);


            UserMaster userMaster = new UserMaster();
            userMaster.users = userData.GetUserList();

            //ViewData["UserList"] = userData.GetUserList();
            return View(userMaster);
        }
    }
}
