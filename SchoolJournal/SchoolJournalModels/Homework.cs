using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

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

        
        [DisplayName("Date ")]
        public Nullable<System.DateTime> DateOfHomework { get; set; }

        
        [DisplayName("Due date ")]
        public Nullable<System.DateTime> DueDate { get; set; }

        [DisplayName("Details ")]
        public string Details { get; set; }


        public IEnumerable<SelectListItem> StudentsList { get; set; }
        public IEnumerable<SelectListItem> SubjectsList { get; set; }

        
        [ForeignKey("StudentID")]
        public virtual Student Students { get; set; }

        [ForeignKey("SubjectID")]
        public virtual Subject Subjects { get; set; }
    }
}
