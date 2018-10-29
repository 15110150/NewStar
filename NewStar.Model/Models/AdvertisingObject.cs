using NewStar.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("AdvertisingObjects")]
    public class AdvertisingObject : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public int ContactID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int MarketingCampaignID { set; get; }

        public bool TotalObject { get; set; }

        [ForeignKey("ContactID")]
        public virtual Contact Contact { set; get; }

        [ForeignKey("MarketingCampaignID")]
        public virtual MarketingCampaign MarketingCampaign { set; get; }
    }
}