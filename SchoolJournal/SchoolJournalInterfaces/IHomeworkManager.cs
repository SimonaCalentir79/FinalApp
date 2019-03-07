using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SchoolJournalInterfaces
{
    public interface IHomeworkManager
    {
        IList<Homework> GetAll();

        IEnumerable<SelectListItem> GetStudentsList(Homework hwork);

        IEnumerable<SelectListItem> GetCoursesList(Homework hwork);

        Homework Get(int id);

        IList<Homework> GetByCourse(string course);

        IList<Homework> GetByStudent(string student);

        void Delete(int id);

        void Add(Homework hwork);

        void Save(Homework hwork);

        Homework HWwithSubjStudList();
    }
}
