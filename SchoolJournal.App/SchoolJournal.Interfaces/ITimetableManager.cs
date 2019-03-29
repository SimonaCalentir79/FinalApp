using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Interfaces
{
    public interface ITimetableManager
    {
        IEnumerable<Timetable> GetAllTimetables();

        Timetable GetTimetableByID(int? id);

        IEnumerable<Timetable> GetTimetableByStudentID(int? id);

        void AddTimetable(Timetable timetable);

        void UpdateTimetable(Timetable timetable);

        void DeleteTimetable(int? id);
    }
}
