namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// Request model for getting a product by ID
/// </summary>
public class ListProductsRequest
{
    /// <summary>
    /// The current page of the product listing to be retrieved
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// The quantity of product to be retrieved per page
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Sort the products to be recovered
    /// </summary>
    public string? Order { get; set; }
}
