using FluentValidation;

namespace Library.Application.Books.Commands.CreateBook;

internal sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(book => book.Title);
    }
}
