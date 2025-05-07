using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }

        public CartItem(Guid productId, string productTitle, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal CalculateValue()
        {
            return Quantity * UnitPrice;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
