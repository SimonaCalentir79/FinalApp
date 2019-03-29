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
using System.Data;

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
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfGrades;
        }

        public Grade GetGradeByID(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));

            Grade grade = new Grade();
            Student student = new Student();
            Semester semester = new Semester();
            Course course = new Course();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetGradeByID", sqlConn);
            cmd.Parameters.AddWithValue("@GradeID", notNullId);

            SqlDataReader reader = cmd.ExecuteReader();
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

                student.StudentID = Convert.ToInt32(reader["StudentID"]);
                student.StudentName = reader["StudentName"].ToString();

                semester.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                semester.SemesterNumber = Convert.ToInt32(reader["SemesterNumber"]);
                semester.SchoolYear = reader["SchoolYear"].ToString();

                course.CourseID = Convert.ToInt32(reader["CourseID"]);
                course.CourseName = reader["CourseName"].ToString();
                course.LevelYear = Convert.ToInt32(reader["LevelYear"]);

                grade.Students = student;
                grade.Semesters = semester;
                grade.Courses = course;
            }
            ADO_NETconfig.CloseReader(reader);
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return grade;
        }

        public IEnumerable<Grade> GetGradesByStudentID(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));

            List<Grade> listOfGrades = new List<Grade>();

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spGetGradeByStudentID", sqlConn);
            cmd.Parameters.AddWithValue("@StudentID", notNullId);

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

            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);

            return listOfGrades;
        }

        public void AddGrade(Grade grade)
        {
            Grade notNullGrade = grade ?? throw new ArgumentNullException(nameof(grade));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spAddGrade", sqlConn);

            cmd.Parameters.AddWithValue("@StudentID", notNullGrade.StudentID);
            cmd.Parameters.AddWithValue("@SemesterID", notNullGrade.SemesterID);
            cmd.Parameters.AddWithValue("@CourseID", notNullGrade.CourseID);
            cmd.Parameters.AddWithValue("@Mark", notNullGrade.Mark);
            cmd.Parameters.AddWithValue("@DateOfMark", notNullGrade.DateOfMark);
            cmd.Parameters.AddWithValue("@GradingWeight", notNullGrade.GradingWeight);
            cmd.Parameters.AddWithValue("@Observations", (object)notNullGrade.Observations??DBNull.Value);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void UpdateGrade(Grade grade)
        {
            Grade notNullGrade = grade ?? throw new ArgumentNullException(nameof(grade));
            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spUpdateGrade", sqlConn);

            cmd.Parameters.AddWithValue("@GradeID", notNullGrade.GradeID);
            cmd.Parameters.AddWithValue("@StudentID", notNullGrade.StudentID);
            cmd.Parameters.AddWithValue("@SemesterID", notNullGrade.SemesterID);
            cmd.Parameters.AddWithValue("@CourseID", notNullGrade.CourseID);
            cmd.Parameters.AddWithValue("@Mark", notNullGrade.Mark);
            cmd.Parameters.AddWithValue("@DateOfMark", notNullGrade.DateOfMark);
            cmd.Parameters.AddWithValue("@GradingWeight", notNullGrade.GradingWeight);
            cmd.Parameters.AddWithValue("@Observations", (object)notNullGrade.Observations??DBNull.Value);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }

        public void DeleteGrade(int? id)
        {
            int notNullId = id ?? throw new ArgumentNullException(nameof(id));

            SqlCommand cmd = ADO_NETconfig.StoredProcedureCommand("spDeleteGrade", sqlConn);

            cmd.Parameters.AddWithValue("@GradeID", notNullId);

            cmd.ExecuteNonQuery();
            if (sqlConn.State != ConnectionState.Closed)
                ADO_NETconfig.CloseConn(sqlConn);
        }
    }
}
