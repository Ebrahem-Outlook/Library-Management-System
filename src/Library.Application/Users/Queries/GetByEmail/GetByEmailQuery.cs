using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using Library.Domain.Users;
using MediatR;

namespace Library.Application.Users.Queries.GetByEmail;

public sealed record GetByEmailQuery() : IQuery<Result<User>>;


