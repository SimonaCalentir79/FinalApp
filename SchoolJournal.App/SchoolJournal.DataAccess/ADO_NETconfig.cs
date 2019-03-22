using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.DataAccess
{
    public class ADO_NETconfig
    {
        public static SqlConnection OpenConn(string conn)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[conn].ConnectionString
            };
            
            connection.Open();
            return connection;
        }

        public static void CloseConn(SqlConnection conn)
        {
            conn.Close();
        }

        public static SqlCommand StoredProcedureCommand(string text, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(text, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return cmd;
        }

        public static SqlDataReader GetObjectFromReader(SqlConnection connection, string commandText)
        {
            SqlCommand command = new SqlCommand(commandText) { Connection = connection };

            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static void CloseReader(SqlDataReader reader)
        {
            reader.Close();
        }

        public static SqlParameter newParam(string paramName, object paramValue)
        {
            SqlParameter parameter = new SqlParameter { Value = paramValue, ParameterName = paramName };
            return parameter;
        }
    }
}
