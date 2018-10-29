using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface IMarketingCampaignRepository : IRepository<MarketingCampaign>
    {
    }

    public class MarketingCampaignRepository : RepositoryBase<MarketingCampaign>, IMarketingCampaignRepository
    {
        public MarketingCampaignRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}