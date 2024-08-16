using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Core.Abstractions.CQRS;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{

}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : class
{

}
