using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetById;

public sealed record GetByIdQuery(Guid BookId) : IQuery<Book>;
