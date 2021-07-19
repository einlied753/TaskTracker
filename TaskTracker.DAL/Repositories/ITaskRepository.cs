using System.Collections.Generic;
using TaskTracker.DAL.Models;
using System.Threading.Tasks;


namespace TaskTracker.DAL.Repositories
{
    public interface ITaskRepository : IRepository<Models.Task> {

        System.Threading.Tasks.Task<IEnumerable<Models.Task>> SelectAllFromProjectAsync(int projectId);
    }
}
