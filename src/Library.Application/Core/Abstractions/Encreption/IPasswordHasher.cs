namespace Library.Application.Core.Abstractions.Encreption;

/// <summary>
/// 
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    string Hash(string password);
}
