using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Core.Abstractions.CQRS;

/// <summary>
/// 
/// </summary>
public interface ICommand : IRequest
{

}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
    where TResponse : Result<TResponse>
{

}
