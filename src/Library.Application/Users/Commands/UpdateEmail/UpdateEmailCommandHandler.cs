using Library.Application.Core.Abstractions.Authentication;
using Library.Application.Core.Abstractions.CQRS;
using Library.Application.Core.Abstractions.Data;
using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Maybe;
using Library.Domain.Core.BaseType.Results;
using Library.Domain.Users;
using Library.Domain.Users.ValueObjects;

namespace Library.Application.Users.Commands.UpdateEmail;

internal sealed class UpdateEmailCommandHandler : ICommandHandler<UpdateEmailCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmailCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(request.Email);

        if(emailResult.IsFailure)
        {
            return Result.Failure<string>(Error.None);
        }

        Maybe<User> maybeUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if(maybeUser.HasNoValue)
        {
            return Result.Failure<string>(Error.None);
        }

        maybeUser.Value.UpdateEmail(emailResult.Value);

        _userRepository.Update(maybeUser.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        string token = _jwtProvider.GenerateToken(maybeUser.Value);

        return Result.Success(token);
    }
}
