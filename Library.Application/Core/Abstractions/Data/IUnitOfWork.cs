using Microsoft.EntityFrameworkCore.Storage;

namespace Library.Application.Core.Abstractions.Data;

/// <summary>
/// 
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}
