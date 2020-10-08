using DoctorsOffice.Core.Models.Base;
using System;

namespace DoctorsOffice.Core.Models
{
    public class MedicalAppointment : ModelBase
    {
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Comments { get; set; }

        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
