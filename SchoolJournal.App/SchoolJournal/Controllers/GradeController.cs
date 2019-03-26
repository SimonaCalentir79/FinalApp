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
    public class GradeController : Controller
    {
        private readonly IGradeManager manager;
        private readonly IPopulateList populate;

        public GradeController()
        {
            manager = new GradeManager();
            populate = new PopulateList();
        }

        public ActionResult Index()
        {
            return View(manager.GetAllGrades().ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Grade grade = manager.GetGradeByID(id);
            grade.StudentsList = populate.StudentsList();
            grade.SemestersList = populate.SemestersList();
            grade.CoursesList = populate.CoursesList();

            if (grade == null)
                return HttpNotFound();

            return View(grade);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Grade grade = new Grade();
            grade.StudentsList = populate.StudentsList();
            grade.SemestersList = populate.SemestersList();
            grade.CoursesList = populate.CoursesList();

            if (grade == null)
                return HttpNotFound();

            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,SemsterID,CourseID,Mark,DateOfMark,GradingWeight,Observations")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                manager.AddGrade(grade);
                return RedirectToAction("Index");
            }
            return View(grade);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Grade grade = manager.GetGradeByID(id);
            grade.StudentsList = populate.StudentsList();
            grade.SemestersList = populate.SemestersList();
            grade.CoursesList = populate.CoursesList();

            if (grade == null)
                return HttpNotFound();

            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradeID,StudentID,SemesterID,CourseID,Mark,DateOfMark,GradingWeight,Observations")]Grade grade, int? id)
        {
            if (id == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                manager.UpdateGrade(grade);
                return RedirectToAction("Index");
            }

            return View(grade);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Grade grade = manager.GetGradeByID(id);

            if (grade == null)
                return HttpNotFound();

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteGrade(id);
            return RedirectToAction("Index");
        }
    }
}