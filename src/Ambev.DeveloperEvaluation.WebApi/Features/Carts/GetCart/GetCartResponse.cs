namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// API response model for GetCart operation
/// </summary>
public class GetCartResponse
{
    /// <summary>
    /// The unique identifier of the created or update Cart
    /// </summary>
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalValue { get; set; }
    public List<GetCartItemResponse> Products { get; set; }

    public GetCartResponse()
    {
        Products = new List<GetCartItemResponse>();
    }
}
