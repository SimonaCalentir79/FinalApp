using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class GradeController : Controller
    {
        private IGradeManager manager;

        public GradeController()
        {
            manager = new GradeManager();
        }

        public ActionResult Index(string option, string search, int? pageNumber, int? id)
        {
            if (option == "Subject")
                return View(manager.GetByCourse(search).ToPagedList(pageNumber ?? 1, 5));
            else if (option == "Student")
                return View(manager.GetByStudent(search).ToPagedList(pageNumber ?? 1, 5));
            else if (option == "Semester")
                return View(manager.GetBySemester(search).ToPagedList(pageNumber ?? 1, 5));
            else if(id != null)
                return View(manager.GetByStudentID(id).ToPagedList(pageNumber ?? 1, 5));
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

            if (manager.Get(id) == null)
                return HttpNotFound();

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
        public ActionResult Update(int id)
        {
            if (manager.Get(id) == null)
                return HttpNotFound();

            return View(manager.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "GradeID,StudentID,SemesterID,CourseID,CategoryID,Mark,DateOfMark,GradingWeight,Observations")]Grade grade)
        {
            if (ModelState.IsValid)
            {
                manager.Save(grade);
                return RedirectToAction("Index");
            }
            return View(grade);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(manager.GradeWithParentsLists());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "GradeID,StudentID,SemesterID,CourseID,CategoryID,Mark,DateOfMark,GradingWeight,Observations")]Grade grade)
        {
            if (ModelState.IsValid)
            {
                manager.Add(grade);
                return RedirectToAction("Index");
            }
            return View(grade);
        }
    }
}