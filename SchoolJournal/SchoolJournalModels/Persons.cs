using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolJournalModels
{
    public class Persons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persons()
        {
            this.Students = new HashSet<Students>();
            this.Teachers = new HashSet<Teachers>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("ID ")]
        public int PersonID { get; set; }

        [Required]
        [DisplayName("Name ")]
        public string PersonName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("E-mail ")]
        public string PersonEmail { get; set; }

        [DisplayName("Phone: ")]
        public string PersonPhone { get; set; }

        [DisplayName("Address: ")]
        public string PersonAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
