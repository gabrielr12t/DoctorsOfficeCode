using DoctorsOffice.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorsOffice.Services.MedicalAppointments
{
    public interface IMedicalAppointmentService
    {
        Task<MedicalAppointment> AddAsync(MedicalAppointment medicalAppointment);

        Task<List<MedicalAppointment>> SelectAsync(DateTime? todayAppointment = null, int? patientId = null);

        Task RemoveAsync(MedicalAppointment medicalAppointment);
    }
}
