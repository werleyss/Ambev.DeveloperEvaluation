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
    /// <summary>
    /// The unique identifier of the user who owns the cart.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The date the cart was created or last updated.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The total value of the cart, including all items and discounts.
    /// </summary>
    public decimal TotalValue { get; set; }

    /// <summary>
    /// The list of products included in the cart.
    /// </summary>
    public List<ListCartItemResponse> Products { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListCartItemResponse"/> class.
    /// </summary>
    public ListCartsResponse()
    {
        Products = new List<ListCartItemResponse>();
    }
}
