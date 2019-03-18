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

        public ActionResult Index(string option, string search, int? pageNumber, int? id)
        {
            try
            {
                if (option == "Subject")
                    return View(manager.GetByCourse(search).ToPagedList(pageNumber ?? 1, 5));
                else if (option == "Student")
                    return View(manager.GetByStudent(search).ToPagedList(pageNumber ?? 1, 5));
                else if (option == "Status")
                    return View(manager.GetByStatus(search).ToPagedList(pageNumber ?? 1, 5));
                else if (id != null)
                    return View(manager.GetByStudentId(id).ToPagedList(pageNumber ?? 1, 5));
                else
                    return View(manager.GetAll().ToPagedList(pageNumber ?? 1, 5));
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error:" + ex.Message.ToString();
            }
            return View(manager.GetAll().ToPagedList(pageNumber ?? 1, 5));
        }

        public ActionResult Details(int id)
        {
            try
            {
                return View(manager.Get(id));
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error:" + ex.Message.ToString();
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Delete(id);
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error:" + ex.Message.ToString();
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
        public ActionResult Update([Bind(Include = "HomeworkID,StudentID,CourseID,DateOfHomework,DueDate,Details,HomeworkStatus")]Homework homework)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Save(homework);
                    return RedirectToAction("Index");
                }

                //return View(homework);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error:" + ex.Message.ToString();
            }
            return View(homework);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Homework homework = manager.HWwithSubjStudList();
            ViewBag.CurrentHW = homework;

            return View(homework);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Homework hwork)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Add(hwork);
                    return RedirectToAction("Index");
                }
                //return View(hwork);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error:" + ex.Message.ToString();
            }
            return View(hwork);
        }
    }
}