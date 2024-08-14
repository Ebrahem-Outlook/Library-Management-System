using FluentValidation;

namespace Library.Application.Books.Queries.GetById;

internal sealed class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(book => book.BookId).NotEmpty().NotNull().WithMessage("BookId can't be null or empty.");
    }
}
