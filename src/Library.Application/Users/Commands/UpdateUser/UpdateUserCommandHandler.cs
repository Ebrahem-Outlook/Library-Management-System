using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Users.Commands.UpdateUser;

internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
{
    public Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    
}
