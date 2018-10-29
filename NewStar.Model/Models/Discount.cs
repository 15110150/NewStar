using NewStar.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Discounts")]
    public class Discount : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string DiscountCode { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public float DiscountValue { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { set; get; }

        public virtual IEnumerable<Invoice> Invoices { set; get; }
    }
}