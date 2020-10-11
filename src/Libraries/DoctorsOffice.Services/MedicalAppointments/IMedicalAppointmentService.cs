using DoctorsOffice.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorsOffice.Services.MedicalAppointments
{
    public interface IMedicalAppointmentService
    {
        Task<MedicalAppointment> AddAsync(MedicalAppointment medicalAppointment);

        Task<List<MedicalAppointment>> SelectAsync(bool? fromTodayDate = null, bool? fromPreviousDate = null, int? patientId = null);

        Task RemoveAsync(MedicalAppointment medicalAppointment);
    }
}
