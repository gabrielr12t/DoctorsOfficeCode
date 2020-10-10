using System;

namespace DoctorsOffice.Core.Validators
{
    public class ValidationCondition : Exception
    {
        public ValidationCondition(string message) : base(message) { }

        public static void ValidateCondition(bool isValid, string errorMessageg)
        {
            if(!isValid)
            {
                throw new ValidationCondition(errorMessageg);
            }
        }
    }
}
