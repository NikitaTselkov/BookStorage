using Core.Models;

namespace DataBaseAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
   
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Book product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }
    }
}
