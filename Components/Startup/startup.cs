using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficeIO.EcHutchCroft.Website.Components.Models.Options;
using OfficeIO.EcHutchCroft.Website.Components.Services;
using System.IO;

namespace OfficeIO.EcHutchCroft.Website.Components.Startup
{
    public class Startup
    {
        #region Entry-Point
        /// <summary>
        /// When the application starts, sets-up the web-application host.
        /// </summary>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Holds the current configuration for the whole application.
        /// </summary>
        public IConfigurationRoot Configuration { get; private set; }
        #endregion

        /// <summary>
        /// Constructor. Builds and loads up the configuration from different sources.
        /// </summary>
        public Startup(IHostingEnvironment env)
        {
            // Build up the configuration from all the different sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"settings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets();

            Configuration = builder.Build();
        }

        /// <summary>
        /// Sets up all the services that are to be injected into eachother using dependency-injection.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add all the MVC service requirements.
            services.AddMvc();

            // Add the configuration option sections.
            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));

            // Add the view-locator service.
            services.Configure<RazorViewEngineOptions>(options => options.ViewLocationExpanders.Add(new ViewLocationExpander()));
        }

        /// <summary>
        /// Configures the HTTP pipeline to respond to different requests.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
