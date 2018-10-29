using NewStar.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Lecturers")]
    public class Lecturer : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        [StringLength(255)]
        public string Diploma { get; set; }

        [StringLength(255)]
        public string IdentityNo { get; set; }

        public int NSContactID { get; set; }

        [ForeignKey("NSContactID")]
        public virtual NSContact NSContact { set; get; }
    }
}