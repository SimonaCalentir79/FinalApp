using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Interfaces
{
    public interface IUserAccountManager
    {
        IEnumerable<UserAccount> GetAllUserAccounts();

        void AddUser(UserAccount userAccount);
    }
}
