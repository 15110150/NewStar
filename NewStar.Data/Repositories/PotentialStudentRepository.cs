using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface IPotentialStudentRepository : IRepository<PotentialStudent>
    {
    }

    public class PotentialStudentRepository : RepositoryBase<PotentialStudent>, IPotentialStudentRepository
    {
        public PotentialStudentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}