using NewStar.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Invoices")]
    public class Invoice : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Code { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }

        public int ClassID { get; set; }

        public int StudentID { get; set; }

        public int DiscountID { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class Class { set; get; }

        [ForeignKey("StudentID")]
        public virtual Student Student { set; get; }

        [ForeignKey("DiscountID")]
        public virtual Discount Discount { set; get; }
    }
}