namespace ContactsService
{
    using ContactsService.Configuration;
    using ContactsService.Repository;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
