using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SchoolJournalDataAccess;
using SchoolJournalInterfaces;
using SchoolJournalModels;

namespace SchoolJournalBusinessLogic
{
    public class TeacherManager:ITeacherManager
    {
        private static SchoolJournalEntities db;//EntityFramework

        private SqlConnection sqlConn = SchoolJournalADOAccess.OpenConn("SchoolJournalDBSQLConn");//SqlConnection

        private IList<Teacher> teachersList = new List<Teacher>();//both

        public TeacherManager()//EntityFramework
        {
            db = new SchoolJournalEntities();

        }

        //public IList<Teacher> GetAllTeachers()//EntityFramework
        //{
        //    return db.Teacher.Select(p => p).ToList();
        //}

        public IList<Teacher> GetAllTeachers()//SqlConnection
        {
            SqlCommand cmd = SchoolJournalADOAccess.StoredProcedureCommand("spGetAllTeachers",sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherEmail = reader["TeacherEmail"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();

                teachersList.Add(teacher);
            }
            SchoolJournalADOAccess.CloseConn(sqlConn);

            return teachersList;
        }

        //public IList<Teacher> GetByName(string name)//EntityFramework
        //{
        //    return db.Teacher.Where(p => p.TeacherName.Contains(name) || name == null).ToList();
        //}

        public IList<Teacher> GetByName(string name)//SqlConnection
        {
            Teacher teacher = new Teacher();
            SqlDataReader reader = SchoolJournalADOAccess.GetObjectFromReader(sqlConn, "select * from Teacher where TeacherName=" + name);

            while (reader.Read())
            {
                teacher.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherEmail = reader["TeacherEmail"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();

                teachersList.Add(teacher);
            }
            return teachersList;
        }

        //public Teacher Get(int id)//EntityFramework
        //{
        //    return db.Teacher.Find(id);
        //}

        public Teacher Get(int id)//SqlConnection
        {
            Teacher teacher = new Teacher();
            SqlDataReader reader = SchoolJournalADOAccess.GetObjectFromReader(sqlConn, "select * from Teacher where TeacherID=" + id);

            while (reader.Read())
            {
                teacher.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherEmail = reader["TeacherEmail"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();
            }
            return teacher;
        }

        //public void Add(Teacher teacher)//EntityFramework
        //{
        //    db.Teacher.Add(teacher);
        //    db.SaveChanges();
        //}

        public void Add(Teacher teacher)//SqlConnection
        {
            SqlCommand cmd = SchoolJournalADOAccess.StoredProcedureCommand("spAddTeacher", sqlConn);

            cmd.Parameters.AddWithValue("@TeacherName",teacher.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherEmail",teacher.TeacherEmail);
            cmd.Parameters.AddWithValue("@TeacherPhone",teacher.TeacherPhone);

            cmd.ExecuteNonQuery();
            SchoolJournalADOAccess.CloseConn(sqlConn);
        }

        //public void Save(Teacher teacher)//EntityFramework
        //{
        //    db.Entry(teacher).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        public void Save(Teacher teacher)//SqlConnection
        {
            SqlCommand cmd = SchoolJournalADOAccess.StoredProcedureCommand("spUpdateTeacher",sqlConn);
            cmd.Parameters.AddWithValue("@TeacherID",teacher.TeacherID);
            cmd.Parameters.AddWithValue("@TeacherName",teacher.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherEmail",teacher.TeacherEmail);
            cmd.Parameters.AddWithValue("@TeacherPhone",teacher.TeacherPhone);

            cmd.ExecuteNonQuery();
            SchoolJournalADOAccess.CloseConn(sqlConn);
        }

        //public void Delete(int id)//EntityFramework
        //{
        //    Teacher teacher = this.Get(id);
        //    db.Teacher.Remove(teacher);
        //    db.SaveChanges();
        //}

        public void Delete(int id)//SqlConnection
        {
            SqlCommand cmd = SchoolJournalADOAccess.StoredProcedureCommand("spDeleteTeacher",sqlConn);
            cmd.Parameters.AddWithValue("TeacherID", id);
            cmd.ExecuteNonQuery();

            SchoolJournalADOAccess.CloseConn(sqlConn);
        }
    }
}
