using System;
using System.Collections.Generic;
using SchoolJournal.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SchoolJournal.DataAccess;
using System.Web.Mvc;
using SchoolJournal.Models;

namespace SchoolJournal.BusinessLogic
{
    public class GradeManager:IGradeManager
    {
        private readonly SqlConnection sqlConn = ADO_NETconfig.OpenConn("SchoolJournalDBSQLConn");

        public IEnumerable<Grade> GetAllGrades()
        {
            List<Grade> listOfGrades = new List<Grade>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetAllGrades", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Grade grade = new Grade();

                grade.GradeID = Convert.ToInt32(reader["GradeID"]);
                grade.StudentID = Convert.ToInt32(reader["StudentID"]);
                grade.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                grade.CourseID = Convert.ToInt32(reader["CourseID"]);
                grade.Mark = Convert.ToDecimal(reader["Mark"]);
                grade.DateOfMark = Convert.ToDateTime(reader["DateOfMark"]);
                grade.GradingWeight = Convert.ToDecimal(reader["GradingWeight"]);
                grade.Observations = reader["Observations"].ToString();

                Student student = new Student();
                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                Semester semester = new Semester();
                semester.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                semester.SemesterNumber = Convert.ToInt32(reader["SemesterNumber"]);
                semester.SchoolYear = reader["SchoolYear"].ToString();

                Course course = new Course();
                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();
                course.LevelYear = Convert.ToInt32(reader["LevelYear"]);

                grade.Students = student;
                grade.Semesters = semester;
                grade.Courses = course;

                listOfGrades.Add(grade);
            }
            ADO_NETconfig.CloseReader(reader);
            ADO_NETconfig.CloseConn(sqlConn);

            return listOfGrades;
        }

        public Grade GetGradeByID(int? id)
        {
            Grade grade = new Grade();
            string query = "select * from Grade g " +
                "join Student s on g.StudentID = s.StudentID " +
                "join Course c on g.CourseID = c.CourseID " +
                "join Semester m on g.SemesterID = m.SemesterID where g.GradeID=";
            SqlDataReader reader = ADO_NETconfig.GetObjectFromReader(sqlConn, query + id);

            while (reader.Read())
            {
                grade.GradeID = Convert.ToInt32(reader["GradeID"]);
                grade.StudentID = Convert.ToInt32(reader["StudentID"]);
                grade.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                grade.CourseID = Convert.ToInt32(reader["CourseID"]);
                grade.Mark = Convert.ToDecimal(reader["Mark"]);
                grade.DateOfMark = Convert.ToDateTime(reader["DateOfMark"]);
                grade.GradingWeight = Convert.ToDecimal(reader["GradingWeight"]);
                grade.Observations = reader["Observations"].ToString();

                Student student = new Student();
                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                Semester semester = new Semester();
                semester.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                semester.SemesterNumber = Convert.ToInt32(reader["SemesterNumber"]);
                semester.SchoolYear = reader["SchoolYear"].ToString();

                Course course = new Course();
                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();
                course.LevelYear = Convert.ToInt32(reader["LevelYear"]);

                grade.Students = student;
                grade.Semesters = semester;
                grade.Courses = course;
            }

            ADO_NETconfig.CloseReader(reader);

            return grade;
        }

        public void AddGrade(Grade grade)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddGrade", sqlConn);

            cmd.Parameters.AddWithValue("@StudentID", grade.StudentID);
            cmd.Parameters.AddWithValue("@SemesterID",grade.SemesterID);
            cmd.Parameters.AddWithValue("@CourseID", grade.CourseID);
            cmd.Parameters.AddWithValue("@Mark", grade.Mark);
            cmd.Parameters.AddWithValue("@DateOfMark", grade.DateOfMark);
            cmd.Parameters.AddWithValue("@GradingWeight", grade.GradingWeight);
            cmd.Parameters.AddWithValue("@Observations", (object)grade.Observations??DBNull.Value);

            cmd.ExecuteNonQuery();
            ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateGrade(Grade grade)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateGrade", sqlConn);

            cmd.Parameters.AddWithValue("@GradeID", grade.GradeID);
            cmd.Parameters.AddWithValue("@StudentID", grade.StudentID);
            cmd.Parameters.AddWithValue("@SemesterID",grade.SemesterID);
            cmd.Parameters.AddWithValue("@CourseID", grade.CourseID);
            cmd.Parameters.AddWithValue("@Mark", grade.Mark);
            cmd.Parameters.AddWithValue("@DateOfMark", grade.DateOfMark);
            cmd.Parameters.AddWithValue("@GradingWeight", grade.GradingWeight);
            cmd.Parameters.AddWithValue("@Observations", (object)grade.Observations??DBNull.Value);

            cmd.ExecuteNonQuery();
            ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteGrade(int? id)
        {
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteGrade", sqlConn);

            cmd.Parameters.AddWithValue("@GradeID", id);

            cmd.ExecuteNonQuery();

            ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
