using MediatR;

namespace Library.Application.Core.Abstractions.CQRS;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
{

}
