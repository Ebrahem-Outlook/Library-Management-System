using Library.Application.Core.Abstractions.Authentication;
using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using Library.Domain.Users;

namespace Library.Application.Authentication.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        this.userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        string email = 
    }
}
