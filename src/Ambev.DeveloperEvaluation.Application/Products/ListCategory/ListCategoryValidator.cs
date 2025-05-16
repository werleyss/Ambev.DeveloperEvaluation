using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;

/// <summary>
/// Validator for ListCategoryCommand
/// </summary>
public class ListCategoryValidator : AbstractValidator<ListCategoryCommand>
{
    /// <summary>
    /// Initializes validation rules for ListCategoryCommand
    /// </summary>
    public ListCategoryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.Size).InclusiveBetween(1, 100);
    }
}
