namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCartItem operation
/// </summary>
public class GetCartItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; private set; }
}
