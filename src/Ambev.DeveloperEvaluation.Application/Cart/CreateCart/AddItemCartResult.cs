namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart
{
    public class AddItemCartResult
    {
        public Guid UseId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
