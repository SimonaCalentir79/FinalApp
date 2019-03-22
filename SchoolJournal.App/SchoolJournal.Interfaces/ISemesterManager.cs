using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Interfaces
{
    public interface ISemesterManager
    {
        IEnumerable<Semester> GetAllSemesters();

        Semester GetSemesterByID(int? id);

        void AddSemester(Semester semester);

        void UpdateSemester(Semester semester);

        void DeleteSemester(int? id);
    }
}
