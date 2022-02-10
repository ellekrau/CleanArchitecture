namespace CleanArchitecture.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }

        protected void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID value");
            Id = id;
        }

        protected static string InvalidValueMessage(string value) =>
            $"Invalid value in {value.ToUpper()}";
    }
}