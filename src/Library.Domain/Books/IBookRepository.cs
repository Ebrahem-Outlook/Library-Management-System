namespace Library.Domain.Books;

public interface IBookRepository
{
    // Commands.
    Task AddAsync(Book book, CancellationToken cancellationToken);
    void Update(Book book);
    void Delete(Book book);

    // Queries.
    Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken);
    Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IEnumerable<Book>> GetByAuthorAsync(string author, CancellationToken cancellationToken);
}
