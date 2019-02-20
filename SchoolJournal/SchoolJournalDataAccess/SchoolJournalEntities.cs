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
