using Library.Application.Core.Abstractions.Authentication;
using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using Library.Domain.Users;

namespace Library.Application.Authentication.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand>
{
    public Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
