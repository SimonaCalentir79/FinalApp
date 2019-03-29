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
    public class Timetable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int TimetableID { get; set; }

        [Required(ErrorMessage = "ID of student is required!")]
        [DisplayName("Student ID ")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Day of the week is required!")]
        [DisplayName("Day of the week ")]
        public string DayOfTheWeek { get; set; }

        [Required(ErrorMessage = "Time interval is required!")]
        [DisplayName("Time interval ")]
        public string TimeInterval { get; set; }

        [Required(ErrorMessage ="Course ID is required!")]
        [DisplayName("Course ID")]
        public int CourseID { get; set; }

        public IEnumerable<SelectListItem> StudentsList { get; set; }
        public IEnumerable<SelectListItem> CoursesList { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Students { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Courses { get; set; }
    }
}
