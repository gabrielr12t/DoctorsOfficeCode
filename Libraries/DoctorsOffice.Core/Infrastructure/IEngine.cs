using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DoctorsOffice.Core.Infrastructure
{
    public interface IEngine
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        void ConfigureRequestPipeline(IApplicationBuilder application);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        IEnumerable<T> ResolveAll<T>();
        object ResolveUnregistered(Type type);
    }
}
