using NewStar.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Marks")]
    public class Mark : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public int ClassID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int StudentID { set; get; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public float MidMark { get; set; }
        public float FinalMark { get; set; }
        public float TotalMark { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class Class { set; get; }

        [ForeignKey("StudentID")]
        public virtual Student Student { set; get; }
    }
}