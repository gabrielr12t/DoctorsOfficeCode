using DoctorsOffice.Core.Infrastructure.DependencyManagement;
using DoctorsOffice.Services.MedicalAppointments;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsOffice.Presentation.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(IMedicalAppointmentService), typeof(MedicalAppointmentService));
        }
    }
}
