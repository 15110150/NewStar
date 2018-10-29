using NewStar.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Tasks")]
    public class Task : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255)]
        public string TaskName { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public int ContactID { get; set; }

        public virtual Contact Contact { set; get; }
    }
}