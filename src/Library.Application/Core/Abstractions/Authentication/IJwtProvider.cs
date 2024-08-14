using Library.Domain.Users;

namespace Library.Application.Core.Abstractions.Authentication;

/// <summary>
/// 
/// </summary>
public interface IJwtProvider
{
    /// <summary>
    /// 
    /// </summary>
    string GenerateToken(User user);
}
