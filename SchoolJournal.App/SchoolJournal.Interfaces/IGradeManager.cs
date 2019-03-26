using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolJournal.Interfaces
{
    public interface IGradeManager
    {
        IEnumerable<Grade> GetAllGrades();

        Grade GetGradeByID(int? id);

        void AddGrade(Grade grade);

        void UpdateGrade(Grade grade);

        void DeleteGrade(int? id);
    }
}
