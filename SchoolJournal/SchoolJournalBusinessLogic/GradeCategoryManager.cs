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
    public class GradeCategoryManager : IGradeCategoryManager
    {
        private static SchoolJournalEntities db;

        private IList<GradeCategory> gradeCategoryList = new List<GradeCategory>();

        public GradeCategoryManager()
        {
            db = new SchoolJournalEntities();
        }

        public void Add(GradeCategory gradeCtg)
        {
            db.GradeCategory.Add(gradeCtg);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            GradeCategory gradeCtg = this.Get(id);
            db.GradeCategory.Remove(gradeCtg);
            db.SaveChanges();
        }

        public GradeCategory Get(int id)
        {
            return db.GradeCategory.Find(id);
        }

        public IList<GradeCategory> GetAllCategories()
        {
            return db.GradeCategory.Select(gc => gc).ToList();
        }

        public IList<GradeCategory> GetByName(string name)
        {
            return db.GradeCategory.Where(gc => gc.CategoryName.Contains(name) || name == null).ToList();
        }

        public void Save(GradeCategory gradeCtg)
        {
            db.Entry(gradeCtg).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
