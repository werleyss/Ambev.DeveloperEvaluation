namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated product,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateProductResult
{
    /// <summary>
    /// Indicates whether the update was successful
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the product's title string.
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
