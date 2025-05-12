namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Response model for GetCartItem operation
/// </summary>
public class ListCartItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
