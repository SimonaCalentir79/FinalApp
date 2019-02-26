using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace SchoolJournalModels
{
    public class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Grades = new HashSet<Grade>();
            this.Homeworks = new HashSet<Homework>();
            this.TermReports = new HashSet<TermReport>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int CourseID { get; set; }

        [Required(ErrorMessage ="Name of course is required!")]
        [DisplayName("Subject ")]
        public string CourseName { get; set; }

        [Required(ErrorMessage ="Level year is required!")]
        [DisplayName("Level year ")]
        public int LevelYear { get; set; }

        [Required(ErrorMessage = "Teacher's name is required!")]
        [DisplayName("Teacher ID ")]
        public int TeacherID { get; set; }

        public IEnumerable<SelectListItem> TeachersList { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teachers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Homework> Homeworks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TermReport> TermReports { get; set; }
    }
}
