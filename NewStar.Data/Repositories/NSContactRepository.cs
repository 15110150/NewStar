using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface INSContactRepository : IRepository<NSContact>
    {
    }

    public class NSContactRepository : RepositoryBase<NSContact>, INSContactRepository
    {
        public NSContactRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}