using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(string FirstName, string LastName) : ICommand;
