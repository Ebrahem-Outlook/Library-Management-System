using FluentValidation;

namespace Library.Application.Books.Queries.GetByTitle;

internal sealed class GetByTitleCommandValidator : AbstractValidator<GetByTitleCommand>
{
    public GetByTitleCommandValidator()
    {
        RuleFor(book => book.Title).NotNull().NotEmpty().WithMessage("Title can't be null or empty.");
    }
}
