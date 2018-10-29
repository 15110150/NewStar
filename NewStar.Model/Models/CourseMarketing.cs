using NewStar.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("CourseMarketings")]
    public class CourseMarketing : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public int CourseID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int MarketingCampaignID { set; get; }

        [ForeignKey("CourseID")]
        public virtual Course Course { set; get; }

        [ForeignKey("MarketingCampaignID")]
        public virtual MarketingCampaign MarketingCampaign { set; get; }
    }
}