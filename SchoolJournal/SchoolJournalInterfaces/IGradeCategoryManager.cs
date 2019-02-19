using SchoolJournalModels;
using System.Collections.Generic;

namespace SchoolJournalInterfaces
{
    public interface IGradeCategoryManager
    {
        IList<GradeCategory> GetAllCategories();

        IList<GradeCategory> GetByName(string name);

        GradeCategory Get(int id);

        void Save(GradeCategory gradeCtg);

        void Delete(int id);

        void Add(GradeCategory gradeCtg);
    }
}
