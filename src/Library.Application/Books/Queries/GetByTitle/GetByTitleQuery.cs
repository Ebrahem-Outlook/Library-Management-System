using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetByTitle;

public sealed record GetByTitleQuery(string Title) : IQuery<Book>;
