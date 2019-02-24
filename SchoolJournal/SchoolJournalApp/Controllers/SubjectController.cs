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
    public class SubjectController : Controller
    {
        private ISubjectManager manager;

        public SubjectController()
        {
            manager = new SubjectManager();
        }

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Subject")
                return View(manager.GetBySubject(search).ToPagedList(pageNumber ?? 1, 5));
            else if (option == "Teacher")
                return View(manager.GetByTeacher(search).ToPagedList(pageNumber ?? 1, 5));
            else if (option == "Level")
                return View(manager.GetByYear(search).ToPagedList(pageNumber ?? 1, 5));
            else
                return View(manager.GetAll().ToPagedList(pageNumber ?? 1, 5));
        }

        public ActionResult Details(int id)
        {
            return View(manager.Get(id));
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            Subject subject = manager.Get(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
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
        public ActionResult Update(int id)
        {
            var subject = manager.Get(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "SubjectID,SubjectName,LevelYear,TeacherID")]Subject subject)
        {
            if (ModelState.IsValid)
            {
                manager.Save(subject);
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(manager.SubjectWithTeachersList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "SubjectID,SubjectName,LevelYear,TeacherID")]Subject subject)
        {
            if (ModelState.IsValid)
            {
                manager.Add(subject);
                return RedirectToAction("Index");
            }
            return View(subject);
        }
    }
}