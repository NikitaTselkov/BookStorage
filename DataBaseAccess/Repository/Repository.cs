using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DataBaseAccess.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public event CollectionChangeEventHandler OnCollectionChanged;

        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
     
        public void Add(T entity)
        {
            dbSet.Add(entity);
            OnCollectionChanged?.Invoke(null,
                new CollectionChangeEventArgs(CollectionChangeAction.Add, entity));
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            OnCollectionChanged?.Invoke(null,
                new CollectionChangeEventArgs(CollectionChangeAction.Remove, entity));
        }
    }
}
