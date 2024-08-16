using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;

namespace Library.Application.Authentication.Login;

public sealed record LoginCommand(string Email, string Password) : ICommand<Result<string>>;
