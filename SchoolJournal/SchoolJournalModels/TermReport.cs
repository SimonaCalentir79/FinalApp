using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace SchoolJournalModels
{
    public class TermReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ReportID { get; set; }

        [Required(ErrorMessage = "Student's name is required!")]
        [DisplayName("Student ID ")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Semester's number is required!")]
        [DisplayName("Semester ID ")]
        public int SemesterID { get; set; }

        [Required(ErrorMessage = "Course's name is required!")]
        [DisplayName("Course ID ")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Average grade is required!")]
        [DisplayName("Average Grade ")]
        public decimal AverageGrade { get; set; }


        public IEnumerable<SelectListItem> StudentsList { get; set; }
        public IEnumerable<SelectListItem> SemestersList { get; set; }
        public IEnumerable<SelectListItem> CoursesList { get; set; }


        [ForeignKey("SemesterID")]
        public virtual Semester Semesters { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Students { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Courses { get; set; }
    }
}
