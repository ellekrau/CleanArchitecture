using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArquitecture.Domain.Test.Entities
{
    public class ProductTest
    {
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
