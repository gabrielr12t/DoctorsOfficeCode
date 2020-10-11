using DoctorsOffice.Core;
using DoctorsOffice.Core.Models;
using DoctorsOffice.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsOffice.Services.MedicalAppointments
{
    public class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IRepositoryAsync<MedicalAppointment> _medicalAppointmentRepository;
        private readonly IRepositoryAsync<Patient> _patientRespository;

        public MedicalAppointmentService(IRepositoryAsync<MedicalAppointment> medicalAppointmentRepository,
                                         IRepositoryAsync<Patient> patientRespository)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _patientRespository = patientRespository;
        }

        public async Task<MedicalAppointment> AddAsync(MedicalAppointment medicalAppointment)
        {
            if (medicalAppointment == null)
                throw new ArgumentNullException(nameof(medicalAppointment));

            var query = _medicalAppointmentRepository.Table;

            bool hasSchedule = query.Any(t => t.StartDate >= medicalAppointment.StartDate && t.FinalDate <= medicalAppointment.FinalDate);

            if (hasSchedule)
            {
                throw new InvalidOperationException("Já existe uma consulta dentro dessa data.");
            }

            if (medicalAppointment is IValidateModel validate)
            {
                validate.Validate();
            }

            return await _medicalAppointmentRepository.AddAsync(medicalAppointment);
        }

        public async Task<List<MedicalAppointment>> SelectAsync(bool? fromTodayDate = null, bool? fromPreviousDate = null, int? patientId = null)
        {
            var query = _medicalAppointmentRepository.Table;

            query = query.Include(p => p.Patient);

            if (fromTodayDate.HasValue)
                query = query.Where(p => p.StartDate >= DateTime.Now && p.FinalDate >= DateTime.Now);

            if (fromPreviousDate.HasValue)
                query = query.Where(p => p.StartDate <= DateTime.Now && p.FinalDate <= DateTime.Now);

            if (patientId.HasValue)
                query = query.Where(p => p.PatientId == patientId.Value);

            query = query.OrderByDescending(p => p.StartDate);

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(MedicalAppointment medicalAppointment)
        {
            if (medicalAppointment == null)
                throw new ArgumentNullException(nameof(medicalAppointment));

            await _medicalAppointmentRepository.RemoveAsync(medicalAppointment);
        }
    }
}
