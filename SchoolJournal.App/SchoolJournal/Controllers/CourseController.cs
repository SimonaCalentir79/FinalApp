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
    public class CourseController : Controller
    {
        private readonly ICourseManager manager;
        private readonly IPopulateList populate;

        public CourseController()
        {
            manager = new CourseManager();
            populate = new PopulateList();
        }

        public ActionResult Index()
        {
            return View(manager.GetAllCourses().ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Course course = manager.GetCourseByID(id);
            course.TeachersList = populate.TeachersList();

            if (course == null)
                return HttpNotFound();

            return View(course);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Course course = new Course();
            course.TeachersList = populate.TeachersList();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="CourseName,LevelYear,TeacherID")] Course course)
        {
            if (ModelState.IsValid)
            {
                manager.AddCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Course course = manager.GetCourseByID(id);
            course.TeachersList = populate.TeachersList();

            if (course == null)
                return HttpNotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="CourseID,CourseName,LevelYear,TeacherID")]Course course, int? id)
        {
            if (id == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                manager.UpdateCourse(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Course course = manager.GetCourseByID(id);

            if (course == null)
                return HttpNotFound();

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}