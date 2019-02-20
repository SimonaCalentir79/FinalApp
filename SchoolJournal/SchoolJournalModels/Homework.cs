using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolJournalModels
{
    public class Homework
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HomeworkID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public Nullable<System.DateTime> DateOfHomework { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Details { get; set; }

        public virtual Student Students { get; set; }
        public virtual Subject Subjects { get; set; }
    }
}
