using NewStar.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Students")]
    public class Student : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public bool IsPotentialStudent { get; set; }

        public int ContactID { get; set; }

        [ForeignKey("ContactID")]
        public virtual Contact Contact { get; set; }

        public virtual IEnumerable<Invoice> Invoices { set; get; }
    }
}