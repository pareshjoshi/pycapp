namespace TokenService.Okta
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using TokenService.Interfaces;

    /// <summary>
    /// The token service implementation for Okta server.
    /// </summary>
    public class OktaTokenService : ITokenService
    {
        private readonly IOptions<OktaConfiguration> configuration;

        private readonly HttpClient client;

        private OktaToken token = new OktaToken();

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaTokenService"/> class.
        /// </summary>
        /// <param name="configuration">The okta configuration.</param>
        /// <param name="client">Http client instance.</param>
        public OktaTokenService(IOptions<OktaConfiguration> configuration, HttpClient client)
        {
            this.configuration = configuration;
            this.client = client;
        }

        /// <inheritdoc />
        public async Task<string> GetTokenAsync()
        {
            if (!this.token.IsValidAndNotExpiring)
            {
                this.token = await GetNewAccessToken().ConfigureAwait(false);
            }

            return token.AccessToken;
        }

        private async Task<OktaToken> GetNewAccessToken()
        {
            var client_id = this.configuration.Value.ClientId;
            var client_secret = this.configuration.Value.ClientSecret;
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(clientCreds));

            var postMessage = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "scope", "access_token" },
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, configuration.Value.TokenUrl) { Content = new FormUrlEncodedContent(postMessage) };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var newToken = JsonConvert.DeserializeObject<OktaToken>(json);
            newToken.ExpiresAt = DateTime.UtcNow.AddSeconds(this.token.ExpiresIn);

            return newToken;
        }

        private class OktaToken
        {
            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }

            [JsonProperty(PropertyName = "expires_in")]
            public int ExpiresIn { get; set; }

            public DateTime ExpiresAt { get; set; }

            public string Scope { get; set; }

            [JsonProperty(PropertyName = "token_type")]
            public string TokenType { get; set; }

            public bool IsValidAndNotExpiring
            {
                get
                {
                    return !string.IsNullOrEmpty(this.AccessToken) && ExpiresAt > DateTime.UtcNow.AddSeconds(30);
                }
            }
        }
    }
}
