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

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="DbContext"/> instance used to access the database.</param>
        public BookRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Asynchronously adds a new <see cref="Book"/> entity to the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> entity to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<Book>().AddAsync(book, cancellationToken);
        }

        /// <summary>
        /// Updates an existing <see cref="Book"/> entity in the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> entity to update.</param>
        public void Update(Book book)
        {
            dbContext.Set<Book>().Update(book);
        }

        /// <summary>
        /// Deletes a <see cref="Book"/> entity from the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> entity to delete.</param>
        public void Delete(Book book)
        {
            dbContext.Set<Book>().Remove(book);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of <see cref="Book"/> entities by author name.
        /// </summary>
        /// <param name="author">The author name to search for.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation, with a result containing the collection of books that match the author name.</returns>
        public async Task<IEnumerable<Book>> GetByAuthorAsync(string author, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(author)) return Enumerable.Empty<Book>();

            return await dbContext.Set<Book>()
                                  .AsNoTracking()
                                  .Where(book => EF.Functions.ILike(book.Author, $"%{author}%")) // Use ILIKE for PostgreSQL
                                  .Take(5)
                                  .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves a <see cref="Book"/> entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation, with a result containing the book with the specified identifier, or <c>null</c> if not found.</returns>
        public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Book>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(book => book.Id == id, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves a <see cref="Book"/> entity by its title.
        /// </summary>
        /// <param name="title">The title to search for.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation, with a result containing the book with the specified title, or <c>null</c> if not found.</returns>
        public async Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Book>()
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(book => EF.Functions.ILike(book.Title, $"%{title}%"), cancellationToken);
        }
    }
}
