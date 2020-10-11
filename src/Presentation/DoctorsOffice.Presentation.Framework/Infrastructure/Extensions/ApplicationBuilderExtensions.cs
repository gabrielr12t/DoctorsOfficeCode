using DoctorsOffice.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DoctorsOffice.Presentation.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureApplicationBuilder(this IApplicationBuilder application,
            IWebHostEnvironment environment,
            DoctorsOfficeContext context)
        {
            if (environment.IsDevelopment())
                application.UseDeveloperExceptionPage();

            context.Database.EnsureCreated();

            application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseCors(p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            application.UseRouting();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
