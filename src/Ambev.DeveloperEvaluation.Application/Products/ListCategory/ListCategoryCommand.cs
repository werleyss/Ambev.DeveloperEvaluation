using System.Drawing;
using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;

/// <summary>
/// Command for retrieving a paginated list of products
/// </summary>
public record ListCategoryCommand : IRequest<PaginatedList<ListCategoryResult>>
{
    /// <summary>
    /// The category of the product listing to be retrieved
    /// </summary>
    public string Category { get; set; } = string.Empty;

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
    /// Initializes a new instance of ListCategorysCommand
    /// </summary>
    public ListCategoryCommand()
    {
    }
}
