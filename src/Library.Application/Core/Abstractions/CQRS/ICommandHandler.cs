using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Core.Abstractions.CQRS;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{

}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : Result<TResponse>
{

}
