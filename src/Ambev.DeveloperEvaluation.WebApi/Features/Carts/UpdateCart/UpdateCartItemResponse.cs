namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// API response model for UpdateCart operation
/// </summary>
public class UpdateCartItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
