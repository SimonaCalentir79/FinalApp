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
    public class GradeManager : IGradeManager
    {
        private static SchoolJournalEntities db;

        public GradeManager()
        {
            db = new SchoolJournalEntities();
        }

        public void Add(Grade grade)
        {
            db.Grade.Add(grade);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Grade.Remove(this.Get(id));
            db.SaveChanges();
        }

        public void Save(Grade grade)
        {
            db.Entry(grade).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetStudentsList()
        {
            return db.Student.Select(s => new SelectListItem { Value = s.StudentID.ToString(), Text = s.StudentName }).ToList();
        }

        public IEnumerable<SelectListItem> GetCoursesList()
        {
            return db.Course.Select(c => new SelectListItem { Value = c.CourseID.ToString(), Text = c.CourseName+"/cls. "+c.LevelYear }).ToList();
        }

        public IEnumerable<SelectListItem> GetSemesterList()
        {
            return db.Semester.Select(sem => new SelectListItem { Value = sem.SemesterID.ToString(), Text = sem.SemesterNumber.ToString() + "/" + sem.SchoolYear }).ToList();
        }

        public Grade Get(int id)
        {
            //return db.Grade.Find(id);
            Grade grade = db.Grade.Find(id);

            grade.StudentsList = GetStudentsList();
            grade.CoursesList = GetCoursesList();
            grade.SemestersList = GetSemesterList();

            return grade;
        }

        public Grade GradeWithParentsLists()
        {
            Grade grade = new Grade();
            grade.StudentsList = GetStudentsList();
            grade.CoursesList = GetCoursesList();
            grade.SemestersList = GetSemesterList();

            return grade;
        }

        public IList<Grade> GetAll()
        {
            return db.Grade.Select(g => g).ToList();
        }

        public IList<Grade> GetBySemester(string semester)
        {
            return db.Grade.Where(g => g.Semesters.SemesterNumber == Convert.ToInt32(semester)).ToList();
        }

        public IList<Grade> GetByStudent(string student)
        {
            return db.Grade.Where(g => g.Students.StudentName.Contains(student) || student == null).ToList();
        }

        public IList<Grade> GetByCourse(string course)
        {
            return db.Grade.Where(g => g.Courses.CourseName.Contains(course) || course == null).ToList();
        }

        public IList<Grade> GetByStudentID(int? studentID)
        {
            return db.Grade.Where(g => g.Students.StudentID==studentID).ToList();
        }
    }
}
