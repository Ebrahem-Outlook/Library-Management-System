using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Users;

namespace Library.Application.Users.Queries.GetByName;

public sealed record GetByNameQuery(string Name) : IQuery<User>;
