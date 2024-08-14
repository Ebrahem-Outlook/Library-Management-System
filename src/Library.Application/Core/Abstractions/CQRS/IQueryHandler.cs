using Library.Domain.Core.BaseType.Results;
using MediatR;

namespace Library.Application.Core.Abstractions.CQRS;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : class
{

}
