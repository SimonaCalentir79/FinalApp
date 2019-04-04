using SchoolJournal.BusinessLogic;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolJournal.Controllers
{
    //[MyExceptionHandler]
    public class AccountController : Controller
    {
        private IUserAccountManager manager;

        public AccountController()
        {
            manager = new UserAccountManager();
        }

        //[MyExceptionHandler]
        public ActionResult Index()
        {
            return View(manager.GetAllUserAccounts().ToList());
        }

        //[MyExceptionHandler]
        public ActionResult Register()
        {
            return View();
        }

        //[MyExceptionHandler]
        [HttpPost]
        public ActionResult Register(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                manager.AddUser(userAccount);
                ModelState.Clear();
                ViewBag.Message = userAccount.FirstName + " " + userAccount.LastName + " succesufully registered.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //[MyExceptionHandler]
        public ActionResult Login()
        {
            return View();
        }

        //[MyExceptionHandler]
        [HttpPost]
        public ActionResult Login(UserAccount userAccount)
        {
            UserAccount usr = new UserAccount();
            var list = manager.GetAllUserAccounts();

            foreach (var user in list)
            {
                if (user.Username == userAccount.Username && user.Password == userAccount.Password)
                {
                    usr = userAccount;
                }
            }
            if (usr != null)
            {
                Session["UserID"] = usr.UserID.ToString();
                Session["Username"] = usr.Username.ToString();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("","Username or Password is wrong!");
                //ViewBag.Message = "Username or Password is wrong!";
                //return RedirectToAction("IndexNoUser", "Home");
            }
            return View();
        }

        //[MyExceptionHandler]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}