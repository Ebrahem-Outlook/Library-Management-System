using Library.Application.Core.Abstractions.Data;
using Library.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    
    internal sealed class UserRepository : IUserRepository
    {
        private readonly IDbContext dbContext;

        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await dbContext.Set<User>().AddAsync(user, cancellationToken);
        }

        public void Update(User user)
        {
            dbContext.Set<User>().Update(user);
        }

        public void Delete(User user)
        {
            dbContext.Set<User>().Remove(user);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(user => user.Email.Value == email, cancellationToken);
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetByNameAsync(string name, CancellationToken cancellationToken, int pageNumber = 1)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .Where(user => user.FirstName.Value.Contains(name, StringComparison.OrdinalIgnoreCase))
                                  .OrderBy(user => user.FirstName)
                                  .Skip((pageNumber - 1) * 10)
                                  .Take(10)
                                  .ToListAsync(cancellationToken);
        }
    }
}
