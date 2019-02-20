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
    public class SemesterManager:ISemesterManager
    {
        private static SchoolJournalEntities db;

        private IList<Semester> semestersList = new List<Semester>();

        public SemesterManager()
        {
            db = new SchoolJournalEntities();
        }

        public void Add(Semester semester)
        {
            db.Semester.Add(semester);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Semester semester = this.Get(id);
            db.Semester.Remove(semester);
            db.SaveChanges();
        }

        public Semester Get(int id)
        {
            return db.Semester.Find(id);
        }

        public IList<Semester> GetAllSemesters()
        {
            return db.Semester.Select(s => s).ToList();
        }

        public IList<Semester> GetByNumber(string number)
        {
            int newNo = Convert.ToInt32(number);
            return db.Semester.Where(s => s.SemesterNumber == newNo).ToList();
        }

        public IList<Semester> GetByYear(string year)
        {
            return db.Semester.Where(s => s.SchoolYear.Contains(year) || year == null).ToList();
        }

        public void Save(Semester semester)
        {
            db.Entry(semester).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
