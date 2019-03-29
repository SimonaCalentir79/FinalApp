using SchoolJournal.DataAccess;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolJournal.BusinessLogic
{
    public class StudentManager:IStudentManager
    {
        private SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> listOfStudents = new List<Student>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllStudents", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student();

                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();
                student.StudentPhoto = reader["StudentPhoto"].ToString();
                student.Observations = reader["Observations"].ToString();

                listOfStudents.Add(student);
            }
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfStudents;
        }

        public Student GetStudentByID(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            Student student = new Student();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetStudentsByID", sqlConn);
            cmd.Parameters.AddWithValue("@StudentID", notNullId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();
                student.StudentPhoto = reader["StudentPhoto"].ToString();
                student.Observations = reader["Observations"].ToString();
            }
            ADO_NETconfig.CloseReader(reader);
            return student;
        }

        public void AddStudent(Student student)
        {
            Student notNullStudent = student ?? throw new ArgumentNullException(nameof(student));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddStudent", sqlConn);

            cmd.Parameters.AddWithValue("@StudentName", notNullStudent.StudentName);
            cmd.Parameters.AddWithValue("@StudentPhoto", (object)notNullStudent.StudentPhoto??DBNull.Value);
            cmd.Parameters.AddWithValue("@Observations", (object)notNullStudent.Observations??DBNull.Value);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateStudent(Student student)
        {
            Student notNullStudent = student ?? throw new ArgumentNullException(nameof(student));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateStudent", sqlConn);

            cmd.Parameters.AddWithValue("@StudentID", notNullStudent.StudentID);
            cmd.Parameters.AddWithValue("@StudentName", notNullStudent.StudentName);
            cmd.Parameters.AddWithValue("@StudentPhoto", (object)notNullStudent.StudentPhoto??DBNull.Value);
            cmd.Parameters.AddWithValue("@Observations", (object)notNullStudent.Observations??DBNull.Value);

            cmd.ExecuteNonQuery();

            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteStudent(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteStudent", sqlConn);

            cmd.Parameters.AddWithValue("@StudentID", notNullId);
            cmd.ExecuteNonQuery();

            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
