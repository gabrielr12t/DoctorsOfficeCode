using DoctorsOffice.Services.MedicalAppointments;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsOffice.WebApi.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IMedicalAppointmentService), typeof(MedicalAppointmentService));
            services.AddControllers();
            services.AddAuthorization();
            services.AddMvc().AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}
