using TaskTracker.DAL.Models;


namespace TaskTracker.DAL.Repositories
{
    internal class ProjectRepository : Repository<Project>, IProjectRepository
    {
        internal ProjectRepository(Context context) : base(context) { }
    }
}