using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolJournalModels
{
    public class Grade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int SemesterID { get; set; }
        public int SubjectID { get; set; }
        public int CategoryID { get; set; }
        public decimal Mark { get; set; }
        public Nullable<System.DateTime> DateOfGrade { get; set; }
        public string Observations { get; set; }

        public virtual GradeCategory GradeCategory { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
