using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface ISemestersManager
    {
        IList<Semesters> GetAllSemesters();

        IList<Semesters> GetByNumber(string number);

        IList<Semesters> GetByYear(string year);

        Semesters Get(int id);

        void Save(Semesters semester);

        void Delete(int id);

        void Add(Semesters semester);
    }
}
