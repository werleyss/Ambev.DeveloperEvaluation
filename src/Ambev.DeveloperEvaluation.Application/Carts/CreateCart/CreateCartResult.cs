namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    /// <summary>
    /// Represents the result of a successful cart creation.
    /// </summary>
    public class CreateCartResult
    {
        /// <summary>
        /// The unique identifier of the created cart.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user who owns the cart.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The date and time when the cart was created.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The total monetary value of all items in the cart.
        /// </summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// The list of products added to the cart.
        /// </summary>
        public List<CreateCartItemResult> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartResult"/> class.
        /// </summary>
        public CreateCartResult()
        {
            Products = new List<CreateCartItemResult>();
        }
    }

}
