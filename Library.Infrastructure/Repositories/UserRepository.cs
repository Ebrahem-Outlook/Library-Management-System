using Library.Application.Core.Abstractions.Data;
using Library.Domain.Users;

namespace Library.Infrastructure.Repositories;

internal sealed class UserRepository(IDbContext dbContext) : IUserRepository
{
}
