using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TeacherID { get; set; }

        [Required(ErrorMessage ="Name of teacher is required!!")]
        [DisplayName("Name ")]
        public string TeacherName { get; set; }

        [DisplayName("E-mail ")]
        [EmailAddress]
        public string TeacherEmail { get; set; }

        [DisplayName("Phone ")]
        public string TeacherPhone { get; set; }
    }
}
