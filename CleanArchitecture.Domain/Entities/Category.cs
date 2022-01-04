using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Domain.Entities;

public sealed class Category : EntityBase
{
    public string? Name { get; private set; }

    public ICollection<Product>? Products { get; set; }

    public Category(string name)
    {
        ValidateName(name);
    }

    public Category(int id, string name)
    {
        ValidateId(id);
        ValidateName(name);
    }

    public void Update(string name)
    {
        ValidateName(name);
    }

    private void ValidateName(string name)
    {
        StringPropertieValidator.Validate(name);
        Name = name;
    }
}