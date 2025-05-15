using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class UpdateCartItemRequest
{
    /// <summary>
    /// The unique identifier of the product being added to the cart.
    /// </summary>
    public Guid ProductId { get; set; }
    /// <summary>
    /// The quantity of the product to be added to the cart.
    /// </summary>
    public int Quantity { get; set; }
}