using Library.Domain.Core.BaseType;

namespace Library.Application.Core.Abstractions.Data;

public interface IDbContext
{

    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
