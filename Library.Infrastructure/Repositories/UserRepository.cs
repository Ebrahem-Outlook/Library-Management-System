using Library.Application.Core.Abstractions.Data;
using Library.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Provides data access methods for managing <see cref="User"/> entities.
    /// </summary>
    internal sealed class UserRepository : IUserRepository
    {
        private readonly IDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context used for interacting with the database.</param>
        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new <see cref="User"/> entity to the database.
        /// </summary>
        /// <param name="user">The <see cref="User"/> entity to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await dbContext.Set<User>().AddAsync(user, cancellationToken);
        }

        /// <summary>
        /// Updates an existing <see cref="User"/> entity in the database.
        /// </summary>
        /// <param name="user">The <see cref="User"/> entity to update.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        public void Update(User user, CancellationToken cancellationToken)
        {
            dbContext.Set<User>().Update(user);
        }

        /// <summary>
        /// Deletes a <see cref="User"/> entity from the database.
        /// </summary>
        /// <param name="user">The <see cref="User"/> entity to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        public void Delete(User user, CancellationToken cancellationToken)
        {
            dbContext.Set<User>().Remove(user);
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its email address.
        /// </summary>
        /// <param name="email">The email address of the <see cref="User"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="User"/> entity or null if not found.</returns>
        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="User"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="User"/> entity or null if not found.</returns>
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of <see cref="User"/> entities by their first name, with optional pagination.
        /// </summary>
        /// <param name="name">The first name to search for.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        /// <param name="pageNumber">The page number for pagination. Defaults to 1.</param>
        /// <returns>A task representing the asynchronous operation, with a list of <see cref="User"/> entities.</returns>
        public async Task<IEnumerable<User>> GetByNameAsync(string name, CancellationToken cancellationToken, int pageNumber = 1)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .Where(user => user.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase))
                                  .OrderBy(user => user.FirstName)
                                  .Skip((pageNumber - 1) * 10)
                                  .Take(10)
                                  .ToListAsync(cancellationToken);
        }
    }
}
