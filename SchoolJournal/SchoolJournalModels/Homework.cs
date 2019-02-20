using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolJournalModels
{
    public class Homework
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int HomeworkID { get; set; }

        [Required]
        [DisplayName("Student ID ")]
        public int StudentID { get; set; }

        [Required]
        [DisplayName("Subject ID")]
        public int SubjectID { get; set; }

        [Required]
        [DisplayName("Date ")]
        public Nullable<System.DateTime> DateOfHomework { get; set; }

        [Required]
        [DisplayName("Due date ")]
        public Nullable<System.DateTime> DueDate { get; set; }

        [DisplayName("Details ")]
        public string Details { get; set; }

        public virtual Student Students { get; set; }
        public virtual Subject Subjects { get; set; }
    }
}
