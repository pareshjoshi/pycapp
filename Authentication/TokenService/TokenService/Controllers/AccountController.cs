namespace TokenService.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TokenService.Interfaces;

    /// <summary>
    /// The account controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="tokenService">The token generation service.</param>
        public AccountController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Gets the generated token.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            var token = await tokenService.GetTokenAsync().ConfigureAwait(false);

            return Ok(token);
        }
    }
}