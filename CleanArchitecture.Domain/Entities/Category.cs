namespace CleanArchitecture.Domain.Entities;

public sealed class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ICollection<Product>? Products { get; set; }

    public Category(string name)
    {
        Name = name;
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name. Too short, minimum 3 characters.");

        Name = name;
    }
}