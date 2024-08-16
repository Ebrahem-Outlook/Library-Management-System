using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;

internal sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
{
    public Task<Result> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
