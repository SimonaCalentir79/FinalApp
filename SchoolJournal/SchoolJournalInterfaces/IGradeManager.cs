using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SchoolJournalInterfaces
{
    public interface IGradeManager
    {
        IList<Grade> GetAll();

        IList<Grade> GetByCourse(string course);

        IList<Grade> GetByStudent(string student);

        IList<Grade> GetBySemester(string semester);

        IList<Grade> GetByStudentID(int? studentID);

        IEnumerable<SelectListItem> GetStudentsList();

        IEnumerable<SelectListItem> GetCoursesList();

        IEnumerable<SelectListItem> GetSemesterList();

        void Add(Grade grade);

        void Delete(int id);

        void Save(Grade grade);

        Grade Get(int id);

        Grade GradeWithParentsLists();
    }
}
