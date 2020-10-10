using DoctorsOffice.Core;
using DoctorsOffice.Core.Models;
using DoctorsOffice.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            if(medicalAppointment is IValidate validate)
            {
                validate.Validate();
            }

            return await _medicalAppointmentRepository.AddAsync(medicalAppointment);
        }

        public async Task<List<MedicalAppointment>> SelectAsync(DateTime? todayAppointment = null, int? patientId = null)
        {
            var query = _medicalAppointmentRepository.Table;

            query = query.Include(p => p.Patient);

            if (todayAppointment.HasValue)
                query = query.Where(p => p.StartDate == todayAppointment.Value);

            if (patientId.HasValue)
                query = query.Where(p => p.PatientId == patientId.Value);

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
