namespace Library.Infrastructure.Authentication.Settings
{
    /// <summary>
    /// Represents the settings required to configure JWT authentication.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// The key used to retrieve JWT settings from the configuration.
        /// </summary>
        public const string SettingsKey = "Jwt";

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtSettings"/> class.
        /// </summary>
        public JwtSettings()
        {
            Issuer = string.Empty;
            Audience = string.Empty;
            SecurityKey = string.Empty;
            TokenExpirationTime = 60; // Default to 60 minutes if not specified
        }

        /// <summary>
        /// Gets or sets the issuer of the JWT token.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the audience for the JWT token.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the security key used to sign the JWT token.
        /// </summary>
        public string SecurityKey { get; set; }

        /// <summary>
        /// Gets or sets the token expiration time in minutes.
        /// </summary>
        public int TokenExpirationTime { get; set; }
    }
}
