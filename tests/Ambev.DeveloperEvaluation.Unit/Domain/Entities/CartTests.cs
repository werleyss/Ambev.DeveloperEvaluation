using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.CodeAnalysis;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class CartTests
    {
        /// <summary>
        /// Tests a new cart, when add an item, then it should add successfully.
        /// </summary>
        [Fact(DisplayName = "New cart, when add an item, then it should add successfully.")]
        public void Given_NewCart_When_AddItem_Then_ShouldAddItemSuccessfully()
        {
            // Arrange
            var cart = new Cart();
            var cartItem = new CartItem(Guid.NewGuid(), "Test Product", 2, 100);

            // Act
            cart.AddItem(cartItem);

            // Assert
            Assert.Equal(200, cart.TotalValue);
        }

        /// <summary>
        /// Tests existing cart when adding the item, it should be added successfully.
        /// </summary>
        [Fact(DisplayName = "Existing cart when adding the item, it should be added successfully")]
        public void Given_ExistingCart_When_AddItem_Then_ShouldAddItemSuccessfully()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();

            var cartItem1 = new CartItem(productId, "Test Product", 2, 100M);

            cart.AddItem(cartItem1);

            var cartItem2 = new CartItem(productId, "Test Product", 1, 100M);

            // Act
            cart.AddItem(cartItem2);

            // Assert
            Assert.Equal(300M, cart.TotalValue);
            Assert.Equal(1, cart.CartItems?.Count);
            Assert.Equal(3, cart.CartItems?.FirstOrDefault(p => p.ProductId == productId)?.Quantity);
        }

        /// <summary>
        /// Tests quantity above 4, when calculating value, then 10% discount is applied.
        /// </summary>
        [Fact(DisplayName = "Given quantity above 4, when calculating value, then 10% discount is applied")]
        public void Given_QuantityAbove4_When_CalculateValue_Then_10PercentDiscount()
        {
            // Arrange
            var item = new CartItem(Guid.NewGuid(), "Test Product", 1, 100); 
            item.AddQuantity(4);

            //Act
            var total = item.CalculateValue();

            // Assert
            Assert.Equal(450, total);
        }

        /// <summary>
        /// Tests quantity between 10 and 20, when calculating value, then 20% discount is applied.
        /// </summary>
        [Fact(DisplayName = "Given quantity between 10 and 20, when calculating value, then 20% discount is applied")]
        public void Given_QuantityBetween10And20_When_CalculateValue_Then_20PercentDiscount()
        {
            // Arrange
            var item = new CartItem(Guid.NewGuid(), "Test Product", 1, 100);
            item.AddQuantity(9);

            //Act
            var total = item.CalculateValue();

            // Assert
            Assert.Equal(800, total);
        }

        /// <summary>
        /// Tests quantity above 20, when adding quantity or calculating value, then throws exception.
        /// </summary>
        [Fact(DisplayName = "Given quantity above 20, when adding quantity or calculating value, then throws exception")]
        public void Given_QuantityAbove20_When_AddQuantityOrCalculate_Then_ThrowsException()
        {
            // Arrange
            var item = new CartItem(Guid.NewGuid(), "Test Product", 20, 100);

            //Act && Assert 
            Assert.Throws<DomainException>(() => item.AddQuantity(1));
            Assert.Throws<DomainException>(() => item.CalculateValue());
        }

        /// <summary>
        /// Tests item does not exist when the item is removed and throws an exception.
        /// </summary>
        [Fact(DisplayName = "Given item does not exist when the item is removed and throws an exception")]
        public void Given_ItemNotExist_When_ItemRemoved_Then_ThrowsException()
        {
            // Arrange
            var cart = new Cart();
            var item = new CartItem(Guid.NewGuid(), "Test Product", 20, 100);

            //Act && Assert 
            Assert.Throws<DomainException>(() => cart.RemoveItem(item));
        }

        /// <summary>
        /// Tests existing cart when item update should be done successfully.
        /// </summary>
        [Fact(DisplayName = "Given existing cart when item update should be done successfully")]
        public void Given_ExistingCart_When_UpdateItem_The_ShouldSuccessfully()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();

            var cartItem1 = new CartItem(productId, "Test Product", 2, 100M);
            cart.AddItem(cartItem1);

            var cartItem2 = new CartItem(productId, "Test Product", 1, 100M);

            // Act
            cart.UpdateItem(cartItem2);

            // Assert
            Assert.Equal(100M, cart.TotalValue);
            Assert.Equal(1, cart.CartItems?.Count);
            Assert.Equal(1, cart.CartItems?.FirstOrDefault(p => p.ProductId == productId)?.Quantity);
        }
    }
}
