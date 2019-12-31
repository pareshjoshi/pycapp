namespace TokenService
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TokenService.Interfaces;
    using TokenService.Okta;

    /// <summary>
    /// The startup class used for configuring service dependencies and middleware.
    /// </summary>
    public class Startup
    {
        private IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Configures the service dependencies.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<OktaConfiguration>(configuration.GetSection("Okta"));
            services.AddHttpClient<ITokenService, OktaTokenService>();

            services.AddControllers();
        }

        /// <summary>
        /// Configures the service middleware pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
