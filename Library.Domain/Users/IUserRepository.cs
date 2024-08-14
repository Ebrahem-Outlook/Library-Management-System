namespace Library.Domain.Users
{
    /// <summary>
    /// Defines the contract for user repository operations, including commands for adding, updating, and deleting users,
    /// as well as queries for retrieving users by various criteria.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Asynchronously adds a new user to the repository.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(User user, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing user in the repository.
        /// </summary>
        /// <param name="user">The user to update.</param>
        void Update(User user);

        /// <summary>
        /// Deletes a user from the repository.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        void Delete(User user);

        /// <summary>
        /// Asynchronously retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the user, or null if not found.</returns>
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously retrieves users by their name, with optional pagination.
        /// </summary>
        /// <param name="name">The name of the users to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <param name="pageNumber">The page number for pagination (default is 1).</param>
        /// <returns>A task representing the asynchronous operation, with a result of a collection of users.</returns>
        Task<IEnumerable<User>> GetByNameAsync(string name, CancellationToken cancellationToken, int pageNumber = 1);

        /// <summary>
        /// Asynchronously retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the user, or null if not found.</returns>
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
