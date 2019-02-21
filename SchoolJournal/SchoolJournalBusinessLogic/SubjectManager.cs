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
    public class SubjectManager : ISubjectManager
    {
        private static SchoolJournalEntities db;

        public SubjectManager()
        {
            db = new SchoolJournalEntities();
        }

        public IList<Subject> GetAll()
        {
            return db.Subject.Select(s => s).ToList();
        }

        public Subject Get(int id)
        {
            return db.Subject.Find(id);
        }

        public IList<Subject> GetBySubject(string subject)
        {
            return db.Subject.Where(p => p.SubjectName.Contains(subject) || subject == null).ToList();
        }

        public IList<Subject> GetByYear(string year)
        {
            int level = Convert.ToInt32(year);
            return db.Subject.Where(p => p.LevelYear == level).ToList();
        }

        public IList<Subject> GetByTeacher(string teacher)
        {
            return db.Subject.Where(p => p.Teachers.TeacherName.Contains(teacher) || teacher == null).ToList();
        }

        public void Delete(int id)
        {
            Subject subject = this.Get(id);
            db.Subject.Remove(subject);
            db.SaveChanges();
        }

        public void Add(Subject subject)
        {
            db.Subject.Add(subject);
            db.SaveChanges();
        }

        public void Save(Subject subject)
        {
            db.Entry(subject).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
