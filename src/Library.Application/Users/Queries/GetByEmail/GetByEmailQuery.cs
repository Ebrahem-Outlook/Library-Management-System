using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Users;

namespace Library.Application.Users.Queries.GetByEmail;

public sealed record GetByEmailQuery(string Email) : IQuery<User>;
