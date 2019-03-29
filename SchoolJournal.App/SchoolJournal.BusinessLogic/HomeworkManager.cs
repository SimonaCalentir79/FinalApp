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
using System.Web.Mvc;

namespace SchoolJournal.BusinessLogic
{
    public class HomeworkManager:IHomeworkManager
    {
        private readonly SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<Homework> GetAllHomeworks()
        {
            List<Homework> listOfHomeworks = new List<Homework>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllHomeworks", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Homework homework = new Homework();

                homework.HomeworkID = Convert.ToInt32(reader["HomeworkID"]);
                homework.StudentID = Convert.ToInt32(reader["StudentID"]);
                homework.CourseID = Convert.ToInt32(reader["CourseID"]);
                homework.DateOfHomework = Convert.ToDateTime(reader["DateOfHomework"]);
                homework.DueDate = Convert.ToDateTime(reader["DueDate"]);
                homework.Details = reader["Details"].ToString();
                homework.HomeworkStatus = reader["HomeworkStatus"].ToString();

                Student student = new Student();
                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                Course course = new Course();
                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();

                homework.Students = student;
                homework.Courses = course;

                listOfHomeworks.Add(homework);
            }
            ADO_NETconfig.CloseReader(reader);
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfHomeworks;
        }

        public Homework GetHomeworkByID(int? id)
        {
            Homework homework = new Homework();
            Student student = new Student();
            Course course = new Course();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetHomeworkByID", sqlConn);
            cmd.Parameters.AddWithValue("@HomeworkID", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                homework.HomeworkID = Convert.ToInt32(reader["HomeworkID"]);
                homework.StudentID = Convert.ToInt32(reader["StudentID"]);
                homework.CourseID = Convert.ToInt32(reader["CourseID"]);
                homework.DateOfHomework = Convert.ToDateTime(reader["DateOfHomework"]);
                homework.DueDate = Convert.ToDateTime(reader["DueDate"]);
                homework.Details = reader["Details"].ToString();
                homework.HomeworkStatus = reader["HomeworkStatus"].ToString();

                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();

                homework.Students = student;
                homework.Courses = course;
            }
            ADO_NETconfig.CloseReader(reader);

            return homework;
        }

        public IEnumerable<Homework> GetHomeworkByStudentID(int? id)
        {
            List<Homework> listOfHomeworks = new List<Homework>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetHomeworkByStudentID", sqlConn);
            cmd.Parameters.AddWithValue("@StudentID", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Homework homework = new Homework();
                homework.HomeworkID = Convert.ToInt32(reader["HomeworkID"]);
                homework.StudentID = Convert.ToInt32(reader["StudentID"]);
                homework.CourseID = Convert.ToInt32(reader["CourseID"]);
                homework.DateOfHomework = Convert.ToDateTime(reader["DateOfHomework"]);
                homework.DueDate = Convert.ToDateTime(reader["DueDate"]);
                homework.Details = reader["Details"].ToString();
                homework.HomeworkStatus = reader["HomeworkStatus"].ToString();

                Student student = new Student();
                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                Course course = new Course();
                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();

                homework.Students = student;
                homework.Courses = course;

                listOfHomeworks.Add(homework);
            }
            ADO_NETconfig.CloseReader(reader);
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfHomeworks;
        }

        public void AddHomework(Homework homework)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddHomework", sqlConn);

            cmd.Parameters.AddWithValue("@StudentID", homework.StudentID);
            cmd.Parameters.AddWithValue("@CourseID", homework.CourseID);
            cmd.Parameters.AddWithValue("@DateOfHomework", homework.DateOfHomework);
            cmd.Parameters.AddWithValue("@DueDate",homework.DueDate);
            cmd.Parameters.AddWithValue("@Details",homework.Details);
            cmd.Parameters.AddWithValue("@HomeworkStatus",homework.HomeworkStatus);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateHomework(Homework homework)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateHomework", sqlConn);

            cmd.Parameters.AddWithValue("@HomeworkID", homework.HomeworkID);
            cmd.Parameters.AddWithValue("@StudentID", homework.StudentID);
            cmd.Parameters.AddWithValue("@CourseID", homework.CourseID);
            cmd.Parameters.AddWithValue("@DateOfHomework", homework.DateOfHomework);
            cmd.Parameters.AddWithValue("@DueDate", homework.DueDate);
            cmd.Parameters.AddWithValue("@Details", homework.Details);
            cmd.Parameters.AddWithValue("@HomeworkStatus", homework.HomeworkStatus);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteHomework(int? id)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteHomework", sqlConn);

            cmd.Parameters.AddWithValue("@HomeworkID", id);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
