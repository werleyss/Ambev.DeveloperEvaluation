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
    }
}
