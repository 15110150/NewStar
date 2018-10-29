using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface INSUserRepository : IRepository<NSUser>
    {
    }

    public class NSUserRepository : RepositoryBase<NSUser>, INSUserRepository
    {
        public NSUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}