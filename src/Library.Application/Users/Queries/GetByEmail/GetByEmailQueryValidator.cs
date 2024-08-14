using FluentValidation;

namespace Library.Application.Users.Queries.GetByEmail;

internal sealed class GetByEmailQueryValidator : AbstractValidator<GetByEmailQuery>
{
    public GetByEmailQueryValidator()
    {
        RuleFor(user => user.Email).NotEmpty().NotEmpty().WithMessage("Email or user can't be null or empty.");
    }
}
