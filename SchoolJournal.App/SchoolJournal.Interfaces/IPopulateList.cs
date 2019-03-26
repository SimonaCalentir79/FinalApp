using System.Collections.Generic;
using System.Web.Mvc;

namespace SchoolJournal.Interfaces
{
    public interface IPopulateList
    {
        IEnumerable<SelectListItem> TeachersList();

        IEnumerable<SelectListItem> StudentsList();

        IEnumerable<SelectListItem> CoursesList();

        IEnumerable<SelectListItem> SemestersList();
    }
}
