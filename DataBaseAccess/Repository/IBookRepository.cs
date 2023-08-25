using Models;

namespace DataBaseAccess.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        public delegate void BookRepositoryChangeEventHandler();

        public event BookRepositoryChangeEventHandler OnBooksChanged;

        public void Save();
        public void Update(Book product);
    }
}
