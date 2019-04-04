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
        IList<Timetable> GetAllTimetables();

        IList<Timetable> GetTimetableByStudentID(int? id);

        IList<Timetable> GetTimetableByDay(string day);

        IList<Timetable> GetTimetableByCourse(string subject);
        
        Timetable GetTimetableByID(int? id);

        void AddTimetable(Timetable timetable);

        void UpdateTimetable(Timetable timetable);

        void DeleteTimetable(int? id);
    }
}
