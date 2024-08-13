namespace Library.Application.Core.Abstractions.Emails;

/// <summary>
/// 
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    Task SendEmail(string from, string to, string body);
}
