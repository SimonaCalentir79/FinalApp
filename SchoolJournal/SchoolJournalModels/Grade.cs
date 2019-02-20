﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Student ID ")]
        public int StudentID { get; set; }

        [DisplayName("Semester ID")]
        public int SemesterID { get; set; }

        [DisplayName("Subject ID")]
        public int SubjectID { get; set; }

        [DisplayName("Category ID")]
        public int CategoryID { get; set; }

        [Required]
        [DisplayName("Grade ")]
        public decimal Mark { get; set; }

        [Required]
        [DisplayName("Date ")]
        public Nullable<System.DateTime> DateOfGrade { get; set; }

        [DisplayName("Observations")]
        public string Observations { get; set; }

        public virtual GradeCategory GradeCategory { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}