using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Users;

namespace Library.Application.Users.Queries.GetById;

public sealed record GetByIdQuery(Guid UserId) : IQuery<User>;
