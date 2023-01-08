using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using ksenz.Driver.Linux;
using ksenz.Game.Apex;
using ksenz.Logging;

namespace ksenz
{
    public static class Startup
    {
        #region Statics

        public static void ConfigureLogging(ILoggingBuilder builder)
        {
            builder.ClearProviders();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, LoggerProvider>());
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Linux>();
            Bootstrap.ConfigureServices(services);
        }

        #endregion
    }
}