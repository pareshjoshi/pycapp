namespace TokenService.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// The token service interface.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Gets token from the configured identity server.
        /// </summary>
        Task<string> GetTokenAsync();
    }
}
