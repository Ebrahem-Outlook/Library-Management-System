namespace Library.Infrastructure.Emails.Settings
{
    /// <summary>
    /// Represents the settings required to configure the email service.
    /// </summary>
    public sealed class MailSettings
    {
        /// <summary>
        /// The key used to retrieve mail settings from the configuration.
        /// </summary>
        public const string SettingsKey = "Mail";

        /// <summary>
        /// Initializes a new instance of the <see cref="MailSettings"/> class.
        /// </summary>
        public MailSettings()
        {
            SenderDisplayName = string.Empty;
            SenderEmail = string.Empty;
            SmtpPassword = string.Empty;
            SmtpServer = string.Empty;
        }

        /// <summary>
        /// Gets or sets the display name of the email sender.
        /// </summary>
        public string SenderDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the sender.
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Gets or sets the password for authenticating with the SMTP server.
        /// </summary>
        public string SmtpPassword { get; set; }

        /// <summary>
        /// Gets or sets the SMTP server address.
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// Gets or sets the port number used for the SMTP server.
        /// </summary>
        public int SmtpPort { get; set; }
    }
}
