using Library.Application.Core.Abstractions.Emails;
using Library.Infrastructure.Emails.Settings;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;

namespace Library.Infrastructure.Emails
{
    /// <summary>
    /// Provides methods for sending emails using SMTP.
    /// </summary>
    internal sealed class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="mailSettings">The mail settings configuration.</param>
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value ?? throw new ArgumentNullException(nameof(mailSettings));
        }

        /// <summary>
        /// Sends an email asynchronously.
        /// </summary>
        /// <param name="emailTo">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The body content of the email.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SendEmail(string emailTo, string subject, string body)
        {
            var email = new MimeMessage
            {
                From = { new MailboxAddress(_mailSettings.SenderDisplayName, _mailSettings.SenderEmail) },
                To = { MailboxAddress.Parse(emailTo) },
                Subject = subject,
                Body = new TextPart(TextFormat.Text) { Text = body }
            };

            try
            {
                using var smtpClient = new SmtpClient();

                await smtpClient.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.SmtpPort, SecureSocketOptions.StartTls)
                    .ConfigureAwait(false);

                await smtpClient.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.SmtpPassword)
                    .ConfigureAwait(false);

                await smtpClient.SendAsync(email).ConfigureAwait(false);

                await smtpClient.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while sending the email.", ex);
            }
        }
    }
}
