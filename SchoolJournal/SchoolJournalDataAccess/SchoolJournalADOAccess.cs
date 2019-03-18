using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SchoolJournalDataAccess
{
    public class SchoolJournalADOAccess
    {
        public static SqlConnection OpenConn(string connName)
        {
            SqlConnection connection = new SqlConnection()
            {
                ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString
            };
            connection.Open();
            return connection;
        }

        public static void CloseConn(SqlConnection connection)
        {
            connection.Close();
        }

        public static SqlCommand StoredProcedureCommand(string text, SqlConnection sqlConnection)
        {
            SqlCommand cmd = new SqlCommand(text,sqlConnection);
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
