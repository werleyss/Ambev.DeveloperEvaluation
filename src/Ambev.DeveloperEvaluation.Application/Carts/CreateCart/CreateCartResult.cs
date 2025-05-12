namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartResult
    {
        /// <summary>
        /// Indicates whether the create was successful
        /// </summary>
        public Guid Id { get; set; }
        public Guid UseId { get; set; }
        public DateTime Date {  get; set; }

        public List<CreateCartItemResult> Products { get; set; }

        public CreateCartResult()
        {
            Products = new List<CreateCartItemResult>();    
        }
    }
}
