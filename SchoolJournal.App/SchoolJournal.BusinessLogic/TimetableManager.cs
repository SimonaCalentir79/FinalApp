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
    public class TimetableManager:ITimetableManager
    {
        private readonly SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<Timetable> GetAllTimetables()
        {
            List<Timetable> listOfTimetables = new List<Timetable>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllTimetables", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Timetable timetable = new Timetable();
                timetable.TimetableID = Convert.ToInt32(reader["TimetableID"]);
                timetable.StudentID = Convert.ToInt32(reader["StudentID"]);
                timetable.DayOfTheWeek = reader["DayOfTheWeek"].ToString();
                timetable.TimeInterval = reader["TimeInterval"].ToString();

                Student student = new Student();
                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                Course course = new Course();
                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();

                timetable.Students = student;
                timetable.Courses = course;

                listOfTimetables.Add(timetable);
            }
            ADO_NETconfig.CloseReader(reader);
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfTimetables;
        }

        public Timetable GetTimetableByID(int? id)
        {
            Timetable timetable = new Timetable();
            Student student = new Student();
            Course course = new Course();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetTimetableByID", sqlConn);
            cmd.Parameters.AddWithValue("@TimetableID", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                timetable.TimetableID = Convert.ToInt32(reader["TimetableID"]);
                timetable.StudentID = Convert.ToInt32(reader["StudentID"]);
                timetable.DayOfTheWeek = reader["DayOfTheWeek"].ToString();
                timetable.TimeInterval = reader["TimeInterval"].ToString();

                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();

                timetable.Students = student;
                timetable.Courses = course;
            }
            ADO_NETconfig.CloseReader(reader);

            return timetable;
        }

        public IEnumerable<Timetable> GetTimetableByStudentID(int? id)
        {
            List<Timetable> listOfTimetables = new List<Timetable>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetTimetableByStudentID", sqlConn);
            cmd.Parameters.AddWithValue("@StudentID", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Timetable timetable = new Timetable();
                timetable.TimetableID = Convert.ToInt32(reader["TimetableID"]);
                timetable.StudentID = Convert.ToInt32(reader["StudentID"]);
                timetable.DayOfTheWeek = reader["DayOfTheWeek"].ToString();
                timetable.TimeInterval = reader["TimeInterval"].ToString();

                Student student = new Student();
                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                Course course = new Course();
                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();

                timetable.Students = student;
                timetable.Courses = course;

                listOfTimetables.Add(timetable);
            }
            ADO_NETconfig.CloseReader(reader);
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfTimetables;
        }

        public void AddTimetable(Timetable timetable)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddTimetable", sqlConn);

            cmd.Parameters.AddWithValue("@StudentID", timetable.StudentID);
            cmd.Parameters.AddWithValue("@DayOfTheWeek", timetable.DayOfTheWeek);
            cmd.Parameters.AddWithValue("@TimeInterval", timetable.TimeInterval);
            cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateTimetable(Timetable timetable)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateTimetable", sqlConn);

            cmd.Parameters.AddWithValue("@TimetableID", timetable.TimetableID);
            cmd.Parameters.AddWithValue("@StudentID", timetable.StudentID);
            cmd.Parameters.AddWithValue("@DayOfTheWeek", timetable.DayOfTheWeek);
            cmd.Parameters.AddWithValue("@TimeInterval", timetable.TimeInterval);
            cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteTimetable(int? id)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteTimetable", sqlConn);

            cmd.Parameters.AddWithValue("@TimetableID", id);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
