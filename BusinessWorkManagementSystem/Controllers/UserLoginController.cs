using BusinessWorkManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessWorkManagementSystem.Controllers
{
    public class UserLoginController : Controller
    {

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        /// <summary>
        /// Pass data using parameters
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        public string LoginUserUsingParameters(string userName, string pass)
        {
          
            return "Using parameters: user name " + userName+" password"+ pass;
        }

        /// <summary>
        /// Pass data using request object
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string LoginUserUsingRequestObject()
        {
            var userName = Request.Form["userName"];
            string pass = Request.Form["pass"];

            return "Using Request object: user name " + userName + " password" + pass;
        }

        /// <summary>
        /// Pass data using FormCollection
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string LoginUserUsingFormCollection(IFormCollection formCollection)
        {
            var userName = formCollection["userName"];
            string pass = formCollection["pass"];

            return "Using form collection: user name " + userName + " password" + pass;
        }

        /// <summary>
        /// Pass data using Strongly binding
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string LoginUserUsingStronglyTypeModel(UserLoginViewModel userLoginViewModel)
        {
            var userName = userLoginViewModel.userName;
            string pass = userLoginViewModel.pass;

            return "Using form collection: user name " + userName + " password" + pass;
        }

        /// <summary>
        /// Pass data using javascript ajax call
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LoginUserUsingJavascriptAjaxCall(string userName, string pass)
        {
            if(userName == null || pass == null) {
                return Json(true);
            }

            return Json(false);
        }


    }

   
}
