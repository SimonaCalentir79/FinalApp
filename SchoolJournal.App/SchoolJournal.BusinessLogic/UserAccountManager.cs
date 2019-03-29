using SchoolJournal.DataAccess;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.BusinessLogic
{
    public class UserAccountManager:IUserAccountManager
    {
        private readonly SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            List<UserAccount> listOfUsers = new List<UserAccount>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllUsers", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                UserAccount userAccount = new UserAccount();

                userAccount.UserID = Convert.ToInt32(reader["UserID"]);
                userAccount.FirstName = reader["FirstName"].ToString();
                userAccount.LastName = reader["LastName"].ToString();
                userAccount.Email = reader["Email"].ToString();
                userAccount.Username = reader["Username"].ToString();
                userAccount.Password = reader["Password"].ToString();
                userAccount.ConfirmPassword = reader["ConfirmPassword"].ToString();

                listOfUsers.Add(userAccount);
            }
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfUsers;
        }

        public void AddUser(UserAccount userAccount)
        {
            UserAccount notNullUA = userAccount ?? throw new ArgumentNullException(nameof(userAccount));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddUserAccounts", sqlConn);

            cmd.Parameters.AddWithValue("@FirstName", notNullUA.FirstName);
            cmd.Parameters.AddWithValue("@LastName", notNullUA.LastName);
            cmd.Parameters.AddWithValue("@Email", notNullUA.Email);
            cmd.Parameters.AddWithValue("@Username", notNullUA.Username);
            cmd.Parameters.AddWithValue("@Password", notNullUA.Password);
            cmd.Parameters.AddWithValue("@ConfirmPassword", notNullUA.ConfirmPassword);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
