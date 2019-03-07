using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SchoolJournalDataAccess
{
    public class SchoolJournalADOAccess
    {
        private string connName = "SchoolJournalDBSQLConn";

        public static SqlConnection OpenConnToDB(string connName)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            connection.Open();
            return connection;
        }

        public static void CloseConnToDB(SqlConnection connection)
        {
            connection.Close();
        }

        //public static void PrintReader(SqlConnection connection, string commandText)
        //{
        //    SqlCommand command = new SqlCommand(commandText);
        //    command.Connection = connection;

        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        for (int i = 0; i < reader.FieldCount; i++)
        //        {
        //            Console.Write($"\t {reader[i]}");
        //        }
        //        Console.WriteLine();
        //    }
        //    reader.Close();
        //}

        public static SqlDataReader GetObjectFromReader(SqlConnection connection, string commandText)
        {
            SqlCommand command = new SqlCommand(commandText);
            command.Connection = connection;

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
