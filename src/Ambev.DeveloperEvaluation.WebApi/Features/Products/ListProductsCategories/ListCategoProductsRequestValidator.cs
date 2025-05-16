using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// Validator for ListProductRequest
/// </summary>
public class ListProductsRequestValidator : AbstractValidator<ListProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for ListProductRequest
    /// </summary>
    public ListProductsRequestValidator()
    {
        RuleFor(x => x.Page)
             .GreaterThan(0).WithMessage("Page number must be greater than zero.");

        RuleFor(x => x.Size)
            .GreaterThan(0).WithMessage("Page size must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("Page size cannot exceed 100.");
    }
}
