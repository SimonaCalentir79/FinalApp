using SchoolJournal.BusinessLogic;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    [MyExceptionHandler]
    public class HomeController : Controller
    {
        private IStudentManager manager;

        public HomeController()
        {
            manager = new StudentManager();
        }

        [MyExceptionHandler]
        public ActionResult Index()
        {
            return View(manager.GetAllStudents());
        }

        [MyExceptionHandler]
        public ActionResult IndexNoUser()
        {
            return View();
        }
    }
}