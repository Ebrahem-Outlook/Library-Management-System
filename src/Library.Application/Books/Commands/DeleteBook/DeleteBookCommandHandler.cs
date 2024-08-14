using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;

namespace Library.Application.Books.Commands.DeleteBook;

internal sealed class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
{
    public Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
