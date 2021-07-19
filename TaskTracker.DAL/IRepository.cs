using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.DAL.Models;

namespace TaskTracker.DAL
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> SelectByIdAsync(int id);

        Task<TEntity> SelectFirstOrDefaultAsync();

        Task<IEnumerable<TEntity>> SelectAllAsync();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
