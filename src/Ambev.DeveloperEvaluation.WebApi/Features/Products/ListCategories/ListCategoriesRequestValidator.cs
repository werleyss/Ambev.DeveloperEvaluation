using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategories;

/// <summary>
/// Validator for ListCategoriesRequest
/// </summary>
public class ListCategoriesRequestValidator : AbstractValidator<ListCategoriesRequest>
{
    /// <summary>
    /// Initializes validation rules for ListCategoriesRequest
    /// </summary>
    public ListCategoriesRequestValidator()
    {
    }
}
