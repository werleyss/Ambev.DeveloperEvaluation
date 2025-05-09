namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartResult
    {
        public Guid UseId { get; set; }
        public DateTime Date {  get; set; }

        public List<CreateCartItemResult> Products { get; set; }

        public CreateCartResult()
        {
            Products = new List<CreateCartItemResult>();    
        }
    }
}
