using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DoctorsOffice.Core.Infrastructure
{
    public class DoctorsOfficeEngine : IEngine
    {
        public void ConfigureRequestPipeline(IApplicationBuilder application)
        {
            throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public object ResolveUnregistered(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
