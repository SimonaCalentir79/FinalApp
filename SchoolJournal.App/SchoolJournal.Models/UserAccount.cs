using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Models
{
    public class UserAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
