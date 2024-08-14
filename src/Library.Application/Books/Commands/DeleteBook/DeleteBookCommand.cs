using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Books.Commands.DeleteBook;

public sealed record DeleteBookCommand(Guid BookId) : ICommand;
