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
    public class Semester
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int SemesterID { get; set; }

        [Required(ErrorMessage = "Number of semester is required!")]
        [DisplayName("No. of semester ")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "School year is required!")]
        [DisplayName("School year ")]
        public string SchoolYear { get; set; }
    }
}
