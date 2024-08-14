using FluentValidation;

namespace Library.Application.Users.Queries.GetById;

internal sealed class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(user => user.UserId).NotEmpty().NotEmpty().WithMessage("UserId can't be null or empty.");
    }
}
