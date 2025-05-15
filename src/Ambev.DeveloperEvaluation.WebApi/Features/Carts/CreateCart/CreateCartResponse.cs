namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// Represents the response returned after creating or updating a cart.
    /// </summary>
    public class CreateCartResponse
    {
        /// <summary>
        /// The unique identifier of the created or updated cart.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user associated with the cart.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The date and time when the cart was created or last updated.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The total value of all items in the cart.
        /// </summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// The list of products included in the cart.
        /// </summary>
        public List<CreateCartItemResponse> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartResponse"/> class.
        /// </summary>
        public CreateCartResponse()
        {
            Products = new List<CreateCartItemResponse>();
        }
    }

}
