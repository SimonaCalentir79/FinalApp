using SchoolJournal.DataAccess;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
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
            ADO_NETconfig.CloseConn(sqlConn);

            return listOfCourses;
        }

        public Course GetCourseByID(int? id)
        {
            Course course = new Course();
            string query = "select * from Course c join Teacher t on c.TeacherID=t.TeacherID where c.CourseID=";
            SqlDataReader reader = ADO_NETconfig.GetObjectFromReader(sqlConn, query + id);

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
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddCourse",sqlConn);

            cmd.Parameters.AddWithValue("@CourseName",course.CourseName);
            cmd.Parameters.AddWithValue("@LevelYear",course.LevelYear);
            cmd.Parameters.AddWithValue("@TeacherID",course.TeacherID);

            cmd.ExecuteNonQuery();
            ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateCourse(Course course)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateCourse",sqlConn);

            cmd.Parameters.AddWithValue("@CourseID",course.CourseID);
            cmd.Parameters.AddWithValue("@CourseName",course.CourseName);
            cmd.Parameters.AddWithValue("@LevelYear",course.LevelYear);
            cmd.Parameters.AddWithValue("@TeacherID",course.TeacherID);

            cmd.ExecuteNonQuery();
            ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteCourse(int? id)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteCourse",sqlConn);

            cmd.Parameters.AddWithValue("@CourseID",id);

            cmd.ExecuteNonQuery();

            ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
