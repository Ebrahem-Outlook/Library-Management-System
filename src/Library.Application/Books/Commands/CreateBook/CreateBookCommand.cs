using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Books.Commands.CreateBook;

public sealed record CreateBookCommand(
    string Title, 
    string Auther, 
    string Summary) : ICommand<string>;
