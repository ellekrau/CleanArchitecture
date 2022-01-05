using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArquitecture.Domain.Test.Entities
{
    public class CategoryTest
    {
        [Fact(DisplayName = "Constructor without ID: Create category with valid state")]
        public void Create_WithValidParameters_ResultObjectWithValidState()
        {
            var action = () => new Category("Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Constructor with ID: Create category with valid state")]
        public void Create_ConstructorWithIdWithValidParameters_ResultObjectWithValidState()
        {
            var action = () => new Category(10, "Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
    }
}
