using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Domain.Entities;
public class Product : EntityBase
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        Id = IdValidator.Validate(id);
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {''
        static string InvalidValueIn(string value) =>
            $"Invalid value in {value.ToUpper()}";

        Name = StringPropertieValidator.Validate(name, 2);
        Description = StringPropertieValidator.Validate(description, 5);

        DomainExceptionValidation.When(price < 0, InvalidValueIn(nameof(price)));
        Price = price;

        DomainExceptionValidation.When(stock < 0, InvalidValueIn(nameof(stock)));
        Stock = stock;

        DomainExceptionValidation.When(image.Length > 255, "Maximum 250 characters in IMAGE name");
        Image = image;
    }
}