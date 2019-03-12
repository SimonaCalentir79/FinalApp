using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface IGradeManager
    {
        IList<Grade> GetAll();

        Grade Get(int id);

        IList<Grade> GetByCourse(string course);

        IList<Grade> GetByStudent(string student);

        IList<Grade> GetBySemester(string semester);

        IList<Grade> GetByStudentID(int studentID);

        void Delete(int id);

        void Add(Grade grade);

        void Save(Grade grade);

        Grade GradeWithParentsLists();
    }
}
