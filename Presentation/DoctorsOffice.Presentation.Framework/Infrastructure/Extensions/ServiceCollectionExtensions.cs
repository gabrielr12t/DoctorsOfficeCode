using DoctorsOffice.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace DoctorsOffice.Presentation.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IEngine ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            IEngine engine = EngineContext.Create();

            engine.ConfigureServices(services, configuration);

            return engine;
        }
    }
}
