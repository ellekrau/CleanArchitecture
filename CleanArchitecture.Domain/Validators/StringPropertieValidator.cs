namespace CleanArchitecture.Domain.Validators
{
    public class StringPropertieValidator
    {
        public static void Validate(string propertieValue, string propertieName, int? minChar = null, int? maxChar = null)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(propertieValue), $"{propertieName.ToUpper()} cannot be empty");

            if (minChar.HasValue)
                MinCharValidate(propertieValue,propertieName, minChar.Value);

            if (maxChar.HasValue)
                MaxCharValidate(propertieValue, propertieName, maxChar.Value);
        }

        public static void MinCharValidate(string propertieValue, string propertieName, int minChar)
        {
            DomainExceptionValidation.When(propertieValue.Length < minChar, $"Min {minChar} characters in {propertieName.ToUpper()}");
        }

        public static void MaxCharValidate(string propertieValue, string propertieName, int maxChar)
        {
            DomainExceptionValidation.When(propertieValue.Length > maxChar, $"Max {maxChar} characters in {propertieName.ToUpper()}");
        }
    }
}
