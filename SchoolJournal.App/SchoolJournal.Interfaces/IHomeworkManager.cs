using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolJournal.Interfaces
{
    public interface IHomeworkManager
    {
        IEnumerable<Homework> GetAllHomeworks();

        Homework GetHomeworkByID(int? id);

        void AddHomework(Homework homework);

        void UpdateHomework(Homework homework);

        void DeleteHomework(int? id);
    }
}
