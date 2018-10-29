using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface IMarkRepository : IRepository<Mark>
    {
    }

    public class MarkRepository : RepositoryBase<Mark>, IMarkRepository
    {
        public MarkRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}