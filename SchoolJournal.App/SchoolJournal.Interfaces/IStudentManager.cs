using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Interfaces
{
    public interface IStudentManager
    {
        IEnumerable<Student> GetAllStudents();

        Student GetStudentByID(int? id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int? id);
    }
}
