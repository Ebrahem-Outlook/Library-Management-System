using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Users.Commands.UpdateEmail;

public sealed record UpdateEmailCommand(Guid UserId, string Email) : ICommand;
