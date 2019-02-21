using SchoolJournalDataAccess;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

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
            return db.Grade.Find(id);
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
