using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface ISemesterManager
    {
        IList<Semester> GetAllSemesters();

        IList<Semester> GetByNumber(string number);

        IList<Semester> GetByYear(string year);

        Semester Get(int id);

        void Save(Semester semester);

        void Delete(int id);

        void Add(Semester semester);
    }
}
