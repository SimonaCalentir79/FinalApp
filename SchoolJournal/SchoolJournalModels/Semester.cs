﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolJournalModels
{
    public class Semester
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semester()
        {
            this.Grades = new HashSet<Grade>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int SemesterID { get; set; }

        [Required(ErrorMessage ="Number of semester is required!")]
        [DisplayName("No. of semester ")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage ="School year is required!")]
        [DisplayName("School year ")]
        public string SchoolYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<TermReport> TermReports { get; set; }
    }
}
