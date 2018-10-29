using NewStar.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Roles")]
    public class Role : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string RoleName { get; set; }

        [StringLength(4000)]
        public string Comment { get; set; }

        public virtual IEnumerable<NSUser> NSUsers { set; get; }
    }
}