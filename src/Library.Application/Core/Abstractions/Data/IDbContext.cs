using Library.Domain.Core.BaseType;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Core.Abstractions.Data;

/// <summary>
/// 
/// </summary>
public interface IDbContext
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
