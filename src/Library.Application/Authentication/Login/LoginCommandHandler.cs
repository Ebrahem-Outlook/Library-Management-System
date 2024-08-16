using Library.Application.Core.Abstractions.Authentication;
using Library.Application.Core.Abstractions.CQRS;
using Library.Application.Core.Abstractions.Data;
using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Maybe;
using Library.Domain.Core.BaseType.Results;
using Library.Domain.Users;
using Library.Domain.Users.ValueObjects;

namespace Library.Application.Authentication.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(request.Email);

        if(emailResult.IsFailure)
        {
            return Result.Failure<string>(Error.None);
        }

        Maybe<User> maybeUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if(maybeUser.HasNoValue)
        {
            return Result.Failure<string>(Error.None);
        }

        User user = maybeUser.Value;

        string token = _jwtProvider.GenerateToken(user);

        return token;
    }
}
