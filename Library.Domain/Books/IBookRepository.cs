namespace Library.Domain.Books;

public interface IBookRepository
{
    // Commands.
    Task AddAsync(Book book, CancellationToken cancellationToken);
    Task UpdateAsync(Book book, CancellationToken cancellationToken);
    Task DeleteAsync(Book book, CancellationToken cancellationToken);

    // Queries.
    Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Book> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IEnumerable<Book>> GetByAuthorAsync(string author, CancellationToken cancellationToken);
}
