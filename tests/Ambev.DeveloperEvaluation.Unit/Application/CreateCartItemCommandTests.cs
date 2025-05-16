using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateCartItemCommandTests
    {
        /// <summary>
        /// Unit test to verify that the AddOrderItemCommand passes validation when the command is valid.
        /// </summary>
        [Fact(DisplayName = "Given valid cart item data When add cart item Then returns success response")]
        public void Command_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange 
            var cartItem = new CreateCartItemCommand(Guid.NewGuid(), "Product Test", 2, 100);

            // Act
            var result = cartItem.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}
