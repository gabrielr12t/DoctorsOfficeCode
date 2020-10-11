using DoctorsOffice.Core.Models;
using DoctorsOffice.Data;
using DoctorsOffice.Data.Context;
using DoctorsOffice.Data.Install;
using DoctorsOffice.Services.MedicalAppointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DoctorsOffice.Services.Tests
{
    public class MedicalAppointmentServiceTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly Patient _patient;
        private readonly MedicalAppointment _medicalAppointment;

        private static ConnectionBuilder connectionBuilder = new ConnectionBuilder();
        private DefaultConnectionString defaultConnection = connectionBuilder.BuildConnectionString();

        public MedicalAppointmentServiceTest()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped(typeof(IMedicalAppointmentService), typeof(MedicalAppointmentService));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddDbContext<DoctorsOfficeContext>(context => context.UseSqlServer(defaultConnection.ConnectionString));

            _serviceProvider = services.BuildServiceProvider();

            _medicalAppointmentService = _serviceProvider.GetService<IMedicalAppointmentService>();

            _patient = new Patient
            {
                Name = "Gabriel",
                BirthDate = new System.DateTime(1995, 06, 16),
            };

            _medicalAppointment = new MedicalAppointment
            {
                Comments = "Consulta com o médico x",
                Patient = _patient,
                StartDate = new DateTime(2021, 10, 08, 12, 00, 00),
                FinalDate = new DateTime(2021, 10, 08, 12, 10, 00)
            };
        }

        [Fact]
        public async void InsertMedicalAppointment()
        {
            await _medicalAppointmentService.AddAsync(_medicalAppointment);
            await _medicalAppointmentService.RemoveAsync(_medicalAppointment);
        }
    }
}
