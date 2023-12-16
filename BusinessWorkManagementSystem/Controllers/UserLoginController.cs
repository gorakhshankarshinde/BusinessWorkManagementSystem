﻿using BusinessWorkManagementSystem.DataAccess;
using BusinessWorkManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BusinessWorkManagementSystem.Controllers
{
    public class UserLoginController : Controller
    {

        IUserData userData;
        IPasswordEncryptionDecryption passwordEncryptionDecryption;

        public UserLoginController()
        {
            userData = new UserData();
            passwordEncryptionDecryption = new PasswordEncryptionDecryption();
        }


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
        public string LoginUserUsingJavascriptAjaxCall(string userName, string pass)
        {
            try
            {
                UserMaster userMaster = new UserMaster();
                userMaster.users = userData.GetUserList();

                if (userName == null || pass == null) {
                    return "login failed.";
                }

                if (IsUserExist(userMaster, userName, pass))
                {
                   
                    return "Login success.";
                }
            }
            catch (Exception)
            {

                return "login failed.";
            }


            return "login failed.";

        }

        private bool IsUserExist(UserMaster userMaster, string? userName, string? pass)
        {
            bool isUserExist = false;
            if (userMaster != null)
            {
                isUserExist = userMaster.users.Any(
                    user => user.UserEmailAddress == userName &&
                    passwordEncryptionDecryption.DecryptPassword("GorakhShankarShinde1991PuneIndia", user.UserPassword) == pass &&
                    user.Active== true);

                if (isUserExist) 
                {
                    ViewData["CurrentUser"] = userMaster.users.Where(user => user.UserEmailAddress == userName &&
                    passwordEncryptionDecryption.DecryptPassword("GorakhShankarShinde1991PuneIndia", user.UserPassword) == pass &&
                    user.Active == true).FirstOrDefault();

                    return isUserExist;
                }
            }

            return isUserExist;
        }
    }

   
}
