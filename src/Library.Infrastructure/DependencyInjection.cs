using Library.Application.Core.Abstractions.Authentication;
using Library.Application.Core.Abstractions.Data;
using Library.Application.Core.Abstractions.Emails;
using Library.Domain.Books;
using Library.Domain.Users;
using Library.Infrastructure.Authentication;
using Library.Infrastructure.Authentication.Settings;
using Library.Infrastructure.Database;
using Library.Infrastructure.Emails;
using Library.Infrastructure.Emails.Settings;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Library.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register EFCore...
        services.AddDbContext<LibraryDbContext>(options =>
        {
            string ConnectionString = configuration.GetConnectionString("Local-SqlServer") ?? throw new InvalidOperationException("ConnectionString does't exsit....");

            options.UseSqlServer(ConnectionString);
        });

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<LibraryDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<LibraryDbContext>());

        // Register User Service..
        services.AddScoped<IUserRepository, UserRepository>();

        // Register Book Service..
        services.AddScoped<IBookRepository, BookRepository>();

        // Register JWT Provider...
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]!))
            });

        // Register Authentication Service...
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));

        services.AddScoped<IJwtProvider, JwtProvider>();

        // Register Email Service...
        services.Configure<MailSettings>(configuration.GetSection(MailSettings.SettingsKey));

        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
