using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolJournal.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Name of student is required!!")]
        [DisplayName("Name ")]
        public string StudentName { get; set; }

        //[DataType(DataType.ImageUrl)]
        //[Required(ErrorMessage = "Photo of student is required!!")]
        [DisplayName("Photo ")]
        public string StudentPhoto { get; set; }

        [Required(ErrorMessage = "Details are required!!")]
        [DisplayName("Details ")]
        public string Observations { get; set; }
    }
}
