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
    public class SemestersManager:ISemestersManager
    {
        private static SchoolJournalEntities db;

        private IList<Semesters> semestersList = new List<Semesters>();

        public SemestersManager()
        {
            db = new SchoolJournalEntities();
        }

        public void Add(Semesters semester)
        {
            db.Semesters.Add(semester);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Semesters semester = this.Get(id);
            db.Semesters.Remove(semester);
            db.SaveChanges();
        }

        public Semesters Get(int id)
        {
            return db.Semesters.Find(id);
        }

        public IList<Semesters> GetAllSemesters()
        {
            return db.Semesters.Select(s => s).ToList();
        }

        public IList<Semesters> GetByNumber(string number)
        {
            int newNo = Convert.ToInt32(number);
            return db.Semesters.Where(s => s.SemesterNumber == newNo/* || number == null*/).ToList();
        }

        public IList<Semesters> GetByYear(string year)
        {
            return db.Semesters.Where(s => s.SchoolYear.Contains(year) || year == null).ToList();
        }

        public void Save(Semesters semester)
        {
            db.Entry(semester).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
