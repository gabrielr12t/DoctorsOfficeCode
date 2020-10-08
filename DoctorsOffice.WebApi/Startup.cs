using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DoctorsOffice.WebApi.Helpers;
using DoctorsOffice.WebApi.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoctorsOffice.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IEnumerable<IInstaller> instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                                                where t.GetInterfaces().Contains(typeof(IInstaller))
                                                         && t.GetConstructor(Type.EmptyTypes) != null
                                                select Activator.CreateInstance(t) as IInstaller;

            foreach (var instance in instances)
                instance.InstallService(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
