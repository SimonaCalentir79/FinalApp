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
                .HasMany(t => t.Subjects);

            modelBuilder.Entity<Subject>()
                .HasRequired(s => s.Teachers)
                .WithMany(s => s.Subjects)
                .HasForeignKey(s => s.TeacherID);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Homeworks);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Homeworks);

            modelBuilder.Entity<Homework>()
                .HasRequired(h => h.Students)
                .WithMany(h => h.Homeworks)
                .HasForeignKey(h => h.StudentID);

            modelBuilder.Entity<Homework>()
                .HasRequired(h => h.Subjects)
                .WithMany(h => h.Homeworks)
                .HasForeignKey(h => h.SubjectID);

            modelBuilder.Entity<Student>()
                .HasMany(g => g.Grades);

            modelBuilder.Entity<Subject>()
                .HasMany(g => g.Grades);

            modelBuilder.Entity<Semester>()
                .HasMany(g => g.Grades);

            modelBuilder.Entity<GradeCategory>()
                .HasMany(g => g.Grades);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Students)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.StudentID);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Subjects)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.SubjectID);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Semesters)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.SemesterID);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.GradeCategories)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.CategoryID);
        }

        public SchoolJournalEntities():base("name=SchoolJournalEntities"){}

        public virtual DbSet<GradeCategory> GradeCategory { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
    }
}
