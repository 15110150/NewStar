using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface IAdvertisingObjectRepository : IRepository<AdvertisingObject>
    {
    }

    public class AdvertisingObjectRepository : RepositoryBase<AdvertisingObject>, IAdvertisingObjectRepository
    {
        public AdvertisingObjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}