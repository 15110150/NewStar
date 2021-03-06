﻿using NewStar.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Contacts")]
    public class Contact : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(20)]
        public string MobilePhone { get; set; }

        [StringLength(20)]
        public string WorkPhone { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Website { get; set; }

        [StringLength(255)]
        public string Facebook { get; set; }

        [StringLength(255)]
        public string Skype { get; set; }

        [StringLength(4000)]
        public string Comment { get; set; }

        public virtual IEnumerable<Task> Tasks { set; get; }
    }
}