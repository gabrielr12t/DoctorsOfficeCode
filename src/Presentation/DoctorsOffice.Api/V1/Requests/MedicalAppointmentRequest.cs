using System;
using System.Globalization;
using DoctorsOffice.Core.Models;

namespace DoctorsOffice.Api.V1.Requests
{
    public class MedicalAppointmentRequest
    {
        public string StartDate { get; set; }
        public string finalDate { get; set; }
        public string PatientName { get; set; }
        public string BirthDate { get; set; }
        public string Comments { get; set; }
    }

    public static class MedicalAppointmentRequestExtensions
    {
        public static MedicalAppointment ToModel(this MedicalAppointmentRequest request)
        {
            MedicalAppointment model = new MedicalAppointment();

            DateTime.TryParse(request.StartDate, out DateTime startDate);
            DateTime.TryParse(request.finalDate, out DateTime finalDate);

            model.StartDate = startDate;
            model.FinalDate = finalDate;
            model.Comments = request.Comments;

            Patient patient = new Patient();
            patient.Name = request.PatientName;

            DateTime.TryParse(request.BirthDate, out DateTime birthDate);
            patient.BirthDate = birthDate;

            model.Patient = patient;

            return model;
        }
    }
}
