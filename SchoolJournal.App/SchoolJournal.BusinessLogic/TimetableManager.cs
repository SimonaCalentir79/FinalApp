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

        public IList<Timetable> GetAllTimetables()
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
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            Timetable timetable = new Timetable();
            Student student = new Student();
            Course course = new Course();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetTimetableByID", sqlConn);
            cmd.Parameters.AddWithValue("@TimetableID", notNullId);

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

        public IList<Timetable> GetTimetableByStudentID(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            List<Timetable> listOfTimetables = new List<Timetable>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetTimetableByStudentID", sqlConn);
            cmd.Parameters.AddWithValue("@StudentID", notNullId);

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

        public IList<Timetable> GetTimetableByDay(string day)
        {
            List<Timetable> listOfTimetables = new List<Timetable>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetTimetableByDay", sqlConn);
            cmd.Parameters.AddWithValue("@DayOfTheWeek", day);

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

        public IList<Timetable> GetTimetableByCourse(string subject)
        {
            List<Timetable> listOfTimetables = new List<Timetable>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetTimetableByCourse", sqlConn);
            cmd.Parameters.AddWithValue("@CourseName", subject);

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
            Timetable notNullTimetable = timetable ?? throw new ArgumentNullException(nameof(timetable));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddTimetable", sqlConn);

            cmd.Parameters.AddWithValue("@StudentID", notNullTimetable.StudentID);
            cmd.Parameters.AddWithValue("@DayOfTheWeek", notNullTimetable.DayOfTheWeek);
            cmd.Parameters.AddWithValue("@TimeInterval", notNullTimetable.TimeInterval);
            cmd.Parameters.AddWithValue("@CourseID", notNullTimetable.CourseID);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateTimetable(Timetable timetable)
        {
            Timetable notNullTimetable = timetable ?? throw new ArgumentNullException(nameof(timetable));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateTimetable", sqlConn);

            cmd.Parameters.AddWithValue("@TimetableID", notNullTimetable.TimetableID);
            cmd.Parameters.AddWithValue("@StudentID", notNullTimetable.StudentID);
            cmd.Parameters.AddWithValue("@DayOfTheWeek", notNullTimetable.DayOfTheWeek);
            cmd.Parameters.AddWithValue("@TimeInterval", notNullTimetable.TimeInterval);
            cmd.Parameters.AddWithValue("@CourseID", notNullTimetable.CourseID);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteTimetable(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteTimetable", sqlConn);

            cmd.Parameters.AddWithValue("@TimetableID", notNullId);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
