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
    public class HomeworkManager:IHomeworkManager
    {
        private static SchoolJournalEntities db;

        public HomeworkManager()
        {
            db = new SchoolJournalEntities();
        }

        public Homework Get(int id)
        {
            return db.Homework.Find(id);
        }

        public IList<Homework> GetAll()
        {
            return db.Homework.Select(h => h).ToList();
        }

        public IList<Homework> GetByStudent(string student)
        {
            return db.Homework.Where(h => h.Students.StudentName.Contains(student) || student == null).ToList();
        }

        public IList<Homework> GetBySubject(string subject)
        {
            return db.Homework.Where(h => h.Subjects.SubjectName.Contains(subject) || subject == null).ToList();
        }

        public void Save(Homework hwork)
        {
            db.Entry(hwork).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Homework hwork)
        {
            db.Homework.Add(hwork);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Homework hwork = this.Get(id);
            db.Homework.Remove(hwork);
            db.SaveChanges();
        }
    }
}
