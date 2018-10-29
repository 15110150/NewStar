using NewStar.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("ClassOrganizations")]
    public class ClassOrganization : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public int ClassID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int LecturerID { set; get; }

        public bool IsMainLecture { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class Class { set; get; }

        [ForeignKey("LecturerID")]
        public virtual Lecturer Lecturer { set; get; }
    }
}