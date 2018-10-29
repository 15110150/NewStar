using NewStar.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("Course")]
    public class Course : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public int CourseCategoryID { get; set; }

        public bool IsLongTerm { get; set; }

        [ForeignKey("CourseCategoryID")]
        public virtual CourseCategory CourseCategory { set; get; }

        public virtual IEnumerable<Class> Classes { set; get; }
        public virtual IEnumerable<Price> Prices { set; get; }
        public virtual IEnumerable<Discount> Discounts { set; get; }
    }
}