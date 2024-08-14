using Library.Application.Core.Abstractions.Data;
using Library.Domain.Books;

namespace Library.Infrastructure.Repositories;

internal sealed class BookRepository(IDbContext dbContext) : IBookRepository
{
    public Task AddAsync(Book book, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Book book, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetByAuthorAsync(string author, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Book book, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
