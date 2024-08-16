using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Books.Commands.UpdateBook;

internal sealed class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand>
{
    public Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    
}
