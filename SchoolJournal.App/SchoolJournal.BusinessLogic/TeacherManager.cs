using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SchoolJournal.DataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Interfaces;
using System.Data;

namespace SchoolJournal.BusinessLogic
{
    public class TeacherManager:ITeacherManager
    {
        private SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<Teacher> GetAllTeachers()
        {
            List<Teacher> listOfTeachers = new List<Teacher>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllTeachers", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Teacher teacher = new Teacher();

                teacher.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherEmail = reader["TeacherEmail"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();

                listOfTeachers.Add(teacher);
            }
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfTeachers;
        }

        public Teacher GetTeacherByID(int? id)
        {
            Teacher teacher = new Teacher();
            SqlDataReader reader = ADO_NETconfig.GetObjectFromReader(sqlConn, "select * from Teacher where TeacherID=" + id);

            while (reader.Read())
            {
                teacher.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherEmail = reader["TeacherEmail"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();
            }

            return teacher;
        }

        public void AddTeacher(Teacher teacher)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddTeacher", sqlConn);

            cmd.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherEmail", (object)teacher.TeacherEmail??DBNull.Value);
            cmd.Parameters.AddWithValue("@TeacherPhone", (object)teacher.TeacherPhone??DBNull.Value);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateTeacher", sqlConn);

            cmd.Parameters.AddWithValue("@TeacherID", teacher.TeacherID);
            cmd.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherEmail", (object)teacher.TeacherEmail??DBNull.Value);
            cmd.Parameters.AddWithValue("@TeacherPhone", (object)teacher.TeacherPhone??DBNull.Value);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteTeacher(int? id)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteTeacher", sqlConn);

            cmd.Parameters.AddWithValue("@TeacherID", id);
            cmd.ExecuteNonQuery();

            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
