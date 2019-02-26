using Model;
using Repository;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProject.ViewModels;

namespace WebProject.Controllers
{
    public class UserController : Controller
    {
        private DBManager db;

        public UserController()
        {
            this.db = new DBManager();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Password = model.Password,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth
            };

            db.UserRepository.InsertUser(user);
            db.UserRepository.Save();
            FormsAuthentication.SetAuthCookie(model.UserName, true);
            ViewBag.Success = "Welcome to Weeds!";

            return RedirectToAction("Index", "Weed");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            var user = db.UserRepository.AuthenticateUser(userName, password);
            //TODO: Implement Make Sure User with such name and password exists.
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                ViewBag.Success = "Welcome To Our Site!";

                return PartialView("LoggedInGreeting", user.UserName);
            }
            ModelState.AddModelError("UserName", "User not does not exist in our database, please check and try again!");
            ViewBag.Success = "Login Failed";
            return PartialView();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Weed");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return PartialView("LoggedInGreeting", HttpContext.User.Identity.Name);
            }
            else
            {
                return PartialView();
            }
        }
    }
}