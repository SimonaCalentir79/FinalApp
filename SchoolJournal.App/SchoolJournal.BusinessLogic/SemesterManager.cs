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
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfSemesters;
        }

        public Semester GetSemesterByID(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            Semester semester = new Semester();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetSemesterByID", sqlConn);
            cmd.Parameters.AddWithValue("@SemesterID", notNullId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                semester.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                semester.SemesterNumber = Convert.ToInt32(reader["SemesterNumber"]);
                semester.SchoolYear = reader["SchoolYear"].ToString();
            }
            ADO_NETconfig.CloseReader(reader);
            return semester;
        }

        public void AddSemester(Semester semester)
        {
            Semester notNullSemester = semester ?? throw new ArgumentNullException(nameof(semester));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddSemester",sqlConn);

            cmd.Parameters.AddWithValue("@SemesterNumber", notNullSemester.SemesterNumber);
            cmd.Parameters.AddWithValue("@SchoolYear", notNullSemester.SchoolYear);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateSemester(Semester semester)
        {
            Semester notNullSemester = semester ?? throw new ArgumentNullException(nameof(semester));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateSemester",sqlConn);

            cmd.Parameters.AddWithValue("@SemesterID", notNullSemester.SemesterID);
            cmd.Parameters.AddWithValue("@SemesterNumber", notNullSemester.SemesterNumber);
            cmd.Parameters.AddWithValue("@SchoolYear", notNullSemester.SchoolYear);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteSemester(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteSemester",sqlConn);

            cmd.Parameters.AddWithValue("@SemesterID", notNullId);
            cmd.ExecuteNonQuery();

            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
