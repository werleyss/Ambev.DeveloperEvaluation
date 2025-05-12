using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Represents the response returned after successfully creating a new cart.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated cart,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateCartResult
{
    /// <summary>
    /// Indicates whether the update was successful
    /// </summary>
    public Guid Id { get; set; }
    public Guid UseId { get; set; }
    public DateTime Date { get; set; }

    public List<UpdateCartItemResult> Products { get; set; }

    public UpdateCartResult()
    {
        Products = new List<UpdateCartItemResult>();

    }
}

