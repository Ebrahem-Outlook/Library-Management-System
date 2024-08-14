using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetByTitle;

internal sealed class GetByTitleQueryHandler : IQueryHandler<GetByTitleQuery, Book>
{
    public Task<Book> Handle(GetByTitleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
