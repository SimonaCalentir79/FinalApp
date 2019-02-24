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

        public Grade Get(int id)
        {
            //return db.Grade.Find(id);
            Grade grade = db.Grade.Find(id);

            grade.StudentsList = db.Student
                .Select(s => new SelectListItem { Value = s.StudentID.ToString(), Text = s.StudentName })
                .ToList();
            grade.SubjectsList = db.Subject
                .Select(s => new SelectListItem { Value = s.SubjectID.ToString(), Text = s.SubjectName+"/cls. "+s.LevelYear })
                .ToList();
            grade.SemestersList = db.Semester
                .Select(s => new SelectListItem { Value = s.SemesterID.ToString(), Text = s.SemesterNumber.ToString()+"/"+s.SchoolYear })
                .ToList();
            grade.GradeCategoriesList = db.GradeCategory
                .Select(g => new SelectListItem { Value = g.CategoryID.ToString(), Text = g.CategoryName + "/" + g.Share.ToString() })
                .ToList();

            return grade;
        }

        public Grade GradeWithParentsLists()
        {
            Grade grade = new Grade();
            grade.StudentsList = db.Student
                .Select(s => new SelectListItem { Value = s.StudentID.ToString(), Text = s.StudentName })
                .ToList();
            grade.SubjectsList = db.Subject
                .Select(s => new SelectListItem { Value = s.SubjectID.ToString(), Text = s.SubjectName + "/cls. " + s.LevelYear })
                .ToList();
            grade.SemestersList = db.Semester
                .Select(s => new SelectListItem { Value = s.SemesterID.ToString(), Text = s.SemesterNumber.ToString() + "/" + s.SchoolYear })
                .ToList();
            grade.GradeCategoriesList = db.GradeCategory
                .Select(g => new SelectListItem { Value = g.CategoryID.ToString(), Text = g.CategoryName + "/" + g.Share.ToString() })
                .ToList();

            return grade;
        }

        public IList<Grade> GetAll()
        {
            return db.Grade.Select(g => g).ToList();
        }

        public IList<Grade> GetByGradeCategory(string gradectg)
        {
            return db.Grade.Where(g => g.GradeCategories.CategoryName.Contains(gradectg) || gradectg == null).ToList();
        }

        public IList<Grade> GetBySemester(string semester)
        {
            return db.Grade.Where(g => g.Semesters.SemesterNumber == Convert.ToInt32(semester)).ToList();
        }

        public IList<Grade> GetByStudent(string student)
        {
            return db.Grade.Where(g => g.Students.StudentName.Contains(student) || student == null).ToList();
        }

        public IList<Grade> GetBySubject(string subject)
        {
            return db.Grade.Where(g => g.Subjects.SubjectName.Contains(subject) || subject == null).ToList();
        }

        public void Save(Grade grade)
        {
            db.Entry(grade).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
