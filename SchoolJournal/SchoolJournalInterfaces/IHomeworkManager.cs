using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface IHomeworkManager
    {
        IList<Homework> GetAll();

        Homework Get(int id);

        IList<Homework> GetBySubject(string subject);

        IList<Homework> GetByStudent(string student);

        void Delete(int id);

        void Add(Homework hwork);

        void Save(Homework hwork);

        Homework HWwithSubjStudList();
    }
}
