using Library.Application.Core.Abstractions.Data;
using Library.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Provides methods to interact with the Book entities in the database.
    /// </summary>
    internal sealed class BookRepository : IBookRepository
    {
        private readonly IDbContext dbContext;

        public BookRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<Book>().AddAsync(book, cancellationToken);
        }

        public void Update(Book book)
        {
            dbContext.Set<Book>().Update(book);
        }

        public void Delete(Book book)
        {
            dbContext.Set<Book>().Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Set<Book>()
                                  .AsNoTracking()
                                  .Take(10)
                                  .ToListAsync(cancellationToken);
        }
        
        public async Task<IEnumerable<Book>> GetByAuthorAsync(string author, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(author)) return Enumerable.Empty<Book>();

            return await dbContext.Set<Book>()
                                  .AsNoTracking()
                                  .Where(book => EF.Functions.ILike(book.Author.Value, $"%{author}%")) 
                                  .Take(5)
                                  .ToListAsync(cancellationToken);
        }

        public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Book>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(book => book.Id == id, cancellationToken);
        }
        
        public async Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Book>()
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(book => EF.Functions.ILike(book.Title.Value, $"%{title}%"), cancellationToken);
        }
    }
}
