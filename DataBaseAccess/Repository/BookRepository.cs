using Models;
using System.ComponentModel;

namespace DataBaseAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public delegate void BookRepositoryChangeEventHandler();
        public event IBookRepository.BookRepositoryChangeEventHandler OnBooksChanged;

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       
        public void Save()
        {
            _dbContext.SaveChanges();
            OnBooksChanged?.Invoke();
        }

        public void Update(Book product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
            OnBooksChanged?.Invoke();
        }
    }
}
