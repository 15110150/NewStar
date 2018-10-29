using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface IPriceRepository : IRepository<Price>
    {
    }

    public class PriceRepository : RepositoryBase<Price>, IPriceRepository
    {
        public PriceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}