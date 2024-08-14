using FluentValidation;

namespace Library.Application.Books.Queries.GetByTitle;

internal sealed class GetByTitleQueryValidator : AbstractValidator<GetByTitleQuery>
{
    public GetByTitleQueryValidator()
    {
        RuleFor(book => book.Title).NotNull().NotEmpty().WithMessage("Title can't be null or empty.");
    }
}
