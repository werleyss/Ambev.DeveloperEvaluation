using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategory;

/// <summary>
/// Validator for ListCategoryRequest
/// </summary>
public class ListCategoryRequestValidator : AbstractValidator<ListCategoryRequest>
{
    /// <summary>
    /// Initializes validation rules for ListCategoryRequest
    /// </summary>
    public ListCategoryRequestValidator()
    {
        RuleFor(x => x.Category)
             .NotEmpty().WithMessage("Category is required.");

        RuleFor(x => x.Page)
             .GreaterThan(0).WithMessage("Page number must be greater than zero.");

        RuleFor(x => x.Size)
            .GreaterThan(0).WithMessage("Page size must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("Page size cannot exceed 100.");
    }
}
