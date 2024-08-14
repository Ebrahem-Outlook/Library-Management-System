using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetByTitle;

internal sealed class GetByTitleCommandHandler : IQueryHandler<GetByTitleCommand, Book>
{
    public Task<Book> Handle(GetByTitleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
