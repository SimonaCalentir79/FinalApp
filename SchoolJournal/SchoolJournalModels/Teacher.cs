using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolJournalModels
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int TeacherID { get; set; }

        [Required(ErrorMessage ="Name of teacher is required!")]
        [DisplayName("Name of teacher: ")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage ="E-mail address is required!")]
        [EmailAddress]
        [DisplayName("E-mail ")]
        public string TeacherEmail { get; set; }

        [DisplayName("Phone ")]
        public string TeacherPhone { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
