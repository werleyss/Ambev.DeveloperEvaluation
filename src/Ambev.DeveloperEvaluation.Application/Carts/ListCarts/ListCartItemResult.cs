using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCartItem operation
/// </summary>
public class GetCartItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
