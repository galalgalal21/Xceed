using System.ComponentModel.DataAnnotations;

namespace Xceed.PL.Helper
{
    public class CustomMinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public CustomMinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth > DateTime.Today.AddYears(-age))
                    age--;

                if (age < _minimumAge)
                {
                    return new ValidationResult(ErrorMessage);
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid date format.");
        }
    }
}
