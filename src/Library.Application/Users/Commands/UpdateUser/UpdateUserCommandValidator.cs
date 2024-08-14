using FluentValidation;

namespace Library.Application.Users.Commands.UpdateUser;

internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("FirstName can't be null or empty.");

        RuleFor(user => user.LastName).NotNull().NotEmpty().WithMessage("FirstName can't be null or empty.");
    }
}
