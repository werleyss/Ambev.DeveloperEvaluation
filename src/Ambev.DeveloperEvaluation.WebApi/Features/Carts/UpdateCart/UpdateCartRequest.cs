namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class UpdateCartRequest
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
    public List<UpdateCartItemRequest> Products { get; set; }

    public UpdateCartRequest()
    {
        Products = new List<UpdateCartItemRequest>();
    }
}