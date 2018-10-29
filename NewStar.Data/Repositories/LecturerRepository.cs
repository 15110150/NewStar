using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface ILecturerRepository : IRepository<Lecturer>
    {
    }

    public class LecturerRepository : RepositoryBase<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}