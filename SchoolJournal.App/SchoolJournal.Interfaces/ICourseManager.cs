using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolJournal.Interfaces
{
    public interface ICourseManager
    {
        IEnumerable<Course> GetAllCourses();

        Course GetCourseByID(int? id);

        void AddCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(int? id);
    }
}
