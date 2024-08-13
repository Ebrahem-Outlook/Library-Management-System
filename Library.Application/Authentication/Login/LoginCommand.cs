using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Authentication.Login;

public sealed record LoginCommand(string Email, string Password) : ICommand;
