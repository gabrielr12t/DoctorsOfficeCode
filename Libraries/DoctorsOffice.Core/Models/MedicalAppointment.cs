using DoctorsOffice.Core.Models.Base;
using DoctorsOffice.Core.Validators;
using System;

namespace DoctorsOffice.Core.Models
{
    public class MedicalAppointment : ModelBase, IValidate
    {
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Comments { get; set; }
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }

        public void Validate()
        {
            ValidationCondition.ValidateCondition(StartDate < FinalDate, "A data inicial não deve ser maior que a data final");
            ValidationCondition.ValidateCondition(Patient != null, "Deve haver um paciente para a consulta");
        }
    }
}
