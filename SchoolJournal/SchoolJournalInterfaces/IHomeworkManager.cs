using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SchoolJournalInterfaces
{
    public interface IHomeworkManager
    {
        IList<Homework> GetByCourse(string course);

        IList<Homework> GetByStudent(string student);

        IList<Homework> GetByStatus(string status);

        IList<Homework> GetAll();

        IList<Homework> GetByStudentId(int? id);

        IEnumerable<SelectListItem> GetStudentsList(Homework hwork);

        IEnumerable<SelectListItem> GetCoursesList(Homework hwork);

        void Delete(int id);

        void Add(Homework hwork);

        void Save(Homework hwork);

        Homework Get(int id);

        Homework HWwithSubjStudList();
    }
}
