namespace CleanArchitecture.Domain.Validators
{
    public class StringPropertieValidator
    {
        public static void Validate(string propertie, int? minChar = null, int? maxChar = null)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(propertie), $"{propertie.ToUpper()} cannot be empty");

            if (minChar.HasValue)
                MinCharValidate(propertie, minChar.Value);

            if (maxChar.HasValue)
                MaxCharValidate(propertie, maxChar.Value);
        }

        public static void MinCharValidate(string propertie, int minChar)
        {
            DomainExceptionValidation.When(propertie.Length < minChar, $"Minimum {minChar} characters in {propertie.ToUpper()}");
        }

        public static void MaxCharValidate(string propertie, int maxChar)
        {
            DomainExceptionValidation.When(propertie.Length > maxChar, $"Minimum {maxChar} characters in {propertie.ToUpper()}");
        }
    }
}
