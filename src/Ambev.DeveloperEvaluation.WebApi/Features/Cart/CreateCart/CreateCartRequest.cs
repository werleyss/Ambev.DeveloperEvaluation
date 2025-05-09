namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    /// <summary>
    /// Represents a request to create a new shopping cart.
    /// </summary>
    public class CreateCartRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user creating the cart.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the date the cart was created.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products to be added to the cart.
        /// </summary>
        public List<CreateCartItemRequest> Products { get; set; }

        public CreateCartRequest()
        {
            Products = new List<CreateCartItemRequest>();
        }
    }

}
