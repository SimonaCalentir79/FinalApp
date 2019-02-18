using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SchoolJournalModels;

namespace SchoolJournalDataAccess
{
    public class SchoolJournalEntities: DbContext
    {
        public SchoolJournalEntities():base("name=SchoolJournalEntities"){}

        public virtual DbSet<GradeCategory> GradeCategory { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Semesters> Semesters { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
    }
}
