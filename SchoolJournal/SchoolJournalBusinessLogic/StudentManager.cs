﻿using SchoolJournalDataAccess;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SchoolJournalBusinessLogic
{
    public class StudentManager : IStudentManager
    {
        private static SchoolJournalEntities db;

        private IList<Student> studentsList = new List<Student>();

        public StudentManager()
        {
            db = new SchoolJournalEntities();
        }

        public void Add(Student student)
        {
            db.Student.Add(student);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = this.Get(id);
            db.Student.Remove(student);
            db.SaveChanges();
        }

        public Student Get(int id)
        {
            return db.Student.Find(id);
        }

        public IList<Student> GetAllStudents()
        {
            return db.Student.Select(s => s).ToList();
        }

        public IList<Student> GetByName(string name)
        {
            return db.Student.Where(s => s.StudentName.Contains(name) || name == null).ToList();
        }

        public void Save(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
