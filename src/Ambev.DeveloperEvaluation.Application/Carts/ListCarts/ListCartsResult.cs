namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Response model for ListCarts operation
/// </summary>
public class ListCartsResult
{
    public Guid Id { get; set; }
    public Guid UseId { get; set; }
    public DateTime Date { get; set; }

    public List<ListCartItemResult> Products { get; set; }

    public ListCartsResult()
    {
        Products = new List<ListCartItemResult>();
    }
}
