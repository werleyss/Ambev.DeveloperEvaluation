namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Response model for ListCartItem operation
/// </summary>
public class ListCartItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; private set; }
}
