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
    public class HomeworkManager:IHomeworkManager
    {
        private static SchoolJournalEntities db;

        public HomeworkManager()
        {
            db = new SchoolJournalEntities();
        }

        public Homework HWwithSubjStudList()
        {
            Homework hwork = new Homework();
            hwork.StudentsList = db.Student.Select(s => new SelectListItem { Value = s.StudentID.ToString(), Text = s.StudentName }).ToList();
            hwork.SubjectsList = db.Subject.Select(s => new SelectListItem { Value = s.SubjectID.ToString(), Text = s.SubjectName }).ToList();

            return hwork;
        }

        public Homework Get(int id)
        {
            //return db.Homework.Find(id);
            Homework hwork = db.Homework.Find(id);
            hwork.StudentsList = db.Student.Select(s => new SelectListItem { Value = s.StudentID.ToString(), Text = s.StudentName }).ToList();
            hwork.SubjectsList = db.Subject.Select(s => new SelectListItem { Value = s.SubjectID.ToString(), Text = s.SubjectName }).ToList();

            return hwork;
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
