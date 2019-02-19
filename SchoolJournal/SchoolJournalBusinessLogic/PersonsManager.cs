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
    public class PersonsManager:IPersonsManager
    {
        private static SchoolJournalEntities db;

        private IList<Persons> personsList = new List<Persons>();

        public PersonsManager()
        {
            db = new SchoolJournalEntities();
        }

        public IList<Persons> GetAllPersons()
        {
            return db.Persons.Select(p => p).ToList();
        }

        public IList<Persons> GetByName(string name)
        {
            return db.Persons.Where(p => p.PersonName.Contains(name) || name == null).ToList();
        }

        public IList<Persons> GetByAddress(string address)
        {
            return db.Persons.Where(p => p.PersonAddress.Contains(address) || address == null).ToList();
        }

        public Persons Get(int id)
        {
            return db.Persons.Find(id);
        }

        public void Save(Persons person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Persons person = this.Get(id);
            db.Persons.Remove(person);
            db.SaveChanges();
        }

        public void Add(Persons person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

        public string[] GetSubjects()
        {
            return db.Subjects.Select(s => s.SubjectName).ToArray();
        }

        public void AddSchoolSubject(Subjects subject)
        {
            subject.TeacherID = 1;
            db.Subjects.Add(subject);
            db.SaveChanges();
        }

        public void AddHomework(Homework homework)
        {
            homework.StudentID = 1;
            homework.SubjectID = 1;
            db.Homework.Add(homework);
            db.SaveChanges();
        }

    }
}
