using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface ISubjectManager
    {
        IList<Subject> GetAll();

        Subject Get(int id);

        IList<Subject> GetBySubject(string subject);

        IList<Subject> GetByYear(string year);

        IList<Subject> GetByTeacher(string teacher);

        void Delete(int id);

        void Add(Subject subject);

        void Save(Subject subject);

        Subject SubjectWithTeachersList();
    }
}
