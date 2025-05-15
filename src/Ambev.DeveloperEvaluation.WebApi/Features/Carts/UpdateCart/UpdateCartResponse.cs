using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// API response model for UpdateCart operation
/// </summary>
public class UpdateCartResponse
{
    /// <summary>
    /// The unique identifier of the created or update Cart
    /// </summary>
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalValue { get; set; }
    public List<UpdateCartItemResponse> Products { get; set; }

    public UpdateCartResponse()
    {
        Products = new List<UpdateCartItemResponse>();
    }
}
