using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Users.Commands.UpdatePassword;

public sealed record UpdatePasswordCommand(Guid UserId, string Password) : ICommand;
