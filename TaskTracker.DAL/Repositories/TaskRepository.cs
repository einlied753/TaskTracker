using System.Collections.Generic;
using System.Linq;
using TaskTracker.DAL.Models;
using System.Data.Entity;


namespace TaskTracker.DAL.Repositories
{
    internal class TaskRepository : Repository<Task>, ITaskRepository
    {
        internal TaskRepository(Context context) : base(context) { }

        public async System.Threading.Tasks.Task<IEnumerable<Models.Task>> SelectAllFromProjectAsync(int projectId)
        {
            return await DbSet.Where(t => t.ProjectId == projectId).ToListAsync();
        }
    }
}