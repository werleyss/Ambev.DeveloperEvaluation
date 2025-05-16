namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategory;

/// <summary>
/// Request model for getting a category product
/// </summary>
public class ListCategoryRequest
{
    /// <summary>
    /// The category of the product listing to be retrieved
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// The current page of the category product listing to be retrieved
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// The quantity of category to be retrieved per page
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Sort the category products to be recovered
    /// </summary>
    public string? Order { get; set; }
}
