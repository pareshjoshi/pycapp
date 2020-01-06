namespace ContactsService.Configuration
{
    /// <summary>
    /// The authentication configuration.
    /// </summary>
    public class AuthConfig
    {
        /// <summary>
        /// Configuration section name.
        /// </summary>
        public const string SectionName = "Authentication";

        /// <summary>
        /// Authority that will authenticate the user.
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// Audience.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Whether HTTPS metadata are required or not.
        /// </summary>
        public bool RequireHttpsMetadata { get; set; }
    }
}
