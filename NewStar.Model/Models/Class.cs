using NewStar.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Classes")]
    public class Class : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string NumberStudent { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CourseID { get; set; }

        public int MarkID { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Room { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { set; get; }

        public virtual IEnumerable<Student> Students { set; get; }
        public virtual IEnumerable<Invoice> Invoices { set; get; }
    }
}