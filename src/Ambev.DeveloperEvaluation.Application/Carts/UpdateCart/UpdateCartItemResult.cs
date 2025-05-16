namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartItemResult
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; private set; }
    }
}
