using FluentValidation;

namespace Library.Application.Books.Queries.GetByAuthor;

internal sealed class GetByAuthorQueryValidator : AbstractValidator<GetByAuthorQuery>
{
    public GetByAuthorQueryValidator()
    {
        RuleFor(book => book.Author).NotNull().NotEmpty().WithMessage("Author can't be null or empty.");
    }
}
