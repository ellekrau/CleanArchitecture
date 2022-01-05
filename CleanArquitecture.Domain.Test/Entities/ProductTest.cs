using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArquitecture.Domain.Test.Entities
{
    public class ProductTest
    {
        [Fact(DisplayName = "Constructor with ID: Create with valid state")]
        public void ConstructorWithId_WithValidParameters_ResultObjectWithValidState()
        {
            var action = () => new Product(10, "Name", "Description", new decimal(200), 20, "Image");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Constructor with ID: ID negative, must Throw DomainExceptionValidation")]
        public void ConstructorWithId_WithNegativeIdValue_ThrowDomainExceptionValidation()
        {
            var action = () => new Product(-1, "Name", "Description", new decimal(100), 10, "Image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ID value");
        }

        [Fact(DisplayName = "Constructor: Create with valid state")]
        public void Constructor_WithValidParameters_ResultObjectWithValidState()
        {
            var action = () => new Product("Name", "Description", new decimal(300), 30, "Image");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Constructor: NAME null or empty must throw DomainExceptionValidation")]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_WithNullOrEmptyName_ThrowDomainExceptionValidation(string productName)
        {
            var action = () => new Product(productName, "Description", new decimal(300), 30, "Image");

            action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("NAME cannot be empty");
        }

        [Fact(DisplayName = "Constructor: NAME must have at least 3 characters, throw DomainExceptionValidation")]
        public void Constructor_WithFewCaracteresInName_ThrowDomainExceptionValidation()
        {
            var action = () => new Product("Pr", "Description", new decimal(20), 20, "Image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Min 3 characters in NAME");
        }

        [Theory(DisplayName = "Constructor: DESCRIPTION null or empty must throw DomainExceptionValidation")]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_WithNullOrEmptyDescription_ThrowDomainExceptionValidation(string description)
        {
            var action = () => new Product("Name", description, new decimal(300), 30, "Image");

            action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("DESCRIPTION cannot be empty");
        }

        [Fact(DisplayName = "Constructor: DESCRIPTION must have at least 3 characters, throw DomainExceptionValidation")]
        public void Constructor_WithFewCaracteresInDescription_ThrowDomainExceptionValidation()
        {
            var action = () => new Product("Name", "Desc", new decimal(20), 20, "Image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Min 5 characters in DESCRIPTION");
        }

        [Fact(DisplayName = "Constructor: PRICE negative, throw DomainExceptionValidation")]
        public void Constructor_WithNegativePriceValue_ThrowDomainExceptionValidation()
        {
            var action = () => new Product("Name", "Description", new decimal(-10), 10, "Image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid value in PRICE");
        }

        [Fact(DisplayName = "Constructor: STOCK negative, throw DomainExceptionValidation")]
        public void Constructor_WithNegativeStockValue_ThrowDomainExceptionValidation()
        {
            var action = () => new Product("Name", "Description", new decimal(10), -10, "Image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid value in STOCK");
        }

        [Fact(DisplayName = "Constructor: IMAGE with too much characters, must throw DomainExceptionValidation")]
        public void Constructor_WithTooMuchCharactersInImage_ThrowDomainExceptionValidation()
        {
            var image = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var action = () => new Product("Name", "Description", new decimal(30), 20, image);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Max 50 characters in IMAGE");
        }
    }
}
