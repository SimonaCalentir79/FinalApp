using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolJournal.Models
{
    public class Grade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeID { get; set; }

        [Required(ErrorMessage = "Student's name is required!")]
        [DisplayName("Student ID ")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Semester is required!")]
        [DisplayName("Semester ID ")]
        public int SemesterID { get; set; }

        [Required(ErrorMessage = "Course's name is required!")]
        [DisplayName("Course ID ")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Grade is required!")]
        [DisplayName("Grade ")]
        public decimal Mark { get; set; }

        [Required(ErrorMessage = "Grade's date is required!")]
        [DisplayName("Date ")]
        [DataType(DataType.Date)]
        public DateTime DateOfMark { get; set; }

        [Required(ErrorMessage = "Grade's weight is required!")]
        [DisplayName("Weight ")]
        public decimal GradingWeight { get; set; }

        [DisplayName("Observations ")]
        public string Observations { get; set; }


        public IEnumerable<SelectListItem> StudentsList { get; set; }
        public IEnumerable<SelectListItem> CoursesList { get; set; }
        public IEnumerable<SelectListItem> SemestersList { get; set; }


        [ForeignKey("SemesterID")]
        public virtual Semester Semesters { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Students { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Courses { get; set; }
    }
}
