using FluentValidation;

namespace Library.Application.Users.Commands.UpdatePassword;

internal sealed class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty().WithMessage("UserId can't null or empty.");

        RuleFor(user => user.Password).NotNull().NotEmpty().WithMessage("Password can't null or empty.");
    }
}
