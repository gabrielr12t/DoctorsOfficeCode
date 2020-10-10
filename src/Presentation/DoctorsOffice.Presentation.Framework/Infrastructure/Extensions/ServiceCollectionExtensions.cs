using DoctorsOffice.Core.Models;
using DoctorsOffice.Core.Validators;
using DoctorsOffice.Data;
using DoctorsOffice.Data.Context;
using DoctorsOffice.Services.MedicalAppointments;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace DoctorsOffice.Presentation.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddAuthorization();

            services.AddScoped(typeof(IMedicalAppointmentService), typeof(MedicalAppointmentService));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddDbContext<DoctorsOfficeContext>(context => context.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
