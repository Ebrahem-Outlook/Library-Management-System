namespace Library.Domain.Users;

public interface IUserRepository
{
    // Commands.
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
    Task DeleteAsync(User user, CancellationToken cancellationToken);

    // Queries.
    Task GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task GetByNameAsync(string name, CancellationToken cancellationToken);
    Task GetByEmailAsync(string email, CancellationToken cancellationToken);
}