namespace CleanArchitecture.Domain.Validators
{
    public class StringPropertieValidator
    {
        public static string Validate(string propertie, int? minChar = null, int? maxChar = null)
        {
            propertie = propertie.ToUpper();

            DomainExceptionValidation.When(string.IsNullOrEmpty(propertie), $"{propertie} cannot be empty");

            if (minChar.HasValue)
                DomainExceptionValidation.When(propertie.Length < minChar, $"Minimum {minChar} characters in {propertie}");

            if (maxChar.HasValue)
                DomainExceptionValidation.When(propertie.Length > minChar, $"Maximum {minChar} characters in {propertie}");

            return propertie;
        }
    }
}
