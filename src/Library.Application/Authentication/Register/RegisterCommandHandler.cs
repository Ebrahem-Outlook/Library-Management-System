using Library.Application.Core.Abstractions.Authentication;
using Library.Application.Core.Abstractions.CQRS;
using Library.Application.Core.Abstractions.Data;
using Library.Domain.Core.BaseType.Results;
using Library.Domain.Users;
using Library.Domain.Users.ValueObjects;

namespace Library.Application.Authentication.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Result<FirstName> firstNameResult = FirstName.Create(request.FirstName);
        Result<LastName> lastNameResult = LastName.Create(request.LastName);
        Result<Email> emailResult = Email.Create(request.Email);
        Result<Password> passwordResult = Password.Create(request.Password);

        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(firstNameResult, lastNameResult, emailResult, passwordResult);

        if(firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure<string>(firstFailureOrSuccess.Error);
        }

        var user = User.Create(firstNameResult.Value, lastNameResult.Value, emailResult.Value, passwordResult.Value);

        await _userRepository.AddAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        string token = _jwtProvider.GenerateToken(user);

        return Result.Success(token);
    }
}
