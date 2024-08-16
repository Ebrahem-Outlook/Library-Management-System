using FluentValidation;

namespace Library.Application.Authentication.Register;

internal sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(user => user.FirstName).NotEmpty().NotNull().WithMessage("FirstName can't be null or empty..");

        RuleFor(user => user.LastName).NotEmpty().NotNull().WithMessage("LastName can't be null or empty..");

        RuleFor(user => user.Email).NotEmpty().NotNull().WithMessage("Email can't be null or empty..");

        RuleFor(user => user.Password).NotEmpty().NotNull().WithMessage("Password can't be null or empty..");
    }
}
