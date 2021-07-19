using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using TaskTracker.DAL.Models;

namespace TaskTracker.DAL
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected Context Context { get; private set; }

        protected DbSet<TEntity> DbSet { get; private set; }

        protected Repository(Context context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual Task<TEntity> SelectByIdAsync(int id)
        {
            return DbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual Task<TEntity> SelectFirstOrDefaultAsync()
        {
            return DbSet.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Added)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

    }
}
