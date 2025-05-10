using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCart operation
/// </summary>
public class GetCartResult
{
    /// <summary>
    /// The unique identifier of the cart
    /// </summary>
    public Guid Id { get; set; }
    public Guid UseId { get; set; }
    public DateTime Date { get; set; }

    public List<GetCartItemResult> Products { get; set; }

    public GetCartResult()
    {
        Products = new List<GetCartItemResult>();
    }
}
