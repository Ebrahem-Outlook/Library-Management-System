using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;

namespace Library.Application.Authentication.Register;

public sealed record RegisterCommand(string Email, string Password) : ICommand<Result<string>>;
