using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace SchoolJournalModels
{
    public class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            this.Grades = new HashSet<Grade>();
            this.Homeworks = new HashSet<Homework>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int SubjectID { get; set; }

        [Required]
        [DisplayName("Subject ")]
        public string SubjectName { get; set; }

        [Required]
        [DisplayName("Level year ")]
        public int LevelYear { get; set; }

        [DisplayName("Teacher ID ")]
        public int TeacherID { get; set; }


        public IEnumerable<SelectListItem> TeachersList { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Homework> Homeworks { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teachers { get; set; }
    }
}
