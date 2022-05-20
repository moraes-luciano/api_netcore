using System.ComponentModel.DataAnnotations;

namespace Api_NetCore.Validations
{
    public class FirstUpAttribute:ValidationAttribute
    {
        //object value => name of the attribute to validate
        //validationContext => Class that has the object value
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Because this attribute is already marked with [Required] Data Anotation we must bypass the empty case
            if (value == null || string.IsNullOrEmpty((value.ToString())))
            {
                return ValidationResult.Success;
                
            }

            var firstUp = value.ToString()?[0].ToString();
            if (firstUp != null && firstUp != firstUp.ToUpper())
            {
                return new ValidationResult("The first character must be in upper case");
            }
            else
            {
                return ValidationResult.Success;
                
            }
        }
    }
}