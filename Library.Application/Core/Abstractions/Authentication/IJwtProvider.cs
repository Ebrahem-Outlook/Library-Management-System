namespace Library.Application.Core.Abstractions.Authentication;

public interface IJwtProvider
{
    string GenerateToken { get; }
}
