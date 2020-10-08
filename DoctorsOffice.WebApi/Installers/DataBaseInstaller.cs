using DoctorsOffice.Data;
using DoctorsOffice.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DoctorsOffice.WebApi.Installers
{
    public class DataBaseInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoctorsOfficeContext>(p => p.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        }
    }
}
