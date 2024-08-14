using FluentValidation;

namespace Library.Application.Books.Commands.DeleteBook;

internal sealed class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(book => book.BookId).NotNull().NotEmpty().WithMessage("BookId can't be null or empty.");
    }
}
