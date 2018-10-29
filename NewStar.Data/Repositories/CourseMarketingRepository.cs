using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface ICourseMarketingRepository : IRepository<CourseMarketing>
    {
    }

    public class CourseMarketingRepository : RepositoryBase<CourseMarketing>, ICourseMarketingRepository
    {
        public CourseMarketingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}