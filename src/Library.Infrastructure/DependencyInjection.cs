using Library.Application.Core.Abstractions.Data;
using Library.Domain.Books;
using Library.Domain.Users;
using Library.Infrastructure.Database;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options =>
        {
            string ConnectionString = configuration.GetConnectionString("Local-SqlServer") ?? throw new InvalidOperationException("ConnectionString does't exsit....");

            options.UseSqlServer(ConnectionString);
        });

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<LibraryDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<LibraryDbContext>());


        

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
