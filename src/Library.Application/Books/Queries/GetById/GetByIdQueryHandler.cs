using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetById;

internal sealed class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, Book>
{
    public Task<Book> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
