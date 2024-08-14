using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;

namespace Library.Application.Authentication.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<string>>
{
    public Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
