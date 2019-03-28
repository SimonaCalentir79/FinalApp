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
    public class CourseManager:ICourseManager
    {
        private readonly SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<Course> GetAllCourses()
        {
            List<Course> listOfCourses = new List<Course>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllCourses", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Course course = new Course();

                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();
                course.LevelYear = Convert.ToInt32(reader["LevelYear"]);
                course.TeacherID = Convert.ToInt32(reader["TeacherID"]);

                Teacher teacher = new Teacher();
                teacher.TeacherID = (int)reader["TeacherID"];
                teacher.TeacherName = (string)reader["TeacherName"];

                course.Teachers = teacher;
                listOfCourses.Add(course);
            }
            ADO_NETconfig.CloseReader(reader);
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfCourses;
        }

        public Course GetCourseByID(int? id)
        {
            int nonNullId = id ?? throw new ArgumentNullException(nameof(id));

            Course course = new Course();
            string query = "select * from Course c join Teacher t on c.TeacherID=t.TeacherID where c.CourseID=";
            SqlDataReader reader = ADO_NETconfig.GetObjectFromReader(sqlConn, query + nonNullId);

            while (reader.Read())
            {
                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();
                course.LevelYear = Convert.ToInt32(reader["LevelYear"].ToString());
                course.TeacherID = Convert.ToInt32(reader["TeacherID"].ToString());

                Teacher teacher = new Teacher();
                teacher.TeacherID = (int)reader["TeacherID"];
                teacher.TeacherName = (string)reader["TeacherName"];

                course.Teachers = teacher;
            }
            ADO_NETconfig.CloseReader(reader);

            return course;
        }

        public void AddCourse(Course course)
        {
            Course nonNullCourse = course ?? throw new ArgumentNullException(nameof(course));

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddCourse",sqlConn);

            cmd.Parameters.AddWithValue("@CourseName", nonNullCourse.CourseName);
            cmd.Parameters.AddWithValue("@LevelYear", nonNullCourse.LevelYear);
            cmd.Parameters.AddWithValue("@TeacherID", nonNullCourse.TeacherID);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateCourse(Course course)
        {
            Course nonNullCourse = course ?? throw new ArgumentNullException(nameof(course));

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateCourse",sqlConn);

            cmd.Parameters.AddWithValue("@CourseID", nonNullCourse.CourseID);
            cmd.Parameters.AddWithValue("@CourseName", nonNullCourse.CourseName);
            cmd.Parameters.AddWithValue("@LevelYear", nonNullCourse.LevelYear);
            cmd.Parameters.AddWithValue("@TeacherID", nonNullCourse.TeacherID);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteCourse(int? id)
        {
            int nonNullId = id ?? throw new ArgumentNullException(nameof(id));

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteCourse",sqlConn);

            cmd.Parameters.AddWithValue("@CourseID", nonNullId);

            cmd.ExecuteNonQuery();

            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
