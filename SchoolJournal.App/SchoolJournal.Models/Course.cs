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
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Name of course is required!")]
        [DisplayName("Subject ")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Level year is required!")]
        [DisplayName("Level year ")]
        public int LevelYear { get; set; }

        [Required(ErrorMessage = "Teacher's name is required!")]
        [DisplayName("Teacher ID ")]
        public int TeacherID { get; set; }

        public IEnumerable<SelectListItem> TeachersList { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teachers { get; set; }
    }
}
