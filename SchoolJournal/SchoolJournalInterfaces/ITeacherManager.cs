using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface ITeacherManager
    {
        IList<Teacher> GetAllTeachers();

        IList<Teacher> GetByName(string name);

        Teacher Get(int id);

        void Save(Teacher teacher);

        void Delete(int id);

        void Add(Teacher teacher);

        //void AddSchoolSubject(Subject subject);

        //void AddHomework(Homework homework);

        //string[] GetSubjects();
    }
}
