using SchoolJournal.DataAccess;
using SchoolJournal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolJournal.BusinessLogic
{
    public class PopulateList:IPopulateList
    {
        private readonly SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<SelectListItem> TeachersList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllTeachers", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SelectListItem
                {
                    Text = reader["TeacherName"].ToString(),
                    Value = reader["TeacherID"].ToString()
                });
            }
            ADO_NETconfig.CloseReader(reader);

            return list;
        }

        public IEnumerable<SelectListItem> StudentsList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllStudents", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SelectListItem
                {
                    Text = reader["StudentName"].ToString(),
                    Value = reader["StudentID"].ToString()
                });
            }
            ADO_NETconfig.CloseReader(reader);

            return list;
        }

        public IEnumerable<SelectListItem> CoursesList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllCourses", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SelectListItem
                {
                    Text = reader["CourseName"].ToString() + "/" + reader["LevelYear"].ToString(),
                    Value = reader["CourseID"].ToString()
                });
            }
            ADO_NETconfig.CloseReader(reader);

            return list;
        }

        public IEnumerable<SelectListItem> SemestersList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllSemesters", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SelectListItem
                {
                    Text = reader["SemesterNumber"].ToString() + "/" + reader["SchoolYear"].ToString(),
                    Value = reader["SemesterID"].ToString()
                });
            }
            ADO_NETconfig.CloseReader(reader);

            return list;
        }
    }
}
