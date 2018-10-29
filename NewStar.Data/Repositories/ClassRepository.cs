using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
    }

    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}