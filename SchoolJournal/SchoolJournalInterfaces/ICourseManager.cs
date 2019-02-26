using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface ICourseManager
    {
        IList<Course> GetAll();

        Course Get(int id);

        IList<Course> GetByCourse(string subject);

        IList<Course> GetByYear(string year);

        IList<Course> GetByTeacher(string teacher);

        void Delete(int id);

        void Add(Course subject);

        void Save(Course subject);

        Course CourseWithTeachersList();
    }
}
