﻿using SchoolJournal.BusinessLogic;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly IHomeworkManager manager;
        private readonly IPopulateList populate;

        public HomeworkController()
        {
            manager = new HomeworkManager();
            populate = new PopulateList();
        }

        public ActionResult Index()
        {
            return View(manager.GetAllHomeworks().ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Homework homework = manager.GetHomeworkByID(id);
            homework.StudentsList = populate.StudentsList();
            homework.CoursesList = populate.CoursesList();

            if (homework == null)
                return HttpNotFound();

            return View(homework);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Homework homework = new Homework();
            homework.StudentsList = populate.StudentsList();
            homework.CoursesList = populate.CoursesList();

            return View(homework);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,CourseID,DateOfHomework,DueDate,Details,HomeworkStatus")] Homework homework)
        {
            if (ModelState.IsValid)
            {
                manager.AddHomework(homework);
                return RedirectToAction("Index");
            }
            return View(homework);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Homework homework = manager.GetHomeworkByID(id);
            homework.StudentsList = populate.StudentsList();
            homework.CoursesList = populate.CoursesList();

            if (homework == null)
                return HttpNotFound();

            return View(homework);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HomeworkID,StudentID,CourseID,DateOfHomework,DueDate,Details,HomeworkStatus")]Homework homework, int? id)
        {
            if (id == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                manager.UpdateHomework(homework);
                return RedirectToAction("Index");
            }

            return View(homework);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Homework homework = manager.GetHomeworkByID(id);

            if (homework == null)
                return HttpNotFound();

            return View(homework);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteHomework(id);
            return RedirectToAction("Index");
        }
    }
}