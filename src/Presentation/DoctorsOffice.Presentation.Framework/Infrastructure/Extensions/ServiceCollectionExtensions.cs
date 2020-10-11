using DoctorsOffice.Data;
using DoctorsOffice.Data.Context;
using DoctorsOffice.Data.Install;
using DoctorsOffice.Services.MedicalAppointments;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace DoctorsOffice.Presentation.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApiServices(this IServiceCollection services)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddAuthorization();

            services.AddScoped(typeof(IMedicalAppointmentService), typeof(MedicalAppointmentService));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            SqlConnectionBuilder connectionBuilder = new SqlConnectionBuilder();
            DefaultConnectionString defaultConnection = connectionBuilder.BuildConnectionString();
            services.AddDbContext<DoctorsOfficeContext>(context => context.UseSqlServer(defaultConnection.ConnectionString));
        }
    }
}
