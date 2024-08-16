using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Users.Commands.UpdateEmail;

internal sealed class UpdateEmailCommandHandler : ICommandHandler<UpdateEmailCommand>
{
    public Task<Result> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    
}
