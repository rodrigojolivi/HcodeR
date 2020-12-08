using System.ComponentModel.DataAnnotations;

namespace HcodeR.Application.Attributes
{
    public class CustomClienteValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var message = $"{validationContext.MemberName} {ErrorMessage}";

            if ((int)value <= 0) return new ValidationResult(message);
           
            return null;
        }
    }
}
