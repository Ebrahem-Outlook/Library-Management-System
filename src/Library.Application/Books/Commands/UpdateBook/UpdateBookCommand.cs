using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Books.Commands.UpdateBook;

public sealed record UpdateBookCommand(
    Guid BookId,
    string Title,
    string Author,
    string Publisher,
    int  PageCount,
    string Summary,
    string Languge,
    string PublicationYear) : ICommand;
