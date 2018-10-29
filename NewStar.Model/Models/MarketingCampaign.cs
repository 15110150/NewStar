using NewStar.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewStar.Model.Models
{
    [Table("MarketingCampaigns")]
    public class MarketingCampaign : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255)]
        public string CampaignName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CampaignType { get; set; }
        public string Frequency { get; set; }
        public string Content { get; set; }
        public string Objective { get; set; }
        public float ExpectedRevenue { get; set; }
        public float ActualCost { get; set; }
        public float ExpectedCost { get; set; }
    }
}