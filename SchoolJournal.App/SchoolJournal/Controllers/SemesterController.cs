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
    public class SemesterController : Controller
    {
        private ISemesterManager manager;

        public SemesterController()
        {
            manager = new SemesterManager();
        }

        [MyExceptionHandler]
        public ActionResult Index()
        {
            return View(manager.GetAllSemesters().ToList());
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Semester semester = manager.GetSemesterByID(id);

            if (semester == null)
                return HttpNotFound();

            return View(semester);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [MyExceptionHandler]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="SemesterNumber,SchoolYear")]Semester semester)
        {
            if (ModelState.IsValid)
            {
                manager.AddSemester(semester);
                return RedirectToAction("Index");
            }
            return View(semester);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Semester semester = manager.GetSemesterByID(id);

            if (semester == null)
                return HttpNotFound();

            return View(semester);
        }

        [MyExceptionHandler]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="SemesterID,SemesterNumber,SchoolYear")]Semester semester, int? id)
        {
            if (id == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                manager.UpdateSemester(semester);
                return RedirectToAction("Index");
            }

            return View(semester);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Semester semester = manager.GetSemesterByID(id);

            if (semester == null)
                return HttpNotFound();

            return View(semester);
        }

        [MyExceptionHandler]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteSemester(id);
            return RedirectToAction("Index");
        }
    }
}