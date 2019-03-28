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
    public class TeacherController : Controller
    {
        private ITeacherManager manager;

        public TeacherController()
        {
            manager = new TeacherManager();
        }
        
        [MyExceptionHandler]
        public ActionResult Index()
        {
            return View(manager.GetAllTeachers().ToList());
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Teacher teacher = manager.GetTeacherByID(id);
            if (teacher == null)
                return HttpNotFound();
            return View(teacher);
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
        public ActionResult Create([Bind(Include ="TeacherName,TeacherEmail,TeacherPhone")]Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                manager.AddTeacher(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Teacher teacher = manager.GetTeacherByID(id);

            if (teacher == null)
                return HttpNotFound();
            return View(teacher);
        }

        [MyExceptionHandler]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherID,TeacherName,TeacherEmail,TeacherPhone")]Teacher teacher, int? id)
        {
            if (id == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                manager.UpdateTeacher(teacher);
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Teacher teacher = manager.GetTeacherByID(id);

            if (teacher == null)
                return HttpNotFound();
            return View(teacher);
        }

        [MyExceptionHandler]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteTeacher(id);
            return RedirectToAction("Index");
        }
    }
}