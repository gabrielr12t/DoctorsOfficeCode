using DoctorsOffice.Core.Models;
using FluentValidation;

namespace DoctorsOffice.Core.Validators
{
    public class MedicalAppointmentValidator : AbstractValidator<MedicalAppointment>
    {
        public MedicalAppointmentValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("Não pode agendar sem uma data inicial")
                .LessThan(p => p.FinalDate).WithMessage("A data inicial deve ser menor que a data final");
        }
    }
}
