using Library.Application.Core.Abstractions.Data;
using Library.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

internal sealed class BookRepository(IDbContext dbContext) : IBookRepository
{
    public async Task AddAsync(Book book, CancellationToken cancellationToken)
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


    public async Task<IEnumerable<Book>> GetByAuthorAsync(string author, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Book>()
                              .AsNoTracking()
                              .Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                              .Take(5)
                              .ToListAsync(cancellationToken);
    }

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Book>()
                              .AsNoTracking()
                              .SingleOrDefaultAsync(book => book.Id == id, cancellationToken);
    }

    public async Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Book>()
                              .AsNoTracking()
                              .FirstOrDefaultAsync(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    } 
}
