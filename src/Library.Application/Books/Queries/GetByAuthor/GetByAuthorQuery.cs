using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetByAuthor;

public sealed record GetByAuthorQuery(string Author) : IQuery<Book>;
