using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Validator for ListProductCommand
/// </summary>
public class ListProductsValidator : AbstractValidator<ListProductsCommand>
{
    /// <summary>
    /// Initializes validation rules for ListProductCommand
    /// </summary>
    public ListProductsValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.Size).InclusiveBetween(1, 100);
    }
}
