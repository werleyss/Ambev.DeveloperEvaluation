using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Gets or serts the title. Must not be null or empty.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or serts the price. Must be greater than zero
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description. Must not be null or empty.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category string.Must not be null or empty.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or serts the image.
    /// </summary>
    public string Image { get; set; } = string.Empty;
}