using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class GetProductResult
{
    /// <summary>
    /// The unique identifier of the product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the product's string number.
    /// Must not be null or empty.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's price number.
    /// Must be greater than zero
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the product's description string.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's category string.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's image string.
    /// </summary>
    public string Image { get; set; } = string.Empty;
}
