using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArquitecture.Domain.Test.Entities
{
    public class CategoryTest
    {
        [Fact(DisplayName = "Constructor with ID: Create category with valid state")]
        public void ConstructorWithId_WithValidParameters_ResultObjectWithValidState()
        {
            var action = () => new Category(10, "Category name");

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Constructor with ID: ID negative must Throw DomainExceptionValidation")]
        public void ConstructorWithId_WithNegativeIdValue_ThrowDomainExceptionValidation()
        {
            var action = () => new Category(-1, "Category name");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ID value");
        }

        [Fact(DisplayName = "Constructor: Create category with valid state")]
        public void Construcor_WithValidParameters_ResultObjectWithValidState()
        {
            var action = () => new Category("Category name");

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Constructor: NAME null or empty must throw DomainExceptionValidation")]
        [InlineData((""))]
        [InlineData(null)]
        public void Construcor_WithNullAndEmptyName_ThrowDomainExceptionValidation(string categoryName)
        {
            var action = () => new Category(categoryName);

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("NAME cannot be empty");
        }

        [Fact(DisplayName = "Constructor: NAME must have at least 3 characters")]
        public void Constructor_WithFewCaractereInName_ThrowDomainExceptionValidation()
        {
            var action = () => new Category("na");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Min 3 characters in NAME");
        }
    }
}
