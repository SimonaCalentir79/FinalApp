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
    public class Homework
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int HomeworkID { get; set; }

        [Required(ErrorMessage = "Student's name is required!")]
        [DisplayName("Student ID ")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Course's name is required!")]
        [DisplayName("Course ID")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Date of homework is required!")]
        [DisplayName("Date ")]
        [DataType(DataType.Date)]
        public DateTime DateOfHomework { get; set; }

        [Required(ErrorMessage = "Due date of homework is required!")]
        [DisplayName("Due date ")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Details can't be null!")]
        [DisplayName("Details ")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Status can't be null!")]
        [DisplayName("Homework status ")]
        public string HomeworkStatus { get; set; }


        public IEnumerable<SelectListItem> StudentsList { get; set; }
        public IEnumerable<SelectListItem> CoursesList { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Students { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Courses { get; set; }
    }
}
