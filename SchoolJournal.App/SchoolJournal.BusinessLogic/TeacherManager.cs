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
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            Teacher teacher = new Teacher();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetTeacherByID", sqlConn);
            cmd.Parameters.AddWithValue("@TeacherID", notNullId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                teacher.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherEmail = reader["TeacherEmail"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();
            }
            ADO_NETconfig.CloseReader(reader);
            return teacher;
        }

        public void AddTeacher(Teacher teacher)
        {
            Teacher notNullTeacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddTeacher", sqlConn);

            cmd.Parameters.AddWithValue("@TeacherName", notNullTeacher.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherEmail", (object)notNullTeacher.TeacherEmail??DBNull.Value);
            cmd.Parameters.AddWithValue("@TeacherPhone", (object)notNullTeacher.TeacherPhone??DBNull.Value);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            Teacher notNullTeacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateTeacher", sqlConn);

            cmd.Parameters.AddWithValue("@TeacherID", notNullTeacher.TeacherID);
            cmd.Parameters.AddWithValue("@TeacherName", notNullTeacher.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherEmail", (object)notNullTeacher.TeacherEmail??DBNull.Value);
            cmd.Parameters.AddWithValue("@TeacherPhone", (object)notNullTeacher.TeacherPhone??DBNull.Value);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteTeacher(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteTeacher", sqlConn);

            cmd.Parameters.AddWithValue("@TeacherID", notNullId);
            cmd.ExecuteNonQuery();

            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
