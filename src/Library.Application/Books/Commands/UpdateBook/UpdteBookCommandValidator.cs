using FluentValidation;

namespace Library.Application.Books.Commands.UpdateBook;

internal sealed class UpdteBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdteBookCommandValidator()
    {
        RuleFor(book => book.BookId).NotEmpty().NotNull().WithMessage("BookId of book can't be null or empty.");

        RuleFor(book => book.Title).NotEmpty().NotNull().WithMessage("Title of book can't be null or empty.");

        RuleFor(book => book.Author).NotEmpty().NotNull().WithMessage("Author of book can't be null or empty.");

        RuleFor(book => book.Publisher).NotEmpty().NotNull().WithMessage("Publisher of book can't be null or empty.");

        RuleFor(book => book.PageCount).NotEmpty().NotNull().WithMessage("PageCount of book can't be null or empty.");

        RuleFor(book => book.Summary).NotEmpty().NotNull().WithMessage("Summary of book can't be null or empty.");

        RuleFor(book => book.Languge).NotEmpty().NotNull().WithMessage("Languge of book can't be null or empty.");

        RuleFor(book => book.PublicationYear).NotEmpty().NotNull().WithMessage("PublicationYear of book can't be null or empty.");
    }
}