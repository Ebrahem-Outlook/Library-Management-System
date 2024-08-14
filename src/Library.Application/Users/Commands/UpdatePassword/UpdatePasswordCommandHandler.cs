using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;

namespace Library.Application.Users.Commands.UpdatePassword;

internal sealed class UpdatePasswordCommandHandler : ICommandHandler<UpdatePasswordCommand>
{
    public Task<Result> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
