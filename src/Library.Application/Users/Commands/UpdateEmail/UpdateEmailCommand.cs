using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;

namespace Library.Application.Users.Commands.UpdateEmail;

public sealed record UpdateEmailCommand(Guid UserId, string Email) : ICommand<Result<string>>;
