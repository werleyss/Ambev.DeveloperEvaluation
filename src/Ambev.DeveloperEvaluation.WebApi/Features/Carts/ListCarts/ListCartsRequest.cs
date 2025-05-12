namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Request model for getting a cart by ID
/// </summary>
public class ListCartsRequest
{
    /// <summary>
    /// Page number for pagination (default: 1)
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Number of items per page (default: 10)
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Ordering of results (e.g., "id desc, userId asc")
    /// </summary>
    public string? Order { get; set; }
}
