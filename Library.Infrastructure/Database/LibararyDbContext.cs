using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Library.Infrastructure.Database;

public sealed class LibararyDbContext : DbContext
{
    public LibararyDbContext(DbContextOptions<LibararyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
