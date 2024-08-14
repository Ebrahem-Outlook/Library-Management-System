namespace Library.Application.Core.Abstractions.Emails;

/// <summary>
/// 
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="emailTo"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    Task SendEmail(string emailTo, string subject, string body);
}
