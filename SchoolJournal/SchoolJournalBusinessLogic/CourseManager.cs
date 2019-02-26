using SchoolJournalDataAccess;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SchoolJournalBusinessLogic
{
    public class CourseManager : ICourseManager
    {
        private static SchoolJournalEntities db;

        public CourseManager()
        {
            db = new SchoolJournalEntities();
        }

        public Course CourseWithTeachersList()
        {
            Course course = new Course();
            course.TeachersList = db.Teacher.Select(t => new SelectListItem { Value = t.TeacherID.ToString(), Text = t.TeacherName }).ToList();

            return course;
        }

        public IList<Course> GetAll()
        {
            return db.Course.Select(s => s).ToList();
        }

        public Course Get(int id)
        {
            //return db.Subject.Find(id);
            Course course = db.Course.Find(id);
            course.TeachersList = db.Teacher.Select(t => new SelectListItem { Value = t.TeacherID.ToString(), Text = t.TeacherName }).ToList();

            return course;
        }

        public IList<Course> GetByCourse(string course)
        {
            return db.Course.Where(p => p.CourseName.Contains(course) || course == null).ToList();
        }

        public IList<Course> GetByYear(string year)
        {
            int level = Convert.ToInt32(year);
            return db.Course.Where(p => p.LevelYear == level).ToList();
        }

        public IList<Course> GetByTeacher(string teacher)
        {
            return db.Course.Where(p => p.Teachers.TeacherName.Contains(teacher) || teacher == null).ToList();
        }

        public void Delete(int id)
        {
            Course course = this.Get(id);
            db.Course.Remove(course);
            db.SaveChanges();
        }

        public void Add(Course course)
        {
            db.Course.Add(course);
            db.SaveChanges();
        }

        public void Save(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
