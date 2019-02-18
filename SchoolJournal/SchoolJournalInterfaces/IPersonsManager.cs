using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolJournalInterfaces
{
    public interface IPersonsManager
    {
        IList<Persons> GetAllPersons();

        IList<Persons> GetByName(string name);

        IList<Persons> GetByAddress(string address);

        Persons Get(int id);

        void Save(Persons person);

        void Delete(int id);

        void Add(Persons person);
    }
}
