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
        [DisplayName("ID: ")]
        public int TeacherID { get; set; }

        [Required]
        [DisplayName("Name: ")]
        public string TeacherName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("E-mail: ")]
        public string TeacherEmail { get; set; }

        [DisplayName("Phone: ")]
        public string TeacherPhone { get; set; }
    }
}
