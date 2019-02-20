using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SchoolJournalDataAccess;
using SchoolJournalInterfaces;
using SchoolJournalModels;

namespace SchoolJournalBusinessLogic
{
    public class TeacherManager:ITeacherManager
    {
        private static SchoolJournalEntities db;

        private IList<Teacher> teachersList = new List<Teacher>();

        public TeacherManager()
        {
            db = new SchoolJournalEntities();

        }

        public IList<Teacher> GetAllTeachers()
        {
            return db.Teacher.Select(p => p).ToList();
        }

        public IList<Teacher> GetByName(string name)
        {
            return db.Teacher.Where(p => p.TeacherName.Contains(name) || name == null).ToList();
        }

        public Teacher Get(int id)
        {
            return db.Teacher.Find(id);
        }

        public void Save(Teacher teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = this.Get(id);
            db.Teacher.Remove(teacher);
            db.SaveChanges();
        }

        public void Add(Teacher teacher)
        {
            db.Teacher.Add(teacher);
            db.SaveChanges();
        }

        //public string[] GetSubjects()
        //{
        //    return db.Subject.Select(s => s.SubjectName).ToArray();
        //}

        //public void AddSchoolSubject(Subject subject)
        //{
        //    subject.TeacherID = 1;
        //    db.Subject.Add(subject);
        //    db.SaveChanges();
        //}

        //public void AddHomework(Homework homework)
        //{
        //    homework.StudentID = 1;
        //    homework.SubjectID = 1;
        //    db.Homework.Add(homework);
        //    db.SaveChanges();
        //}

    }
}
