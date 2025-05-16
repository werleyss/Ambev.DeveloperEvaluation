using System.Drawing;
using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories;

/// <summary>
/// Command to retrieve a category list
/// </summary>
public record ListCategoriesCommand : IRequest<List<string>>
{
    public ListCategoriesCommand()
    {
    }
}
