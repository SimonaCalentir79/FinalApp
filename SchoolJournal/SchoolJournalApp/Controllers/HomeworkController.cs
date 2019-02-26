using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class HomeworkController : Controller
    {
        private IHomeworkManager manager;

        public HomeworkController()
        {
            manager = new HomeworkManager();
        }

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            try
            {
                if (option == "Subject")
                    return View(manager.GetByCourse(search).ToPagedList(pageNumber ?? 1, 5));
                else if (option == "Student")
                    return View(manager.GetByStudent(search).ToPagedList(pageNumber ?? 1, 5));
                else
                    return View(manager.GetAll().ToPagedList(pageNumber ?? 1, 5));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "HomeworkController", "Index"));
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                return View(manager.Get(id));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "HomeworkController", "Details"));
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Delete(id);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "HomeworkController", "Delete"));
            }
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
        public ActionResult Update([Bind(Include = "HomeworkID,StudentID,CourseID,DateOfHomework,DueDate,Details,HomeworkStatus")]Homework homework)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Save(homework);
                    return RedirectToAction("Index");
                }
                return View(homework);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "HomeworkController", "Update"));
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(manager.HWwithSubjStudList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "HomeworkID,StudentID,CourseID,DateOfHomework,DueDate,Details,HomeworkStatus")]Homework hwork)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Add(hwork);
                    return RedirectToAction("Index");
                }
                return View(hwork);
            }
            catch (ArgumentNullException nullex)
            {
                return View("Error", new HandleErrorInfo(nullex, "HomeworkController", "Add"));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "HomeworkController", "Add"));
            }
        }
    }
}