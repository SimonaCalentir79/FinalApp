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
    public class TimetableController : Controller
    {
        private readonly ITimetableManager manager;
        private readonly IPopulateList populate;

        public TimetableController()
        {
            manager = new TimetableManager();
            populate = new PopulateList();
        }

        [MyExceptionHandler]
        public ActionResult Index(int? id)
        {
            if (id != null)
                return View(manager.GetTimetableByStudentID(id).ToList());
            return View(manager.GetAllTimetables().ToList());
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Timetable timetable = manager.GetTimetableByID(id);
            timetable.StudentsList = populate.StudentsList();
            timetable.CoursesList = populate.CoursesList();

            if (timetable == null)
                return HttpNotFound();

            return View(timetable);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Create()
        {
            Timetable timetable = new Timetable();
            timetable.StudentsList = populate.StudentsList();
            timetable.CoursesList = populate.CoursesList();

            return View(timetable);
        }

        [MyExceptionHandler]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,DayOfTheWeek,TimeInterval,CourseID")]Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                manager.AddTimetable(timetable);
                return RedirectToAction("Index");
            }
            return View(timetable);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Timetable timetable = manager.GetTimetableByID(id);
            timetable.StudentsList = populate.StudentsList();
            timetable.CoursesList = populate.CoursesList();

            if (timetable == null)
                return HttpNotFound();

            return View(timetable);
        }

        [MyExceptionHandler]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimetableID,StudentID,DayOfTheWeek,TimeInterval,CourseID")]Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                manager.UpdateTimetable(timetable);
                return RedirectToAction("Index");
            }
            return View(timetable);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Timetable timetable = manager.GetTimetableByID(id);
            return View(timetable);
        }

        [MyExceptionHandler]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteTimetable(id);
            return RedirectToAction("Index");
        }
    }
}