namespace TokenService.Okta
{
    using System;

    /// <summary>
    /// The okta configuration keys.
    /// </summary>
    public class OktaConfiguration
    {
        /// <summary>
        /// Okta server uri.
        /// </summary>
        public Uri TokenUrl { get; set; }

        /// <summary>
        /// Client id to be used for token generation.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret used for token generation.
        /// </summary>
        public string ClientSecret { get; set; }
    }
}
