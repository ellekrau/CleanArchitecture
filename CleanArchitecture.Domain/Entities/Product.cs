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
        ValidateId(id);
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        ValidateName(name);
        ValidateDescription(description);
        ValidatePrice(price);
        ValidateStock(stock);
        ValidateImage(image);
    }

    private void ValidateImage(string image)
    {
        StringPropertieValidator.MaxCharValidate(image, nameof(Image), 255);
        Image = image;
    }

    private void ValidateStock(int stock)
    {
        DomainExceptionValidation.When(stock < 0, InvalidValueMessage(nameof(stock)));
        Stock = stock;
    }

    private void ValidatePrice(decimal price)
    {
        DomainExceptionValidation.When(price < 0, InvalidValueMessage(nameof(price)));
        Price = price;
    }

    private void ValidateDescription(string description)
    {
        StringPropertieValidator.Validate(description, nameof(Description), 5);
        Description = description;
    }

    private void ValidateName(string name)
    {
        StringPropertieValidator.Validate(name, nameof(Name), 2);
        Name = name;
    }
}