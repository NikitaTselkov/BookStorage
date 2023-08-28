using System.ComponentModel;
using System.Linq.Expressions;

namespace DataBaseAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        public event CollectionChangeEventHandler OnCollectionChanged;
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
    }
}
