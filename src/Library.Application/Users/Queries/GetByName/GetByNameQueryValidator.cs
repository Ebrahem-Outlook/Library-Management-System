using FluentValidation;

namespace Library.Application.Users.Queries.GetByName;

internal sealed class GetByNameQueryValidator : AbstractValidator<GetByNameQuery>
{
    public GetByNameQueryValidator()
    {
        RuleFor(user => user.Name).NotNull().NotEmpty().WithMessage("Name of user can't be null or empty.");
    }
}
