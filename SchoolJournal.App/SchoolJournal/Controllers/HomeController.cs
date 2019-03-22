using SchoolJournal.BusinessLogic;
using SchoolJournal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    public class HomeController : Controller
    {
        private IStudentManager manager;

        public HomeController()
        {
            manager = new StudentManager();
        }

        public ActionResult Index()
        {
            return View(manager.GetAllStudents());
        }
    }
}