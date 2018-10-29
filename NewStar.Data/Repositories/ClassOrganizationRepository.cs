using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface IClassOrganizationRepository : IRepository<ClassOrganization>
    {
    }

    public class ClassOrganizationRepository : RepositoryBase<ClassOrganization>, IClassOrganizationRepository
    {
        public ClassOrganizationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}