using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
    }

    public class CourseCategoryRepository : RepositoryBase<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}