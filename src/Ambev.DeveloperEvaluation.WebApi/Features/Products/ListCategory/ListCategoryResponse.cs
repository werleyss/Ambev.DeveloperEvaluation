namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategory;

/// <summary>
/// API response model for ListCategory operation
/// </summary>
public class ListCategoryResponse
{
    /// <summary>
    /// The unique identifier of the created product
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
