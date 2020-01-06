namespace ContactsService
{
    using ContactsService.Configuration;
    using ContactsService.Repository;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    /// <summary>
    /// Start up class that register middleware pipeline and its dependencies.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// The application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Register service dependencies.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Mongo>(Configuration.GetSection(Mongo.SectionName));

            services.AddSingleton<IMongoClient>((provider) =>
           {
               var option = provider.GetService<IOptions<Mongo>>().Value;

               return new MongoClient(option.ConnectionString);
           });

            services.AddSingleton<IContactsRepository, ContactsRepository>();
            services.AddHealthChecks();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var config = new AuthConfig();
                Configuration.GetSection(AuthConfig.SectionName).Bind(config);

                options.Authority = config.Authority;
                options.Audience = config.Audience;
                options.RequireHttpsMetadata = config.RequireHttpsMetadata;
            });

            services.AddControllers();
        }

        /// <summary>
        /// Registers application middleware.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
