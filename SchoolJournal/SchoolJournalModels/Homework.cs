using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;
using static SchoolJournalModels.CustomValidation;

namespace SchoolJournalModels
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

        [Required(ErrorMessage ="Date of homework is required!")]
        [DisplayName("Date ")]
        [DataType(DataType.Date)]
        public DateTime DateOfHomework { get; set; }

        [Required(ErrorMessage ="Due date of homework is required!")]
        [DisplayName("Due date ")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Details can't be null!")]
        [DisplayName("Details ")]
        public string Details { get; set; }

        [Required(ErrorMessage ="Status can't be null!")]
        [DisplayName("Homework status ")]
        [CheckStatus(AllowStatus ="TO DO, IN PROGRESS, FINISHED",ErrorMessage = "Choose a valid status eg.'TO DO', 'IN PROGRESS', 'FINISHED'.")]
        public string HomeworkStatus { get; set; }

        public IEnumerable<SelectListItem> StudentsList { get; set; }
        public IEnumerable<SelectListItem> CoursesList { get; set; }
        
        [ForeignKey("StudentID")]
        public virtual Student Students { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Courses { get; set; }
    }
}
