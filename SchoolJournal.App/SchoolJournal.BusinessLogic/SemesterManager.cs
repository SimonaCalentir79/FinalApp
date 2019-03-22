using SchoolJournal.DataAccess;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.BusinessLogic
{
    public class SemesterManager:ISemesterManager
    {
        private SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<Semester> GetAllSemesters()
        {
            List<Semester> listOfSemesters = new List<Semester>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllSemesters",sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Semester semester = new Semester();

                semester.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                semester.SemesterNumber = Convert.ToInt32(reader["SemesterNumber"]);
                semester.SchoolYear = reader["SchoolYear"].ToString();

                listOfSemesters.Add(semester);
            }
            ADO_NETconfig.CloseConn(sqlConn);

            return listOfSemesters;
        }

        public Semester GetSemesterByID(int? id)
        {
            Semester semester = new Semester();
            SqlDataReader reader = ADO_NETconfig.GetObjectFromReader(sqlConn,"select * from Semester where SemesterID="+id);

            while (reader.Read())
            {
                semester.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                semester.SemesterNumber = Convert.ToInt32(reader["SemesterNumber"]);
                semester.SchoolYear = reader["SchoolYear"].ToString();
            }

            return semester;
        }

        public void AddSemester(Semester semester)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddSemester",sqlConn);

            cmd.Parameters.AddWithValue("@SemesterNumber",semester.SemesterNumber);
            cmd.Parameters.AddWithValue("@SchoolYear",semester.SchoolYear);

            cmd.ExecuteNonQuery();
            ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateSemester(Semester semester)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateSemester",sqlConn);

            cmd.Parameters.AddWithValue("@SemesterID",semester.SemesterID);
            cmd.Parameters.AddWithValue("@SemesterNumber",semester.SemesterNumber);
            cmd.Parameters.AddWithValue("@SchoolYear",semester.SchoolYear);

            cmd.ExecuteNonQuery();
            ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteSemester(int? id)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteSemester",sqlConn);

            cmd.Parameters.AddWithValue("@SemesterID",id);
            cmd.ExecuteNonQuery();

            ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
