namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class CreateCartResponse
    {
        /// <summary>
        /// The unique identifier of the created or update Cart
        /// </summary>
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public DateTime Date {  get; set; }
        public List<CreateCartItemResponse> Products { get; set; }

        public CreateCartResponse()
        {
            Products = new List<CreateCartItemResponse>();
        }
    }
}
