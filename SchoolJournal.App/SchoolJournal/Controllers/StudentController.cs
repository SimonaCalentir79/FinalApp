using SchoolJournal.BusinessLogic;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    public class StudentController : Controller
    {
        private IStudentManager manager;

        public StudentController()
        {
            manager = new StudentManager();
        }

        public ActionResult Index()
        {
            return View(manager.GetAllStudents().ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Student student = manager.GetStudentByID(id);

            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentName,StudentPhoto,Observations")]Student student, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                student.StudentPhoto = Path.GetFileName(file.FileName);
                manager.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Student student = manager.GetStudentByID(id);

            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,StudentPhoto,Observations")]Student student, int? id)
        {
            if (id == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                manager.UpdateStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Student student = manager.GetStudentByID(id);

            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}