using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentManager manager;

        public StudentController()
        {
            manager = new StudentManager();
        }

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Name")
                return View(manager.GetByName(search).ToPagedList(pageNumber ?? 1, 5));
            else
                return View(manager.GetAllStudents().ToPagedList(pageNumber ?? 1, 5));
        }

        public ActionResult Details(int id)
        {
            return View(manager.Get(id));
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (manager.Get(id) == null)
            {
                return HttpNotFound();
            }
            return View(manager.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "StudentId,StudentName")]Student student)
        {
            if (ModelState.IsValid)
            {
                manager.Save(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            if (manager.Get(id) == null)
            {
                return HttpNotFound();
            }
            return View(manager.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                manager.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id, saveChangesError = true });
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "StudentId,StudentName")]Student student)
        {
            if (ModelState.IsValid)
            {
                manager.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}