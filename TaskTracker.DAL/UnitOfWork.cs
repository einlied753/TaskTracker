using System;
using System.Threading.Tasks;
using TaskTracker.DAL.Repositories;

namespace TaskTracker.DAL
{
    public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable where TDbContext : Context, new ()
    {
        private TDbContext _context;
        private bool _disposed = false;

        public UnitOfWork()
        {
            _context = new TDbContext();
        }
        

        public ITaskRepository GetTaskRepo() => new TaskRepository(_context);

        public IProjectRepository GetProjectRepo() => new ProjectRepository(_context);

        public IUserRepository GetUserRepo() => new UserRepository(_context);


        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
