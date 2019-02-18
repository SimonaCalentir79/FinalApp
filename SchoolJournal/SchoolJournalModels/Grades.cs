using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolJournalModels
{
    public class Grades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int SemesterID { get; set; }
        public int SubjectID { get; set; }
        public int CategoryID { get; set; }
        public decimal Grade { get; set; }
        public Nullable<System.DateTime> DateOfGrade { get; set; }
        public string Observations { get; set; }

        public virtual GradeCategory GradeCategory { get; set; }
        public virtual Semesters Semesters { get; set; }
        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
