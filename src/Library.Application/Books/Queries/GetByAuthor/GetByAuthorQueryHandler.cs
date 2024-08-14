using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetByAuthor;

internal sealed class GetByAuthorQueryHandler : IQueryHandler<GetByAuthorQuery, Book>
{
    public Task<Book> Handle(GetByAuthorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
