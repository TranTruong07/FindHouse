using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.WebApp.ValidationAttributeCustom
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            if(value is DateTime birthdate)
            {
                if(birthdate < DateTime.Now.AddYears(-_minimumAge))
                {
                    return new ValidationResult("User need enough 18 age.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
