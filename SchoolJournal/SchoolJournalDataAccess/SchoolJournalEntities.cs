using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SchoolJournalModels;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace SchoolJournalDataAccess
{
    public class SchoolJournalEntities: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses);

            modelBuilder.Entity<Course>()
                .HasRequired(s => s.Teachers)
                .WithMany(s => s.Courses)
                .HasForeignKey(s => s.TeacherID);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Homeworks);

            modelBuilder.Entity<Course>()
                .HasMany(s => s.Homeworks);

            modelBuilder.Entity<Homework>()
                .HasRequired(h => h.Students)
                .WithMany(h => h.Homeworks)
                .HasForeignKey(h => h.StudentID);

            modelBuilder.Entity<Homework>()
                .HasRequired(h => h.Courses)
                .WithMany(h => h.Homeworks)
                .HasForeignKey(h => h.CourseID);

            modelBuilder.Entity<Student>()
                .HasMany(g => g.Grades);

            modelBuilder.Entity<Course>()
                .HasMany(g => g.Grades);

            modelBuilder.Entity<Semester>()
                .HasMany(g => g.Grades);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Students)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.StudentID);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Courses)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.CourseID);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Semesters)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.SemesterID);

            modelBuilder.Entity<Student>()
                .HasMany(g => g.TermReports);

            modelBuilder.Entity<Course>()
                .HasMany(g => g.TermReports);

            modelBuilder.Entity<Semester>()
                .HasMany(g => g.TermReports);

            modelBuilder.Entity<TermReport>()
                .HasRequired(g => g.Students)
                .WithMany(g => g.TermReports)
                .HasForeignKey(g => g.StudentID);

            modelBuilder.Entity<TermReport>()
                .HasRequired(g => g.Courses)
                .WithMany(g => g.TermReports)
                .HasForeignKey(g => g.CourseID);

            modelBuilder.Entity<TermReport>()
                .HasRequired(g => g.Semesters)
                .WithMany(g => g.TermReports)
                .HasForeignKey(g => g.SemesterID);
        }

        public SchoolJournalEntities():base("name=SchoolJournalEntities"){}

        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TermReport> TermReport { get; set; }
    }
}
