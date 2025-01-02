using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.WebApp.ValidationAttributeCustom
{
    public class ComparePasswordAttribute : ValidationAttribute
    {
        private readonly string _password;

        public ComparePasswordAttribute(string password)
        {
            _password = password;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? confirmPass = value as string;
            var passWordProp = validationContext.ObjectType.GetProperty(_password);
            if(confirmPass != null && passWordProp != null)
            {
                string? password = passWordProp.GetValue(validationContext.ObjectInstance) as string;
                if(password != null && password.Equals(value))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Confirm password is invalid.");
        }
    }
}
