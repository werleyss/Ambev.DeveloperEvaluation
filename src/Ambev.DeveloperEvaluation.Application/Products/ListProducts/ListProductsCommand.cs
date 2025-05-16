using System.Drawing;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Command for retrieving a paginated list of products
/// </summary>
public record ListProductsCommand : IRequest<ListProductsResult>
{
    /// <summary>
    /// Page number for pagination
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// Number of items per page
    /// </summary>
    public int Size { get; init; } = 10;

    /// <summary>
    /// Ordering criteria (e.g., "price desc, title asc")
    /// </summary>
    public string? Order { get; init; }

    /// <summary>
    /// Initializes a new instance of ListProductsCommand
    /// </summary>
    /// <param name="page">The page number</param>
    /// <param name="size">The page size</param>
    /// <param name="orderBy">The ordering criteria</param>
    public ListProductsCommand(int page = 1, int size = 10, string? order = null)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}
