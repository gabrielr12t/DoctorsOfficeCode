using DoctorsOffice.Data.Context;
using DoctorsOffice.Presentation.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsOffice.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApiServices(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DoctorsOfficeContext context)
        {
            app.ConfigureApplicationBuilder(env, context);
        }
    }
}
