using System;
using System.Threading.Tasks;
using TaskTracker.DAL.Repositories;


namespace TaskTracker.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository GetTaskRepo();

        IProjectRepository GetProjectRepo();

        IUserRepository GetUserRepo();

        Task SaveAsync();

        void Dispose(bool disposing);

        void Dispose();
    }
}
