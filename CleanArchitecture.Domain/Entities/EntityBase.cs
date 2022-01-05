namespace CleanArchitecture.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }

        protected static void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID value");
        }

        protected static string InvalidValueMessage(string value) =>
            $"Invalid value in {value.ToUpper()}";
    }
}