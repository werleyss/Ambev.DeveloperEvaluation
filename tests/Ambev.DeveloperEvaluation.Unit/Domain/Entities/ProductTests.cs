﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductTests
    {
        /// <summary>
        /// Tests that validation passes when all product properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid product data")]
        public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();

            // Act
            var result = product.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        /// <summary>
        /// Tests that validation fails when product properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid product data")]
        public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var product = new Product
            {
                Title = "", // Invalid: empty
                Price = 0M,
                Description = string.Empty, // Invalid: empty
                Category = string.Empty, // Invalid: empty
                Image = string.Empty, // Invalid: empty
            };

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
