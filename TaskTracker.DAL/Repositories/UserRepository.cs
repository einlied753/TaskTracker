using TaskTracker.DAL.Models;


namespace TaskTracker.DAL.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(Context context): base(context) { }
    }
}
