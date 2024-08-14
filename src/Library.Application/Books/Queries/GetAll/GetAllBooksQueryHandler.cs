using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Books;

namespace Library.Application.Books.Queries.GetAll;

internal sealed class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.GetAllAsync(cancellationToken);
    }
}

