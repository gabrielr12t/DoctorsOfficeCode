namespace DoctorsOffice.Core
{
    public interface IValidate
    {
        /// <summary>
        /// This function should throw an exception if the model is not valid
        /// </summary>
        void Validate();
    }
}
