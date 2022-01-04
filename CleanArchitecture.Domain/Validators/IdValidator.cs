namespace CleanArchitecture.Domain.Validators
{
    public static class IdValidator
    {
        public static int Validate(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID value");

            return id;
        }
    }
}
