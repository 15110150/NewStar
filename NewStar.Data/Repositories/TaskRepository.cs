using NewStar.Data.Insfrastructure;
using NewStar.Model.Models;

namespace NewStar.Data.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
    }

    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}