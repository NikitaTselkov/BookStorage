using Core.Models;

namespace DataBaseAccess.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        public void Save();
        public void Update(Book product);
    }
}
