using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Authentication.Register;

public sealed record RegisterCommand(string Email, string Password) : ICommand;
