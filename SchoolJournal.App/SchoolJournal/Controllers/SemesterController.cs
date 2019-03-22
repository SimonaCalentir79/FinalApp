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
    public class SemesterController : Controller
    {
        private ISemesterManager manager;

        public SemesterController()
        {
            manager = new SemesterManager();
        }

        public ActionResult Index()
        {
            return View(manager.GetAllSemesters().ToList());
        }

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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteSemester(id);
            return RedirectToAction("Index");
        }
    }
}