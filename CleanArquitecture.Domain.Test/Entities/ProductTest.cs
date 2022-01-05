using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArquitecture.Domain.Test.Entities
{
    public class ProductTest
    {
        [Fact(DisplayName = "Constructor with ID: Create category with valid state")]
        public void ConstructorWithId_WithValidParameters_ResultObjectWithValidState()
        {
            var action = () => new Product(10, "Name", "Description", new decimal(200), 20, "Image");

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Constructor with ID: ID negative must Throw DomainExceptionValidation")]
        public void ConstructorWithId_WithNegativeIdValue_ThrowDomainExceptionValidation()
        {
            var action = () => new Product(-1, "Name", "Description", new decimal(100), 10, "Image");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ID value");
        }
    }
}
