using NewStar.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("NSUsers")]
    public class NSUser : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        public int NSContactID { get; set; }

        public int RoleID { get; set; }

        [StringLength(4000)]
        public string Comment { get; set; }

        [ForeignKey("NSContactID")]
        public virtual NSContact NSContact { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}