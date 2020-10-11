using System;

namespace DoctorsOffice.Api.V1.Requests
{
    public class MedicalAppointmentRequest
    {
        public string StartDate { get; set; }
        public string finalDate { get; set; }
        public string comments { get; set; }
    }
}
