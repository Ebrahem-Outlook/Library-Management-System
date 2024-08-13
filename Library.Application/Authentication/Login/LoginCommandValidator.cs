using FluentValidation;

namespace Library.Application.Authentication.Login;

internal sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("Email can't be null or empty.");

        RuleFor(user => user.Password).NotNull().NotEmpty().WithMessage("Password can't be null or empty.");
    }
}
