using NewStar.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("PotentialStudent")]
    public class PotentialStudent : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public bool IsPotentialStudent { get; set; }

        public int NSContactID { get; set; }

        [ForeignKey("NSContactID")]
        public virtual NSContact NSContact { get; set; }
    }
}