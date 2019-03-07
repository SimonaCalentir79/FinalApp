using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalInterfaces
{
    public interface IStudentManager
    {
        IList<Student> GetAllStudents();

        IList<Student> GetByName(string name);

        Student Get(int id);

        void Save(Student student);

        void Delete(int id);

        void Add(Student student);

        string GetPhotoName(int id);
    }
}
