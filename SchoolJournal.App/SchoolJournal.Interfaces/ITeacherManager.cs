using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Interfaces
{
    public interface ITeacherManager
    {
        IEnumerable<Teacher> GetAllTeachers();

        Teacher GetTeacherByID(int? id);

        void AddTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        void DeleteTeacher(int? id);
    }
}
