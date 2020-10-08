using Microsoft.Extensions.DependencyInjection;

namespace DoctorsOffice.Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(IServiceCollection builder);
    }
}
