namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// API response model for GetCart operation
/// </summary>
public class ListCartsResponse
{
    /// <summary>
    /// The unique identifier of the created or update Cart
    /// </summary>
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalValue { get; set; }
    public List<ListCartItemResponse> Products { get; set; }

    public ListCartsResponse()
    {
        Products = new List<ListCartItemResponse>();
    }
}
