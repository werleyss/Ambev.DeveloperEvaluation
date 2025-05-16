using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// API response model for UpdateCart operation
/// </summary>
public class UpdateCartResponse
{
    /// <summary>
    /// The unique identifier of the cart to retrieve
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user creating the cart.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the date the cart was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the list of products to be added to the cart.
    /// </summary>
    public List<UpdateCartItemResponse> Products { get; set; }

    public UpdateCartResponse()
    {
        Products = new List<UpdateCartItemResponse>();
    }
}
