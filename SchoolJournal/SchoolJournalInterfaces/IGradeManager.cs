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

        IList<Grade> GetBySubject(string subject);

        IList<Grade> GetByStudent(string student);

        IList<Grade> GetBySemester(string semester);

        IList<Grade> GetByGradeCategory(string gradectg);

        void Delete(int id);

        void Add(Grade grade);

        void Save(Grade grade);
    }
}
