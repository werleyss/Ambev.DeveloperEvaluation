namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// Represents an item to be added to a cart during a create cart request.
    /// </summary>
    public class CreateCartItemRequest
    {
        /// <summary>
        /// The unique identifier of the product being added to the cart.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity of the product to be added to the cart.
        /// </summary>
        public int Quantity { get; set; }
    }

}
