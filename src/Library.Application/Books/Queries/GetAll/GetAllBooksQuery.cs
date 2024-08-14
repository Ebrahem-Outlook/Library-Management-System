using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetAll;

public sealed record GetAllBooksQuery() : IQuery<IEnumerable<Book>>;
